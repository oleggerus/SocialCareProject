var Notifications = Notifications || {};
Notifications.FilterMapping = {
};

Notifications.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Notifications = ko.observableArray([]);

    self.Init = function () {
        ko.mapping.fromJS(Notifications.Notifications, {}, self.Notifications);
        ko.mapping.fromJS(Notifications.Pager, {}, self.Pager);
    };

    self.Details = function (referenceId) {
        setLocation(Notifications.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
        };

        $.ajax({
            url: Notifications.GetNotifications,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Notifications, {}, self.Notifications);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(Notifications.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(Notifications.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Init();
};

Notifications.Init = function () {
    var viewModel = new Notifications.ListViewModel();
    ko.applyBindings(viewModel,
        $(Notifications.ContainerId)[0]);
};