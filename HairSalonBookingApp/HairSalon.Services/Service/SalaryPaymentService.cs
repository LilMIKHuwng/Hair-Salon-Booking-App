using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.SalaryPaymentModelViews;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Services.Service
{
    public class SalaryPaymentService : ISalaryPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalaryPaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BasePaginatedList<SalaryPaymentModelView>> GetAllSalaryPaymentAsync(int pageNumber, int pageSize)
        {
            IQueryable<SalaryPayment> salaryPaymentQuery = _unitOfWork.GetRepository<SalaryPayment>().Entities
                                                        .Where(p => !p.DeletedTime.HasValue)
                                                        .OrderByDescending(s => s.CreatedTime);

            // Count the total number of matching records
            int totalCount = await salaryPaymentQuery.CountAsync();

            // Apply pagination
            List<SalaryPayment> paginatedSalaryPayment = await salaryPaymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to RoleModelView
            List<SalaryPaymentModelView> salaryPaymentModelViews = _mapper.Map<List<SalaryPaymentModelView>>(paginatedSalaryPayment); ;

            return new BasePaginatedList<SalaryPaymentModelView>(salaryPaymentModelViews, totalCount, pageNumber, pageSize);
        }

        public async Task<SalaryPaymentModelView> AddSalaryPaymentAsync(CreateSalaryPaymentModelView model, string createdBy, string lastUpdatedBy)
        {
            IGenericRepository<SalaryPayment> salaryPaymentRepository = _unitOfWork.GetRepository<SalaryPayment>();
            IGenericRepository<User> userRepository = _unitOfWork.GetRepository<User>();
            User existedUser = await userRepository.GetByIdAsync(model.UserId);

            if (existedUser == null)
            {
                throw new Exception("User not found.");
            }

            SalaryPayment newSalary = _mapper.Map<SalaryPayment>(model);

            //Tracking create
            newSalary.CreatedBy = createdBy;
            newSalary.LastUpdatedBy = lastUpdatedBy;

            //Insert new role to DB
            await _unitOfWork.GetRepository<SalaryPayment>().InsertAsync(newSalary);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<SalaryPaymentModelView>(newSalary);
        }

        public async Task<string> DeleteSalaryPaymentAsync(string id, string deletedBy)
        {
            IGenericRepository<SalaryPayment> salaryPaymentRepository = _unitOfWork.GetRepository<SalaryPayment>();

            SalaryPayment deleteRole = await salaryPaymentRepository.Entities
                                        .FirstOrDefaultAsync(role => role.Id == id && !role.DeletedTime.HasValue)
                                        ?? throw new Exception("The Role cannot be found or has been deleted!");

            //Tracking delete
            deleteRole.DeletedBy = deletedBy;
            deleteRole.LastUpdatedBy = deletedBy;
            deleteRole.DeletedTime = DateTime.UtcNow;

            //Update role for delete
            salaryPaymentRepository.Update(deleteRole);
            await _unitOfWork.SaveAsync();

            return "Delete";
        }


        public async Task<SalaryPaymentModelView> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model, string lastUpdatedBy)
        {
            IGenericRepository<SalaryPayment> salaryPaymentRepository = _unitOfWork.GetRepository<SalaryPayment>();

            SalaryPayment updateSalaryPayment = await salaryPaymentRepository.Entities
                                        .FirstOrDefaultAsync(role => role.Id == id && !role.DeletedTime.HasValue)
                                        ?? throw new Exception("The Role cannot be found or has been deleted!");

            _mapper.Map(model, updateSalaryPayment);

            //Tracking update
            updateSalaryPayment.LastUpdatedBy = lastUpdatedBy;
            updateSalaryPayment.LastUpdatedTime = DateTime.UtcNow;

            //Update role
            await salaryPaymentRepository.UpdateAsync(updateSalaryPayment);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<SalaryPaymentModelView>(updateSalaryPayment);
        }
    }
}
