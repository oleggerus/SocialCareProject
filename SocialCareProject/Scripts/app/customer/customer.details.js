var CustomerDetails = CustomerDetails || {};

CustomerDetails.FilterMapping = {
};


CustomerDetails.CareRequsetModal = function(id) {
    var self = this;

    self.Reason = ko.observable();
    self.CustomerId = ko.observable(id);

    self.ShowModal = function () {
        $("#careRequestModal").appendTo("#page");
        $("#careRequestModal").modal('show');
    };

    self.SendRequest = function() {
        var url = CustomerDetails.SendRequestUrl;
        $.ajax({
            url: url,
            dataType: "json",
            data: {
                customerId: self.CustomerId(),
                reason: self.Reason()
            }
        }).done(function(result) {
            if (result && result.success) {
                $("#careRequestModal").modal('hide');
                CustomerDetails.CanCreateCareRequest = false;
                var btn = document.getElementById('careRequestBtnId');
                btn.style.visibility = 'hidden';
                notify.ok(result.message);
            } else if (result && !result.success) {
                notify.fail(result.message);
            }
        }).fail(function() {
            notify.fail("Щось пішло не так. Спробуйте ще раз");
        });
    };
};

CustomerDetails.CustomerViewModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.AdministrationPhone = ko.observable();
    self.AdministrationContactName = ko.observable();
    self.Administration = ko.observable();
    self.Info = ko.observable();
    self.IsSelfPaid = ko.observable();
    self.IsInvalid = ko.observable();
    self.StatusId = ko.observable();
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.MiddleName = ko.observable();
    self.Email = ko.observable();
    self.Phone = ko.observable();
    self.Email = ko.observable();
    self.DateOfBirth = ko.observable();
    self.Gender = ko.observable();
    self.Avatar = ko.observable();
    self.HouseNameRoomNumber = ko.observable();
    self.Street = ko.observable();
    self.RegionId = ko.observable();
    self.City = ko.observable();
    self.ZipPostalCode = ko.observable();
    self.HomePhoneNumber = ko.observable();
    self.CustomerId = ko.observable();
    self.ImageMimeType = ko.observable();
    

    self.CareRequestModal = new CustomerDetails.CareRequsetModal(CustomerDetails.Details.CustomerId);
    self.MakeCareRequest = function () {
        self.CareRequestModal.ShowModal();
    };

   };

CustomerDetails.CustomerDetailsViewModel = function () {
    var self = this;
    self.Loading = ko.observable(false);

    self.Details = new CustomerDetails.CustomerViewModel();
    self.Init = function () {
        ko.mapping.fromJS(CustomerDetails.Details, {}, self.Details);
    };

    self.UpdateProfile = function () {
        notify.close()
        self.Loading(true);
        $.ajax({
            url: CustomerDetails.UpdateDetails,
            //type: "POST",
            dataType: "json",
            data: ko.mapping.toJS(self.Details, {})
        }).done(function (result) {
            if (result && result.success) {
                notify.ok("Успішно збережено");
            } else {
                notify.fail(result.message, true);
            }
        }).fail(function () {
            notify.fail("Відбувся збій", true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            pager: ko.mapping.toJS(self.Pager, {})
        };

        $.ajax({
            url: CustomerDetails.GetCustomerDetails,
            type: "POST",
            dataType: "json",
            data: data
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.CustomerDetails, {}, self.CustomerDetails);

                history.replaceState({}, null, result.redirect);

            } else {
                notify.fail(CustomerDetails.GeneralErrorMessage, true);
            }
        }).fail(function () {
            notify.fail(CustomerDetails.GeneralErrorMessage, true);
        }).always(function () {
            self.Loading(false);
        });
    };

    self.Init();
};

CustomerDetails.Init = function () {
    var viewModel = new CustomerDetails.CustomerDetailsViewModel();
    ko.applyBindings(viewModel,
        $(CustomerDetails.ContainerId, CustomerDetails.ButtonsId)[0]);
};