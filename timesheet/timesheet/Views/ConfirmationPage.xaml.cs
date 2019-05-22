using System;
using timesheet.Helpers;
using timesheet.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPage : ContentPage
    {

        public ConfirmationPage()
        {
            InitializeComponent();
        }

        private void RefusedSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (refusedSwitch.IsToggled)
            {
                confirmedSwitch.IsVisible = false;
            }
            if (!refusedSwitch.IsToggled)
            {
                confirmedSwitch.IsVisible = true;
            }

        }

        private void ConfirmedSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (confirmedSwitch.IsToggled)
            {
                refusedSwitch.IsVisible = false;
            }
            if (!confirmedSwitch.IsToggled)
            {
                refusedSwitch.IsVisible = true;
            }
        }

        async void OnSave(object sender, EventArgs e)
        {
            var todoItem = (TsItems)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void OnSpeakClicked(object sender, EventArgs e)
        {
            var todoItem = (TsItems)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(todoItem.Hours + " " + todoItem.Description);
        }
    }
}