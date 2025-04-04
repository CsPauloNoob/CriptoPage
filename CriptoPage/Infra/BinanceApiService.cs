using Binance.Net.Clients;
using Binance.Net.Enums;
using CriptoPage.Model;
using CryptoExchange.Net.CommonObjects;

namespace CriptoPage.Infra
{
    public static class BinanceApiService
    {
        public static async Task<Btc_Brl_Diario> BtcCotacaoDiaria()
        {
            using var client = new BinanceRestClient();

            var symbol = "BTCBRL";

            // Preço atual
            var currentPriceResult = await client.SpotApi.ExchangeData.GetPriceAsync(symbol);

            // Preço de 24h atrás (via candle de 1 dia atrás)
            //var yesterday = DateTime.UtcNow.Date.AddDays(-1);
            //var candleResult = await client.SpotApi.ExchangeData.GetKlinesAsync(
            //    symbol,
            //    KlineInterval.OneDay,
            //    yesterday,
            //    yesterday.AddDays(1),
            //    1
            //);
            client.Dispose();
            return new Btc_Brl_Diario { Date = DateTime.UtcNow, Close = (double)currentPriceResult.Data.Price, Name = "Bitcoin", Symbol = symbol };

        }

        public static async Task<double> CotacaoRealUsdt()
        {
            using var client = new BinanceRestClient();
            var symbol = "USDTBRL";
            // Preço atual
            var currentPriceResult = await client.SpotApi.ExchangeData.GetPriceAsync(symbol);

            return (double)currentPriceResult.Data.Price;
        }
    }
}
