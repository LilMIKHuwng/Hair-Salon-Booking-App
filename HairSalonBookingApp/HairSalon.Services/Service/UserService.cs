﻿using XuongMay.Contract.Repositories.Interface;
using XuongMay.Contract.Services.Interface;
using XuongMay.ModelViews.UserModelViews;

namespace XuongMay.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IList<UserResponseModel>> GetAll()
        {
            IList<UserResponseModel> users = new List<UserResponseModel>
            {
                new UserResponseModel { Id = "1" },
                new UserResponseModel { Id = "2" },
                new UserResponseModel { Id = "3" }
            };

            return Task.FromResult(users);
        }
    }
}
