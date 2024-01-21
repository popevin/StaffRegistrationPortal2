using StaffApplication2.DTOs;
using StaffApplication2.Common;

namespace StaffApplication2.Services
{
    public interface IUserService
    {
        Task<BaseResponse> CreateUser(CreateUser request);

        Task<BaseResponse> UpdateUser(UpdateUser request);

        Task<BaseResponse> LogInUser(EmailandPassword request);

        Task<BaseResponse> LogOutUser(EmailandPassword request);

        Task<BaseResponse> DeActivate(DeactivateUser request);

        Task<BaseResponse> ReActivate(ReactivateUser request);

        Task<BaseResponse> FindUser(string userEmail);

        Task<BaseResponse> FindUser(long userId);

        Task<BaseResponse> GetAllUsers();

        Task<BaseResponse> GetAllActiveUsers();
    }
}
