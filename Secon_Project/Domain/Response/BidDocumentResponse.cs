using Domain.Entity.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class BidDocumentResponse
    {
        public int bidDocumentId { get; set; }
        public int bidId { get; set; }
        public int technicalProposalId { get; set; }
        public string companyRegistrationCertificate { get; set; }
        public string taxComplianceCertificate { get; set; }
        public string financialStatementsLast_2Years { get; set; }

        public BidDocumentResponse() { }
    }
}
