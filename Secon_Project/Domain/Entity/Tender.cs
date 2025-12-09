using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Tender
    {
        [Key]
        public int tenderId { get; set; }
        public string tenderTitle { get; set; }
        public string? tenderDescription { get; set; }
        public int userId { get; set; }
        public Users user { get; set; }

        public DateOnly issueDate { get; set; }
        public DateOnly closingDate { get; set; }
        public double budget { get; set; }


        public int tenderTypeId { get; set; }
        public TenderType tenderType { get; set; }

        public ICollection<TenderDocument> tenderDocuments { get; private set; }
        public int tenderCategoryId { get; set; }
        public TenderCategory tenderCategory { get; set; }
        public Tender(string tenderTitle, int userId, DateOnly issueDate, DateOnly closingDate, int tenderTypeId, int tenderCategoryId)
        {
            this.tenderTitle = tenderTitle;
           this.issueDate = issueDate;
            this.userId = userId;
            this.closingDate = closingDate;
            this.tenderTypeId = tenderTypeId;
            this.tenderCategoryId = tenderCategoryId;
        }
        public void AddTenderDocument(TenderDocument document)
        {
            tenderDocuments.Add(document);
        }


    }
}
