var Offers = Offers || {};

Offers.FilterMapping = {
};

Offers.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Offers = ko.observableArray([]);

    self.Init = function () {
        ko.mapping.fromJS(Offers.Offers, {}, self.Offers);
        ko.mapping.fromJS(Offers.Pager, {}, self.Pager);
    };

    self.Details = function (referenceId) {
        setLocation(Offers.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
        };
        notify.close();
        $.ajax({
            url: Offers.GetOffers,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Offers, {}, self.Offers);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(Offers.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(Offers.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Init();
};

Offers.Init = function () {
    var viewModel = new Offers.ListViewModel();
    ko.applyBindings(viewModel,
        $(Offers.ContainerId)[0]);
};