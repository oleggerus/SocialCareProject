var ProductDetails = ProductDetails || {};

ProductDetails.ProductViewModel = function () {
    var self = this;
    self.Details = ko.observable();

    self.Init = function () {
        ko.mapping.fromJS(ProductDetails.Details, {}, self.Details);
    };

    self.Init();

};

ProductDetails.Init = function () {
    var viewModel = new ProductDetails.ProductViewModel();
    ko.applyBindings(viewModel,
        $(ProductDetails.ContainerId)[0]);
};