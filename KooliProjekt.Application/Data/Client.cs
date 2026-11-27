using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class Client
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [Required]
        [StringLength(25)]
        public string userName { get; set; }

        [StringLength(255)]
        public string passwordHash { get; set; }
    }
}
