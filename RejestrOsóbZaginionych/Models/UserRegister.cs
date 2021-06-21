using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrOsóbZaginionych.Models
{
    public class UserRegister
    {
        public int id { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string login { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [DataType(DataType.Password)]
        [DisplayName("Powtórz hasło")]
        [Compare("Password")]
        public string rpassword { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string rank = "Użytkownik";

    }
}