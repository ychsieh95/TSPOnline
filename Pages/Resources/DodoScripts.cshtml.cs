using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TSPOnline.Models;
using TSPOnline.Repositorys;

namespace TSPOnline.Pages.Resources
{
    public class DodoScriptsModel : PageModel
    {
        public List<DodoScript> DodoScripts { get; private set; }

        private readonly AppSettings appSettings;
        private readonly IWebHostEnvironment hostingEnvironment;

        public DodoScriptsModel(IOptions<AppSettings> appSettings, IWebHostEnvironment hostingEnvironment) =>
            (this.appSettings, this.hostingEnvironment) = (appSettings.Value, hostingEnvironment);

        public async Task OnGetAsync()
        {
            var resourceRepository = new ResourceRepository(appSettings.ConnectionStrings.DefaultConnection);
            DodoScripts = (await resourceRepository.SelectDodoScriptsAsync() as List<DodoScript>)
                .OrderBy(dodoScript => dodoScript.LV_Boss)
                .ThenBy(dodoScript => dodoScript.LV_Average)
                .ThenBy(dodoScript => dodoScript.AGI).ToList();
            DodoScripts.ForEach(x => x.LV_Average = x.LV_Average / 1.000000000000000000000000000000000m);
            DodoScripts = MatchScriptImage(dodoScripts: new List<DodoScript>(DodoScripts));
        }

        private List<DodoScript> MatchScriptImage(List<DodoScript> dodoScripts)
        {
            string absolutePath = $"{hostingEnvironment.WebRootPath}/images/dodo-scripts/";
            List<string> images = System.IO.Directory.GetFileSystemEntries(absolutePath).ToList();
            List<string[]> imageNames = new List<string[]>();
            images.ForEach(image =>
                imageNames.Add(new string[]
                {
                    System.IO.Path.GetFileName(image).Remove(System.IO.Path.GetFileName(image).LastIndexOf('.')),
                    System.IO.Path.GetFileName(image).Remove(0, System.IO.Path.GetFileName(image).LastIndexOf('.')+1)
                }
            ));

            foreach (var dodoScript in dodoScripts)
            {
                string[] imageName;
                switch (imageNames.Count(name => name[0].Contains(dodoScript.Name)))
                {
                    case 0:
                        dodoScript.ImageName = "";
                        break;

                    case 1:
                        imageName = imageNames.First(name => name[0].Equals(dodoScript.Name));
                        dodoScript.ImageName = string.Format("{0}.{1}", imageName[0], imageName[1]);
                        break;

                    case 2:
                        if (imageNames.Count(name => name[0].Contains(dodoScript.Name) && name[0].Contains(dodoScript.Location)) == 0)
                        {
                            imageName = imageNames.First(name => name[0].Equals(dodoScript.Name));
                            dodoScript.ImageName = string.Format("{0}.{1}", imageName[0], imageName[1]);
                        }
                        else
                        {
                            imageName = imageNames.First(name => name[0].Contains(dodoScript.Name) && name[0].Contains(dodoScript.Location));
                            dodoScript.ImageName = string.Format("{0}.{1}", imageName[0], imageName[1]);
                        }
                        break;
                }
            }

            return dodoScripts;
        }
    }
}