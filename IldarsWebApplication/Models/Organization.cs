using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IldarsWebApplication.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [Display(Name = "ИНН организации")]
        public string Inn { get; set; }
        [Display(Name = "Название организации")]
        public string Title { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Organization()
        {
            Employees = new List<Employee>();
        }
    }
}