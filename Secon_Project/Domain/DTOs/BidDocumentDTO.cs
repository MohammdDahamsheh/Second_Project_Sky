using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class BidDocumentDTO
    {
        public BidDocumentDTO() { }
        public int bidId { get; set; }
        public string documentPath { get; set; }
    }
}
