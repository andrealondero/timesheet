using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public TsItems Item { get; set; }
        ItemPageViewModel viewModel;
        public AddItemPage(ItemPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public AddItemPage()
        {
            InitializeComponent();
            Item = new TsItems
            {
                Date = DateTime.Now,
                Hours = 0,
                Description = "Your activities here.",
                ConfirmedStatus = false,
                RefusedStatus = false,
                User_ID = 1,
                ID = 1
            };
            viewModel = new ItemPageViewModel(Item);
            BindingContext = viewModel;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hourseditor.Text))
            {
                await DisplayAlert("Compiling error", "Insert worked hours number", "OK");
            }
            if (String.IsNullOrEmpty(descriptioneditor.Text))
            {
                await DisplayAlert("Compiling error", "Insert activities description", "OK");
            }
            else
            {
                var item = (TsItems)BindingContext;
                await App.Database.SaveItemAsync(item);
                await Navigation.PushAsync(new ItemListPage

                {
                    BindingContext = new TsItems()
                });
            }
            /*var item = (TsItems)BindingContext;
            await App.Database.SaveItemAsync(item);
            await Navigation.PushAsync(new ItemListPage

            {
                BindingContext = new TsItems()
            });*/
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}