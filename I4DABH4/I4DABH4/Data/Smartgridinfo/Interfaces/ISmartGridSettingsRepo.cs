using I4DABH4.Models;
using I4DABH4.Repos;

namespace I4DABH4.Data.Smartgridinfo.Interfaces
{
    public interface ISmartGridSettingsRepo : IRepository<GridSettings>
    {
        void SetGridSettings(GridSettings settings);
    }
}