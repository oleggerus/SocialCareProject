var People = People || {};
People.FilterMapping = {
    'ignore': ["Clear"]
};

People.PeopleMapping = {
    create: function (options) {
        return new People.CustomerViewModel(options.data);
    }
};

People.FilterViewModel = function () {
    var self = this;
    self.Name = ko.observable(null);
    self.StatusId = ko.observable(null);
    self.Email = ko.observable(null);
    self.Phone = ko.observable(null);


    self.Clear = function () {
        self.Name(null);
        self.Email(null);
        self.StatusId(null);
        self.Phone(null);
    };
};


People.CustomerViewModel = function (data) {
    var self = this;


    ko.mapping.fromJS(data, {}, self);

    self.CareStatus = ko.pureComputed(function () {
        var status = ko.utils.arrayFirst(People.CustomerStatuses,
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
                return "label text-uppercase label-danger";
        case 2:
                return "label text-uppercase label-success";
        case 3:
                return "label text-uppercase label-info";
       
        default:
                return "label text-uppercase label-default";
        }
    });
};

People.ListViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);
    self.Pager = new PagerViewModel();
    self.Filter = new People.FilterViewModel();
    self.People = ko.observableArray([]);

    self.Init = function () {
        ko.mapping.fromJS(People.People, People.PeopleMapping, self.People);
        ko.mapping.fromJS(People.Pager, {}, self.Pager);
        ko.mapping.fromJS(People.Filter, {}, self.Filter);
    };

    self.Details = function (referenceId) {
        setLocation(People.Details + encodeURIComponent(location.href));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {}),
            filter: ko.mapping.toJS(self.Filter, People.FilterMapping)
        };

        $.ajax({
            url: People.GetPeople,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.People, People.PeopleMapping, self.People);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(People.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(People.GeneralErrorMessage, true);
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

People.Init = function () {
    var viewModel = new People.ListViewModel();
    ko.applyBindings(viewModel,
        $(People.ContainerId)[0]);
};