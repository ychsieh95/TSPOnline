namespace TSPOnline.Models
{
    public class Ore
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 等級 (Level)
        /// </summary>
        public int LV { get; set; }

        /// <summary>
        /// 屬性
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// 地區─礦坑名稱
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 掉落物品
        /// </summary>
        public string Items { get; set; }

    }
}