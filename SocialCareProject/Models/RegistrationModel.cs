using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataRepository.Enums;

namespace SocialCareProject.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Введіть своє ім'я")]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введіть своє прізвище")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Введіть свою електронну адресу")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Електронна адреса")]
        public string Email { get; set; }
        //[Required]
        //public Guid ActivationCode { get; set; }

        [Required(ErrorMessage = "Введіть свій пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введіть свій пароль ще раз")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторний пароль")]
        [Compare("Password", ErrorMessage = "Паролі повинні співпадати")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введіть свій номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефону")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Введіть свою дату народження")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Оберіть стать")]
        [Display(Name = "Стать")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Оберіть роль")]
        [Display(Name = "Ваша роль")]
        public int RoleId { get; set; }


        [Display(Name = "Вендор")]
        public int? VendorId { get; set; }

        [Display(Name = "Адміністрація")]
        public int? AdministrationId { get; set; }

        [Required(ErrorMessage = "Оберіть область")]
        [Display(Name = "Область")]
        public Regions RegionId { get; set; }

        [Required(ErrorMessage = "Оберіть населений пункт")]
        [Display(Name = "Місто/село")]
        public string City { get; set; }

        [Display(Name = "Вулиця")]
        public string Street { get; set; }

        [Display(Name = "Номер будинку та квартири")]
        public string HouseNameRoomNumber { get; set; }

        [Display(Name = "Поштовий індекс")]
        public string ZipPostalCode { get; set; }


        //public IList<KeyValuePair<int, string>> Administrations { get; set; } = new List<KeyValuePair<int, string>>();

        //public IList<KeyValuePair<int, string>> Vendors { get; set; } = new List<KeyValuePair<int, string>>();      
    }
}