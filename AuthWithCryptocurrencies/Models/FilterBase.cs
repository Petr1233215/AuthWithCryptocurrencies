using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthWithCryptocurrencies.Models
{
    public class FilterBase
    {
        public int Currentpage { get; set; } = 1;

        public int CountElementsOnPage { get; set; } = 10;

        public OrderEnum Order { get; set; } = OrderEnum.asc;

        public string ColumnName { get; set; }

        public enum OrderEnum
        {
            asc,
            desc
        }
    }
}
