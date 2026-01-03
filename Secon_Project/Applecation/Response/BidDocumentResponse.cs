using Domain.Entity.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Response
{
    public class BidDocumentResponse
    {
        public int bidDocumentId { get; set; }
        public int bidId { get; set; }
        public int technicalProposalId { get; set; }
        public byte[] companyRegistrationCertificate { get; set; }
        public byte[] taxComplianceCertificate { get; set; }
        public byte[] financialStatementsLast_2Years { get; set; }

        public BidDocumentResponse() { }
    }
}
