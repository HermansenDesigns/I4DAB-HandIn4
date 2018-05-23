using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Smartgridinfo;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace I4DABH4.Data.Prosumerinfo.Interfaces
{
    public interface IUnitOfWork
    {
        IProsumerRepository ProsumerRepo { get; }
        ISmartGridSettingsRepo GridRepo { get; }
        void SaveChanges();
    }
}
