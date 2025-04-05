using Binance.Net.Clients;
using Binance.Net.Enums;
using CriptoPage.Model;
using CryptoExchange.Net.CommonObjects;

namespace CriptoPage.Infra
{
    public static class BinanceApiService
    {
        public static async Task<CoinData> BtcCotacaoDiaria()
        {
            using var client = new BinanceRestClient();

            var symbol = "BTCBRL";

            // Preço atual
            var currentPriceResult = await client.SpotApi.ExchangeData.GetTickerAsync(symbol);

            client.Dispose();

            return new CoinData
            {
                Date = DateTime.UtcNow,
                Last_Price_Data = (double)currentPriceResult.Data.LastPrice,
                PercentVariation = (double)currentPriceResult.Data.PriceChangePercent,
                Name = "Bitcoin",
                Symbol = symbol
            };


        }

        public static async Task<CoinData> CotacaoRealUsdt()
        {
            using var client = new BinanceRestClient();
            var symbol = "USDTBRL";

            // Preço atual
            var currentPriceResult = await client.SpotApi.ExchangeData.GetTickerAsync(symbol);

            client.Dispose();

            return new CoinData
            {
                Date = DateTime.UtcNow,
                Last_Price_Data = (double)currentPriceResult.Data.LastPrice,
                PercentVariation = (double)currentPriceResult.Data.PriceChangePercent,
                Name = "Bitcoin",
                Symbol = symbol
            };
        }
    }
}
