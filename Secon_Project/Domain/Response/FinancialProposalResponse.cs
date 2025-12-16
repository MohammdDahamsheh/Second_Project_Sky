using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class FinancialProposalResponse
    {
        public FinancialProposalResponse()
        {
        }
        public int FinancialProposalId { get; set; }
        public string itemDescription { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal total { get; set; }
        public int bidDocumentId { get; set; }

    }
}
