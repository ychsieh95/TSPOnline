using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IOreRepository
    {
        Task<IEnumerable<Ore>> SelectOresAsync();
    }
}
