using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViewExchangeCharts.Data
{
    public class ShareService
    {
        public List<TimeSeriesData> GetShare(string Symbol = "predefined")
        {
            if (string.IsNullOrWhiteSpace(Symbol))
            {
                throw new ArgumentException($"\"{nameof(Symbol)}\" darf nicht NULL oder ein Leerraumzeichen sein.", nameof(Symbol));
            }



            var exampleData = "";

            return ReadJsonToShare(); ;
        }

        private List<TimeSeriesData> ReadJsonToShare(string json = "")
        {
            using StreamReader file = File.OpenText(@"X:\Dev\Visual Studio Projekte\ViewExchangeCharts\ViewExchangeCharts\Data\exampleShareTimeSeriesData.json");
            using JsonTextReader reader = new(file);
            JObject? obj = JToken.ReadFrom(reader)?["Time Series (Daily)"] as JObject;
            List<TimeSeriesData> list = new();
            foreach (var share in obj)
            {
                TimeSeriesData data = new TimeSeriesData
                {
                    Date = DateTime.Parse(share.Key),
                    Close = share.Value["4. close"].ToString()
                };
                list.Add(data);
            }
            return list;

        }
    }
}
