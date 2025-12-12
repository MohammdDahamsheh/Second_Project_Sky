using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bids
{
    public class PaymentTerms
    {
        public PaymentTerms() { }
        [Key]
        public int paymentTermsId { get; set; }
        public string termMethod { get; set; }
        public string PenaltiesForDelays { get; set; }

        public Bid bid { get; set; }
    }
}
