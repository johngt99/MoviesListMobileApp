namespace MobileAppDevelopment.ViewModels
{
    public partial class AppShellViewModel :BaseViewModel
    {
        [ICommand]
        async void SignOut()
        {            
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
