var Workers = Workers || {};
Workers.FilterMapping = {
};

Workers.WorkersMapping = {
    create: function (options) {
        return new Workers.SocialWorkerViewModel(options.data);
    }
};

Workers.SocialWorkerViewModel = function (data) {
    var self = this;


    ko.mapping.fromJS(data, {}, self);
    self.DetailsPanelExpanded = ko.observable(false);


    self.GetCssStylesByStatus = ko.pureComputed(function () {
        return self.IsFree() ? "label text-uppercase label-success" : "label text-uppercase label-default";        
    });
};

Workers.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Workers = ko.observableArray([]);

    self.Init = function () {
        ko.mapping.fromJS(Workers.Workers, Workers.WorkersMapping, self.Workers);
        ko.mapping.fromJS(Workers.Pager, {}, self.Pager);
    };

    self.Details = function (referenceId) {
        setLocation(Workers.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
        };
        notify.close();
        $.ajax({
            url: Workers.GetWorkers,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Workers, Workers.WorkersMapping, self.Workers);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(Workers.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(Workers.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Init();
};

Workers.Init = function () {
    var viewModel = new Workers.ListViewModel();
    ko.applyBindings(viewModel,
        $(Workers.ContainerId)[0]);
};