using FluentValidation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;

using timesheet.Models;
using timesheet.Validator;
using timesheet.ViewModels;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public TsItems Item { get; set; }
        public IValidator _itemValidator;      
        AddItemViewModel viewModel;
        public AddItemPage(ItemPageViewModel viewModel)
        {
            InitializeComponent();
            _itemValidator = new ItemValidator();
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
            viewModel = new AddItemViewModel(Navigation);
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
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}