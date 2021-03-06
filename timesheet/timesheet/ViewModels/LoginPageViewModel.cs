﻿using System.Windows.Input;
using timesheet.Helpers;
using timesheet.Models;
using timesheet.Views;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand CompilerUserCommand { get; private set; }
        public ICommand ViewerUserCommand { get; private set; }
        public ICommand ConfirmationSuperuserCommand { get; private set; }

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCommand = new Command(() => UpdateUserInfo());
            LogoutCommand = new Command(() => ResetUserInfo());
            CompilerUserCommand = new Command(() => GoToAddItem());
            ViewerUserCommand = new Command(() => GoToListItem());
            ConfirmationSuperuserCommand = new Command(() => GoToConfirmItem());
        }
        public void GoToAddItem()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsUser = UserUser(userCredits);
            if (IsUser)
            {
                UserSettings.GetUserData();
                _navigation.PushAsync(new Views.AddItemPage());
            }
        }
        public void GoToListItem()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsUser = UserUser(userCredits);
            if (IsUser)
            {
                UserSettings.GetUserData();
                _navigation.PushAsync(new Views.ItemListPage());
            }
        }
        public void GoToConfirmItem()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsSuperUser = SuperUserUser(userCredits);
            if (IsSuperUser)
            {
                UserSettings.GetSuperuserData();
                _navigation.PushAsync(new Views.ConfirmationListPage());
            }
        }
        public void UpdateUserInfo()
        {
            var userCredits = new Users
            {
                Mail = UserSettings.Mail,
                Password = UserSettings.Password
            };
            var IsUser = UserUser(userCredits);
            var IsSuperUser = SuperUserUser(userCredits);
            if (IsUser && !IsSuperUser)
            {
                UserSettings.GetUserData();
                _navigation.PushAsync(new Views.DashBoardPage());
            }
            else if (!IsUser && IsSuperUser)
            {
                UserSettings.GetSuperuserData();
                _navigation.PushAsync(new Views.DashBoardPage());
            }
        }
        bool UserUser(Users user)
        {
            return user.Mail == "andrea.londero" && user.Password == "aryonsolutions";
        }
        bool SuperUserUser(Users user)
        {
            return user.Mail == "paolo.loconsole" && user.Password == "supervisore";
        }
        void ResetUserInfo()
        {
            _navigation.PushAsync(new LoginPage());
            UserSettings.ClearAllData();
        }
    }
}
