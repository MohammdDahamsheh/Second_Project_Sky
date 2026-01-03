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

        public byte[] documentFile { get; set; }
        public string addBy { get; set; }
        public TenderDocument(int tenderId, byte[] documentFile, string addBy)
        {
            this.tenderId = tenderId;
            this.documentFile = documentFile;
            this.addBy = addBy;
        }
    }
}
