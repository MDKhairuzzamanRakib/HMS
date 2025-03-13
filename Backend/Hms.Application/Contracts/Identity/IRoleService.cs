using Hms.Application.DTOs.AspNetRoles;
using Hms.Application.Responses;
using Hms.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Contracts.Identity
{
    public interface IRoleService
    {
        //Task<List<Employee>> GetEmployees();
        //Task<Employee> GetEmployee(string userId);
        //Task<PagedResult<UserDto>> GetUsers(QueryParams queryParams);
        //Task<BaseCommandResponse> Save(CreateUserDto user);
        Task<BaseCommandResponse> Save(AspNetRolesDto model);
        Task<BaseCommandResponse> Update(AspNetRolesDto model);
        Task<BaseCommandResponse> Delete(string Id);
        Task<object> Get();
        Task<object> GetById(string Id);
        Task<List<SelectedModel>> GetSelectedRoleList();
        Task<List<SelectedModel>> GetSelectedAllRoleList();
        Task<List<SelectedModel>> GetSelectedRoleForTraineeList();
    }
}
