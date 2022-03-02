using MetrologyApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrologyApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            NominalPoint = new NominalPointRepo(_db);
            ActualPoint = new ActualPointRepo(_db);
            Result = new ResultRepo(_db);
        }

        public INominalPointRepo NominalPoint { get; private set; }
        public IActualPointRepo ActualPoint { get; private set; }
        public IResultRepo Result { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
