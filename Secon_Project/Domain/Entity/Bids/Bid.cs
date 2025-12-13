using Domain.Entity.Evaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Domain.Entity.Bids
{
    public class Bid
    {
        [Key]
        public int bidId { get; set; }
        public int tenderId { get; set; }
        public Tender tender { get; set; }
        public int userId { get; set; }
        public Users user { get; set; }
        public string CompanyName { get; set; }
        public string address { get; set; }
        public decimal totalBidAmount { get; set; }

        public PaymentTerms paymentTerms { get; set; }
        public int paymentTermsId { get; set; }

        //public int bidDocumentId { get; set; }
        public BidDocument bidDocument { get; private set; }

        public WinBid winBid { get; set; }
        public Declaretion  declaretion { get; set; }
        public Bid()
        {
        }


    }
}
