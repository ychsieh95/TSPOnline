namespace TSPOnline.Models
{
    public class Equipment
    {

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 裝備部位
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 等級 (Level)
        /// </summary>
        public int LV { get; set; }

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
        /// 火屬性
        /// </summary>
        public int FIRE { get; set; }

        /// <summary>
        /// 水屬性
        /// </summary>
        public int WATER { get; set; }

        /// <summary>
        /// 風屬性
        /// </summary>
        public int WIND { get; set; }

        /// <summary>
        /// 地屬性
        /// </summary>
        public int EARTH { get; set; }

        /// <summary>
        /// 心屬性
        /// </summary>
        public int HEART { get; set; }

        /// <summary>
        /// 取得位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 遊戲金
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 點數
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// 取得能力值格式化字串
        /// </summary>
        /// <returns></returns>
        public string GetStatesString(string splitChar = "；")
        {
            string str = "";

            if (INT != 0) { str += "知" + (INT > 0 ? "+" : "") + INT + "；"; }
            if (ATK != 0) { str += "攻" + (ATK > 0 ? "+" : "") + ATK + "；"; }
            if (DEF != 0) { str += "防" + (DEF > 0 ? "+" : "") + DEF + "；"; }
            if (AGI != 0) { str += "敏" + (AGI > 0 ? "+" : "") + AGI + "；"; }
            if (HPX != 0) { str += "HP" + (HPX > 0 ? "+" : "") + HPX + "；"; }
            if (SPX != 0) { str += "SP" + (SPX > 0 ? "+" : "") + SPX + "；"; }
            if (EARTH != 0) { str += "地" + (EARTH > 0 ? "+" : "") + EARTH + "；"; }
            if (FIRE != 0) { str += "火" + (FIRE > 0 ? "+" : "") + FIRE + "；"; }
            if (WATER != 0) { str += "水" + (WATER > 0 ? "+" : "") + WATER + "；"; }
            if (WIND != 0) { str += "風" + (WIND > 0 ? "+" : "") + WIND + "；"; }
            if (HEART != 0) { str += "心" + (HEART > 0 ? "+" : "") + HEART + "；"; }

            return str.TrimEnd('；');
        }
    }
}