using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TSPOnline.Pages.Maps
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, List<string>> Labyrinths { get; private set; }

        public void OnGet() =>
            Labyrinths = new Dictionary<string, List<string>>()
            {
                { "幽州", new List<string>() { "涿郡山洞", "大興山洞" } },
                { "冀州", new List<string>() { "常山礦坑", "朝歌墓穴", "鉅鹿坑道第一層", "鉅鹿坑道第二層", "鉅鹿坑道三層" } },
                { "青州", new List<string>() { "蓬萊海賊洞", "北海神鬼洞", "東郡礦坑", "泰山山洞第一層", "泰山山洞第二層", "泰山山洞第三層", "泰山山洞第四層", "跨州山洞" } },
                { "徐州", new List<string>() { "下邳土山山洞", "盱眙迷宮" } },
                { "淮南", new List<string>() { "壽春山洞", "濡須鐘乳石洞" } },
                { "揚州", new List<string>() { "太湖水洞", "安勒山洞", "餘杭山洞", "會稽礦坑", "許昌山洞", "千毒洞", "汝南礦坑" } },
                { "司隸", new List<string>() { "虎牢山洞", "皇陵洞窟" } },
                { "關中", new List<string>() { "始皇陵第一層", "始皇陵第二層", "始皇陵第三層", "城北山洞", "藍田礦坑" } },
                { "雍州", new List<string>() { "陜北窯洞" } }
            };
    }
}