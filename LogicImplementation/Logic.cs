using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using DataAccessImplementation;
using System.Text.RegularExpressions;

namespace LogicImplementation
{
    public class Logic
    {
        public List<Edition> Editions = new List<Edition>();
        public DataHandler backend = new DataHandler();

        public void parseEditionsFromList()
        {
            // get array of strings
            List<string> lines = backend.ReadCSV();

            foreach (var line in lines)
            {
                string[] singleStrings = line.Split(';');

                if (singleStrings[0] == "") continue;

                Edition ed = new Edition();

                //                                    0   1   2   3   4   5      6       7      8      9
                // strings are formatted like this: year thu fri sat sun comb campvvk campadd bonvvk bonadd
                ed.Year = singleStrings[0];
                ed.DayPrices = new string[] { singleStrings[1], singleStrings[2], singleStrings[3], singleStrings[4] };
                ed.CombiPrice = singleStrings[5];
                ed.CampingPrices = new string[] { singleStrings[6], singleStrings[7] };
                ed.CouponPrices = new string[] { singleStrings[8], singleStrings[9] };

                string allowedChars = "0123456789,./()XLcashkrt ";
                // filter out any non numbers
                ed.Year = new string(ed.Year.Where(c => allowedChars.Contains(c)).ToArray());
                for (int i = 0; i < 4; i++) ed.DayPrices[i] = new string(ed.DayPrices[i].Where(c => allowedChars.Contains(c)).ToArray());
                ed.CombiPrice = new string(ed.CombiPrice.Where(c => allowedChars.Contains(c)).ToArray());
                for (int i = 0; i < 2; i++) ed.CampingPrices[i] = new string(ed.CampingPrices[i].Where(c => allowedChars.Contains(c)).ToArray());
                for (int i = 0; i < 2; i++) ed.CouponPrices[i] = new string(ed.CouponPrices[i].Where(c => allowedChars.Contains(c)).ToArray());

                // add to list of editions
                Editions.Add(ed);
            }
        }

        public void writeFile()
        {
            backend.WriteHTML(Editions);
        }

        public static void main()
        {
            Logic logic = new Logic();
            logic.parseEditionsFromList();
            logic.writeFile();
        }
    }
}
