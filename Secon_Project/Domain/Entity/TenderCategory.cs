using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class TenderCategory
    {
        [Key]
        public int tenderCategoryId { get; set; }
        public string categoryName { get; set; }
        public Tender tender { get; set; }
        public TenderCategory(string categoryName)
        {
            this.categoryName = categoryName;
        }
    }
}
