using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace SearchSample
{
    [Activity(Label = "@string/app_label", MainLauncher = true, Icon = "@drawable/icon")]
    [MetaData("android.app.default_searchable", Value = "searchsample.SearchActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate
            {
                var intent = new Intent(this, typeof (SearchActivity));
                StartActivity(intent);
            };
        }
    }
}

