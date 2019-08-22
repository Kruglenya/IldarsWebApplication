using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IldarsWebApplication.Models
{
    public class JobType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public JobType()
        {
            Employees = new List<Employee>();
        }
    }
}