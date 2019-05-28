using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new LoginPageViewModel(Navigation);
        }

        private void IsPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (isPassword.IsToggled)
            {
                passwordEntry.IsPassword = false;
            }
            if (!isPassword.IsToggled)
            {
                passwordEntry.IsPassword = true;
            }
        }
    }
}