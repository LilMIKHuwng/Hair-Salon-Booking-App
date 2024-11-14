using AutoMapper;
using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core.Base;
using HairSalon.ModelViews.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HairSalon.Core;

namespace HairSalon.Services.Service
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        // Constructor injection of dependencies
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        // Method to add a new message
        public async Task<string> AddMessageAsync(CreateMessageViewModel model)
        {
            try
            {
                // Map CreateMessageViewModel to Message entity
                Message newMessage = _mapper.Map<Message>(model);

                // Assign unique ID and metadata
                newMessage.Id = Guid.NewGuid().ToString("N");
                newMessage.SenderId = model.SenderId;

                // Insert the message and save changes
                await _unitOfWork.GetRepository<Message>().InsertAsync(newMessage);
                await _unitOfWork.SaveAsync();

                return "Message added successfully!";
            }
            catch (BaseException.BadRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred while adding the message." + ex.Message;
            }
        }

        public async Task<BasePaginatedList<MessageViewModel>> GetAllMessageAsync(int pageNumber, int pageSize)
        {
            var messageQuery = _unitOfWork.GetRepository<Message>().Entities; 
            messageQuery = messageQuery.OrderByDescending(s => s.CreatedTime);
            int totalCount = await messageQuery.CountAsync();

            List<Message> paginatedShops = await messageQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<MessageViewModel> messageModelViews = _mapper.Map<List<MessageViewModel>>(paginatedShops);
            return new BasePaginatedList<MessageViewModel>(messageModelViews, totalCount, pageNumber, pageSize);
        }

        // Method to retrieve a message by its ID
        public async Task<MessageViewModel> GetMessageByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString()))
                {
                    throw new BaseException.BadRequestException("404", "Please provide a valid Message ID.");
                }

                // Retrieve the existing message
                Message existingMessage = await _unitOfWork.GetRepository<Message>().Entities
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (existingMessage == null)
                {
                    throw new BaseException.BadRequestException("404", "The message cannot be found!");
                }

                // Map the entity to the view model
                MessageViewModel messageViewModel = _mapper.Map<MessageViewModel>(existingMessage);
                return messageViewModel;
            }
            catch (BaseException.BadRequestException ex)
            {
                throw ex; // Rethrow known exception to handle it higher up the stack if necessary
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the message.", ex);
            }
        }
    }

}
