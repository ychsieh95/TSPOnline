namespace TSPOnline.Models
{
    public class DodoScript
    {
        /// <summary>
        /// 腳本名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 腳本地點
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 斷刷
        /// </summary>
        public bool IsInterrupted { get; set; }

        /// <summary>
        /// 主怪等級
        /// </summary>
        public int LV_Boss { get; set; }

        /// <summary>
        /// 隊伍平均等級
        /// </summary>
        public decimal LV_Average { get; set; }

        /// <summary>
        /// 敏捷需求
        /// </summary>
        public int AGI { get; set; }

        /// <summary>
        /// 開荒等級建議
        /// </summary>
        public string SUG_LV_New { get; set; }

        /// <summary>
        /// 200 武將帶建議
        /// </summary>
        public string SUG_LV_Old { get; set; }

        /// <summary>
        /// 前置任務名稱
        /// </summary>
        public string Mission { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 圖片名稱
        /// </summary>
        public string ImageName { get; set; }
    }
}