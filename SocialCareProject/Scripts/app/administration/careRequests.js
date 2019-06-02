var Requests = Requests || {};

Requests.FilterMapping = {
    'ignore': ["Clear"]
};

Requests.RequestsMapping = {
    create: function (options) {
        return new Requests.RequestViewModel(options.data);
    }
};

Requests.FilterViewModel = function () {
    var self = this;
    self.Name = ko.observable(null);
    self.StatusId = ko.observable(null);
    


    self.Clear = function () {
        self.Name(null);
        self.StatusId(null);
    };
};

Requests.AllRequests = null;

Requests.AssignWorkerModal = function (requestId) {
    var self = this;

    self.AssignedPersonId = ko.observable();
    self.CustomerFullName = ko.observable();
    self.RequestId = ko.observable(requestId);
    self.WorkerId = ko.observable();
    self.Answer = ko.observable();

    self.GetSelectedCustomerFullName = function (custId) {
        var person = ko.utils.arrayFirst(Requests.AllRequests,
            function (item) {
                return item.CustomerId === custId;
            });
        if (person) {
            self.CustomerFullName(person.CustomerFullName);
        } else {
            self.CustomerFullName("");
        }
    };

    self.ShowModal = function (custId) {

        self.GetSelectedCustomerFullName(custId);
        $("#assignWorkerModal").appendTo("#page");
        $("#assignWorkerModal").modal('show');
    };

    self.SendRequest = function () {
        var url = Requests.AssignUrl;
        notify.close();
        $.ajax({
            url: url,
            dataType: "json",
            data: {
                workerId: self.WorkerId(),
                answer: self.Answer(),
                requestId: self.RequestId
            }
        }).done(function (result) {
            if (result && result.success) {
                $("#assignWorkerModal").modal('hide');
                var btn = document.getElementById('actionButton');
                btn.style.visibility = 'hidden';
                notify.ok(result.message);
            } else if (result && !result.success) {
                notify.fail(result.message);
            }
        }).fail(function () {
            notify.fail("Щось пішло не так. Спробуйте ще раз");
        });
    };
};

Requests.RejectRequestModal = function (requestId) {
    var self = this;

    self.CustomerId = ko.observable();
    self.CustomerFullName = ko.observable();
    self.Answer = ko.observable();
    self.RequestId = ko.observable(requestId);
    self.GetSelectedCustomerFullName = function (custId) {
        var person = ko.utils.arrayFirst(Requests.AllRequests,
            function (item) {
                return item.CustomerId === custId;
            });
        if (person) {
            self.CustomerFullName(person.CustomerFullName);
        } else {
            self.CustomerFullName("");
        }
    };

    self.ShowModal = function (custId) {

        self.GetSelectedCustomerFullName(custId);
        $("#rejectRequest").appendTo("#page");
        $("#rejectRequest").modal('show');
    };

    self.SendRequest = function () {
        notify.close();
        var url = Requests.RejectUrl;
        $.ajax({
            url: url,
            dataType: "json",
            data: {
                requestId: self.RequestId(),
                answer: self.Answer()
            }
        }).done(function (result) {
            if (result && result.success) {
                $("#rejectRequest").modal('hide');
                var btn = document.getElementById('actionButton');
                btn.style.visibility = 'hidden';
                notify.ok(result.message);
            } else if (result && !result.success) {
                notify.fail(result.message);
            }
        }).fail(function () {
            notify.fail("Щось пішло не так. Спробуйте ще раз");
        });
    };
};



Requests.RequestViewModel = function (data) {
    var self = this;
 
    self.DetailsPanelExpanded = ko.observable(false);

    ko.mapping.fromJS(data, {}, self);
    self.AssignWorkerModal = new Requests.AssignWorkerModal(self.Id());
    self.RejectRequestModal = new Requests.RejectRequestModal(self.Id());
    
    self.RequestStatus = ko.pureComputed(function () {
        var status = ko.utils.arrayFirst(Requests.CareRequestStatuses,
            function (item) {
                return item.Key === self.StatusId();
            });
        if (status) {
            return status.Value;
        }
    });

    self.OpenApproveModal = function () {
        self.AssignWorkerModal.ShowModal(self.CustomerId());
    };

    self.OpenRejectModal = function () {
        self.RejectRequestModal.ShowModal(self.CustomerId());
    };

    self.GetCssStylesByStatus = ko.pureComputed(function () {
        switch (self.StatusId()) {
            case 1:
                return "label text-uppercase label-warning";
            case 2:
                return "label text-uppercase label-success";
            case 3:
                return "label text-uppercase label-info";

            default:
                return "label text-uppercase label-default";
        }
    });
};



Requests.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Requests = ko.observableArray([]);
    self.Workers = ko.observableArray([]);
    self.Filter = new Requests.FilterViewModel();

    self.Init = function () {
        Requests.AllRequests = Requests.Requests; 
        ko.mapping.fromJS(Requests.Requests, Requests.RequestsMapping, self.Requests);
        ko.mapping.fromJS(Requests.Pager, {}, self.Pager);
        ko.mapping.fromJS(Requests.Filter, {}, self.Filter);
        ko.mapping.fromJS(Requests.Workers, {}, self.Workers);
    };

    
    self.Details = function (referenceId) {
        setLocation(Requests.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        notify.close();
        self.Loading(true);
        var filter = {};
        var data = {
            pager: ko.mapping.toJS(self.Pager, {}),
            statusId: self.Filter.StatusId(),
            name: self.Filter.Name()
            //filter: ko.mapping.toJS(self.Filter, Requests.FilterMapping)

        };

        $.ajax({
            url: Requests.GetRequests,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Requests, Requests.RequestsMapping, self.Requests);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);
                Requests.AllRequests = result.data.Requests; 
                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(Requests.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(Requests.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.ClearFilter = function () {
        self.Pager.PageIndex(0);
        self.Filter.Clear();
        self.Load();
    };
    self.ApplyFilter = function () {
        self.Pager.PageIndex(0);
        self.Load(true);
    };

    self.Init();
};

Requests.Init = function () {
    var viewModel = new Requests.ListViewModel();
    ko.applyBindings(viewModel,
        $(Requests.ContainerId)[0]);
};