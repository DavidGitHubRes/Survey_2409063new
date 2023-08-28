namespace Survey_2409063;

public partial class SurveyDetailsView : ContentPage
{
    private readonly string[] teams =
        {
            "Real Madrid",
            "Manchester City",
            "Inter Miami",
            "Al Nssr",
            "Dracos FC",
            "Napoli",
            "FC Barcelona",
            "Liverpool",
            "Brigthon",
        };

    SurveyDatabase _database;

    public SurveyDetailsView()
    {
        InitializeComponent();
        _database = new SurveyDatabase(App.DBPath);
    }

    private async void FavoriteTeamButton_Clicked(object sender, EventArgs e)
    {
        var favoriteTeam = await DisplayActionSheet(Literals.FavoriteTEamTittle, null, null, teams);
        if (!string.IsNullOrWhiteSpace(favoriteTeam))
        {
            FavoriteTeamLabel.Text = favoriteTeam;
        }
    }


    private async void SaveSurveyButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(FavoriteTeamLabel.Text))
        {
            return;
        }

        var newSurvey = new Surveys()
        {
            Name = NameEntry.Text,
            Birthdate = Birthdatepicker.Date,
            FavoriteTeam = FavoriteTeamLabel.Text
        };

        await _database.SaveSurveyAsync(newSurvey);

        MessagingCenter.Send((ContentPage)this,
            Messages.NewSurveyComplete, newSurvey);


        await Navigation.PopAsync();
    }

    private async void AcceptButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(FavoriteTeamLabel.Text))
        {
            return;
        }

        var newSurvey = new Surveys()
        {
            Name = NameEntry.Text,
            Birthdate = Birthdatepicker.Date,
            FavoriteTeam = FavoriteTeamLabel.Text
        };

        await _database.SaveSurveyAsync(newSurvey);

        MessagingCenter.Send((ContentPage)this,
        Messages.NewSurveyComplete, newSurvey);

        await Navigation.PopAsync();
    }

    private async void Cancelar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}