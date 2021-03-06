﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SocialCareProject.Areas.Customer.Models.Customer
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Administration { get; set; }
        public string AdministrationPhone { get; set; }
        public string AdministrationContactName { get; set; }



        public string Info { get; set; }
        public bool? IsSelfPaid { get; set; }
        public bool? IsInvalid { get; set; }

        public int? StatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public byte[] Avatar { get; set; }
        public string ImageMimeType { get; set; }


        public string HouseNameRoomNumber { get; set; }
        public string Street { get; set; }
        public int RegionId { get; set; }
        public string City { get; set; }
        public string ZipPostalCode { get; set; }
        public string HomePhoneNumber { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}