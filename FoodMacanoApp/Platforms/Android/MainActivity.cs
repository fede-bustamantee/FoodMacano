using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace FoodMacanoApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            // Assuming you want to call AuthenticateAsync instead
            Task.Run(async () =>
            {
                await WebAuthenticator.AuthenticateAsync(new Uri(data.Data.ToString()), new Uri($"com.googleusercontent.apps.{FoodMacanoApp.Properties.Resources.client_id}:/auth"));
            });
        }
    }
}