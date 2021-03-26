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

namespace TSPOnline.Pages.Materials
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Type { get; set; }
        [BindProperty(SupportsGet = true)]
        public int MinLevel { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public int MaxLevel { get; set; } = 600;
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NpcAttribute { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NpcName { get; set; }

        public List<SelectListItem> Types { get; private set; }
        public List<SelectListItem> NpcAttributes { get; private set; }
        public List<Material> Materials { get; private set; }

        private readonly AppSettings appSettings;

        public IndexModel(IOptions<AppSettings> appSettings) =>
            this.appSettings = appSettings.Value;

        public async Task OnGetAsync()
        {
            Types = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: false),
                new SelectListItem(text: "木", value: "木", selected: false),
                new SelectListItem(text: "布", value: "布", selected: false),
                new SelectListItem(text: "皮", value: "皮", selected: false),
                new SelectListItem(text: "竹", value: "竹", selected: false),
                new SelectListItem(text: "特礦", value: "特礦", selected: false),
                new SelectListItem(text: "紙", value: "紙", selected: false),
                new SelectListItem(text: "骨", value: "骨", selected: false),
                new SelectListItem(text: "陶", value: "陶", selected: false)
            };
            if (string.IsNullOrEmpty(Type))
                Types.First().Selected = true;
            else
                Types.First(type => type.Value == Type).Selected = true;

            NpcAttributes = new List<SelectListItem>()
            {
                new SelectListItem(text: "所有", value: "所有", selected: false),
                new SelectListItem(text: "地", value: "地", selected: false),
                new SelectListItem(text: "火", value: "火", selected: false),
                new SelectListItem(text: "水", value: "水", selected: false),
                new SelectListItem(text: "風", value: "風", selected: false),
                new SelectListItem(text: "心", value: "心", selected: false),
                new SelectListItem(text: "無", value: "無", selected: false)
            };
            if (string.IsNullOrEmpty(NpcAttribute))
                NpcAttributes.First().Selected = true;
            else
                NpcAttributes.First(attr => attr.Value == NpcAttribute).Selected = true;

            var materialRepository = new MaterialRepository(appSettings.ConnectionStrings.DefaultConnection);
            Materials = await materialRepository.SelectMaterialsAsync() as List<Material>;

            if (!string.IsNullOrEmpty(Type) && Type != "所有")
                Materials.RemoveAll(material => !material.Type.Contains(Type));
            Materials.RemoveAll(material => material.LV <= MinLevel);
            Materials.RemoveAll(material => material.LV >= MaxLevel);
            if (!string.IsNullOrEmpty(Name))
                Materials.RemoveAll(material => !material.Name.Contains(Name));
            if (!string.IsNullOrEmpty(Location))
                Materials.RemoveAll(material => !material.Location.Contains(Location));
            if (!string.IsNullOrEmpty(NpcAttribute))
                switch (NpcAttribute)
                {
                    case "所有": break;
                    case "無": Materials.RemoveAll(material => !material.NpcAttribute.Contains(NpcAttribute) && !string.IsNullOrEmpty(material.NpcAttribute)); break;
                    default: Materials.RemoveAll(material => !material.NpcAttribute.Contains(NpcAttribute)); break;
                }
            if (!string.IsNullOrEmpty(NpcName))
                Materials.RemoveAll(material => !material.NpcName.Contains(NpcName));

            if (Materials.Count <= 0)
                ModelState.AddModelError("Warning", "查無符合條件材料");
            else
                Materials = Materials
                    .OrderBy(material => material.Type, new OrderByMaterialType())
                    .ThenBy(material => material.LV)
                    .ThenBy(material => material.Location)
                    .ThenBy(material => material.Name)
                    .ThenBy(material => material.NpcLV)
                    .ThenBy(material => material.NpcAttribute)
                    .ThenBy(material => material.NpcName)
                    .ToList();
        }
    }
}