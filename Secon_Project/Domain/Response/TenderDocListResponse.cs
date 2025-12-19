using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class TenderDocListResponse
    {
        public TenderDocListResponse() { }
        public int tenderDocumentId { get; set; }
        public string documentPath { get; set; }
        public string addBy { get; set; }
    }
}
