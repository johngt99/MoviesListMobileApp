namespace MobileAppDevelopment.Views;

public partial class DetailsPage : ContentPage
{
    
	public DetailsPage(MovieDetailsViewModel viewModels)
	{
		InitializeComponent();
		BindingContext = viewModels;
	}

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }


}