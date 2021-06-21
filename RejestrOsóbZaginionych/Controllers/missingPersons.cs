namespace RejestrOsóbZaginionych.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class missingPersons
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string imie { get; set; }

        [Required]
        [StringLength(50)]
        public string nazwisko { get; set; }

        public int? wiek { get; set; }

        [Required]
        [StringLength(1)]
        public string plec { get; set; }

        [Required]
        [StringLength(50)]
        public string wojewodztwo { get; set; }

        [Column(TypeName = "date")]
        public DateTime data { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string opis { get; set; }

        [StringLength(50)]
        public string obraz { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
