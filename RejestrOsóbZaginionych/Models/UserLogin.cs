using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrOsóbZaginionych.Models
{

    public class UserLogin
    {

        public int id { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string login { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string email { get; set; }

        public string rank { get; set; }
        [NotMapped]
        public string LoginErrorMessage { get; set; }
    }
}