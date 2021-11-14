using AuthWithCryptocurrencies.Models.Exhange;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Test
{
    //Тестовый проект для взаимодействия с api
    class Program
    {
        private const string API_KEY = "";
        static void Main(string[] args)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            var str = client.DownloadString(URL.ToString());

            //var jObject = JObject.Parse(str);
            //var results = jObject["data"].Children().Select(c => ((JObject)c)["quote"]["USD"]["price"].ToString()).ToList();

            //foreach (var res in results)
            //{
            //    Console.WriteLine(res);
            //}

            var obj = JsonConvert.DeserializeObject<ListingExchangeModelMain>(str).Data
                .Select(c => new KeyValuePair<int, ListingExhangeModel>(c.Id, c))
                .ToDictionary(c => c.Key, c => c.Value);


            URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info");

            queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["id"] = String.Join(",", new string[] { "1", "2", "3" });
            URL.Query = queryString.ToString();

            str = client.DownloadString(URL.ToString());

            //var songs = JObject.Parse(str)["data"].Children();

            //foreach (JProperty song in songs)
            //{
            //    if (!Int32.TryParse(song.Name, out int id)) continue;
            //    Console.WriteLine("Song " + song.Name + " artist: " + song.Value["id"]);
            //    Console.WriteLine("Song " + song.Name + " title: " + song.Value["id"]);
            //}

            var obj2 = JsonConvert.DeserializeObject<InfoExchangeModel>(str);

            //var oo = JsonConvert.DeserializeObject<Dictionary<int, string>>(songs);
        }
    }
}
