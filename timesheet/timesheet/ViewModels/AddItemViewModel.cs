using System;
using timesheet.Models;
using timesheet.Services;
using timesheet.Validator;

using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {
        public AddItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _itemValidator = new ItemValidator();
            _itemRepository = new TitemsRepository();
            _items = new TsItems();           
        }


    }
}
