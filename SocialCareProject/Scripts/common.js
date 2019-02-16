function PagerViewModel() {
    var self = this;

    self.PageSize = ko.observable(0);
    self.PageIndex = ko.observable(0);
    self.TotalPages = ko.observable(0);
    self.HasNextPage = ko.observable(0);
    self.HasPreviousPage = ko.observable(0);
    self.TotalCount = ko.observable(0);

    self.PageSlide = ko.observable(1);

    self.Load = null;
    self.PageClickHandler = null;

    self.Pages = ko.computed(function () {
        var pageNum = self.PageIndex() + 1;
        var pageFrom = Math.max(1, pageNum - self.PageSlide());
        var pageTo = Math.min(self.TotalPages(), pageNum + self.PageSlide());
        pageFrom = Math.max(1, Math.min(pageTo - self.PageSlide(), pageFrom));
        pageTo = Math.min(self.TotalPages(), Math.max(pageFrom + self.PageSlide(), pageNum == 1 ? pageTo + self.PageSlide() : pageTo));

        var result = [];
        for (var i = pageFrom; i <= pageTo; i++) {
            result.push(i);
        }

        return result;
    });

    self.StartRecord = ko.pureComputed(function () {
        return (self.PageIndex() * self.PageSize()) + 1;
    });

    self.EndRecord = ko.pureComputed(function () {
        var end = ((self.PageIndex() + 1) * self.PageSize());
        return (end > self.TotalCount()) ? self.TotalCount() : end;
    });
};