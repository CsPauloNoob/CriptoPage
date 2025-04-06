namespace CriptoPage.Model
{
    public class CoinData
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        //Ultimo preço do dia
        public double Last_Price_Data { get; set; }
        //Primeiro preço do dia
        public double? FirstDayPrice { get; set; }
        public double PercentVariation { get; set; }
    }
}
