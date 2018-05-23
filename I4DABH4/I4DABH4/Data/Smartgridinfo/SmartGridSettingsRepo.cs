using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Prosumerinfo;
using I4DABH4.Data.Smartgridinfo.Interfaces;
using I4DABH4.Models;
using Microsoft.EntityFrameworkCore;

namespace I4DABH4.Data.Smartgridinfo
{
    public class SmartGridSettingsRepo : Repository<GridSettings>, ISmartGridSettingsRepo
    {
        public SmartGridSettingsRepo(DbContext context) : base(context)
        {
        }

        public void SetGridSettings(GridSettings settings)
        {
            var dyppekogerstatus = base.Get(settings.Id);
            if (dyppekogerstatus == null)
            {
                base.Insert(settings);
            }
            else
            {
                base.Update(settings);
            }
        }
    }
}
