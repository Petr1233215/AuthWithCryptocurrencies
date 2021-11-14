using AuthWithCryptocurrencies.Models;
using AuthWithCryptocurrencies.Models.Exhange;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AuthWithCryptocurrencies.Helpers
{
    public class ExhangeHelper
    {
        /// <summary>
        /// Ключ аутентификации для сайта: pro-api.coinmarketcap.com
        /// </summary>
        private const string API_KEY = "";

        /// <summary>
        /// Получаем объект webClient с установленным header'ом
        /// </summary>
        private static WebClient GetClient()
        {
            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");

            return client;
        }

        /// <summary>
        /// Получаем главную View model для отображения криптовалют
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="countElements">Количество элементов на странице</param>
        /// <returns>View model для отображения криптовалют</returns>
        public static ListingExchangeModelMain GetListingData(FilterBase filter)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var startIndex = (filter.Currentpage - 1) * filter.CountElementsOnPage + 1;

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = startIndex.ToString();
            queryString["limit"] = filter.CountElementsOnPage.ToString();
            queryString["convert"] = "USD";

            if (!string.IsNullOrEmpty(filter.ColumnName))
            {
                queryString["sort"] = filter.ColumnName;
                queryString["sort_dir"] = filter.Order.ToString();
            }

            URL.Query = queryString.ToString();

            var jsonStr = GetClient().DownloadString(URL.ToString());

            ListingExchangeModelMain listingExhangeModel = null;
            try
            {
                listingExhangeModel = JsonConvert.DeserializeObject<ListingExchangeModelMain>(jsonStr)
                    .AddInfoLogoLinkToListingExchange(GetClient());
            }
            catch (Exception)
            {

                //To-Do Вывести ошибку в какой-нибудь логер
            }

            return listingExhangeModel;
        }
    }

    public static class ListingExchangeModelView_Extension
    {
        /// <summary>
        /// Добавляем информацию о лого для криптовалюты, путем изменения объекта listingExhangeModel
        /// </summary>
        public static ListingExchangeModelMain AddInfoLogoLinkToListingExchange(this ListingExchangeModelMain listingExchangeModelView, WebClient client)
        {
            var logoLinks = GetLogoLinksById(listingExchangeModelView.Data.Select(c => c.Id.ToString()), client);

            listingExchangeModelView.Data.ForEach(c =>
            {
                if (logoLinks.TryGetValue(c.Id, out string logoLink))
                    c.LogoLink = logoLink;
            });

            return listingExchangeModelView;

        }

        /// <summary>
        /// Получаем ссылки на лого, для криптовалют
        /// </summary>
        /// <param name="idCrypto">Коллекия id-шников криптовалют</param>
        /// <returns>словарь, где ключ- это id, а значение - это лого</returns>
        private static Dictionary<int, string> GetLogoLinksById(IEnumerable<string> idCrypto, WebClient client)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["id"] = string.Join(",", idCrypto);
            URL.Query = queryString.ToString();

            var jsonStr = client.DownloadString(URL.ToString());

            return JsonConvert.DeserializeObject<InfoExchangeModel>(jsonStr).Data
                .ToDictionary(c => c.Key, c => c.Value.Logo);
        }
    }
}
