using IldarsWebApplication.Helper;
using IldarsWebApplication.Models;
using IldarsWebApplication.ViewModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IldarsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();
        //private string EncryptionKeyFile;

        public HomeController()
        {
            //EncryptionKeyFile = System.Web.HttpContext.Current.Server.MapPath("key.config");
            //SymmetricEncryptionUtility.AlgorithmName = "DES";
            //if (!System.IO.File.Exists(EncryptionKeyFile))
            //{
            //    SymmetricEncryptionUtility.GenerateKey(EncryptionKeyFile);
            //}
        }
        public ActionResult Index()
        {
            return View();
        }

        private async Task<SelectList> TerrToList()
        {
            //List<QueryResult> list = new List<QueryResult>();
            //try
            //{
            //    var sql = @"select distinct ROW_NUMBER() OVER(ORDER BY Area ASC) AS Id,  Area as [Name] from [Globus].[dbo].[Location]
            //                        where Area is not null group by Area";
            //    list = await db.Database.SqlQuery<QueryResult>(sql).ToListAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            List<QueryResult> list = new List<QueryResult>() { new QueryResult() {Id =  1   , Name = "	Адыгея	" },
             //new QueryResult() {Id =    2   , Name = "	Адыгея (Адыгея)	" },
             new QueryResult() {Id =    3   , Name = "	Алтай	" },
             //new QueryResult() {Id =    4   , Name = "	Алтайский	" },
             new QueryResult() {Id =    5   , Name = "	Амурская	" },
             new QueryResult() {Id =    6   , Name = "	Архангельская	" },
             new QueryResult() {Id =    7   , Name = "	Астраханская	" },
             new QueryResult() {Id =    8   , Name = "	Башкортостан	" },
             new QueryResult() {Id =    9   , Name = "	Белгородская	" },
             new QueryResult() {Id =    10  , Name = "	Белоярский	" },
             new QueryResult() {Id =    11  , Name = "	Брянская	" },
             new QueryResult() {Id =    12  , Name = "	Бурятия	" },
             new QueryResult() {Id =    13  , Name = "	Владимирская	" },
             //new QueryResult() {Id =    14  , Name = "	Владимирская область	" },
             new QueryResult() {Id =    15  , Name = "	Волгоградская	" },
             new QueryResult() {Id =    16  , Name = "	Вологодская	" },
             new QueryResult() {Id =    17  , Name = "	Володарский	" },
             new QueryResult() {Id =    18  , Name = "	Воронежская	" },
             new QueryResult() {Id =    19  , Name = "	Дагестан	" },
             //new QueryResult() {Id =    20  , Name = "	Еврейская	" },
             //new QueryResult() {Id =    21  , Name = "	Еврейская Автономная	" },
             new QueryResult() {Id =    22  , Name = "	Еврейская автономная область	" },
             new QueryResult() {Id =    23  , Name = "	Забайкальский	" },
             new QueryResult() {Id =    24  , Name = "	Ивановская	" },
             new QueryResult() {Id =    25  , Name = "	Ингушетия	" },
             new QueryResult() {Id =    26  , Name = "	Иркутская	" },
            // new QueryResult() {Id =    27  , Name = "	Кабардино-Балкария	" },
             new QueryResult() {Id =    28  , Name = "	Кабардино-Балкарская	" },
             new QueryResult() {Id =    29  , Name = "	Калининградская	" },
             new QueryResult() {Id =    30  , Name = "	Калмыкия	" },
             new QueryResult() {Id =    31  , Name = "	Калужская	" },
             new QueryResult() {Id =    32  , Name = "	Камчатский	" },
             new QueryResult() {Id =    33  , Name = "	Карачаево-Черкессия	" },
             //new QueryResult() {Id =    34  , Name = "	Карачаево-Черкесская	" },
            // new QueryResult() {Id =    35  , Name = "	Карачаево-Черкесское	" },
             new QueryResult() {Id =    36  , Name = "	Карелия	" },
             new QueryResult() {Id =    37  , Name = "	Кемеровская	" },
             new QueryResult() {Id =    38  , Name = "	Киреевский	" },
             //new QueryResult() {Id =    39  , Name = "	Кировская	" },
             new QueryResult() {Id =    40  , Name = "	Кировская область	" },
            // new QueryResult() {Id =    41  , Name = "	Кировскоая	" },
            // new QueryResult() {Id =    42  , Name = "	Кировскская	" },
             new QueryResult() {Id =    43  , Name = "	Коми	" },
             new QueryResult() {Id =    44  , Name = "	Костромская	" },
             new QueryResult() {Id =    45  , Name = "	Краснодарский	" },
             new QueryResult() {Id =    46  , Name = "	Красноярский	" },
             new QueryResult() {Id =    47  , Name = "	Курганская	" },
             new QueryResult() {Id =    48  , Name = "	Курская	" },
             new QueryResult() {Id =    49  , Name = "	Ленинградская	" },
             new QueryResult() {Id =    50  , Name = "	Ленинский	" },
             new QueryResult() {Id =    51  , Name = "	Липецкая	" },
             new QueryResult() {Id =    52  , Name = "	Лысковский	" },
             new QueryResult() {Id =    53  , Name = "	Магаданская	" },
             new QueryResult() {Id =    54  , Name = "	Марий Эл	" },
             new QueryResult() {Id =    55  , Name = "	Михайловский	" },
             new QueryResult() {Id =    56  , Name = "	Мордовия	" },
             new QueryResult() {Id =    57  , Name = "	Москва	" },
            // new QueryResult() {Id =    58  , Name = "	Московкая	" },
            // new QueryResult() {Id =    59  , Name = "	Московская	" },
             new QueryResult() {Id =    60  , Name = "	Московская область	" },
             new QueryResult() {Id =    61  , Name = "	Мурманская	" },
             new QueryResult() {Id =    62  , Name = "	Ненецкий	" },
            // new QueryResult() {Id =    63  , Name = "	Нижегордская	" },
            // new QueryResult() {Id =    64  , Name = "	Нижегородская	" },
             new QueryResult() {Id =    65  , Name = "	Нижегородская область	" },
             new QueryResult() {Id =    66  , Name = "	Новгородская	" },
             new QueryResult() {Id =    67  , Name = "	Новосибирская	" },
             new QueryResult() {Id =    68  , Name = "	Одинцовский	" },
             new QueryResult() {Id =    69  , Name = "	Омская	" },
             new QueryResult() {Id =    70  , Name = "	Оренбургская	" },
             new QueryResult() {Id =    71  , Name = "	Орловская	" },
             new QueryResult() {Id =    72  , Name = "	ОСБ Банк Татарстан	" },
             new QueryResult() {Id =    73  , Name = "	Пензенская	" },
             new QueryResult() {Id =    74  , Name = "	Пермский	" },
            // new QueryResult() {Id =    75  , Name = "	Приморский	" },
             new QueryResult() {Id =    76  , Name = "	Приморский край	" },
             new QueryResult() {Id =    77  , Name = "	Псковская	" },
             new QueryResult() {Id =    78  , Name = "	Ростовская	" },
            // new QueryResult() {Id =    79  , Name = "	Ростоская	" },
             new QueryResult() {Id =    80  , Name = "	Рязанская	" },
             new QueryResult() {Id =    81  , Name = "	Сабинский	" },
             new QueryResult() {Id =    82  , Name = "	Самарская	" },
             new QueryResult() {Id =    83  , Name = "	Самарская область	" },
             new QueryResult() {Id =    84  , Name = "	Санкт-Петербург	" },
             new QueryResult() {Id =    85  , Name = "	Саратовская	" },
             new QueryResult() {Id =    86  , Name = "	Саха (Якутия)	" },
            // new QueryResult() {Id =    87  , Name = "	Саха /Якутия/	" },
             new QueryResult() {Id =    88  , Name = "	Сахалинская	" },
             new QueryResult() {Id =    89  , Name = "	Свердловская	" },
             new QueryResult() {Id =    90  , Name = "	Северная Осетия	" },
            // new QueryResult() {Id =    91  , Name = "	Северная Осетия - Алания	" },
             new QueryResult() {Id =    92  , Name = "	Северная Осетия-Алания	" },
            // new QueryResult() {Id =    93  , Name = "	Смоленкая	" },
             new QueryResult() {Id =    94  , Name = "	Смоленская	" },
            // new QueryResult() {Id =    95  , Name = "	Ставропольский	" },
             new QueryResult() {Id =    96  , Name = "	Ставропольский край	" },
             new QueryResult() {Id =    97  , Name = "	Тамбовская	" },
             new QueryResult() {Id =    98  , Name = "	Татарстан	" },
             //new QueryResult() {Id =    99  , Name = "	Татарстан (Татарстан)	" },
             new QueryResult() {Id =    100 , Name = "	Тверская	" },
             new QueryResult() {Id =    101 , Name = "	Томская	" },
             new QueryResult() {Id =    102 , Name = "	Тульская	" },
             new QueryResult() {Id =    103 , Name = "	Тыва	" },
             new QueryResult() {Id =    104 , Name = "	Тюменская	" },
            // new QueryResult() {Id =    105 , Name = "	Тюменское	" },
             new QueryResult() {Id =    106 , Name = "	Удмуртия	" },
            // new QueryResult() {Id =    107 , Name = "	Удмуртская	" },
             new QueryResult() {Id =    108 , Name = "	Ульяновская	" },
             new QueryResult() {Id =    109 , Name = "	Хабаровский	" },
             new QueryResult() {Id =    110 , Name = "	Хакасия	" },
             new QueryResult() {Id =    111 , Name = "	Ханты-мансийский	" },
             new QueryResult() {Id =    112 , Name = "	Ханты-Мансийский Автономный округ - Югра	" },
             //new QueryResult() {Id =    113 , Name = "	ХМАО	" },
             //new QueryResult() {Id =    114 , Name = "	ХМАО-Югра	" },
             new QueryResult() {Id =    115 , Name = "	Челябинская	" },
            // new QueryResult() {Id =    116 , Name = "	Челябинская область	" },
            // new QueryResult() {Id =    117 , Name = "	Челябинское	" },
             new QueryResult() {Id =    118 , Name = "	Чеченская	" },
            // new QueryResult() {Id =    119 , Name = "	Чечня	" },
             new QueryResult() {Id =    120 , Name = "	Чувашия	" },
            // new QueryResult() {Id =    121 , Name = "	Чувашия (Чувашия)	" },
            // new QueryResult() {Id =    122 , Name = "	Чувашская	" },
            // new QueryResult() {Id =    123 , Name = "	Чувашская Республика -	" },
             new QueryResult() {Id =    124 , Name = "	Чукотский	" },
             new QueryResult() {Id =    125 , Name = "	Ямало-Ненецкий	" },
             new QueryResult() {Id =    126 , Name = "	Ярославская	" }
             };
            return new SelectList(list, "Name", "Name");
        }

        public async Task<ActionResult> NewEmployee()
        {
            ViewBag.selectListTerr = await TerrToList();
            EmployeeViewModel model = new EmployeeViewModel();
            return View(model);
        }

        public FileContentResult GetImage(int Id)
        {
            Employee emp = db.Employees.FirstOrDefault(g => g.Id == Id);

            if (emp != null)
            {
                return File(emp.ImageData, emp.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<ActionResult> NewEmployee([Bind(Include = "SurName,FirstName,MiddleName, Gender, Serial, Code, IssueDate, WhoIssued,Registration,CitizenShip,BirthPlace,HireDate,Title,TerritoryService,Position,IsInnerClient,Organization")] EmployeeViewModel model,
                                            string IsInner, string region, string locality, string street, string house, string building, string structure, string apartment, HttpPostedFileBase image = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee findEmp = db.Employees.Where(s => s.Serial == model.Serial & s.Code == model.Code).FirstOrDefault();
                    if (findEmp == null)
                    {
                        Employee emp = new Employee { AddedDate = DateTime.Now };
                        emp.SurName = model.SurName;
                        emp.FirstName = model.FirstName;
                        emp.MiddleName = model.MiddleName;
                        emp.Position = model.Position;
                        emp.Gender = model.Gender;
                        emp.Serial = model.Serial;
                        emp.Code = model.Code;
                        emp.IssueDate = model.IssueDate;
                        emp.WhoIssued = model.WhoIssued;
                        emp.Registration = String.Join(" ", new string[] { region, locality, street, house, building, structure, apartment });
                        emp.CitizenShip = model.CitizenShip;
                        emp.BirthPlace = model.BirthPlace;
                        emp.HireDate = model.HireDate;
                        emp.Title = model.Title;
                        emp.TerritoryService = model.TerritoryService;

                        emp.IsInnerClient = IsInner == "on" ? true : false;

                        db.Employees.Add(emp);

                        Organization org = new Organization
                        {
                            Inn = model.Organization.Inn,
                            Title = model.Organization.Title
                        };
                        Organization orgFind = db.Organizations.Where(s => s.Inn == model.Organization.Inn & s.Title == model.Organization.Title).FirstOrDefault();
                        if (orgFind == null)
                        {
                            db.Organizations.Add(org);
                            org.Employees.Add(emp);
                        }
                        else
                        {
                            orgFind.Employees.Add(emp);
                        }
                        if (image != null)
                        {
                            emp.ImageMimeType = image.ContentType;
                            emp.ImageData = new byte[image.ContentLength];
                            image.InputStream.Read(emp.ImageData, 0, image.ContentLength);
                        }
                    }
                    else
                    {
                        ViewBag.ReturnMessage = "Такой сотрудник уже существует";
                        return View(model);
                    }
                    db.SaveChanges();

                    return RedirectToAction("Success", "Home");
                }
                ViewBag.selectListTerr = await TerrToList();
            }
            catch(Exception ex)
            {
                Elmah.Error error = new Elmah.Error(ex);
            }
            return View(model);
        }
        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admission(string AdsearchPattern)
        {
            return PartialView("_AdmissionSearchResult");
        }
        public ActionResult Admission()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Journal()
        {
            List<JournalSearchViewModel> el = new List<JournalSearchViewModel>();
            ViewBag.Title = String.Empty;
            return View(el);
        }

        [HttpPost]
        public ActionResult Journal(string JsearchPattern, string optradio)
        {
            List<JournalSearchViewModel> el = new List<JournalSearchViewModel>();
            switch (optradio)
            {
                case "One":
                    break;
                case "Two":
                    List<Organization> result = db.Organizations.Include("Employees").Where(c => c.Inn == JsearchPattern).ToList();
                    ViewBag.OrgTitle = result.FirstOrDefault() != null ? result.FirstOrDefault().Title : String.Empty;
                    foreach (var it in result.Distinct())
                    {
                        foreach (var emp in it.Employees.Distinct())
                        {
                            JournalSearchViewModel jvm = new JournalSearchViewModel();
                            jvm.FullName = String.Join(" ", new List<string> { emp.FirstName, emp.MiddleName, emp.SurName });
                            jvm.AddedDate = emp.AddedDate;
                            foreach (var st in emp.Statuses)
                            {
                                switch (st.Type)
                                {
                                    case "проверка службой безопастности":
                                        jvm.SecurityDateStatus = st.Type + '\n' + st.StampDate.ToString();
                                        break;
                                    case "допуск к работе":
                                        jvm.AdmissionDateStatus = st.Type + '\n' + st.StampDate.ToString();
                                        break;
                                    case "письмо получено":
                                        jvm.LetterReceivedDateStatus = st.Type + '\n' + st.StampDate.ToString();
                                        break;
                                }
                            }
                            el.Add(jvm);
                        }
                    }
                    break;
            }
            return View(el);
        }

        [HttpPost]
        public async Task<string> Upload(HttpPostedFileBase claimfile)
        {
            int Added = 0;
            int Existed = 0;
            IWorkbook book;
            try
            {
                if (claimfile == null || claimfile.ContentLength == 0)
                return "Файл нулевого размера.";
                if (Path.GetExtension(claimfile.FileName) != ".xls" && Path.GetExtension(claimfile.FileName) != ".xlsx")
                {
                    return "Неверный тип файла. Поддерживаются только файлы с расширением XLS или XLSX.";
                }
                book = WorkbookFactory.Create(claimfile.InputStream);
                var sheet = book.GetSheetAt(0);
                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    var row = sheet.GetRow(rowNum);
                    try
                    {
                        Employee emp = new Employee();
                        //{

                        //};
                        emp.SurName = row.GetCell(0) != null ? row.GetCell(0).StringCellValue : String.Empty;
                        emp.FirstName = row.GetCell(1) != null ? row.GetCell(1).StringCellValue : String.Empty;
                        emp.MiddleName = row.GetCell(2) != null ? row.GetCell(2).StringCellValue : String.Empty;
                        emp.Position = row.GetCell(3) != null ? row.GetCell(3).StringCellValue : String.Empty;
                        emp.Gender = row.GetCell(4) != null ? row.GetCell(4).StringCellValue : String.Empty;
                        emp.Serial = row.GetCell(5) != null ? row.GetCell(5).StringCellValue : String.Empty;
                        emp.Code = row.GetCell(6) != null ? row.GetCell(6).StringCellValue : String.Empty;
                        emp.IssueDate = row.GetCell(7) != null ? (DateTime)row.GetCell(7).DateCellValue : new DateTime(1900, 1, 1);
                        emp.WhoIssued = row.GetCell(8) != null ? row.GetCell(8).StringCellValue : String.Empty;
                        emp.Registration = row.GetCell(9) != null ? row.GetCell(9).StringCellValue : String.Empty;
                        emp.CitizenShip = row.GetCell(10) != null ? row.GetCell(10).StringCellValue : String.Empty;
                        emp.BirthPlace = row.GetCell(11) != null ? row.GetCell(11).StringCellValue : String.Empty;
                        emp.HireDate = row.GetCell(12) != null ? (DateTime)row.GetCell(12).DateCellValue : new DateTime(1900, 1, 1);
                        emp.BirthDate = row.GetCell(13) != null ? (DateTime)row.GetCell(13).DateCellValue : new DateTime(1900, 1, 1);
                        emp.TerritoryService = row.GetCell(14) != null ? row.GetCell(14).StringCellValue : String.Empty;
                        try
                        {
                            Employee findEmp = db.Employees.Where(s => s.Serial == emp.Serial & s.Code == emp.Code).FirstOrDefault();
                            if (findEmp == null)
                            {
                                emp.AddedDate = DateTime.Now;
                                db.Employees.Add(emp);
                                Added++;
                            }
                            else
                            {
                                Existed++;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Elmah.Error error = new Elmah.Error(ex);
                return "";
            }
            return "Успешно добавлено " + Added.ToString() + " сотрудников" + " пропущено " + Existed.ToString() + " существующих";
        }

        public ActionResult Upload()
        {
            return View();
        }


        public FileResult Download()
        {
            try
            {
                string sql = @"select em.[Id] as [Номер]
                                      ,[SurName] as [Имя]
                                      ,[FirstName] as [Фамилия]
                                      ,[MiddleName] as [Отчество]
                                      ,case [Gender]  when 'Female' then 'Ж' when 'Male' then 'М' end as [Пол]
                                      ,[Serial] as [Серия паспорта]
                                      ,[Code] as [Код подразделения]
                                      ,[IssueDate] as [Дата выдачи паспорта]
                                      ,[WhoIssued] as [Кем выдан]
                                      ,[Registration] as [Регистрация]
                                      ,[CitizenShip] as [Гражданство]
                                      ,[BirthPlace] as [Место рождения]
                                      ,[HireDate] as [Дата приёма на работу]
                                      ,[BirthDate] as [Дата рождения]
                                      ,[TerritoryService] as [Территория обслуживания]
                                      ,[AddedDate] as [Дата создания]
                                      ,case [IsInnerClient]  when '1' then 'Внутренний' when '0' then 'Внешний' end as [Внешний/Внутренний]
									  ,[Position] as [Должность]
									  ,org.Inn as [Инн организации]
									  ,org.Title as [Название организации]
                                       FROM dbo.Employees em
									   left join dbo.OrganizationEmployees oemp on em.Id = oemp.Employee_Id
									   left join dbo.Organizations org on org.Id = oemp.Organization_Id";
                return CsvHelper.Export(sql);
            }
            catch (Exception ex)
            {
                return new FileContentResult(System.Text.Encoding.ASCII.GetBytes(ex.Message), "text/plain");
            }
        }
    }
}