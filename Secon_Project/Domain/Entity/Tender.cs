
using Domain.Entity.Bids;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Tender
    {
        [Key]
        public int tenderId { get; set; }
        public string tenderTitle { get; set; }
        public string tenderDescription { get; set; }
        public int userId { get; set; }
        public Users user { get; set; }

        public DateOnly issueDate { get; set; }
        public DateOnly closingDate { get; set; }
        public double budget { get; set; }


        public int tenderTypeId { get; set; }
        public TenderType tenderType { get; set; }

        public ICollection<TenderDocument>? tenderDocuments { get; private set; }
        public int tenderCategoryId { get; set; }
        public TenderCategory tenderCategory { get; set; }
        public IEnumerable<Bid> bids { get; set; }
        public ICollection<EligibilityCriteria> eligibilityCriterias { get; set; }



        public Tender()
        {
        }

        public Tender(string tenderTitle, int userId, DateOnly issueDate, DateOnly closingDate, int tenderTypeId, int tenderCategoryId)
        {
            this.tenderTitle = tenderTitle;
           this.issueDate = issueDate;
            this.userId = userId;
            this.closingDate = closingDate;
            this.tenderTypeId = tenderTypeId;
            this.tenderCategoryId = tenderCategoryId;
        }

        public Tender(
            string tenderTitle,
            string tenderDescription,
            DateOnly issueDate,
            DateOnly closingDate,
            double budget,
            int tenderTypeId,
            int tenderCategoryId
            )
        {
            this.tenderTitle = tenderTitle;
            this.tenderDescription = tenderDescription;
            this.issueDate = issueDate;
            this.closingDate = closingDate;
            this.budget = budget;
            this.tenderTypeId = tenderTypeId;
            this.tenderCategoryId = tenderCategoryId;
        }
        
        public void AddTenderDocument(TenderDocument document)
        {
            if (tenderDocuments == null)
            {
                tenderDocuments = new List<TenderDocument>();
            }
            tenderDocuments.Add(document);
        }
        public void AddEligibilityCriteria(EligibilityCriteria criteria)
        {
            if (eligibilityCriterias == null)
            {
                eligibilityCriterias = new List<EligibilityCriteria>();
            }
            eligibilityCriterias.Add(criteria);
        }

    }
}
