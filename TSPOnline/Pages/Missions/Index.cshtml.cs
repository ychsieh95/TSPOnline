using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TSPOnline.Extensions;
using TSPOnline.Models;
using TSPOnline.Repositorys;

namespace TSPOnline.Pages.Missions
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Conditions { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Steps { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Items { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Remark { get; set; }

        public List<Mission> Missions { get; private set; }

        private readonly AppSettings appSettings;

        public IndexModel(IOptions<AppSettings> appSettings) =>
            this.appSettings = appSettings.Value;

        public async Task OnGetAsync()
        {
            var missionRepository = new MissionRepository(appSettings.ConnectionStrings.DefaultConnection);
            Missions = await missionRepository.SelectMissionsAsync() as List<Mission>;

            if (!string.IsNullOrEmpty(Name))
                Missions.RemoveAll(mission => !mission.Name.Contains(Name));
            if (!string.IsNullOrEmpty(Location))
                Missions.RemoveAll(mission => !mission.Location.Contains(Location));
            if (!string.IsNullOrEmpty(Conditions))
                Missions.RemoveAll(mission => !mission.Conditions.Contains(Conditions));
            if (!string.IsNullOrEmpty(Steps))
                Missions.RemoveAll(mission => !mission.Steps.Contains(Steps));
            if (!string.IsNullOrEmpty(Items))
                Missions.RemoveAll(mission => !mission.Items.Contains(Items));
            if (!string.IsNullOrEmpty(Remark))
                Missions.RemoveAll(mission => !mission.Remark.Contains(Remark));

            foreach (var mission in Missions)
            {
                mission.Steps = mission.Steps.Replace(Environment.NewLine, "<br />");
                mission.Items = mission.Items.Replace(Environment.NewLine, "<br />");
                mission.Remark = mission.Remark.Replace(Environment.NewLine, "<br />");
            }

            if (Missions.Count <= 0)
                ModelState.AddModelError("Warning", "查無符合條件任務");
            else
                Missions = Missions
                    .OrderBy(mission => mission.Location.Split('─')[0], new OrderByLocation())
                    .ThenBy(mission => mission.Name)
                    .ThenBy(mission => mission.Conditions)
                    .ToList();
        }
    }
}