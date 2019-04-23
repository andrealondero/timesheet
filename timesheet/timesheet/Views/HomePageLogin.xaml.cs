using System;
using timesheet.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageLogin : ContentPage
    {
        public HomePageLogin()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new Users
            {
                Mail = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreUserCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                await DisplayAlert("Your Logged as", $"user", "OK");
                Navigation.InsertPageBefore(new DashBoardPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }

            var isSuperuser = AreSuperuserCredentialsCorrect(user);
            if (isSuperuser)
            {
                App.IsUserLoggedIn = true;
                await DisplayAlert("Your Logged as", $"superuser", "OK");
                Navigation.InsertPageBefore(new DashBoardPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreUserCredentialsCorrect(Users user)
        {
            return user.Mail == "andrea.londero" && user.Password == "aryonsolutions";
        }

        bool AreSuperuserCredentialsCorrect(Users user)
        {
            return user.Mail == "paolo.loconsole" && user.Password == "supervisore";
        }
    }
}