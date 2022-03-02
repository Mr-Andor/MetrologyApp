using MetrologyApp.DataAccess.Repository.IRepository;
using MetrologyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrologyApp.DataAccess.Repository
{
    public class NominalPointRepo : Repository<NominalPoint>, INominalPointRepo
    {

        private AppDbContext _db;

        public NominalPointRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(NominalPoint obj)
        {
            _db.NominalPoints.Update(obj);
        }
    }
}
