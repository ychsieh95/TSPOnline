using System.Collections.Generic;

namespace TSPOnline.Extensions
{
    /// <summary>
    /// 自定義屬性排序
    /// </summary>
    public class OrderByAttribute : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            switch (x)
            {
                case "地":
                    switch (y)
                    {
                        case "地": return 0;
                        case "火": return -1;
                        case "水": return -1;
                        case "風": return -1;
                        case "心": return -1;
                        case "無": return -1;
                        default: return 0;
                    }
                case "火":
                    switch (y)
                    {
                        case "地": return 1;
                        case "火": return 0;
                        case "水": return -1;
                        case "風": return -1;
                        case "心": return -1;
                        case "無": return -1;
                        default: return 0;
                    }
                case "水":
                    switch (y)
                    {
                        case "地": return 1;
                        case "火": return 1;
                        case "水": return 0;
                        case "風": return -1;
                        case "心": return -1;
                        case "無": return -1;
                        default: return 0;
                    }
                case "風":
                    switch (y)
                    {
                        case "地": return 1;
                        case "火": return 1;
                        case "水": return 1;
                        case "風": return 0;
                        case "心": return -1;
                        case "無": return -1;
                        default: return 0;
                    }
                case "心":
                    switch (y)
                    {
                        case "地": return 1;
                        case "火": return 1;
                        case "水": return 1;
                        case "風": return 1;
                        case "心": return 0;
                        case "無": return -1;
                        default: return 0;
                    }
                case "無":
                    switch (y)
                    {
                        case "地": return 1;
                        case "火": return 1;
                        case "水": return 1;
                        case "風": return 1;
                        case "心": return 1;
                        case "無": return 0;
                        default: return 0;
                    }
                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// 自定義武將姓名排序 (狂 > 真 > 預設排序)
    /// </summary>
    public class OrderByPetName : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string xName = x.Contains("．") ? x.Split('．')[1] : x;
            string yName = y.Contains("．") ? y.Split('．')[1] : y;

