

using Domain.Entity;

namespace Applecation.DTOs
{
    public class TendersOpenDTO
    {

        public string tenderTitle { get; set; }
        public string tenderDescription { get; set; }
        //public int? userId { get; set; }
        //public Users? user { get; set; }

        public string userName { get; set; }
        public string userEmail { get; set; }
        public string phoneNumber { get; set; }

        public DateOnly issueDate { get; set; }
        public DateOnly closingDate { get; set; }
        public double budget { get; set; }


        //public TenderType tenderType { get; set; }
        public string tenderTypeName { get; set; }

        public List<byte[]>? tenderDocumentsPath { get;  set; }= new List<byte[]>();
        //public int tenderCategoryId { get; set; }
        //public TenderCategory tenderCategory { get; set; }
        public string tenderCategoryName { get; set; }

        public TendersOpenDTO() {

        }



    }
}
