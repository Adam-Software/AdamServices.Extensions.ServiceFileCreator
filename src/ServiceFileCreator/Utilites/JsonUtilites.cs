using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServiceFileCreator.Utilites
{
    internal static class JsonUtilites
    {
        private static readonly JsonSerializerOptions mJsonSerializerOptions = new();

        static JsonUtilites()
        {
            mJsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            mJsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
            mJsonSerializerOptions.WriteIndented = true;
            mJsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }

        internal static async Task<T> ReadJsonFileAsync<T>(string path, string fileName) where T : class, new()
        {
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                return new T();
            }

            string jsonString = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(jsonString, mJsonSerializerOptions);
        }

        internal static async Task SaveJsonFilesAsync<T>(T content, string path, string fileName) where T : class
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, fileName);

            string jsonString = JsonSerializer.Serialize(content, mJsonSerializerOptions);
            await File.WriteAllTextAsync(filePath, jsonString);
        }
    }
}
