using System;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;

namespace timesheet.Views
{
    public partial class ItemPage : ContentPage
    {
        public TsItems Item { get; set; }
        ItemPageViewModel viewModel;
        public ItemPage(ItemPageViewModel viewModel)
        {
            Init();
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ItemPage()
        {
            InitializeComponent();
            Item = new TsItems
            {
                ID = 1,
                User_ID = 1,
                Date = DateTime.Now,
                Hours = 0,
                Description = "your activities here",
                ConfirmedStatus = false,
                RefusedStatus = false,
            };
            viewModel = new ItemPageViewModel(Item);
            BindingContext = viewModel;
        }

        public void Init()
        {
            datePicker.DateSelected += (s, e) => hoursEntry.Focus();
            hoursEntry.Completed += (s, e) => descriptionEditor.Focus();
            descriptionEditor.Completed += (s, e) => OnSaveClicked(s, e);
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hoursEntry.Text))
            {
                await DisplayAlert("Compiling error", "Insert worked hours number", "OK");
            }
            if (String.IsNullOrEmpty(descriptionEditor.Text))
            {
                await DisplayAlert("Compiling error", "Insert activities description", "OK");
            }
            else
            {
                if (!String.IsNullOrEmpty(hoursEntry.Text) && !String.IsNullOrEmpty(descriptionEditor.Text))
                {
                    bool CreateItem = await Application.Current.MainPage.DisplayAlert("MODIFY ITEM", "Save changes?", "YES", "NO");
                    if (CreateItem)
                    {
                        var item = (TsItems)BindingContext;
                        await App.Database.SaveItemAsync(item);
                        await Navigation.PushAsync(new ItemListPage
                        {
                            BindingContext = new TsItems()
                        });
                    }
                }
            }
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            bool CreateItem = await Application.Current.MainPage.DisplayAlert("DELETE ITEM", "Delete timesheet?", "YES", "NO");
            if (CreateItem)
            {
                var item = (TsItems)BindingContext;
                await App.Database.DeleteItemAsync(item);
                await Navigation.PopAsync();
            }
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}