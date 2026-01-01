using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Response
{
    public class TenderResponse
    {
        public TenderResponse() { }

        public int tenderId { get; set; }
        public string tenderTitle { get; set; }
        public string tenderDescription { get; set; }
        public string username { get; set; }

        public DateOnly issueDate { get; set; }
        public DateOnly closingDate { get; set; }
        public double budget { get; set; }

        public string tenderType { get; set; }
        public string tenderCategory { get; set; }
    }
}
