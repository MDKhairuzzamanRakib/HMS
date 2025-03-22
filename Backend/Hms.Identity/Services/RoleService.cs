using Hms.Application.Contracts.Identity;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.UserManage.AspNetRoles;
using Hms.Application.Models.Identity;
using Hms.Application.Responses;
using Hms.Domain.UserManage;
using Hms.Identity.Models;
using Hms.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Identity.Services
{
    public class RoleService : IRoleService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHmsRepository<AspNetUsers> _aspNetUserRepository;
        private readonly IHmsRepository<AspNetUserRoles> _aspNetUserRolesRepository;
        private readonly IHmsRepository<AspNetRoles> _aspNetRolesRepository;
        private readonly JwtSettings _jwtSettings;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
        IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager, IHmsRepository<AspNetUsers> aspNetUserRepository, IHmsRepository<AspNetUserRoles> aspNetUserRolesRepository, IHmsRepository<AspNetRoles> aspNetRolesRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _aspNetUserRepository = aspNetUserRepository;
            _aspNetUserRolesRepository = aspNetUserRolesRepository;
            _aspNetRolesRepository = aspNetRolesRepository;
        }

        public Task<List<SelectedModel>> GetSelectedAllRoleList()
        {
            throw new NotImplementedException();
        }

        public Task<List<SelectedModel>> GetSelectedRoleForTraineeList()
        {
            throw new NotImplementedException();
        }

        public Task<List<SelectedModel>> GetSelectedRoleList()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseCommandResponse> Save(AspNetRolesDto request)
        {
            var response = new BaseCommandResponse();

            var role = new ApplicationRole
            {
                Name = request.Name
            };

            var existingRole = await _roleManager.FindByNameAsync(request.Name);

            if (existingRole != null)
            {
                response.Success = false;
                response.Message = $"Creation Failed, RoleName '{request.Name}' already Exists.";
            }

            else
            {
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Message = $"Creation Successfull, RoleName : '{request.Name}'.";
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Creation Failed! '{result.Errors}'";
                }
            }

            return response;
            //throw new NotImplementedException();

        }

        public async Task<BaseCommandResponse> Update(AspNetRolesDto request)
        {
            var response = new BaseCommandResponse();

            var roles = await _roleManager.FindByIdAsync(request.Id);

            if (roles == null)
            {
                response.Success = false;
                response.Message = $"Update Failed, Role Not Found.";
            }

            var findRoles = _aspNetRolesRepository.Where(x => x.Name == request.Name && x.Id != request.Id);

            if (findRoles.Any())
            {
                response.Success = false;
                response.Message = $"Update Failed, RoleName '{request.Name}' already Exists.";
            }

            else
            {
                roles.Name = request.Name;

                var result = await _roleManager.UpdateAsync(roles);


                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Message = $"Update Successfull, RoleName : '{request.Name}'.";
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Update Failed! '{result.Errors}'";
                }
            }

            return response;
        }
        public async Task<BaseCommandResponse> Delete(string id)
        {
            var response = new BaseCommandResponse();

            var role = new ApplicationRole
            {
                Id = id
            };


            var existingRole = await _roleManager.FindByIdAsync(id);

            if (existingRole == null)
            {
                response.Success = false;
                response.Message = $"Delete Failed, Role Not Found.";
            }

            else
            {
                var result = await _roleManager.DeleteAsync(existingRole);


                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Message = $"Delete Successfull.";
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Delete Failed! '{result.Errors}'";
                }
            }

            return response;
        }



        public async Task<object> Get()
        {
            var result = _aspNetRolesRepository.Where(x => true);

            return result;
        }

        public async Task<object> GetById(string Id)
        {
            var roles = await _roleManager.FindByIdAsync(Id);

            return roles;
        }
    }
}

