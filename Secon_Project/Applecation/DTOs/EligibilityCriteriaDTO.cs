using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class EligibilityCriteriaDTO
    {
        public EligibilityCriteriaDTO() { }
        public string CriteriaDescription { get; set; }
        public int tenderId { get; set; }

        public EligibilityCriteriaDTO(string criteriaDescription, int tenderId)
        {
            CriteriaDescription = criteriaDescription;
            this.tenderId = tenderId;
        }
    }
}
