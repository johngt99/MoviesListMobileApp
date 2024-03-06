using MobileAppDevelopment.Services;
using MobileAppDevelopment.Views;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MobileAppDevelopment.ViewModels;

public partial class MoviesViewModel : BaseViewModel 
{
    Movie movie { get; set; }    
    List<Movie> movies = null;
    public ObservableCollection<Movie> WatchedMovies  { get; set; } = new ();
    public ObservableCollection<Movie> Movies { get; set; } = new();
    MovieService movieService;
    public ICommand ClearCommand { get; }

    public  ICommand PerformSearch => new Command<string>((string query) =>
    {
        
        IEnumerable<Movie> FilteredMovies = movies;        
        FilteredMovies = FilteredMovies.Where(movies => movies.Title.ToUpper().Contains(query.ToUpper()));
        List<Movie> filteredList = FilteredMovies.ToList();
               

        if (filteredList.Count != 0 || query != null)
        {
            Movies.Clear();
            foreach (var movie in filteredList)
                Movies.Add(movie);
        }

    });

    private void ExecuteClearCommand()
    {
        
        Movies.Clear();
        foreach (var movie in movies)
            Movies.Add(movie);
        
    }
   
    public MoviesViewModel(MovieService movieService)
    {
        Title = "Movie List";
        this.movieService = movieService;
        ClearCommand = new Command(ExecuteClearCommand);

    }
    
    [ICommand]
    async Task GoToDetailsAsync(Movie movie)
    {
        if (movie == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Movie", movie}
            });
    }

    [ICommand]
    async Task GetMoviesAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            movies = await movieService.GetMovies();

            if (Movies.Count != 0)
                Movies.Clear();

            foreach (var movie in movies)
                Movies.Add(movie);

       
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    [ICommand]
    async Task GetWatchedMoviesAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            movies = await movieService.GetMovies();

            if (WatchedMovies.Count != 0)
                Movies.Clear();

            foreach (var movie in movies)
                if(Convert.ToBoolean(movie.Watched) != false)
                WatchedMovies.Add(movie);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


}
