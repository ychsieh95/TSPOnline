using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IMissionRepository
    {
        Task<IEnumerable<Mission>> SelectMissionsAsync();
    }
}
