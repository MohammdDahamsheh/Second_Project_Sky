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
        public int technicalProposalId { get; set; }
        public TechnicalProposal technicalProposal { get; set; }
        public ICollection<FinancialProposal> financialProposal { get; private set; }
        public byte[] companyRegistrationCertificate { get; set; }
        public byte[] taxComplianceCertificate { get; set; }
        public byte[] financialStatementsLast_2Years { get; set; }

        public void addFinancialProposal(FinancialProposal financialProposal)
        {
            if (this.financialProposal == null)
            {
                this.financialProposal = new List<FinancialProposal>();
            }
            this.financialProposal.Add(financialProposal);
        }


    }
}
