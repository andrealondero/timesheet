using System;

using timesheet.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static Action EmulateBackPressed;
        private bool AcceptBack;
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
        protected override bool OnBackButtonPressed()
        {
            if (AcceptBack)
                return false;
            PromptForExit();
            return true;
        }
        private async void PromptForExit()
        {
            if (await DisplayAlert("QUIT", "Are you sure?", "YES", "NO"))
            {
                AcceptBack = true;
                EmulateBackPressed();
            }
        }
    }
}