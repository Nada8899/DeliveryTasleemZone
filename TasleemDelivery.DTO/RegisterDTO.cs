using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TasleemDelivery.SharedValidation.CustomValidations;

namespace TasleemDelivery.DTO
{
    public class RegisterDTO
    {
        public string ?Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [UniqueEmailAttribute]
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
