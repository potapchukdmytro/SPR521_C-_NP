using System.Text.Json;

namespace Patterns.Adapter
{
    public class AnalyzeLibrary
    {
        class DataBuisness
        {
            public string BudgetMax { get; set; }
            public string BudgetMin { get; set; }
        }

        public string AnalyzeData(string dataJson)
        {
            var data = JsonSerializer.Deserialize<DataBuisness>(dataJson);
            return $"BudgetMax: {data.BudgetMax}, BudgetMin: {data.BudgetMin}";
        }
    }
}
