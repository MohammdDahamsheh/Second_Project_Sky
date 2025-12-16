using Domain.Entity;
using Domain.Entity.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class WinBidResponse
    {
        public WinBidResponse() { }
        public int winBidId { get; set; }
        public int bidId { get; set; }
        public DateOnly awardedDate { get; set; }
        public int tenderId { get; set; }
        public string comments { get; set; }
    }
}
