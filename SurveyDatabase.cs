using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_2409063
{
    public class SurveyDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SurveyDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Surveys>().Wait();
        }

        public Task<List<Surveys>> GetSurveysAsync()
        {
            return _database.Table<Surveys>().ToListAsync();
        }

        public Task<int> SaveSurveyAsync(Surveys survey)
        {
            if (survey.Id != 0)
            {
                return _database.UpdateAsync(survey);
            }
            else
            {
                return _database.InsertAsync(survey);
            }
        }

        public Task<int> BorrarLast(int surveyId)
        {
            return _database.ExecuteAsync("DELETE FROM Surveys WHERE Id = ?", surveyId);
        }


    }
}
