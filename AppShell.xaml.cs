using MobileAppDevelopment.ViewModels;
using MobileAppDevelopment.Views;

namespace MobileAppDevelopment;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

		
		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
	}
}
