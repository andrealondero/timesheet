using System;
using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{   
    public class HomePageLoginCS : ContentPage
    {
        Entry usernameEntry, passwordEntry;
        Label messageLabel;
        public HomePageLoginCS()
        {
            messageLabel = new Label();
            usernameEntry = new Entry
            {
                Placeholder = "username"
            };
            passwordEntry = new Entry
            {
                IsPassword = true
            };
            var loginButton = new Button
            {
                Text = "LOGIN"
            };
            loginButton.Clicked += OnLoginButtonClicked;

            Title = "Login";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "Username" },
                    usernameEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                    loginButton,
                    messageLabel
                }
            };
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new Users
            {
                Mail = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new DashBoardPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(Users user)
        {
            return user.Mail == "andrea.londero" && user.Password == "aryonsolutions";
        }
    }
}