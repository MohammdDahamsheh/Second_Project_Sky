using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class FinancialProposalDTO
    {
        public FinancialProposalDTO() { }
        
        public string itemDescription { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public int bidDocumentId { get; set; }

    }
}
