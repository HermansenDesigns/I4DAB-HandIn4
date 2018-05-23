using I4DABH4.Data.Prosumerinfo.Interfaces;
using I4DABH4.Models;
using I4DABH4.Repos;
using Microsoft.EntityFrameworkCore;

namespace I4DABH4.Data.Prosumerinfo
{
    public class ProsumerRepository : Repository<Prosumer>, IProsumerRepository
    {
        public ProsumerRepository(ProsumerContext context) : base(context)
        {
            
        }
    }
}
