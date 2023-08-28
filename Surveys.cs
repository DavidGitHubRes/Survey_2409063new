using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_2409063
{
    public class Surveys
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FavoriteTeam { get; set; }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        public override string ToString()
        {
            return $"{Name} | {Birthdate} | {FavoriteTeam}";
        }

    }
}
