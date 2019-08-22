using IldarsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IldarsWebApplication.ViewModel
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Organization = new Organization();
        }
        public EmployeeViewModel(Employee emp)
        {
            SurName = emp.SurName;
            FirstName = emp.FirstName;
            MiddleName = emp.MiddleName;
            Position = emp.Position;
            Gender = emp.Gender;
            Serial = emp.Serial;
            Code = emp.Code;
            IssueDate = emp.IssueDate;
            WhoIssued = emp.WhoIssued;
            Registration = emp.Registration;
            CitizenShip = emp.CitizenShip;
            BirthPlace = emp.BirthPlace;
            HireDate = emp.HireDate;
            BirthDate = emp.BirthDate;
            Title = emp.Title;
            TerritoryService = emp.TerritoryService;
            AddedDate = emp.AddedDate;
            Organization = new Organization();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string SurName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Номер и серия паспорта")]
        public string Serial { get; set; }

        [Required]
        [Display(Name = "Код подразделения")]
        public string Code { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Когда выдан")]
        public DateTime? IssueDate { get; set; }

        [Required]
        [Display(Name = "Кем выдан")]
        public string WhoIssued { get; set; }
        [Display(Name = "Регистрация")]
        public string Registration { get; set; }
        [Display(Name = "Гражданство")]
        public string CitizenShip { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Место рождения")]
        public string BirthPlace { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата приёма на работу")]
        public DateTime? HireDate { get; set; }

        [Display(Name = "Описание")]
        public string Title { get; set; }
        [Display(Name = "Территория обслуживания")]
        public string TerritoryService { get; set; }

        public bool IsInnerClient { get; set; }
        public DateTime? AddedDate { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public Organization Organization { get; set; }
    }
}