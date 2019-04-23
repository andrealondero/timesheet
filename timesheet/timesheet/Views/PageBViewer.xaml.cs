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
            listView.ItemsSource = await App.Database.GetAllItemsAsync();
        }

        async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex == 0)
            {
                pickerstatusLabel.Text = picker.Items[selectedIndex];
                listView.ItemsSource = await App.Database.GetItemsConfirmedAsync();
            }

            else if (selectedIndex == 1)
            {
                pickerstatusLabel.Text = picker.Items[selectedIndex];
                listView.ItemsSource = await App.Database.GetItemsRefusedAsync();
            }

            else if (selectedIndex == 2)
            {
                pickerstatusLabel.Text = picker.Items[selectedIndex];
                listView.ItemsSource = await App.Database.GetItemsSuspendedAsync();
            }

            else if (selectedIndex == 3)
            {
                pickerstatusLabel.Text = picker.Items[selectedIndex];
                listView.ItemsSource = await App.Database.GetAllItemsAsync();
            }
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

        /*switch (selectedIndex)
        {
            case 1:
                listView.ItemsSource = App.Database.GetItemsConfirmedAsync();
                pickerstatusLabel.Text = picker.Items[selectedIndex];
                break;
            case 2:
                Console.WriteLine("Case 2");
                break;
            default:
                Console.WriteLine("Default case");
                break;
                if (selectedIndex == 0)
                {
                    ((App)App.Current).ResumeAtTodoId = -1;
                    listView.ItemsSource = App.Database.GetItemsConfirmedAsync();
                    pickerstatusLabel.Text = picker.Items[selectedIndex];
                }*/
    }
}