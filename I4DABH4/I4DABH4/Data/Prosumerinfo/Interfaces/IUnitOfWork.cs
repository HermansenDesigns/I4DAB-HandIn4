using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace I4DABH4.Data.Prosumerinfo.Interfaces
{
    public interface IUnitOfWork
    {
        ProsumerRepository ProsumerRepo { get; }
        void SaveChanges();
    }
}
