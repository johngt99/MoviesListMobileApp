using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MobileAppDevelopment.Services;

public class MovieService
{
    public MovieService()
    {
       
    }

    public async Task<List<Movie>> GetMovies()
    {

        using var stream = await FileSystem.OpenAppPackageFileAsync("moviefile.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        return JsonConvert.DeserializeObject<List<Movie>>(contents);

    }
}
