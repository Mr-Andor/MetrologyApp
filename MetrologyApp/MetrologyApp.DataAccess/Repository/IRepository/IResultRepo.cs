using MetrologyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrologyApp.DataAccess.Repository.IRepository
{
    public interface IResultRepo : IRepository<Result>
    {
        void Update(Result obj);

    }
}
