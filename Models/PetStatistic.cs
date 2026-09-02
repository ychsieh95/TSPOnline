namespace TSPOnline.Models
{
    public class PetStatistic
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 轉生 (Reincarnation)
        /// </summary>
        public int RE { get; set; }

        /// <summary>
        /// 等級 (Level)
        /// </summary>
        public int LV { get; set; }

        /// <summary>
        /// HP
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// SP
        /// </summary>
        public int SP { get; set; }

        /// <summary>
        /// 知力 (Intelligence)
        /// </summary>
        public int INT { get; set; }

        /// <summary>
        /// 攻擊 (Weapon Attack)
        /// </summary>
        public int ATK { get; set; }

        /// <summary>
        /// 防禦力 (Weapon Defense)
        /// </summary>
        public int DEF { get; set; }

        /// <summary>
        /// 體質 (Health Point)
        /// </summary>
        public int HPX { get; set; }

        /// <summary>
        /// 能量 (Magic point)
        /// </summary>
        public int SPX { get; set; }

        /// <summary>
        /// 敏捷 (Agility)
        /// </summary>
        public int AGI { get; set; }

        /// <summary>
        /// 數值總和
        /// </summary>
        public int AttributeSum { get; set; }
    }
}