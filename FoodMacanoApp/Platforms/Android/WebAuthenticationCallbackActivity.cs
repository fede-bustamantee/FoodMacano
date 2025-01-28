using Android.App;
using Android.Content.PM;

namespace FoodMacanoApp
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
        Categories = new[] {
            Android.Content.Intent.CategoryDefault,
            Android.Content.Intent.CategoryBrowsable
        },
        DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "com.googleusercontent.apps.112810612683-6ppus9qlp78lq6sf31v4c5cf122tj8rp";
    }
}