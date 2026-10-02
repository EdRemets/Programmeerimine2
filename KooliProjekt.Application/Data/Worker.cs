using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class Worker
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public bool isAdmin { get; set; }
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
