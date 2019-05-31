﻿using System;
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
            if (confirmedSwitch.IsVisible && refusedSwitch.IsVisible)
            {
                await DisplayAlert("ERROR", "Please choose CONFIRM OR REFUSE", "OK");
            }
            else
            {
                if (confirmedSwitch.IsVisible && !refusedSwitch.IsVisible || !confirmedSwitch.IsVisible && refusedSwitch.IsVisible)
                {
                    bool CreateItem = await Application.Current.MainPage.DisplayAlert("CONFIRM", "Save the timesheet?", "YES", "NO");
                    if (CreateItem)
                    {
                        var todoItem = (TsItems)BindingContext;
                        await App.Database.SaveItemAsync(todoItem);
                        await Navigation.PopAsync();
                    }
                }
            }
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}