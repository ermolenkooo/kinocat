using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.ModelsForDB
{
    [Table("Users")]
    public class FilmDB
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }
        public string Timing { get; set; }
        public string Original { get; set; }
        public string Seasons { get; set; }
        //public List<LetterDB> Letters { get; set; }
        //public List<LoveDB> Love { get; set; }
        //public List<WatchlistDB> Watchlist { get; set; }
        //public List<MarkDB> Marks { get; set; }
    }
}
