using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Prosumerinfo.Interfaces;
using I4DABH4.Data.Smartgridinfo;
using I4DABH4.Data.Smartgridinfo.Interfaces;
using I4DABH4.Models;

namespace I4DABH4.Data.Prosumerinfo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProsumerContext _context;

        public UnitOfWork()
        {
            _context = new ProsumerContext();

            ProsumerRepo = new ProsumerRepository(_context);

            GridRepo = new SmartGridSettingsRepo(_context);
        }


        public IProsumerRepository ProsumerRepo { get; }
        public ISmartGridSettingsRepo GridRepo { get; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
