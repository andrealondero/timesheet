using System;
using timesheet.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class DashBoardPage : ContentPage

    {
        public static bool GetuserAsync { get; set; }
        public static bool GetsupeuserAsync { get; set; }
        public DashBoardPage()

        {
            InitializeComponent();
            BindingContext = new HomePageLogin();
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new HomePageLogin(), this);
            await Navigation.PopAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            if (!GetuserAsync)
            {
                await Navigation.PushAsync(new AddItemPage
                {
                    BindingContext = new TsItems()
                });
            }
            else
            {
                await DisplayAlert("Your Logged as", $"superuser", "OK");
            }
        }

        async void ViewerButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemListPage
            {
                BindingContext = new Users()
            });
        }

        async void ConfirmationButton(object sender, EventArgs e)
        {
            var superuser = new Users
            {
                Mail = "paolo.loconsole",
                Password = "supervisore"
            };

            var issuperuser = SuperuserLogged(superuser);
            if (issuperuser)
            {
                await Navigation.PushAsync(new ConfirmationListPage
                {
                    BindingContext = new Users()
                });
            }
            else
            {
                await DisplayAlert("You can't access this page", $"Maybe you're not a superuser", "OK");
            }
        }

        bool SuperuserLogged(Users superuser)
        {
            return superuser.Mail == "paolo.loconsole" && superuser.Password == "supervisore";
        }
    }
}