using System;
using System.IO;
using timesheet.Helpers;
using timesheet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet
{
    public partial class App : Application
    {
        static DBHelper database;
        public App()
        {
            InitializeComponent();
            Resources = new ResourceDictionary();
            Resources.Add("primaryGray", Color.FromHex("E5E9EA"));
            Resources.Add("primaryDarkGray", Color.FromHex("2D2A2A"));
            Resources.Add("primaryAqua", Color.FromHex("83D3D4"));
            Resources.Add("primaryDarkAqua", Color.FromHex("2D8183"));
            Resources.Add("primaryRed", Color.FromHex("FF5657"));
            Resources.Add("primaryDarkRed", Color.FromHex("910C07"));

            var nav = new NavigationPage(new PageBViewer());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryRed"];
            nav.BarTextColor = Color.White;
             
            MainPage = nav;
        }

        public static DBHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ManagerDB.db"));
                }
                return database;
            }
        }

        public int ResumeAtTimesheetId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
