using Hms.Application.Models.Identity;
using Hms.Application.Models;
using Hms.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Application.DTOs.Common;
using Hms.Application.DTOs.UserManage.User;

namespace Hms.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<BaseCommandResponse> UpdateUserPassword(string userId, PasswordChangeDto userDto);
        Task<Employee> GetEmployeeByUserId(string userId);
        Task<Employee> GetEmployee(string userId);
        Task<PagedResult<UserDto>> GetUsers(QueryParams queryParams);
        Task<BaseCommandResponse> Save(string userId, CreateUserDto user);
        Task<BaseCommandResponse> UpdateUser(string userId, UpdateEmailPhoneDto user);
        Task<BaseCommandResponse> ResetPassword(string userId, CreateUserDto user);
        Task<UserDto> GetUserById(string id);
        Task<BaseCommandResponse> DeleteUser(string id);
        //Task<PagedResult<UserDto>> GetStudentUsers(QueryParams queryParams);
        Task<PagedResult<UserDto>> GetTeacherUsers(QueryParams queryParams);
    }
}
