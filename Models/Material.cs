namespace TSPOnline.Models
{
    public class Material
    {
        /// <summary>
        /// 物品名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 種類	
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 物品等級
        /// </summary>
        public int LV { get; set; }

        /// <summary>
        /// 地區─地點
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// NPC名稱
        /// </summary>
        public string NpcName { get; set; }

        /// <summary>
        /// NPC等級
        /// </summary>
        public int NpcLV { get; set; }

        /// <summary>
        /// NPC屬性	
        /// </summary>
        public string NpcAttribute { get; set; }
    }
}