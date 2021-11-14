using System.Collections.Generic;

namespace AuthWithCryptocurrencies.Models.Exhange
{
    public class InfoExchangeModel
    {
        public Dictionary<int, DataInfoExchange> Data { get; set; }

        public class DataInfoExchange
        {
            public string Logo { get; set; }
        }
    }
}