            switch (x.Substring(0, 1))
            {
                case "狂":
                    switch (y.Substring(0, 1))
                    {
                        case "狂": return string.Compare(x, y);
                        case "真": return -1;
                        default: return -1;
                    }
                case "真":
                    switch (y.Substring(0, 1))
                    {
                        case "狂": return 1;
                        case "真": return string.Compare(x, y);
                        default: return -1;
                    }
                default:
                    switch (y.Substring(0, 1))
                    {
                        case "狂": return 1;
                        case "真": return 1;
                        default: return string.Compare(x, y);
                    }
            }
        }
    }

    /// <summary>
    /// 自定義裝備部位排序
    /// </summary>
    public class OrderByEquipment : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            switch (x)
            {
                case "手":
                    switch (y)
                    {
                        case "手": return 0;
                        case "頭": return -1;
                        case "衣": return -1;
                        case "腕": return -1;
                        case "腳": return -1;
                        default: return 0;
                    }
                case "頭":
                    switch (y)
                    {
                        case "手": return 1;
                        case "頭": return 0;
                        case "衣": return -1;
                        case "腕": return -1;
                        case "腳": return -1;
                        default: return 0;
                    }
                case "衣":
                    switch (y)
                    {
                        case "手": return 1;
                        case "頭": return 1;
                        case "衣": return 0;
                        case "腕": return -1;
                        case "腳": return -1;
                        default: return 0;
                    }
                case "腕":
                    switch (y)
                    {
                        case "手": return 1;
                        case "頭": return 1;
                        case "衣": return 1;
                        case "腕": return 0;
                        case "腳": return -1;
                        default: return 0;
                    }
                case "腳":
                    switch (y)
                    {
                        case "手": return 1;
                        case "頭": return 1;
                        case "衣": return 1;
                        case "腕": return 1;
                        case "腳": return 0;
                        default: return 0;
                    }
                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// 自定義材料種類排序
    /// </summary>
    public class OrderByMaterialType : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            switch (x)
            {
                case "木":
                    switch (y)
                    {
                        case "木": return 0;
                        case "布": return -1;
                        case "皮": return -1;
                        case "竹": return -1;
                        case "紙": return -1;
                        case "骨": return -1;
                        case "陶": return -1;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "布":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 0;
                        case "皮": return -1;
                        case "竹": return -1;
                        case "紙": return -1;
                        case "骨": return -1;
                        case "陶": return -1;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "皮":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 1;
                        case "皮": return 0;
                        case "竹": return -1;
                        case "紙": return -1;
                        case "骨": return -1;
                        case "陶": return -1;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "竹":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 1;
                        case "皮": return 1;
                        case "竹": return 0;
                        case "紙": return -1;
                        case "骨": return -1;
                        case "陶": return -1;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "紙":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 1;
                        case "皮": return 1;
                        case "竹": return 1;
                        case "紙": return 0;
                        case "骨": return -1;
                        case "陶": return -1;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "骨":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 1;
                        case "皮": return 1;
                        case "竹": return 1;
                        case "紙": return 1;
                        case "骨": return 0;
                        case "陶": return -1;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "陶":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 1;
                        case "皮": return 1;
                        case "竹": return 1;
                        case "紙": return 1;
                        case "骨": return 1;
                        case "陶": return 0;
                        case "特殊礦物": return -1;
                        default: return 0;
                    }
                case "特殊礦物":
                    switch (y)
                    {
                        case "木": return 1;
                        case "布": return 1;
                        case "皮": return 1;
                        case "竹": return 1;
                        case "紙": return 1;
                        case "骨": return 1;
                        case "陶": return 1;
                        case "特殊礦物": return 0;
                        default: return 0;
                    }
                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// 自定義地圖（地區）排序
    /// </summary>
    public class OrderByLocation : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            switch (x)
            {
                case ("進入遊戲"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 0;
                        case ("新手村"): return -1;
                        case ("幽州"): return -1;
                        case ("冀州"): return -1;
                        case ("青州"): return -1;
                        case ("徐州"): return -1;
                        case ("并州"): return -1;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("新手村"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 0;
                        case ("幽州"): return -1;
                        case ("冀州"): return -1;
                        case ("青州"): return -1;
                        case ("徐州"): return -1;
                        case ("并州"): return -1;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("幽州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 0;
                        case ("冀州"): return -1;
                        case ("青州"): return -1;
                        case ("徐州"): return -1;
                        case ("并州"): return -1;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("冀州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 0;
                        case ("青州"): return -1;
                        case ("徐州"): return -1;
                        case ("并州"): return -1;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("青州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 0;
                        case ("徐州"): return -1;
                        case ("并州"): return -1;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("徐州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 0;
                        case ("并州"): return -1;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("并州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 0;
                        case ("遼東"): return -1;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("遼東"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 0;
                        case ("塞外"): return -1;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("塞外"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 0;
                        case ("淮南"): return -1;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("淮南"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 0;
                        case ("兗州"): return -1;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("兗州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 0;
                        case ("司隸"): return -1;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("司隸"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 0;
                        case ("荊北"): return -1;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("荊北"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 0;
                        case ("關中"): return -1;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("關中"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 0;
                        case ("益州"): return -1;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("益州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 0;
                        case ("涼州"): return -1;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("涼州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 0;
                        case ("江東"): return -1;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("江東"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 0;
                        case ("揚州"): return -1;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("揚州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 0;
                        case ("荊南"): return -1;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("荊南"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 0;
                        case ("交州"): return -1;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("交州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 0;
                        case ("嶺南"): return -1;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("嶺南"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 0;
                        case ("夷州"): return -1;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("夷州"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 0;
                        case ("西域"): return -1;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("西域"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 0;
                        case ("絲路"): return -1;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("絲路"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 0;
                        case ("南中"): return -1;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("南中"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 0;
                        case ("西寧"): return -1;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("西寧"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 0;
                        case ("燕然"): return -1;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("燕然"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 0;
                        case ("高句麗"): return -1;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("高句麗"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 1;
                        case ("高句麗"): return 0;
                        case ("日本"): return -1;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("日本"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 1;
                        case ("高句麗"): return 1;
                        case ("日本"): return 0;
                        case ("高句麗日本"): return -1;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("高句麗日本"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 1;
                        case ("高句麗"): return 1;
                        case ("日本"): return 1;
                        case ("高句麗日本"): return 0;
                        case ("仙界"): return -1;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("仙界"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 1;
                        case ("高句麗"): return 1;
                        case ("日本"): return 1;
                        case ("高句麗日本"): return 1;
                        case ("仙界"): return 0;
                        case ("地獄"): return -1;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("地獄"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 1;
                        case ("高句麗"): return 1;
                        case ("日本"): return 1;
                        case ("高句麗日本"): return 1;
                        case ("仙界"): return 1;
                        case ("地獄"): return 0;
                        case ("聖誕村"): return -1;
                        default: return 0;
                    }
                case ("聖誕村"):
                    switch (y)
                    {
                        case ("進入遊戲"): return 1;
                        case ("新手村"): return 1;
                        case ("幽州"): return 1;
                        case ("冀州"): return 1;
                        case ("青州"): return 1;
                        case ("徐州"): return 1;
                        case ("并州"): return 1;
                        case ("遼東"): return 1;
                        case ("塞外"): return 1;
                        case ("淮南"): return 1;
                        case ("兗州"): return 1;
                        case ("司隸"): return 1;
                        case ("荊北"): return 1;
                        case ("關中"): return 1;
                        case ("益州"): return 1;
                        case ("涼州"): return 1;
                        case ("江東"): return 1;
                        case ("揚州"): return 1;
                        case ("荊南"): return 1;
                        case ("交州"): return 1;
                        case ("嶺南"): return 1;
                        case ("夷州"): return 1;
                        case ("西域"): return 1;
                        case ("絲路"): return 1;
                        case ("南中"): return 1;
                        case ("西寧"): return 1;
                        case ("燕然"): return 1;
                        case ("高句麗"): return 1;
                        case ("日本"): return 1;
                        case ("高句麗日本"): return 1;
                        case ("仙界"): return 1;
                        case ("地獄"): return 1;
                        case ("聖誕村"): return 0;
                        default: return 0;
                    }
                default: return 0;
            }
        }
    }
}
