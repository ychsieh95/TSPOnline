namespace TSPOnline.Models
{
    public class Mission
    {
        /// <summary>
        /// 任務名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地區
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 任務條件
        /// </summary>
        public string Conditions { get; set; }

        /// <summary>
        /// 任務流程
        /// </summary>
        public string Steps { get; set; }

        /// <summary>
        /// 所得物品
        /// </summary>
        public string Items { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
    }
}