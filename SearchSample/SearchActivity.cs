using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace SearchSample
{
    [Activity(Label = "@string/app_label", LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionSearch, Intent.ActionView , "com.google.android.gms.actions.SEARCH_ACTION" }, 
        Categories = new []{Intent.CategoryDefault})]
    [MetaData("android.app.searchable", Resource = "@xml/searchable")]
    public class SearchActivity : Activity
    {
        private TextView _queryTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Search);

            _queryTextView = FindViewById<TextView>(Resource.Id.query);

            HandleIntent(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            HandleIntent(intent);
        }

        private void HandleIntent(Intent intent)
        {
            if (Intent.ActionSearch != intent.Action && 
                "com.google.android.gms.actions.SEARCH_ACTION" != intent.Action)
                return;
            var query = intent.GetStringExtra(SearchManager.Query);
            _queryTextView.Text = query;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.search, menu);

            var searchManager = (SearchManager)GetSystemService(SearchService);
            var searchView = menu.FindItem(Resource.Id.search).ActionView.JavaCast<SearchView>();
            searchView.SetSearchableInfo(searchManager.GetSearchableInfo(ComponentName));

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.search:
                    OnSearchRequested();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}