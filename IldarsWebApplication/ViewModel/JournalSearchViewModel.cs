using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IldarsWebApplication.ViewModel
{
    public class JournalSearchViewModel
    {
        public string FullName { get; set; }

        public DateTime? AddedDate { get; set; }
        public string SecurityDateStatus { get; set; }
        public string AdmissionDateStatus { get; set; }
        public string LetterReceivedDateStatus { get; set; }
    }
}