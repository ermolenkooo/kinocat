using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App1.ModelsForDB
{
    [Table("Users")]
    public class UserDB
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        [OneToMany]
        public List<LoveDB> Love { get; set; }
        [OneToMany]
        public List<MarkDB> Marks { get; set; }
        [OneToMany]
        public List<WatchlistDB> Watchlist { get; set; }
        [OneToMany]
        public List<LetterDB> Letters { get; set; }
    }
}
