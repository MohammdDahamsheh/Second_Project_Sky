using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class TenderDTO
    {
        public int tenderCategoryId { get; set; }
        public int tenderTypeId { get; set; }
        public DateOnly closingDate { get; set; }
        public string tenderTitle { get; set; }
        public string tenderDescription { get; set; }
        public double budget { get; set; }


        public TenderDTO(
            int tenderCategoryId,
            int tenderTypeId,
            DateOnly closingDate,
            string tenderTitle,
            string tenderDescription,
            double budget

            )
        {
            this.tenderCategoryId = tenderCategoryId;
            this.tenderTypeId = tenderTypeId;
            this.closingDate = closingDate;
            this.tenderTitle = tenderTitle;
            this.tenderDescription = tenderDescription;
            this.budget = budget;
        }
    }
}
