using System.Collections.Generic;
using System.Threading.Tasks;
using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> SelectPetsAsync();
        Task<IEnumerable<Pet>> SelectPetsAsync(string name, bool byKeywork = false);
        Task<IEnumerable<PetSkills>> SelectPetSkillsAsync();
        Task<IEnumerable<PetSkills>> SelectPetSkillsAsync(string name);
        Task<IEnumerable<PetStatistic>> SelectPetStatisticsAsync();
        Task<IEnumerable<PetStatistic>> SelectPetStatisticsAsync(string name);
    }
}
