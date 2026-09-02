using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> SelectMaterialsAsync();
    }
}
