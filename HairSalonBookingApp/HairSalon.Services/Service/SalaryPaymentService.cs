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

            int totalCount = await salaryPaymentQuery.CountAsync();

            List<SalaryPayment> paginatedSalaryPayment = await salaryPaymentQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<SalaryPaymentModelView> salaryPaymentModelViews = _mapper.Map<List<SalaryPaymentModelView>>(paginatedSalaryPayment); ;

            return new BasePaginatedList<SalaryPaymentModelView>(salaryPaymentModelViews, totalCount, pageNumber, pageSize);
        }

		public async Task<SalaryPaymentModelView> AddSalaryPaymentAsync(CreateSalaryPaymentModelView model)
		{
			if (string.IsNullOrWhiteSpace(model.UserId))
			{
				throw new Exception("User ID cannot be empty.");
			}

			SalaryPayment newSalaryPayment = _mapper.Map<SalaryPayment>(model);

			newSalaryPayment.Id = Guid.NewGuid().ToString("N");
			newSalaryPayment.CreatedBy = "claim account";
			newSalaryPayment.CreatedTime = DateTimeOffset.UtcNow;
			newSalaryPayment.LastUpdatedTime = DateTimeOffset.UtcNow;

			await _unitOfWork.GetRepository<SalaryPayment>().InsertAsync(newSalaryPayment);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<SalaryPaymentModelView>(newSalaryPayment);
		}

		public async Task<SalaryPaymentModelView> UpdateSalaryPaymentAsync(string id, UpdatedSalaryPaymentModelView model)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Salary Payment ID.");
			}

			SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The Salary Payment cannot be found or has been deleted!");

			_mapper.Map(model, existingSalary);

			// Set additional properties
			existingSalary.LastUpdatedBy = "claim account";
			existingSalary.LastUpdatedTime = DateTimeOffset.UtcNow;

			_unitOfWork.GetRepository<SalaryPayment>().Update(existingSalary);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<SalaryPaymentModelView>(existingSalary);
		}

		public async Task<string> DeleteSalaryPaymentAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Salary Payment ID.");
			}

			SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The Salary Payment cannot be found or has been deleted!");

			existingSalary.DeletedTime = DateTimeOffset.UtcNow;
			existingSalary.DeletedBy = "claim account";

			_unitOfWork.GetRepository<SalaryPayment>().Update(existingSalary);
			await _unitOfWork.SaveAsync();
			return "Deleted";
		}

		public async Task<SalaryPaymentModelView> GetSalaryPaymentAsync(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new Exception("Please provide a valid Salary Payment ID.");
			}

			SalaryPayment existingSalary = await _unitOfWork.GetRepository<SalaryPayment>().Entities
				.FirstOrDefaultAsync(s => s.Id == id && !s.DeletedTime.HasValue)
				?? throw new Exception("The Salary Payment cannot be found or has been deleted!");

			return _mapper.Map<SalaryPaymentModelView>(existingSalary);
		}
	}
}
