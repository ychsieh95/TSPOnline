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

namespace TSPOnline.Pages.Monsters
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
        public string Attribute { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Items { get; set; }

        public List<SelectListItem> Attributes { get; private set; }
        public List<SelectListItem> Types { get; private set; }
        public List<Monster> Monsters { get; private set; }

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
                new SelectListItem(text: "無", value: "無", selected: false)
            };
            if (string.IsNullOrEmpty(Attribute))
                Attributes.First().Selected = true;
            else
                Attributes.First(attr => attr.Value == Attribute).Selected = true;

            Types = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: false),
                new SelectListItem(text: "一般", value: "一般", selected: false),
                new SelectListItem(text: "聖靈", value: "聖靈", selected: false)
            };
            if (string.IsNullOrEmpty(Type))
                Types.First().Selected = true;
            else
                Types.First(type => type.Value == Type).Selected = true;

            var monsterRepository = new MonsterRepository(appSettings.ConnectionStrings.DefaultConnection);
            Monsters = await monsterRepository.SelectMonstersAsync() as List<Monster>;

            Monsters.RemoveAll(monster => monster.LV <= MinLevel);
            Monsters.RemoveAll(monster => monster.LV >= MaxLevel);
            if (!string.IsNullOrEmpty(Name))
                Monsters.RemoveAll(monster => !monster.Name.Contains(Name));
            if (!string.IsNullOrEmpty(Attribute) && Attribute != "所有")
                Monsters.RemoveAll(monster => !monster.Attribute.Contains(Attribute));
            if (!string.IsNullOrEmpty(Type))
                switch (Type)
                {
                    case "所有": break;
                    case "一般": Monsters.RemoveAll(monster => monster.IsSoul); break;
                    case "聖靈": Monsters.RemoveAll(monster => !monster.IsSoul); break;
                }
            if (!string.IsNullOrEmpty(Location))
                Monsters.RemoveAll(monster => !monster.Location.Contains(Location));
            if (!string.IsNullOrEmpty(Items))
                Monsters.RemoveAll(monster => !monster.Items.Contains(Items));

            if (Monsters.Count <= 0)
                ModelState.AddModelError("Warning", "查無符合條件野怪");
            else
                Monsters = Monsters
                    .OrderBy(monster => monster.LV)
                    .ThenBy(monster => monster.IsSoul)
                    .ThenBy(monster => monster.Attribute, new OrderByAttribute())
                    .ThenByDescending(monster => monster.HP)
                    .ThenByDescending(monster => monster.AGI)
                    .ThenBy(monster => monster.Location)
                    .ToList();
        }
    }
}