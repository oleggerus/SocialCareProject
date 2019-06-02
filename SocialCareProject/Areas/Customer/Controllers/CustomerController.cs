using System;
using System.Web;
using System.Web.Mvc;
using DataRepository.Entities.People;
using DataRepository.Enums;
using Services.Address;
using Services.People;
using SocialCareProject.Areas.Customer.Models.Customer;
using SocialCareProject.Authentication;
using SocialCareProject.Factories;

namespace SocialCareProject.Areas.Customer.Controllers
{
    public class CustomerController : BaseCustomerController
    {
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;



        public CustomerController(ICustomerModelFactory customerModelFactory,
            ICustomerService customerService, IUserService userService,
            IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
            _customerModelFactory = customerModelFactory;
            _userService = userService;
        }


        // GET: Customer/Customer
        public ActionResult Index()
        {
            if (!(HttpContext.User is CustomUser currentUser))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var customer = _customerService.GetCustomerByUserId(currentUser.UserId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var customerModel = _customerModelFactory.PrepareCustomerModel(customer);

            ViewBag.CanCreateCareRequest = _customerService.CanCreateCareRequest(customer.Id);

            return View("CustomerDetails", customerModel);
        }

        [HttpPost]
        public ActionResult EditAvatar(HttpPostedFileBase image = null)
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var user = _userService.GetUserById(id);

            if (image != null)
            {
                user.ImageMimeType = image.ContentType;
                user.Avatar = new byte[image.ContentLength];
                image.InputStream.Read(user.Avatar, 0, image.ContentLength);
            }

            _userService.UpdateUser(user);
            if (currentUser == null) return View("CustomerDetails");
            var customer = _customerService.GetCustomerByUserId(currentUser.UserId);
            var customerModel = _customerModelFactory.PrepareCustomerModel(customer);

            ViewBag.CanCreateCareRequest = _customerService.CanCreateCareRequest(customer.Id);
            return View("CustomerDetails", customerModel);

        }

        public FileContentResult GetImage()
        {
            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var customer = _customerService.GetCustomerByUserId(id);

            return File(customer.User.Avatar, customer.User.ImageMimeType);
        }

        public JsonResult UpdateDetails(CustomerModel model)
        {
            if (string.IsNullOrWhiteSpace(model.LastName) || string.IsNullOrWhiteSpace(model.FirstName) ||
                string.IsNullOrWhiteSpace(model.City)
                || string.IsNullOrWhiteSpace(model.Phone) || string.IsNullOrWhiteSpace(model.Email) 
                || string.IsNullOrWhiteSpace(model.HouseNameRoomNumber)
                || string.IsNullOrWhiteSpace(model.Street) || string.IsNullOrWhiteSpace(model.ZipPostalCode))
            {
              return Json(new { success = false, message = "Заповніть усі необхідні поля" }, JsonRequestBehavior.AllowGet);
            }

            var currentUser = HttpContext.User as CustomUser;
            var id = currentUser?.UserId ?? default(int);

            var user = _userService.GetUserById(id);
            user.FirstName = model.FirstName;
            user.LastName= model.LastName;
            user.MiddleName = model. MiddleName;
            user.Email = model.Email;
            user.Phone =  model.Phone;
            user.UpdatedOnUtc = DateTime.UtcNow;
            
            _userService.UpdateUser(user);
            var customer = _customerService.GetCustomerByUserId(id);
            var address = _addressService.GetAddressById(customer.AddressId);

            address.City = model.City;
            address.HouseNameRoomNumber = model.HouseNameRoomNumber;
            address.ZipPostalCode = model.ZipPostalCode;
            address.UpdatedOnUtc = DateTime.UtcNow;
            address.Street = model.Street;
            _addressService.UpdateAddress(address);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MakeCareRequest(int customerId, string reason)
        {
            var customer = _customerService.GetCustomerById(customerId);

            if (string.IsNullOrWhiteSpace(reason))
            {
                return Json(new { success = false, message = "Додайте необхідну інформацію" }, JsonRequestBehavior.AllowGet);
            }

            if (!_customerService.CanCreateCareRequest(customer.Id))
            {
                return Json(new { success = false, message = "Такий запит уже існує в системі" }, JsonRequestBehavior.AllowGet);
            }
            var careRequest = new CareRequest
            {
                CustomerId = customerId,
                Reason = reason,
                StatusId = (int)CareRequestStatuses.Opened
            };


            _customerService.InsertCareRequest(careRequest);
            return Json(new { success = true, message = "Ваш запит був успішно створений" }, JsonRequestBehavior.AllowGet);
        }
    }

}