using Hms.Application.Models.Identity;
using Hms.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<BaseCommandResponse> Register(RegistrationRequest request);
        Task<BaseCommandResponse> UpdateUser(UpdateUserRequest request);
        Task<BaseCommandResponse> UpdateUserAndChangePassword(UpdateUserRequest request);
        Task<BaseCommandResponse> ResetPassword(UpdateUserRequest request);
        Task<BaseCommandResponse> VerifyToken(VerifyTokenRequest request);
    }
}
