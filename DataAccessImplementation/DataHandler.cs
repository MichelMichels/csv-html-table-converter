using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using System.IO;

namespace DataAccessImplementation
{
    public class DataHandler
    {
        public List<String> ReadCSV()
        {
            List<String> lines = new List<string>();

            lines.AddRange(File.ReadAllLines(@"D:\Documents\rw_prices.csv"));

            return lines;
        }

        public void WriteHTML(List<Edition> editions)
        {
            using (StreamWriter file = new StreamWriter(@"D:\Documents\index.html"))
            {
                file.WriteLine("<!--");
                file.WriteLine("  Automatically generated HTML file");
                file.WriteLine("  @date 1/12/2015");
                file.WriteLine("  @author Michel Michels");
                file.WriteLine("-->");
                file.WriteLine("<!DOCTYPE html>");
                file.WriteLine("<html>");
                file.WriteLine("<head>");
                file.WriteLine("    <title>Prijzen historiek Rock Werchter</title>");
                file.WriteLine("    <link rel=\"stylesheet\" type=<\"text / css\" href=\"style.css\">");
                file.WriteLine("</head>");
                file.WriteLine("<body>");
                file.WriteLine("    <h1>Prijzen historiek Rock Werchter (2004 - 2016)</h1>");
                file.WriteLine("    <table>");
                file.WriteLine("        <thead>");
                file.WriteLine("            <tr>");
                file.WriteLine("                <th><div class=\"width-hack\">Jaargang</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Donderdag</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Vrijdag</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Zaterdag</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Zondag</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Combi</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Camp VVK</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Camp ADD</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Bon VVK</div></th>");
                file.WriteLine("                <th><div class=\"width-hack\">Bon ADD</div></th>");
                file.WriteLine("            </tr>");
                file.WriteLine("        </thead>");
                file.WriteLine("        <tbody>");
                
                foreach(var ed in editions)
                {
                    ed.CheckEmptyValues();

                    file.WriteLine("            <tr>");
                    file.WriteLine("                <td class=\"year\"><div class=\"width-hack\">{0}</div></td>", ed.Year);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.DayPrices[0]);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.DayPrices[1]);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.DayPrices[2]);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.DayPrices[3]);
                    file.WriteLine("                <td><div class=\"width-hack combi\">&euro; {0}</div></td>", ed.CombiPrice);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.CampingPrices[0]);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.CampingPrices[1]);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.CouponPrices[0]);
                    file.WriteLine("                <td><div class=\"width-hack\">&euro; {0}</div></td>", ed.CouponPrices[1]);
                    file.WriteLine("            </tr>");
                    file.WriteLine();
                }

                file.WriteLine("        </tbody>");
                file.WriteLine("    </table>");
                file.WriteLine("</body>");
                file.WriteLine("</html>");
            }
        }
    }
}
