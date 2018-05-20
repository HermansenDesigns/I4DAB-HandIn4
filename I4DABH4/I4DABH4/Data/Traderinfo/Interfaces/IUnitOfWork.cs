using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I4DABH4.Data.Traderinfo
{
    public interface IUnitOfWork
    {
        TradesRepo TradesRepo { get; }

        void Dispose();
    }
}
