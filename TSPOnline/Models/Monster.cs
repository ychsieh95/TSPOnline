namespace TSPOnline.Models
{
    public class Monster
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 等級
        /// </summary>
        public int LV { get; set; }

        /// <summary>
        /// 聖靈
        /// </summary>
        public bool IsSoul { get; set; } = false;

        /// <summary>
        /// 屬性
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// 血量
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// 敏捷
        /// </summary>
        public int AGI { get; set; }

        /// <summary>
        /// 技能一
        /// </summary>
        public string Skill1 { get; set; }

        /// <summary>
        /// 技能二
        /// </summary>
        public string Skill2{ get; set; }

        /// <summary>
        /// 技能三
        /// </summary>
        public string Skill3 { get; set; }

        /// <summary>
        /// 地區─地點
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 掉落物品
        /// </summary>
        public string Items { get; set; }
    }
}