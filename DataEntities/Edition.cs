using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class Edition
    {
        public string Year { get; set; }
        public string[] DayPrices { get; set; }
        public string CombiPrice { get; set; }
        public string[] CampingPrices { get; set; }
        public string[] CouponPrices { get; set; }

        public Edition()
        {
            Year = "";
            DayPrices = new string[0];
            CombiPrice = "";
            CampingPrices = new string[0];
            CouponPrices = new string[0];
        }

        public Edition(string Year, string [] DayPrices, string CombiPrice, string[] CampingPrices, string[] CouponPrices)
        {
            this.Year = Year;
            this.DayPrices = DayPrices;
            this.CombiPrice = CombiPrice;
            this.CampingPrices = CampingPrices;
            this.CouponPrices = CouponPrices;
        }

        public void CheckEmptyValues()
        {
            for (int i = 0; i < 4; i++) if (string.IsNullOrEmpty(DayPrices[i])) DayPrices[i] = "/";
            if (string.IsNullOrEmpty(CombiPrice)) CombiPrice = "/";
            for (int i = 0; i < 2; i++) if (string.IsNullOrEmpty(CampingPrices[i])) CampingPrices[i] = "/";
            for (int i = 0; i < 2; i++) if (string.IsNullOrEmpty(CouponPrices[i])) CouponPrices[i] = "/";
        }
    }
}
