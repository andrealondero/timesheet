using timesheet.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationListPage : ContentPage
    {

        public ConfirmationListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetAllItemsAsync();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TsItems).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TsItems).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ConfirmationPage
                {
                    BindingContext = e.SelectedItem as TsItems
                });
            }
        }
    }
}