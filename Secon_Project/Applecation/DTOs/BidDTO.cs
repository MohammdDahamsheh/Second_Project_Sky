using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class BidDTO
    {
        public BidDTO() { }
        public int tenderId { get; set; }
        public string CompanyName { get; set; }
        public string address { get; set; }
        public decimal totalBidAmount { get; set; }



        // Payment Terms Details
        public string PenaltiesForDelays { get; set; }
        public string termMethod { get; set; }
        public string PaymentScheduleAdvance { get; set; }
        public string PaymentScheduleUponMilestoneCompletion { get; set; }
        public string PaymentScheduleAdvanceFinalApproval { get; set; }




    }
}
