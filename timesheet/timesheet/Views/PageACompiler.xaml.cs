using System;
using timesheet.Helpers;
using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{
    public partial class PageACompiler : ContentPage
    {
        public PageACompiler()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (TsItems)BindingContext;
            await App.Database.SaveItemAsync(item);
            await Navigation.PushAsync(new PageBViewer

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