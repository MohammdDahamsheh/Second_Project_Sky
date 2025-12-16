using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity;
using Domain.Response;
using Infrastrucure;
using Microsoft.EntityFrameworkCore;


namespace Applecation.Service
{
    public class TenderService
    {
        private readonly TenderContext context;

        private readonly IUnitOfWork<Tender> tenderUnitOfWork;
        private readonly IUnitOfWork<Users> userUnitOfWork;
        private readonly IUnitOfWork<TenderType> typeUnitOfWork;
        private readonly IUnitOfWork<TenderCategory> categoryUnitOfWork;

        public TenderService(IUnitOfWork<Tender> tenderUnitOfWork,TenderContext context, IUnitOfWork<Users> userUnitOfWork) 
        { this.tenderUnitOfWork = tenderUnitOfWork;
            this.context = context;
            this.userUnitOfWork = userUnitOfWork;
        }
        public async Task<IEnumerable<TenderResponse>> GetAllTenders()
        {
            //To check if tenders exist:
            var tenders = await tenderUnitOfWork.GetRepository.GetAllAsync();

            var result = new List<TenderResponse>();
            foreach (var tenderResponse in tenders) { 
                var tender = await (from u in context.Users
                                    join t in context.tenders
                                    on u.userId equals tenderResponse.userId
                                    join tt in context.tenderTypes
                                    on tenderResponse.tenderTypeId equals tt.tenderTypeId
                                    join tc in context.tenderCategories
                                    on tenderResponse.tenderCategoryId equals tc.tenderCategoryId
                                    where tenderResponse.tenderId == t.tenderId
                                    select new TenderResponse
                                    {
                                        tenderId = t.tenderId,
                                        tenderTitle = t.tenderTitle,
                                        tenderDescription = t.tenderDescription,
                                        username = u.userName,
                                        issueDate = t.issueDate,
                                        closingDate = t.closingDate,
                                        budget = t.budget,
                                        tenderType = tt.typeName,
                                        tenderCategory = tc.categoryName
                                    }).FirstAsync();
                result.Add(tender);

            }




            return result;
        }
        public async Task<TenderResponse> GetTenderById(int id)
        {
            //To check if tender exists:
            var tender = await tenderUnitOfWork.GetRepository.GetByIdAsync(id);
          

            var result = await (from u in context.Users
                                join t in context.tenders
                                on u.userId equals t.userId
                                join tt in context.tenderTypes
                                on t.tenderTypeId equals tt.tenderTypeId
                                join tc in context.tenderCategories
                                on t.tenderCategoryId equals tc.tenderCategoryId
                                where t.tenderId == id
                                select new TenderResponse
                                {
                                    tenderId = t.tenderId,
                                    tenderTitle = t.tenderTitle,
                                    tenderDescription = t.tenderDescription,
                                    username = u.userName,
                                    issueDate = t.issueDate,
                                    closingDate = t.closingDate,
                                    budget = t.budget,
                                    tenderType = tt.typeName,
                                    tenderCategory = tc.categoryName

                                }).FirstOrDefaultAsync();
            if(result == null) 
            {
                throw new Exception("Tender not found");
            }

          


            return result;
        }
        public async Task<bool> AddTender(TenderDTO tender)
        {
            var tenderEntity = new Tender
            {
                tenderCategoryId = tender.tenderCategoryId,
                tenderTypeId = tender.tenderTypeId,
                closingDate = tender.closingDate,
                tenderTitle = tender.tenderTitle,
                tenderDescription = tender.tenderDescription,
                issueDate = DateOnly.FromDateTime(DateTime.Now),
                budget = tender.budget
                //userId = 1 

            };
            var result = await tenderUnitOfWork.GetRepository.AddAsync(tenderEntity);
            if (result)
            {
                await tenderUnitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTender(UpdateTenderDTO tender)
        {
            var existingTender = await tenderUnitOfWork.GetRepository.GetByIdAsync(tender.tenderId);

            existingTender.tenderCategoryId = tender.tenderCategoryId;
            existingTender.tenderTypeId = tender.tenderTypeId;
            existingTender.closingDate = tender.closingDate;
            existingTender.tenderTitle = tender.tenderTitle;
            existingTender.tenderDescription = tender.tenderDescription;
            existingTender.budget = tender.budget;

            var result =  tenderUnitOfWork.GetRepository.UpdateAsync(existingTender);
            if (result)
            {
                await tenderUnitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> addTenderDocument(TenderDocumentDTO tenderDocumentDTO) {
           
            var tender=await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderDocumentDTO.tenderId);
            var username = (from u in userUnitOfWork.GetRepository.GetAllAsync().Result
                            where u.userId == tender.userId
                            select u.userName).FirstOrDefault();
                            
            var tenderDocument = new TenderDocument(
                tenderDocumentDTO.tenderId,
                tenderDocumentDTO.documentPath,
                username!
                );
            tender.AddTenderDocument(tenderDocument);
            await tenderUnitOfWork.SaveChangesAsync();

            return true;

        }
        public async Task<IEnumerable<TendersOpenDTO>> getOpenTenders() {
            var allTenders = await (from t in context.tenders
                                    join type in context.tenderTypes
                                    on t.tenderTypeId equals type.tenderTypeId
                                    //join doc in context.tenderDocuments
                                    //on t.tenderId equals doc.tenderId 
                                    where type.typeName == "Open"
                                    select new TendersOpenDTO {
                                        budget = t.budget,
                                        closingDate = t.closingDate,
                                        issueDate = t.issueDate,
                                        tenderCategoryName = t.tenderCategory.categoryName,
                                        tenderDescription = t.tenderDescription,
                                        tenderTitle = t.tenderTitle,
                                        tenderTypeName = type.typeName,
                                        userName = t.user.userName,
                                        tenderDocumentsPath = (
                                        from doc in t.tenderDocuments
                                        where doc.tenderId == t.tenderId
                                        select doc.documentPath

                                        ).ToList(),
                                        phoneNumber = t.user.phoneNumber,
                                        userEmail = t.user.email
                                    }
                                    ).ToListAsync();
            if (allTenders == null || allTenders.Count == 0) {
                throw new Exception("No open tenders found");
            }
            return allTenders;



        }
        public async Task<EligibilityCriteriaDTO> AddEligibilityCriteria(EligibilityCriteriaDTO eligibilityCriteriaDTO) {
              
            var tender = await tenderUnitOfWork.GetRepository.GetByIdAsync(eligibilityCriteriaDTO.tenderId);
            
            var eligibilityCriteria = new EligibilityCriteria
            (
                 eligibilityCriteriaDTO.CriteriaDescription,
                 eligibilityCriteriaDTO.tenderId
            );
            tender.AddEligibilityCriteria(eligibilityCriteria);
            await context.SaveChangesAsync();

            return eligibilityCriteriaDTO;
        }

        public async Task<IEnumerable<EligibilityCriteriaResponse>> getEligibilityCriterias(int tenderId)
        {
            var eligibilityCriterias = await(from ec in context.EligibilityCriterias
                                             where ec.tenderId == tenderId
                                             select new EligibilityCriteriaResponse
                                             {
                                                 EligibilityCriteriaId = ec.EligibilityCriteriaId,
                                                 CriteriaDescription = ec.CriteriaDescription
                                             }
                                             ).ToListAsync();
            if (eligibilityCriterias == null || eligibilityCriterias.Count == 0) { 
            throw new Exception("No eligibility criteria found for this tender");

            }
            return eligibilityCriterias;

        }
    }
}
