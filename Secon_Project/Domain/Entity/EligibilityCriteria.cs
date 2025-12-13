using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class EligibilityCriteria
    {
        [Key]
        public int EligibilityCriteriaId { get; set; }
       public string CriteriaDescription { get; set; }
        public int tenderId { get; set; }
        public Tender tender { get; set; }

        public EligibilityCriteria(string criteriaDescription, int tenderId)
        {
            CriteriaDescription = criteriaDescription;
            this.tenderId = tenderId;
        }
    }
}
