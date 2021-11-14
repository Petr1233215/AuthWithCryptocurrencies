using AuthWithCryptocurrencies.Helpers;
using AuthWithCryptocurrencies.Models;
using AuthWithCryptocurrencies.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace AuthWithCryptocurrencies.Controllers
{
    public class ExchangeController : Controller
    {
        public IActionResult Index(FilterBase filter)
        {
            filter = filter ?? new FilterBase();

            var viewExchangeModel = new ViewListingExchangeModel
            {
                ListingExchangeModelMain = ExhangeHelper.GetListingData(filter),
                Filter = filter
            };

            return View(viewExchangeModel);
        }
    }
}
