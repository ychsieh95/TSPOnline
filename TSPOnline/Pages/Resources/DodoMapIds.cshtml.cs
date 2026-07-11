using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TSPOnline.Extensions;
using TSPOnline.Models;
using TSPOnline.Repositorys;

namespace TSPOnline.Pages.Resources
{
    public class DodoMapIdsModel : PageModel
    {
        public Dictionary<string, List<DodoMapID>> DodoMapIDsDictionary { get; private set; }

        private readonly AppSettings appSettings;

        public DodoMapIdsModel(IOptions<AppSettings> appSettings) =>
            this.appSettings = appSettings.Value;

        public async Task OnGetAsync()
        {
            var resourceRepository = new ResourceRepository(appSettings.ConnectionStrings.DefaultConnection);
            var dodoMapIDs = (await resourceRepository.SelectDodoMapIDsAsync() as List<DodoMapID>)
                .OrderBy(dodoMapID => dodoMapID.Location, new OrderByLocation())
                .ThenBy(dodoMapID => dodoMapID.Place)
                .ThenBy(dodoMapID => dodoMapID.ID)
                .ToList();

            DodoMapIDsDictionary = new Dictionary<string, List<DodoMapID>>();
            foreach (var dodoMapID in dodoMapIDs)
                if (!DodoMapIDsDictionary.Keys.Contains(dodoMapID.Location))
                    DodoMapIDsDictionary.Add(dodoMapID.Location, new List<DodoMapID>() { dodoMapID });
                else
                    DodoMapIDsDictionary[dodoMapID.Location].Add(dodoMapID);

            foreach (var key in DodoMapIDsDictionary.Keys)
                DodoMapIDsDictionary[key].Sort(delegate (DodoMapID dodoMapID1, DodoMapID dodoMapID2)
                {
                    if (dodoMapID1.ID > dodoMapID2.ID)
                        return 1;
                    else if (dodoMapID1 == dodoMapID2)
                        return 0;
                    else
                        return -1;
                });
        }
    }
}