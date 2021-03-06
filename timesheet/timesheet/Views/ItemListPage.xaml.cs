﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using timesheet.Helpers;
using timesheet.Models;
using timesheet.ViewModels;

using Xamarin.Forms;

namespace timesheet.Views
{
    public partial class ItemListPage : ContentPage
    {
        public TsItems Item { get; set; }
        ItemViewModel viewModel;
        List<TsItems> Items;
        private ObservableCollection<DBHelper> items;

        public ItemListPage()
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

        async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex == 0)
            {
                listView.ItemsSource = await App.Database.GetItemsConfirmedAsync();
            }

            else if (selectedIndex == 1)
            {
                listView.ItemsSource = await App.Database.GetItemsRefusedAsync();
            }

            else if (selectedIndex == 2)
            {
                listView.ItemsSource = await App.Database.GetItemsSuspendedAsync();
            }

            else if (selectedIndex == 3)
            {
                listView.ItemsSource = await App.Database.GetAllItemsAsync();
            }
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage
            {
                BindingContext = new TsItems()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*if (!(e.SelectedItem is TsItems item))
                return;
            await Navigation.PushAsync(new ItemPage(new ItemPageViewModel(item)));
            listView.SelectedItem = null;*/
            // errori di bindaggio dati, non posso poi salvare o modificare l'item nel db
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ItemPage
                {
                    BindingContext = e.SelectedItem as TsItems
                });
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetAllItemsAsync();
        }
    }
}