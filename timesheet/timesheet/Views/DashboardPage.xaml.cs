using System;
using timesheet.Models;
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
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageACompiler
            {
                BindingContext = new TsItems()
            });
        }

        async void ViewerButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageBViewer());
        }

        async void ConfirmationButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageCConfirmationList());
        }
    }
}