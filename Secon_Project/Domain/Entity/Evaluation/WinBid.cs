using Domain.Entity.Bids;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Evaluation
{
    public class WinBid
    {
        [Key]
        public int winBidId{get;set;}
        public int bidId { get; set; }
        public Bid bid { get; set; }
        public DateOnly awardedDate { get; set; }
        public int tenderId { get; set; }
        public Tender tender { get; set; }
        public string comments { get; set; }
        public WinBid()
        {
        }




    }
}
