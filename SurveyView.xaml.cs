namespace Survey_2409063;

public partial class SurveyView : ContentPage
{
    SurveyDatabase _database;

    [Obsolete]
    public SurveyView()
    {
        InitializeComponent();
        _database = new SurveyDatabase(App.DBPath);
        MessagingCenter.Subscribe<ContentPage, Surveys>(this, Messages.NewSurveyComplete, (sender, args) =>
        {
            SurveysPanel.Children.Add(new Label() { Text = args.ToString() });
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        SurveysPanel.Children.Clear();

        var surveys = await _database.GetSurveysAsync();

        foreach (var survey in surveys)
        {
            var surveyLabel = new Label
            {
                Text = survey.ToString()
            };

            SurveysPanel.Children.Add(surveyLabel);
        }
    }
    private async void AddSurveyButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SurveyDetailsView());
    }

    private async void BorrarUltimo(object sender, EventArgs e)
    {
        var surveys = await _database.GetSurveysAsync();

        if (surveys.Count > 0)
        {
            var lastSurvey = surveys[surveys.Count - 1];
            await _database.BorrarLast(lastSurvey.Id); // Pasamos el ID del último registro

            // Opcional: Actualiza la vista después de borrar
            SurveysPanel.Children.Clear();
            var remainingSurveys = await _database.GetSurveysAsync();
            foreach (var survey in remainingSurveys)
            {
                var surveyLabel = new Label
                {
                    Text = survey.ToString()
                };
                SurveysPanel.Children.Add(surveyLabel);
            }
        }
    }

}