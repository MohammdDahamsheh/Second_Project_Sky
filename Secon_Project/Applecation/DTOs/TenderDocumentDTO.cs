using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class TenderDocumentDTO
    {
        public int tenderId { get; set; }
        public string documentPath { get; set; }
        //public string addBy { get; set; }
        public TenderDocumentDTO(
            string documentPath
            )
        {
            this.documentPath = documentPath;
            //this.addBy = addBy;
        }
    }
}
