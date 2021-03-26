using System.Collections.Generic;
using System.Threading.Tasks;
using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<DodoMapID>> SelectDodoMapIDsAsync();
        Task<IEnumerable<DodoScript>> SelectDodoScriptsAsync();
    }
}
