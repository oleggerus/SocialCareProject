using DataRepository.Enums;
using Newtonsoft.Json;
using Services;
using Services.Administration;
using Services.Offer;
using Services.People;
using Services.Vendor;
using SocialCareProject.Factories;
using SocialCareProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SocialCareProject.Authentication;

namespace SocialCareProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAdministrationService _administrationService;
        private readonly IVendorService _vendorService;
        private readonly IPeopleFactory _peopleFactory;
        private readonly IAddressModelFactory _addressModelFactory;

        private readonly ICustomerService _customerService;
        private readonly IProviderService _providerService;
        private readonly IRoleService _roleService;



        public HomeController(IUserService userService,
            IOfferService offerService,
            IAuthenticationService authenticationService,
            IAdministrationService administrationService,
            IVendorService vendorService,
            IPeopleFactory peopleFactory,
            IAddressModelFactory addressModelFactory,
            ICustomerService customerService,
            IProviderService providerService,
            IRoleService roleService)
        {
            _userService = userService;
            _offerService = offerService;
            _authenticationService = authenticationService;
            _administrationService = administrationService;
            _vendorService = vendorService;
            _peopleFactory = peopleFactory;
            _addressModelFactory = addressModelFactory;
            _customerService = customerService;
            _providerService = providerService;
            _roleService = roleService;
        }

        public ActionResult Index()
        {
            var currentUser = _authenticationService.GetAuthenticatedCustomer();
            var user = HttpContext.User as CustomUser;
            if (user == null)
            {
                return View();
            }

            switch (user.AreaId)
            {
                case (int)AreaTypes.Customer:
                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                case (int)AreaTypes.Vendor:
                    return RedirectToAction("Index", "Home", new { area = "Provider" });
                case (int)AreaTypes.Administration:
                    return RedirectToAction("Index", "Home", new { area = "Worker" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var validationResult = _authenticationService.ValidateUser(model.Username, model.Password);
            if (validationResult == UserValidationsStatuses.CustomerNotExist)
            {
                ModelState.AddModelError("", "Такого користувача немає в системі");
            }
            else if (validationResult == UserValidationsStatuses.WrongPassword)
            {
                ModelState.AddModelError(nameof(model.Password), "Неправильно введений пароль");
            }
            else if (validationResult == UserValidationsStatuses.NotActive)
            {
                ModelState.AddModelError("", "Користувач є неактивним");
            }
            else if (validationResult == UserValidationsStatuses.Deleted)
            {
                ModelState.AddModelError("", "Користувача було видалено");
            }
            else
            {
                var user = _userService.GetUserByEmail(model.Username);

                var userModel = new Models.UserModel
                {
                    UserId = user.Id,
                    AreaId = user.Role.AreaId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleName = new List<string>() { user.Role.Name }
                };

                var userData = JsonConvert.SerializeObject(userModel);
                var authTicket = new FormsAuthenticationTicket
                (
                    1, model.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                );

                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(faCookie);

                //_authenticationService.SignIn(user, false);

                switch (user.Role.AreaId)
                {
                    case (int)AreaTypes.Customer:
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    case (int)AreaTypes.Vendor:
                        return RedirectToAction("Index", "Home", new { area = "Provider" });
                    case (int)AreaTypes.Administration:
                        return RedirectToAction("Index", "Home", new { area = "Worker" });
                }
            }

            return RedirectToAction("About");
        }

        public ActionResult Logout()
        {
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        [HttpGet]
        public ActionResult Registration()
        {
            var model = new RegistrationModel();
            ViewBag.Administrations = _administrationService.GetAllAdministrationsKeyValuePairs();
            ViewBag.Vendors = _vendorService.GetAllVendorsKeyValuePairs();
            return View(model);
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            var statusRegistration = false;
            var messageRegistration = string.Empty;
            ViewBag.Administrations = _administrationService.GetAllAdministrationsKeyValuePairs();
            ViewBag.Vendors = _vendorService.GetAllVendorsKeyValuePairs();
            switch (model.RoleId)
            {
                case default(int):
                    ModelState.AddModelError("RoleId", "Оберіть роль");
                    break;
                case (int)AreaTypes.Customer:
                    {
                        if (model.AdministrationId == null || model.AdministrationId.Value == default(int))
                        {
                            ModelState.AddModelError("AdministrationId", "Оберіть адміністрацію");
                        }

                        break;
                    }
            }


            if (ModelState.IsValid)
            {
                // Email Verification
                var userName = _userService.GetUserByEmail(model.Email);
                if (userName != null)
                {
                    ModelState.AddModelError("Warning Email", "Ця електронна адреса уже зареєстрована");
                    return View(model);
                }

                var user = _peopleFactory.PrepareUser(model);
                var address = _addressModelFactory.PrepareAddressFromRegistrationModel(model);
                if (model.RoleId == (int)AreaTypes.Customer)
                {
                    var customer = _peopleFactory.PrepareCustomer(model, user, address);
                    _customerService.Create(customer);
                }
                if (model.RoleId == (int)AreaTypes.Vendor)
                {
                    var provider = _peopleFactory.PrepareProvider(model, user, address);
                    _providerService.Create(provider);
                }


                //Verification Email
                //VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());
                messageRegistration = "Ви були успішно зареєстровані";
                statusRegistration = true;
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                messageRegistration = "Перевірте свої дані!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(model);
        }

        [HttpGet]
        public ActionResult ActivationAccount(string id)
        {
            bool statusAccount = false;
            //using (AuthenticationDB dbContext = new DataAccess.AuthenticationDB())
            //{
            //    var userAccount = dbContext.Users.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

            //    if (userAccount != null)
            //    {
            //        userAccount.IsActive = true;
            //        dbContext.SaveChanges();
            //        statusAccount = true;
            //    }
            //    else
            //    {
            //        ViewBag.Message = "Something Wrong !!";
            //    }

            //}
            ViewBag.Status = statusAccount;
            return View();
        }
        [NonAction]
        public void VerificationEmail(string email, string activationCode)
        {
            var url = string.Format("/Account/ActivationAccount/{0}", activationCode);
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

            var fromEmail = new MailAddress("mehdi.rami2012@gmail.com", "Activation Account - AKKA");
            var toEmail = new MailAddress(email);

            var fromEmailPassword = "******************";
            string subject = "Activation Account !";

            string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            })

                smtp.Send(message);

        }
    }
}