using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class TenderType
    {
        [Key]
        public int tenderTypeId{ get; set; }
        public string typeName { get; set; }
        public Tender tender { get; set; }

        public TenderType(string typeName) {
        this.typeName = typeName;
        }

    }
}
