using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IMonsterRepository
    {
        Task<IEnumerable<Monster>> SelectMonstersAsync();
    }
}
