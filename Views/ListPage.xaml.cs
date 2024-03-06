
namespace MobileAppDevelopment.Views;

public partial class ListPage : ContentPage
{
	public ListPage(MoviesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetWatchedMoviesCommand.Execute(null);
    }
}