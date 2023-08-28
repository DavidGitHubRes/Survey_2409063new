namespace Survey_2409063;

public partial class App : Application
{
    public static string DBPath { get; private set; }
    public static SurveyDatabase Database { get; private set; }
    public App()
	{
		InitializeComponent();

        DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Surveys.db3");
        Database = new SurveyDatabase(DBPath);

        MainPage = new NavigationPage(new SurveyView());
    }
}
