namespace MobileAppDevelopment.Views;

public partial class HomePage : ContentPage
{
    public HomePage(MoviesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetMoviesCommand.Execute(null);
    }
}