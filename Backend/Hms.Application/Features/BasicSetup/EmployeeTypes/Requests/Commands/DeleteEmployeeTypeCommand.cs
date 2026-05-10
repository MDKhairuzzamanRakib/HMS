using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Commands
{
    public class DeleteEmployeeTypeCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
