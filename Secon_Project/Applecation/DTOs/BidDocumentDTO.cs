using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class BidDocumentDTO
    {
        public BidDocumentDTO() { }
        public int bidId { get; set; }
        //  company proposal details
        public string companyRegistrationCertificate { get; set; }
        public string taxComplianceCertificate { get; set; }
        public string financialStatementsLast_2Years { get; set; }

        //technical proposal details
        public string technicalApproachDescription { get; set; }
        public string methodologyDescription { get; set; }
        public string proposedSolution { get; set; }

       


    }
}
