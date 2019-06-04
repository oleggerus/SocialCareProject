var Products = Products || {};
Products.FilterMapping = {
};

Products.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();

    self.Products = ko.observableArray([]);

    self.Init = function () {
        ko.mapping.fromJS(Products.Products, {}, self.Products);
        ko.mapping.fromJS(Products.Pager, {}, self.Pager);
    };

    self.Details = function (id) {
        window.location.replace(Products.Details + "?id="+id);
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
        };
        notify.close();
        $.ajax({
            url: Products.GetProducts,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Products, {}, self.Products);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(Products.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(Products.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Init();
};

Products.Init = function () {
    var viewModel = new Products.ListViewModel();
    ko.applyBindings(viewModel,
        $(Products.ContainerId)[0]);
};