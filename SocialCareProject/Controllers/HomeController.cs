using DataRepository.Enums;
using Newtonsoft.Json;
using Services;
using Services.Offer;
using Services.People;
using SocialCareProject.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataRepository.Entities.People;

namespace SocialCareProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;
        private readonly IAuthenticationService _authenticationService;


        public HomeController(IUserService userService,
            IOfferService offerService,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _offerService = offerService;
            _authenticationService = authenticationService;
        }

        public ActionResult Index()
        {
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
            return RedirectToRoute("HomePage");
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
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel registrationView)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                // Email Verification
                string userName = Membership.GetUserNameByEmail(registrationView.Email);
                if (!string.IsNullOrEmpty(userName))
                {
                    ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                    return View(registrationView);
                }

                //Save User Data 
                //using (AuthenticationDB dbContext = new AuthenticationDB())
                //{
                //    var user = new User()
                //    {
                //        Username = registrationView.Username,
                //        FirstName = registrationView.FirstName,
                //        LastName = registrationView.LastName,
                //        Email = registrationView.Email,
                //        Password = registrationView.Password,
                //        ActivationCode = Guid.NewGuid(),
                //    };

                //    dbContext.Users.Add(user);
                //    dbContext.SaveChanges();
                //}

                //Verification Email
                VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());
                messageRegistration = "Your account has been created successfully. ^_^";
                statusRegistration = true;
            }
            else
            {
                messageRegistration = "Something Wrong!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(registrationView);
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