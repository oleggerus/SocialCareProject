var PersonRequests = PersonRequests || {};

PersonRequests.FilterMapping = {
};

PersonRequests.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Items = ko.observableArray([]);

    self.Init = function () {
        ko.mapping.fromJS(PersonRequests.Items, {}, self.Items);
        ko.mapping.fromJS(PersonRequests.Pager, {}, self.Pager);
    };

    self.Details = function (referenceId) {
        setLocation(PersonRequests.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
        };

        $.ajax({
            url: PersonRequests.GetPersonRequests,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Items, {}, self.Items);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(PersonRequests.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(PersonRequests.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Init();
};

PersonRequests.Init = function () {
    var viewModel = new PersonRequests.ListViewModel();
    ko.applyBindings(viewModel,
        $(PersonRequests.ContainerId)[0]);
};