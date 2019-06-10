﻿using Plugin.InputKit.Shared.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationListPage : ContentPage
    {
        public TsItems Item { get; set; }
        AddItemViewModel viewModel;
        List<TsItems> Items;
        private ObservableCollection<DBHelper> items;

        public ConfirmationListPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            ItemsList();
        }
        public void ItemsList()
        {
            Items = new List<TsItems>();
            Items.Add(new TsItems
            {
                ID = 1,
                User_ID = 1,
                Hours = 0,
                Description = "your activities",
                ConfirmedStatus = false,
                RefusedStatus = false,
                Date = DateTime.Now
            });
            listView.ItemsSource = Items;
        }

        async void Radio_SelectedItemChanged(object sender, EventArgs e)
        {
            var button = (RadioButtonGroupView)sender;
            int selectedIndex = button.SelectedIndex;

            if (selectedIndex == 0)
            {
                listView.ItemsSource = App.Database.GetItemsConfirmed();
            }

            else if (selectedIndex == 1)
            {
                listView.ItemsSource = App.Database.GetItemsRefused();
            }

            else if (selectedIndex == 2)
            {
                listView.ItemsSource = App.Database.GetItemsSuspended();
            }

            else if (selectedIndex == 3)
            {
                listView.ItemsSource = App.Database.GetAllItems();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = App.Database.GetAllItems();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TsItems).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TsItems).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ConfirmationPage
                {
                    BindingContext = e.SelectedItem as TsItems
                });
            }
        }
    }
}