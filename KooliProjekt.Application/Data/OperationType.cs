using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class OperationType
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }
    }
}
