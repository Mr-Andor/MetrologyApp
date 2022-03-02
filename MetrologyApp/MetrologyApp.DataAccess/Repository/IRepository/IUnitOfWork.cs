using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetrologyApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        INominalPointRepo NominalPoint { get; }
        IActualPointRepo ActualPoint { get; }
        IResultRepo Result { get;  }
        void Save();

    }
}
