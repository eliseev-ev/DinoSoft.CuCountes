using DinoSoft.CuCounters.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Data.Repository
{
    public class DataRepository
    {
        private readonly string fileName;
        public DataRepository()
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
