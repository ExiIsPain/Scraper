using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.IO;

namespace Scraper
{
    internal class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // vytáhne HTML doc
            var URL = "https://en.wikipedia.org/wiki/List_of_Monty_Python%27s_Flying_Circus_episodes";
            var client = new HttpClient();
            var response = await client.GetStringAsync(URL);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);
            //sepíše ho do souboru
            using (StreamWriter htmlTXT = new StreamWriter("html.txt"))
            {
                htmlTXT.WriteLine(response);    
            }
            //parsing
            var episodes = htmlDoc.DocumentNode.SelectNodes("//*[@class = 'summary']").ToList();
            using (StreamWriter htmlTXT = new StreamWriter("html_parsed.txt"))
            {
                //výstup
                foreach (var episode in episodes)
                {
                htmlTXT.WriteLine(episode.InnerText);
                }
                
            }


        }
    }
}
