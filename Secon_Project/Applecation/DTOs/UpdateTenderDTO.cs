using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs
{
    public class UpdateTenderDTO
    {
        public int tenderId { get; set; }
        public int tenderCategoryId { get; set; }
        public int tenderTypeId { get; set; }
        public DateOnly closingDate { get; set; }
        public string tenderTitle { get; set; }
        public string tenderDescription { get; set; }
        public double budget { get; set; }

        public UpdateTenderDTO() { }

    }
}
