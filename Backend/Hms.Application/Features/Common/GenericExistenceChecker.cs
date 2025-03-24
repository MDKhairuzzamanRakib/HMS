using Hms.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.Common
{
    public class GenericExistenceChecker
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericExistenceChecker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool EntityExists<T>(string propertyNameString, string valueString, string propertyNameInt, int valueInt) where T : class
        {
            var repository = _unitOfWork.Repository<T>();

            var normalizedValue = valueString.Trim().ToLower().Replace(" ", string.Empty);

            var entity = repository
                .Where(e => EF.Property<string>(e, propertyNameString).Trim().ToLower().Replace(" ", string.Empty) == normalizedValue)
                .Where(e => EF.Property<int>(e, propertyNameInt) != valueInt)
                .Any();

            return entity;
        }
    }
}
