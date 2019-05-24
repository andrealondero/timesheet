using System.Windows.Input;

using timesheet.Helpers;
using timesheet.Views;

using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; private set; }
        public DashBoardViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LogoutCommand = new Command(() => ResetUserInfo());
        }
        void ResetUserInfo()
        {
            _navigation.PushAsync(new LoginPage());
            UserSettings.ClearAllData();
        }
    }
}
