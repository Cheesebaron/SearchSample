SearchSample
============

Just a quick Sample app showing how the Search Interface works.

"OK, Google" search functionality
=================================

According to [Jarek Wilkiewicz's][2] answer on [this thread on Google+][1], the function only works with apps that have been published to the Play Store, and not when creating a new app and debugging it. So to manually trigger the Intent you can issue the followin command in a CLI:

```
adb shell am start -a com.google.android.gms.actions.SEARCH_ACTION -e query foo <app package name here>
```

This isn't ideal at all, but it provides a way to test the intent out.

[1]: https://plus.google.com/+AndroidDevelopers/posts/afSRdDQiy1N
[2]: https://plus.google.com/115372405214595182619
