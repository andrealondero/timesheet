using System;
using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{
    public partial class PageBViewer : ContentPage
    {

        public PageBViewer()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageACompiler
            {
                BindingContext = new TsItems()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PageACompiler
                {
                    BindingContext = e.SelectedItem as TsItems
                });
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                pickerstatusLabel.Text = picker.Items[selectedIndex];
            }
        }
    }
}