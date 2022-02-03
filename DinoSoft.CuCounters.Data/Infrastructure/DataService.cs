using System.Text.Json;
using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Data.Infrastructure
{
    public class DataService
    {
        private readonly string fileName;
        public DataService()
        {
            fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db");
        }

        public MainData GetMainData()
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<MainData>(json);
            }
            var mainData = new MainData();
            SaveMainData(mainData);
            return mainData;
        }

        public void SaveMainData(MainData mainData)
        {
            string json = JsonSerializer.Serialize(mainData);
            File.WriteAllText(fileName, json);
        }

    }
}
