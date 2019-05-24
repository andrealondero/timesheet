using System.Windows.Input;
using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCommand = new Command(() => UpdateUserInfo());
        }
        public void UpdateUserInfo()
        {
            _navigation.PushAsync(new Views.DashBoardPage());
        }
    }
}
