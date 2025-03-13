using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Contracts.Persistence
{
    public interface IHmsRepository<T> : IGenericRepository<T> where T : class
    {
        DataTable ExecWithStoreProcedure(string query, IDictionary<string, object> values);
        DataTable ExecWithSqlQuery(string query);
        int ExecNoneQuery(string query);

    }
}