namespace ViewExchangeCharts.Data
{
    public class Share
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public TimeSeriesData Data { get; set; }
    }

    public struct TimeSeriesData
    {
        public DateTime Date;
        public string Close;
    }
}
