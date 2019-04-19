using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace timesheet.Views
{
    class PageBPicker : ContentPage
    {
        public PageBPicker()
        {
            Title = "Picker ItemsSource";

            var pickerList = new List<string>();
            pickerList.Add("CONFIRMED");
            pickerList.Add("REFUSED");
            pickerList.Add("SUSPENDED");

            var picker = new Picker { Title = "Select timesheet status", TitleColor = Color.Red };
            picker.ItemsSource = pickerList;

            Content = new StackLayout
            {
                Margin = new Thickness(20, 35, 20, 20),
                Children = {
                    new Label { Text = "Select timesheet status", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                    picker
                }
            };
        }
    }
}
