using System;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class DashBoardPage : ContentPage

    {
        public DashBoardPage()

        {
            InitializeComponent();
            BindingContext = new DashBoardViewModel(Navigation);
        }

        /*async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new HomePageLogin(), this);
            await Navigation.PopAsync();
        }*/

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage
            {
                BindingContext = new TsItems()
            });
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
            await Navigation.PushAsync(new ConfirmationListPage
            {
                BindingContext = new Users()
            });
        }
    }
}