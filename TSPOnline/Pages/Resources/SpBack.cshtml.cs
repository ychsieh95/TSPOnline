using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TSPOnline.Pages.Resources
{
    public class SpBackModel : PageModel
    {
        public List<string> SkillLevels { get; private set; }
        public List<string> StaffINT { get; private set; }

        public void OnGet()
        {
            SkillLevels = new List<string>()
            {
                "0 - 1", "2 - 4", "5 - 7", "8 - 11", "12 - 15",
                "16 - 19", "20 - 23", "24 - 27", "28 - 31", "32 - 35",
                "36 - 39", "40 - 43", "44 - 47", "48 - 50", "51 - 53",
                "54 - 56", "57 - 59", "60 - 62", "63 - 65", "66 - 68",
                "69 - 71", "72 - 74", "75 - 77", "78 - 80", "81 - 83",
                "84 - 86", "87 - 89", "90 - 92", "93 - 95", "96 - 98",
                "99 - 101", "102 - 104", "105 - 107", "108 - 111", "112 - 115"
            };

            StaffINT = new List<string>()
            {
                "0", "1 - 2", "3 - 6", "7 - 12", "13 - 20",
                "21 - 30", "31 - 42", "43 - 56", "57 - 72", "73 - 90",
                "91 - 110", "111 - 132", "133 - 156", "157 - 182", "183 - 210",
                "211 - 240", "241 - 272", "273 - 306", "307 - 342", "343 - 380",
                "381 - 420", "421 - 462", "463 - 506", "507 - 552", "553 - 600"
            };
        }
    }
}