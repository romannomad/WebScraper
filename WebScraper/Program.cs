using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {

        static void Main(String[] args)
        {
            //Send get request to wheather.com
            string url = "https://weather.com/weather/today/l/4c9ff75840c6ce23fa10812d0f14b605af47896e9ca3fd59abdb9edd1b9d486a";

            var httpClient = new HttpClient();
            string htmlContent = httpClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);

            //Get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--zUBSz']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            //Get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue---VS-k']");
            var conditions = conditionElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            //Get the location
            var cityElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--yub4l']");
            var city = cityElement.InnerText.Trim();
            Console.WriteLine("City: " + city);
        }
    }
}
