using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AuthWithCryptocurrencies.Models.Exhange
{
    public class ListingExchangeModelMain
    {
        public List<ListingExhangeModel> Data { get; set; }
    }

    public class ListingExhangeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string LogoLink { get; set; }

        public QuoteClass Quote { get; set; }

        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }

        public class QuoteClass
        {
            public USDClass USD { get; set; }

            public class USDClass
            {
                public double Price { get; set; }

                [JsonProperty("percent_change_24h")]
                public double PercentChange24h { get; set; }

                [JsonProperty("percent_change_1h")]
                public double PercentChange1h { get; set; }

                [JsonProperty("market_cap")]
                public double MarketCap { get; set; }
            }
        }
    }
}
