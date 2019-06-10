using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using timesheet.Models;
using timesheet.Services;
using timesheet.Views;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ICommand NewCommand { get; private set; }
        public ListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _itemRepository = new TitemsRepository();

            NewCommand = new Command(async () => await AddItem());

            FetchItem();
        }
        void FetchItem()
        {
            ItemsList = _itemRepository.GetAllItems();
        }

        async Task AddItem()
        {
            await _navigation.PushAsync(new AddItemPage());
        }

        async void ShowItemDetail(int selectedItemID)
        {
            await _navigation.PushAsync(new ItemPage(selectedItemID));
        }
        TsItems _selectedItem;
        public TsItems SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                    ShowItemDetail(value.ID);
                }
            }
        }
    }
}
