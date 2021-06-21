using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrOsóbZaginionych.Models
{
    public class MissingPerson
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string imie { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string nazwisko { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public int wiek { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string plec { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string wojewodztwo { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public DateTime data { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string obraz { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string opis { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string status { get; set; }

    }
}