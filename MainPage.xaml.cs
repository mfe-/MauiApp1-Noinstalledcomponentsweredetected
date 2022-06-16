namespace MauiApp2;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    public static Page page;
    private void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            count++;
            CounterBtn.Text = $"Current count: {count}";
            SemanticScreenReader.Announce(CounterBtn.Text);
            if (App.Current.MainPage is NavigationPage navigationPage)
            {
                if (MainPage.page == null)
                {
                    MainPage.page = new NewGamePage();
                }
                navigationPage.CurrentPage.Navigation.PushAsync(MainPage.page);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex);
        }

    }
}

