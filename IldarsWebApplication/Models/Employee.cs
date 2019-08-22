using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace IldarsWebApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string SurName {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string Position { get; set; }

        public string Gender { get; set; }
        public string Serial { get; set; }
        public string Code { get; set; }
        public DateTime? IssueDate { get; set; }
        public string WhoIssued { get; set; }
        public string Registration { get; set; }
        public string CitizenShip { get; set; }
        public string BirthPlace { get; set; }

        public DateTime? HireDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Title { get; set; }
        public string TerritoryService { get; set; }
        public DateTime? AddedDate { get; set; }
        public bool IsInnerClient { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual ICollection<JobType> JobTypes { get; set;}
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
        public Employee()
        {
            JobTypes = new List<JobType>();
            Organizations = new List<Organization>();
            Statuses = new List<Status>();
        }
    }
}