using StaffApplication2.Common;
using StaffApplication2.DTOs;

namespace StaffApplication2.Services
{
    public interface IEmployeeService
    {
        Task<BaseResponse> CreateEmployee(CreateEmployee request);

        Task<BaseResponse> UpdateEmployee(UpdateEmployee request);

        Task<BaseResponse> DeleteEmployee(DeleteEmployee request);

        Task<BaseResponse> FindEmployee(string Email);

        Task<BaseResponse> FindEmployee(long userId);

        Task<BaseResponse> GetAllEmployee();

        Task<BaseResponse> GetAllActiveEmployee();
    }
}
