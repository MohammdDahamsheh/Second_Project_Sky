using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class TenderDocument
    {
        [Key]
        public int tenderDocumentId { get; set; }
        public int tenderId { get; set; }
        public Tender tender { get; set; }

        public string documentPath { get; set; }
        public string addBy { get; set; }
        public TenderDocument(int tenderId, string documentPath, string addBy)
        {
            this.tenderId = tenderId;
            this.documentPath = documentPath;
            this.addBy = addBy;
        }
    }
}
