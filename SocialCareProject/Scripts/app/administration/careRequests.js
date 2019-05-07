var Requests = Requests || {};
Requests.FilterMapping = {
};

Requests.RequestsMapping = {
    create: function (options) {
        return new Requests.RequestViewModel(options.data);
    }
};

Requests.RequestViewModel = function (data) {
    var self = this;
 
    self.DetailsPanelExpanded = ko.observable(false);


    ko.mapping.fromJS(data, {}, self);

    self.RequestStatus = ko.pureComputed(function () {
        var status = ko.utils.arrayFirst(Requests.CareRequestStatuses,
            function (item) {
                return item.Key === self.StatusId();
            });
        if (status) {
            return status.Value;
        }
    });

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


    self.AssignWorkerToUser = function() {

    };

};

Requests.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Requests = ko.observableArray([]);

    self.Init = function () {
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