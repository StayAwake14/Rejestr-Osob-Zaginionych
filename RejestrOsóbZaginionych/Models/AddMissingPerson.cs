using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrOsóbZaginionych.Models
{
    [Table("missingPersons")]
    public class AddMssingPerson
    {
        [Key]
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int wiek { get; set; }
        public string plec { get; set; }
        public string wojewodztwo { get; set; }
        public string data { get; set; }

        public string opis { get; set; }
        //  [NotMapped]
        [DisplayName("Upload File")]
        [Required]
        public string obraz { get; set; }

        public string status { get; set; }
       // [NotMapped]
      //  [Required]
      //  public HttpPostedFile SendFile { get; set; }

    }
}