using MetrologyApp.DataAccess.Repository.IRepository;
using MetrologyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrologyApp.DataAccess.Repository
{
    public class ResultRepo : Repository<Result>, IResultRepo
    {

        private AppDbContext _db;

        public ResultRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Result obj)
        {
            _db.Results.Update(obj);
        }
    }
}
