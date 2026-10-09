using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class Car
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string manufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string model { get; set; }

        [Required]
        [StringLength(20)]
        public string licensePlate { get; set; }
    }
}
