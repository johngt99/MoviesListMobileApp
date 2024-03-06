using MobileAppDevelopment.Services;
using System.Windows.Input;

namespace MobileAppDevelopment.ViewModels;

[QueryProperty("Movie", "Movie")]
public partial class MovieDetailsViewModel : BaseViewModel
{
    MovieService movieService;
    public ICommand ExecuteFlag { get; }
    public MovieDetailsViewModel() 
    {
        movieService = new MovieService();
        ExecuteFlag = new Command(Flag);
    }

    [ObservableProperty]
    Movie movie;

    public void Flag()
    {
        if (movie != null) 
        {
            if(Convert.ToBoolean(movie.Watched) != true) 
            {
                movie.Watched = "True";
            }
            else
            {
                movie.Watched = "False";
            }          
            
        }        
    }
}
