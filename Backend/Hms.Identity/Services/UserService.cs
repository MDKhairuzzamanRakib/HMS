using Hms.Application.Contracts.Identity;
using Hms.Application.DTOs.Common;
using Hms.Application.Models.Identity;
using Hms.Application.Models;
using Hms.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms.Application.DTOs.UserManage.User;

namespace Hms.Identity.Services
{
    public class UserService : IUserService
    {
        public Task<BaseCommandResponse> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UserDto>> GetTeacherUsers(QueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UserDto>> GetUsers(QueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommandResponse> ResetPassword(string userId, CreateUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommandResponse> Save(string userId, CreateUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommandResponse> UpdateUser(string userId, UpdateEmailPhoneDto user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommandResponse> UpdateUserPassword(string userId, PasswordChangeDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
