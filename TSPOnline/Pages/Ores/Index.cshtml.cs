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

namespace TSPOnline.Pages.Ores
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
        public string Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Items { get; set; }

        public List<SelectListItem> Attributes { get; private set; }
        public List<Ore> Ores { get; private set; }

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
                new SelectListItem(text: "風", value: "風", selected: false)
            };
            if (string.IsNullOrEmpty(Attribute))
                Attributes.First().Selected = true;
            else
                Attributes.First(attr => attr.Value == Attribute).Selected = true;

            var oreRepository = new OreRepository(appSettings.ConnectionStrings.DefaultConnection);
            Ores = await oreRepository.SelectOresAsync() as List<Ore>;

            Ores.RemoveAll(ore => ore.LV <= MinLevel);
            Ores.RemoveAll(ore => ore.LV >= MaxLevel);
            if (!string.IsNullOrEmpty(Name))
                Ores.RemoveAll(ore => !ore.Name.Contains(Name));
            if (!string.IsNullOrEmpty(Attribute) && Attribute != "所有")
                Ores.RemoveAll(ore => !ore.Attribute.Contains(Attribute));
            if (!string.IsNullOrEmpty(Location))
                Ores.RemoveAll(ore => !ore.Location.Contains(Location));
            if (!string.IsNullOrEmpty(Items))
                Ores.RemoveAll(ore => !ore.Items.Contains(Items));

            if (Ores.Count <= 0)
                ModelState.AddModelError("Warning", "查無符合條件礦怪");
            else
                Ores = Ores
                    .OrderBy(ore => ore.LV)
                    .ThenBy(ore => ore.Attribute, new OrderByAttribute())
                    .ThenBy(ore => ore.Location)
                    .ToList();
        }
    }
}