using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Repos;

namespace I4DABH4.Data.Traderinfo
{
    public interface IUnitOfWork
    {
        TradesRepo TradesRepo { get; }
        GridRepo GridRepo { get; }

        ProsumerRepository ProsumerRepo { get; }
        void Dispose();
        void SaveChanges();
    }
}
