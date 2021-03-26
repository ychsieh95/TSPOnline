using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TSPOnline.Models;
using TSPOnline.Repositorys;

namespace TSPOnline.Pages.Pets
{
    public class DetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public Pet Pet { get; private set; }
        public string PetImageUrl { get; private set; }

        private readonly AppSettings appSettings;
        private readonly IWebHostEnvironment hostingEnvironment;

        public DetailsModel(IOptions<AppSettings> appSettings, IWebHostEnvironment hostingEnvironment) =>
            (this.appSettings, this.hostingEnvironment) = (appSettings.Value, hostingEnvironment);

        public async Task OnGetAsync()
        {
            var petRepository = new PetRepository(appSettings.ConnectionStrings.DefaultConnection);
            var pets = await petRepository.SelectPetsAsync(name: Name) as List<Pet>;

            if (pets.Count <= 0)
            {
                ModelState.AddModelError("Failure", "查無武將資訊");
                PetImageUrl = "";
            }
            else
            {
                Pet = pets.First();
                Pet.Skills = await petRepository.SelectPetSkillsAsync(name: Pet.Name) as List<PetSkills>;
                Pet.Statistics = (await petRepository.SelectPetStatisticsAsync(name: Pet.Name) as List<PetStatistic>).OrderBy(stat => stat.RE).ToList();
                foreach (var stat in Pet.Statistics)
                    stat.AttributeSum = new List<int>()
                    {
                        stat.INT, stat.ATK, stat.DEF, stat.HPX, stat.SPX, stat.AGI
                    }.Where(value => value > 0).Sum();

                string attrCht =
                    Pet.Attribute == "地" ? "earth" :
                    Pet.Attribute == "火" ? "fire" :
                    Pet.Attribute == "水" ? "water" :
                    Pet.Attribute == "風" ? "wind" :
                    Pet.Attribute == "心" ? "heart" : "none";
                string absolutePath = $"{hostingEnvironment.WebRootPath}/images/pets/{attrCht}";
                string petImagePath = System.IO.Directory.GetFileSystemEntries(absolutePath).ToList().FirstOrDefault(x => x.Contains(Pet.Name));
                if (string.IsNullOrEmpty(petImagePath))
                    PetImageUrl = "";
                else
                {
                    petImagePath = petImagePath.Replace('\\', '/');
                    PetImageUrl = string.Format("{0}/{1}", attrCht, petImagePath.Remove(0, petImagePath.LastIndexOf('/') + 1));
                }
            }
        }
    }
}