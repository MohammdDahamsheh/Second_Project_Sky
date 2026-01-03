using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bids
{
    public class TechnicalProposal
    {
        [Key]
        public int TechnicalProposalId { get; set; }
        //public string technicalApproachDescription { get; set; }
        //public string methodologyDescription { get; set; }
        //public string proposedSolution { get; set; }
        public byte[] technicalProposalDocument { get; set; }

        public BidDocument bidDocument { get; set; }

        public TechnicalProposal()
        {
        }
    }
}
