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
            var item = (TsItems)BindingContext;
            await App.Database.SaveItemAsync(item);
            await Navigation.PushAsync(new ItemListPage
            {
                BindingContext = new TsItems()
            });
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (TsItems)BindingContext;
            await App.Database.DeleteItemAsync(item);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void OnSpeakClicked(object sender, EventArgs e)
        {
            var item = (TsItems)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(item.Hours + " " + item.Description);
        }
    }
}