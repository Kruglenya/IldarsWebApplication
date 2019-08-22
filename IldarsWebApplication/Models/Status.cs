using System;
using System.Collections.Generic;

namespace IldarsWebApplication.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime StampDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Status()
        {
            Employees = new List<Employee>();
        }
    }
}