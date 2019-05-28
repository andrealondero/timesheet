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
            BindingContext = new LoginPageViewModel(Navigation);
        }
    }
}