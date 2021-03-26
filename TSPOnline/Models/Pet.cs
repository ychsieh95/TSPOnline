using System.Collections.Generic;

namespace TSPOnline.Models
{
    public class Pet
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 屬性
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// 職業
        /// </summary>
        public string Occupation { get; set; }

        /// <summary>
        /// 網羅
        /// </summary>
        public bool Catch { get; set; }

        /// <summary>
        /// 數值
        /// </summary>
        public List<PetStatistic> Statistics { get; set; } = new List<PetStatistic>()
        {
            new PetStatistic() { RE = 0 },
            new PetStatistic() { RE = 1 },
            new PetStatistic() { RE = 2 }
        };

        /// <summary>
        /// 技能
        /// </summary>
        public List<PetSkills> Skills { get; set; } = new List<PetSkills>()
        {
            new PetSkills() { RE = 0 },
            new PetSkills() { RE = 1 },
            new PetSkills() { RE = 2 }
        };

        /// <summary>
        /// 第四特技
        /// </summary>
        public string SpecialSkill { get; set; }

        /// <summary>
        /// 第五無雙技
        /// </summary>
        public string UnparalleledSkill { get; set; }

        /// <summary>
        /// 被動技能
        /// </summary>
        public string PassiveSkill { get; set; }

        /// <summary>
        /// 出沒地
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 掉落物品
        /// </summary>
        public string Items { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
    }
}