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

namespace TSPOnline.Pages.Equipments
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int MinLevel { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public int MaxLevel { get; set; } = 600;
        [BindProperty(SupportsGet = true)]
        public string Site { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string States { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Source { get; set; }

        public List<SelectListItem> Sites { get; private set; }
        public List<SelectListItem> Types { get; private set; }
        public List<SelectListItem> Sources { get; private set; }
        public List<Equipment> Equipments { get; private set; }

        private readonly AppSettings appSettings;

        public IndexModel(IOptions<AppSettings> appSettings) =>
            this.appSettings = appSettings.Value;

        public async Task OnGetAsync()
        {
            Sites = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: false),
                new SelectListItem(text: "手", value: "手", selected: false),
                new SelectListItem(text: "頭", value: "頭", selected: false),
                new SelectListItem(text: "衣", value: "衣", selected: false),
                new SelectListItem(text: "腕", value: "腕", selected: false),
                new SelectListItem(text: "腳", value: "腳", selected: false)
            };
            if (string.IsNullOrEmpty(Site))
                Sites.First().Selected = true;
            else
                Sites.First(site => site.Value == Site).Selected = true;

            Types = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: false),
                new SelectListItem(text: "武", value: "武", selected: false),
                new SelectListItem(text: "書", value: "書", selected: false)
            };
            if (string.IsNullOrEmpty(Type))
                Types.First().Selected = true;
            else
                Types.First(type => type.Value == Type).Selected = true;

            Sources = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: true),
                new SelectListItem(text: "武器鋪", value: "武器鋪", selected: false),
                new SelectListItem(text: "點數", value: "點數", selected: false)
            };
            if (string.IsNullOrEmpty(Source))
                Sites.First().Selected = true;
            else
                Sites.First(source => source.Value == Source).Selected = true;

            var equtRepository = new EquipmentRepository(appSettings.ConnectionStrings.DefaultConnection);
            Equipments = await equtRepository.SelectEquipmentsAsync() as List<Equipment>;

            Equipments.RemoveAll(equipment => equipment.LV <= MinLevel);
            Equipments.RemoveAll(equipment => equipment.LV >= MaxLevel);
            if (!string.IsNullOrEmpty(Site) && Site != "所有")
                Equipments.RemoveAll(equipment => !equipment.Site.Contains(Site));
            if (!string.IsNullOrEmpty(Type))
               switch (Type)
                {
                    case "所有": break;
                    case "武": Equipments.RemoveAll(equipment => equipment.Type == "書"); break;
                    case "書": Equipments.RemoveAll(equipment => equipment.Type != "書"); break;
                }
            if (!string.IsNullOrEmpty(Name))
                Equipments.RemoveAll(equipment => !equipment.Name.Contains(Name));
            if (!string.IsNullOrEmpty(States))
                Equipments.RemoveAll(equipment => !equipment.GetStatesString().Contains(States));
            if (!string.IsNullOrEmpty(Location))
                Equipments.RemoveAll(equipment => !equipment.Location.Contains(Location));
            if (!string.IsNullOrEmpty(Source))
                switch (Source)
                {
                    case "所有": break;
                    case "武器鋪": Equipments.RemoveAll(equipment => equipment.Price <= 0); break;
                    case "點數": Equipments.RemoveAll(equipment => equipment.Point <= 0); break;
                }

            if (Equipments.Count <= 0)
                ModelState.AddModelError("Warning", "查無符合條件裝備");
            else
                Equipments = Equipments
                    .OrderBy(equipment => equipment.Site, new OrderByEquipment())
                    .ThenBy(equipment => equipment.LV)
                    .ThenBy(equipment => equipment.Type)
                    .ThenBy(equipment => equipment.GetStatesString())
                    .ThenBy(equipment => equipment.Location)
                    .ThenBy(equipment => equipment.Price)
                    .ThenBy(equipment => equipment.Point).ToList();
        }
    }
}