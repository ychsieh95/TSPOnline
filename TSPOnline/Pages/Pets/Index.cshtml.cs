using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using TSPOnline.Extensions;
using TSPOnline.Models;
using TSPOnline.Repositorys;

namespace TSPOnline.Pages.Pets
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int MinLevel { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public int MaxLevel { get; set; } = 600;
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool OnlyCanCatch { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Attribute { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Skill { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool WithReSkills { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Items { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Remark { get; set; }

        public List<SelectListItem> Attributes { get; private set; }
        public List<Pet> Pets { get; private set; }

        private readonly AppSettings appSettings;

        public IndexModel(IOptions<AppSettings> appSettings) =>
            this.appSettings = appSettings.Value;

        public async Task OnGetAsync()
        {
            Attributes = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: false),
                new SelectListItem(text: "地", value: "地", selected: false),
                new SelectListItem(text: "火", value: "火", selected: false),
                new SelectListItem(text: "水", value: "水", selected: false),
                new SelectListItem(text: "風", value: "風", selected: false),
                new SelectListItem(text: "心", value: "心", selected: false),
                new SelectListItem(text: "無", value: "無", selected: false),
                new SelectListItem(text: "坐騎", value: "坐騎", selected: false)
            };
            if (string.IsNullOrEmpty(Attribute))
                Attributes.First().Selected = true;
            else
                Attributes.First(attr => attr.Value == Attribute).Selected = true;

            var petRepository = new PetRepository(appSettings.ConnectionStrings.DefaultConnection);

            if (string.IsNullOrEmpty(Name))
                Pets = await petRepository.SelectPetsAsync() as List<Pet>;
            else
                Pets = await petRepository.SelectPetsAsync(name: Name, byKeywork: true) as List<Pet>;

            // Skills & Statistics pair
            foreach (var pet in Pets)
            {
                pet.Skills = await petRepository.SelectPetSkillsAsync(name: pet.Name) as List<PetSkills>;
                pet.Statistics = (await petRepository.SelectPetStatisticsAsync(name: pet.Name) as List<PetStatistic>).OrderBy(stat => stat.RE).ToList();
                foreach (var stat in pet.Statistics)
                    stat.AttributeSum = new List<int>()
                    {
                        stat.INT, stat.ATK, stat.DEF, stat.HPX, stat.SPX, stat.AGI
                    }.Where(value => value > 0).Sum();
            }

            if (!string.IsNullOrEmpty(Skill))
            {
                if (WithReSkills)
                    Pets.RemoveAll(pet => !pet.Skills.Any(skill => skill.Skill1.Contains(Skill) || skill.Skill2.Contains(Skill) || skill.Skill3.Contains(Skill)));
                else
                        Pets.RemoveAll(pet => !pet.Skills.Any(skill =>
                            skill.RE == (pet.Name.Substring(0, 2).Equals("狂．") ? 2 : 0) &&
                            (skill.Skill1.Contains(Skill) || skill.Skill2.Contains(Skill) || skill.Skill3.Contains(Skill))));
            }

            foreach (var pet in Pets)
                if (pet.Name.Substring(0, 2).Equals("狂．"))
                {
                    pet.Skills.RemoveAll(skill => skill.RE != 2);
                    pet.Statistics.RemoveAll(statistics => statistics.RE != 2);
                }
                else
                {
                    pet.Skills.RemoveAll(skill => skill.RE != 0);
                    pet.Statistics.RemoveAll(statistics => statistics.RE != 0);
                }

            Pets.RemoveAll(pet => pet.Statistics.First().LV <= MinLevel);
            Pets.RemoveAll(pet => pet.Statistics.First().LV >= MaxLevel);
            if (OnlyCanCatch)
                Pets.RemoveAll(pet => !pet.Catch);
            if (!string.IsNullOrEmpty(Attribute) && Attribute != "所有")
                Pets.RemoveAll(pet => !pet.Attribute.Contains(Attribute));
            if (!string.IsNullOrEmpty(Location))
                Pets.RemoveAll(pet => !pet.Location.Contains(Location));
            if (!string.IsNullOrEmpty(Items))
                Pets.RemoveAll(pet => !pet.Items.Contains(Items));
            if (!string.IsNullOrEmpty(Remark))
                Pets.RemoveAll(pet => !pet.Remark.Contains(Remark));

            if (Pets.Count <= 0)
                ModelState.AddModelError("Warning", "查無符合條件武將");
            else
                Pets = Pets
                    .OrderByDescending(pet => pet.Statistics.First().LV)
                    .ThenBy(pet => pet.Attribute, new OrderByAttribute())
                    .ThenBy(pet => pet.Name, new OrderByPetName())
                    .ThenBy(pet => pet.Catch)
                    .ThenBy(pet => pet.Location)
                    .ToList();
        }
    }
}