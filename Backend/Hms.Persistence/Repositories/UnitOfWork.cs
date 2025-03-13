using Hms.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HmsDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Hashtable _repositories;
        //private ILeaveAllocationRepository _leaveAllocationRepository;
        //private ILeaveTypeRepository _leaveTypeRepository;
        //private ILeaveRequestRepository _leaveRequestRepository;


        public UnitOfWork(HmsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        public IHmsRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(HmsRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IHmsRepository<TEntity>)_repositories[type];
        }
        //public ILeaveAllocationRepository LeaveAllocationRepository => 
        //    _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);
        //public ILeaveTypeRepository LeaveTypeRepository => 
        //    _leaveTypeRepository ??= new LeaveTypeRepository(_context);
        //public ILeaveRequestRepository LeaveRequestRepository => 
        //    _leaveRequestRepository ??= new LeaveRequestRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            //var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            //await _context.SaveChangesAsync(username);

            var cancellationToken = new CancellationToken();  // You can also pass a cancellation token if needed
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
