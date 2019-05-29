using System;
using System.IO;

using timesheet.Helpers;
using timesheet.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace timesheet

{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        static DBHelper database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGray", Color.FromHex("E5E9EA"));
            Resources.Add("primaryDarkGray", Color.FromHex("2D2A2A"));
            Resources.Add("primaryAqua", Color.FromHex("83D3D4"));
            Resources.Add("primaryDarkAqua", Color.FromHex("2D8183"));
            Resources.Add("primaryRed", Color.FromHex("FF5657"));
            Resources.Add("primaryDarkRed", Color.FromHex("910C07"));

            var nav = new NavigationPage(new LoginPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryAqua"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }
        public static DBHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ManagerDB.db3"));
                }
                return database;
            }
        }
        public int ResumeAtTodoId { get; set; }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
