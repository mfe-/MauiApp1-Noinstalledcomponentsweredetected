MauiApp1

Repo Steps:

1. create a new dotnet maui project with visual studio 2022
2. add a second contentpage (in this repo the name of the second contentpage is `NewGamePage.xaml`
3. In `App.xaml.cs` replace `MainPage = new MainPage()` with `MainPage = new NavigationPage(new MainPage());`
4. In `MainPage.xaml.cs` replace the content of `OnCounterClicked` with

```csharp
        public static Page page;
        private void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                count++;
                CounterLabel.Text = $"Current count: {count}";
                SemanticScreenReader.Announce(CounterLabel.Text);
                if (App.Current.MainPage is NavigationPage navigationPage)
                {
                    if (MainPage.page == null)
                    {
                        MainPage.page = new NewGamePage();
                    }
                    navigationPage.CurrentPage.Navigation.PushAsync(MainPage.page);
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }

        }
```
5. build and run the app on the windows platform
6. click on button `click me`
7. click left arrow back button
8. click again on `click me`
9. `App.g.i.cs` throws 
10. `exception: Catastrophic failure (0x8000FFFF (E_UNEXPECTED))
Microsoft.UI.Xaml.Controls.Frame.NavigationFailed was unhandled.`

If you use `navigationPage.CurrentPage.Navigation.PushAsync(new NewGamePage())` you won't run into the issue so it looks like it can't handle PushAsync with the same instance.


Navigation.PushAsync(); on windows platform throws exception: Catastrophic failure (0x8000FFFF (E_UNEXPECTED)) with same page instance. This issue don't occour on android.




{"No installed components were detected. (0x800F1000)"}

Stacktrace:
   at WinRT.ExceptionHelpers.ThrowExceptionForHR(Int32 hr)
   at ABI.Microsoft.UI.Xaml.Controls.IFrame.global::Microsoft.UI.Xaml.Controls.IFrame.Navigate(Type sourcePageType, Object parameter, NavigationTransitionInfo infoOverride)
   at Microsoft.UI.Xaml.Controls.Frame.Navigate(Type sourcePageType, Object parameter, NavigationTransitionInfo infoOverride)
   at Microsoft.Maui.NavigationManager.NavigateTo(NavigationRequest args)
   at Microsoft.Maui.Handlers.NavigationViewHandler.RequestNavigation(NavigationViewHandler arg1, INavigationView arg2, Object arg3)
   at Microsoft.Maui.CommandMapper`2.<>c__DisplayClass6_0.<Add>b__0(IElementHandler h, IElement v, Object o)
   at Microsoft.Maui.CommandMapper.InvokeCore(String key, IElementHandler viewHandler, IElement virtualView, Object args)
   at Microsoft.Maui.CommandMapper.Invoke(IElementHandler viewHandler, IElement virtualView, String property, Object args)
   at Microsoft.Maui.Handlers.ElementHandler.Invoke(String command, Object args)
   at Microsoft.Maui.Controls.NavigationPage.Microsoft.Maui.INavigationView.RequestNavigation(NavigationRequest eventArgs)
   at Microsoft.Maui.Controls.NavigationPage.<SendHandlerUpdateAsync>d__16.MoveNext()
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.GetResult()

