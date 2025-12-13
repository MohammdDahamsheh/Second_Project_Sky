using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bids
{
    public class FinancialProposal
    {
        public FinancialProposal()
        {
        }
        [Key]
        public int financialProposalId { get; set; }
        public string itemDescription { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }

        public int bidDocumentId { get; set; }
        public BidDocument bidDocument { get; set; }


    }
}
