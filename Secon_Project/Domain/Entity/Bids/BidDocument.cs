using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bids
{
    public class BidDocument
    {
        public BidDocument()
        {
        }
        public int bidDocumentId { get; set; }
        public int bidId { get; set; }
        public Bid bid { get; set; }
        public string documentPath { get; set; }

    }
}
