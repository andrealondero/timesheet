using System;
using System.Threading.Tasks;
using System.Windows.Input;
using timesheet.Models;
using timesheet.Services;
using timesheet.Validator;
using timesheet.Views;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class ItemPageViewModel : BaseViewModel
    {
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        //public TsItems Item { get; set; }
        /*public ItemPageViewModel(TsItems item = null)
        {
            Item = item;
        }*/
        public ItemPageViewModel(INavigation navigation, int selectedID)
        {
            _navigation = navigation;
            _itemValidator = new ItemValidator();
            _items = new TsItems
            {
                ID = selectedID
            };
            _itemRepository = new TitemsRepository();

            UpdateCommand = new Command(async () => await UpdateItem());
            DeleteCommand = new Command(async () => await DeleteItem());

            FetchItemDetails();
        }
        void FetchItemDetails()
        {
            _items = _itemRepository.GetItem(_items.ID);
        }

        async Task UpdateItem()
        {
            _itemRepository.SaveItem(_items);
            _navigation.InsertPageBefore(new ItemListPage(),
                _navigation.NavigationStack[_navigation.NavigationStack.Count - 3]);
            await _navigation.PopAsync();
        }
        async Task DeleteItem()
        {
            bool CreateItem = await Application.Current.MainPage.DisplayAlert("DELETE ITEM", "Delete timesheet?", "YES", "NO");
            if (CreateItem)
            {
                _itemRepository.DeleteItem(_items.ID);
                await _navigation.PopAsync();
            }
        }
    }
}
