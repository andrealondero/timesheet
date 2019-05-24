using timesheet.Models;

namespace timesheet.ViewModels
{
    public class ItemPageViewModel : BaseViewModel
    {
        public TsItems Item { get; set; }
        public ItemPageViewModel(TsItems item = null)
        {
            Item = item;
        }
    }
}
