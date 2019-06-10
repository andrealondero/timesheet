﻿using FluentValidation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;

using timesheet.Models;
using timesheet.Validator;
using timesheet.ViewModels;
using timesheet.Services;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public TsItems Item { get; set; }      
        public AddItemPage()
        {
            InitializeComponent();
            Item = new TsItems
            {
                Date = DateTime.UtcNow,
                Hours = 0,
                Description = "Your activities here.",
                ConfirmedStatus = false,
                RefusedStatus = false,
                User_ID = 1,
                ID = 1
            };

            activateDate.IsVisible = true;
            activateDate.Focused += (sender, e) =>
            {
                datepicker.Focus();
            };
            datepicker.DateSelected += (sender, e) =>
            {
                dateLabel.Text = datepicker.Date.ToLongDateString();
            };

            BindingContext = new AddItemViewModel(Navigation);
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dateLabel.Text))
            {
                await DisplayAlert("Compiling error", "Select a date", "OK");
            }
            if (String.IsNullOrEmpty(hoursLabel.Text))
            {
                await DisplayAlert("Compiling error", "Insert worked hours number", "OK");
            }
            if (String.IsNullOrEmpty(descriptioneditor.Text))
            {
                await DisplayAlert("Compiling error", "Insert activities description", "OK");
            }
            else
            {
                if (!String.IsNullOrEmpty(hoursLabel.Text) && !String.IsNullOrEmpty(descriptioneditor.Text) && !String.IsNullOrEmpty(dateLabel.Text))
                {
                    bool CreateItem = await Application.Current.MainPage.DisplayAlert("NEW ITEM", "Add a new item?", "YES", "NO");
                    if (CreateItem)
                    {
                        /*var item = (TsItems)BindingContext;
                        App.Database.SaveItem(item);*/
                        //await Navigation.PushAsync(new ItemListPage());
                        var item = new TsItems();
                        App.Database.SaveItem(item);
                        Navigation.InsertPageBefore(new ItemListPage(),
                            Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                        await Navigation.PopAsync();
                    }
                }
            }
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            hoursLabel.Text = string.Format("{0}", value);
        }
        private void Datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateLabel.Text = e.NewDate.ToLongDateString();  
        }
    }
}