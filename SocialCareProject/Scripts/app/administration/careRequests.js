var Requests = Requests || {};
Requests.FilterMapping = {
};

Requests.RequestsMapping = {
    create: function (options) {
        return new Requests.RequestViewModel(options.data);
    }
};

Requests.AllRequests = null;

Requests.AssignWorkerModal = function (requestId) {
    var self = this;

    self.AssignedPerson = ko.observable();
    self.CustomerId = ko.observable();
    self.CustomerFullName = ko.observable();
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
        $("#assignWorkerModal").appendTo("#page");
        $("#assignWorkerModal").modal('show');
    };

    self.SendRequest = function () {
        //var url = CustomerDetails.SendRequestUrl;
        //$.ajax({
        //    url: url,
        //    dataType: "json",
        //    data: {
        //        customerId: self.CustomerId(),
        //        reason: self.Reason()
        //    }
        //}).done(function (result) {
        //    if (result && result.success) {
        //        $("#careRequestModal").modal('hide');
        //        CustomerDetails.CanCreateCareRequest = false;
        //        var btn = document.getElementById('assignWorkerModal');
        //        btn.style.visibility = 'hidden';
        //        notify.ok(result.message);
        //    } else if (result && !result.success) {
        //        notify.fail(result.message);
        //    }
        //}).fail(function () {
        //    notify.fail("Щось пішло не так. Спробуйте ще раз");
        //});
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
                $("#careRequestModal").modal('hide');
                CustomerDetails.CanCreateCareRequest = false;
                var btn = document.getElementById('assignWorkerModal');
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

    self.Init = function () {
        Requests.AllRequests = Requests.Requests; 
        ko.mapping.fromJS(Requests.Requests, Requests.RequestsMapping, self.Requests);
        ko.mapping.fromJS(Requests.Pager, {}, self.Pager);
    };

    
    self.Details = function (referenceId) {
        setLocation(Requests.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
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

    self.Init();
};

Requests.Init = function () {
    var viewModel = new Requests.ListViewModel();
    ko.applyBindings(viewModel,
        $(Requests.ContainerId)[0]);
};