using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MobileAppDevelopment.Models;
using MobileAppDevelopment.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppDevelopment.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        [ICommand]
        public async void Login()
        {
            if(!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                if(UserName != "admin" || Password != "123")
                {
                    Console.WriteLine("User not found !!!");
                }
                else
                {
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                
            }
        }
    }
}
