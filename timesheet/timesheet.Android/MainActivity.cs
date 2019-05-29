using Android.App;
using Android.Content.PM;
using Android.OS;
using timesheet.Views;

namespace timesheet.Droid
{
    [Activity(Label = "timesheet", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,

        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            DashBoardPage.EmulateBackPressed = OnBackPressed;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}