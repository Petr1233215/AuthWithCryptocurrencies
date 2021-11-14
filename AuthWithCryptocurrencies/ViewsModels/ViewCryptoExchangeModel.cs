using AuthWithCryptocurrencies.Models;
using AuthWithCryptocurrencies.Models.Exhange;

namespace AuthWithCryptocurrencies.ViewsModels
{
    public class ViewListingExchangeModel
    {
        public ListingExchangeModelMain ListingExchangeModelMain { get; set; }

        public FilterBase Filter { get; set; }
    }
}
