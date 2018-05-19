using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace I4DABH4.Repos
{
    public class ProsumerRepository : GenericRepository<Prosumer>, IProsumerRepository
    {
        private ProsumerContext _context;
        private DbSet<Prosumer> _prosumers; 
        public ProsumerRepository(ProsumerContext context) : base(context)
        {
            _context = context;
            _prosumers = _context.Prosumers; 
        }

        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }
    }
}
