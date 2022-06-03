using System.Text.Json;

namespace DinoSoft.CuCounters.Data.Infrastructure
{
    [Obsolete("Больше не используется. Можно удалить")]
    public class DataContextProvider
    {
        private readonly string fileName;
        public DataContextProvider()
        {
            fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db");
        }

        public DataContext DataContext
        {
            get
            {
                if (File.Exists(fileName))
                {
                    var json = File.ReadAllText(fileName);
                    return JsonSerializer.Deserialize<DataContext>(json);
                }
                var mainData = new DataContext();
                Save(mainData);
                return mainData;
            }
        }

        public void Save(DataContext mainData)
        {
            string json = JsonSerializer.Serialize(mainData);
            File.WriteAllText(fileName, json);
        }

    }
}
