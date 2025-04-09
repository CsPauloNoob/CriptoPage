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

        public static async Task<CoinData> CotacaoBtcDataEspecifica(DateTime data)
        {
            using var client = new BinanceRestClient();
            var symbol = "BTCBRL";

            // Obtendo dados históricos
            var historicalDataResult = await client.SpotApi.ExchangeData.GetKlinesAsync(symbol, KlineInterval.OneDay, startTime: data, endTime: data.AddDays(1));

            if (!historicalDataResult.Success || historicalDataResult.Data.Count() == 0)
            {
                throw new Exception("Não foi possível obter os dados históricos para a data especificada.");
            }

            var kline = historicalDataResult.Data.First();

            client.Dispose();

            return new CoinData
            {
                Date = data,
                Last_Price_Data = (double)kline.ClosePrice,
                FirstDayPrice = (double)kline.OpenPrice,
                PercentVariation = (double)((kline.ClosePrice - kline.OpenPrice) / kline.OpenPrice * 100),
                Name = "Bitcoin",
                Symbol = symbol
            };
        }
    }
}
