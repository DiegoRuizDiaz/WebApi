using Newtonsoft.Json;
using WebApi.Repository.Models;
namespace WebApi.Service
{
    public class CategoriasService
    {
        private readonly string _jsonPath;
        public CategoriasService()
        {
            _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Repository\\Data\\", "data.json");
        }

        public async Task<CategoriasResponse?> GetCategorias()
        {
            if (!File.Exists(_jsonPath))
            {
                return null;
            }

            var json = await File.ReadAllTextAsync(_jsonPath);           

            return JsonConvert.DeserializeObject<CategoriasResponse>(json);
        }
    }
}
