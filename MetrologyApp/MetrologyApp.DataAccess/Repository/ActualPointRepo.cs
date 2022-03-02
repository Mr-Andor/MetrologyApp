using MetrologyApp.DataAccess.Repository.IRepository;
using MetrologyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrologyApp.DataAccess.Repository
{
    public class ActualPointRepo : Repository<ActualPoint>, IActualPointRepo
    {

        private AppDbContext _db;

        public ActualPointRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ActualPoint obj)
        {
            _db.ActualPoints.Update(obj);
        }
    }
}
