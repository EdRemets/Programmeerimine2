using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class Operation
    {
        [Key]
        public int id { get; set; }

        public DateTime date { get; set; }

        public Status status { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? cost { get; set; }

        [Required]
        public Car car { get; set; }

        [Required]
        public OperationType operationType { get; set; }

        [Required]
        public Worker worker { get; set; }
    }
}

