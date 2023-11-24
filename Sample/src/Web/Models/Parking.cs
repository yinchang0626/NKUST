using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Parking : IComparable
    {
        public string 型式 { get; set; }
        public string 行政區 { get; set; }
        public string 場名 { get; set; }
        public string 位置 { get; set; }
        public string 大車 { get; set; }
        public string 小車 { get; set; }
        public string 機車 { get; set; }
        public string 收費標準 { get; set; }
        public string 管理業者 { get; set; }
        public string 聯絡電話 { get; set; }
        public string 履約起迄 { get; set; }
        public bool IsHasSpace
        {
            get
            {
                int.TryParse(機車, out int 機車數量);
                int.TryParse(小車, out int 小車數量);
                int.TryParse(大車, out int 大車數量);

                return
                    機車數量 > 0 ||
                    小車數量 > 0 ||
                    大車數量 > 0;
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var displayIsHasSpace = IsHasSpace ? "是" : "否";
            return $"停車場名稱:{場名}-{行政區},聯絡電話{聯絡電話},是否有空位:{displayIsHasSpace}";
        }
    }
}
