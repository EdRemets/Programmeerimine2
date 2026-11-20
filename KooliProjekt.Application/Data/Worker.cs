using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    [Index(nameof(userName), IsUnique = true)]
    public class Worker
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public bool isAdmin { get; set; }

        [StringLength(25)]
        public string userName { get; set; }

        [StringLength(255)]
        public string passwordHash { get; set; }

        private List<Operation> operations = new List<Operation>();
        public List<Operation> getOperations() {
            return operations;
        }
        public void AddOperation(Operation operation) {
            if (isAdmin)
            {
                operations.Add(operation);
                return;
            }
            Console.WriteLine("Not Admin");
        }
        public void ChangeStatus(Operation operation, Status status) { 
            operation.status = status;
        }
    }
}
