using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardSuperPage : ContentPage
    {
        public DashBoardSuperPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel(Navigation);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}