using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bids
{
    public class Declaretion
    {
        public Declaretion()
        {
        }
        [Key]
        public int declaretionId { get; set; }
        public string declarationText { get; set; }
        public int bidId { get; set; }
        public Bid bid { get; set; }
    }
}
