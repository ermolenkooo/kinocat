using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

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
        public List<FollowerDB> Followers { get; set; }
        public List<FollowerDB> Following { get; set; }
        //public List<LetterDB> Letters { get; set; }
        //public List<LoveDB> Love { get; set; }
        //public List<WatchlistDB> Watchlist { get; set; }
        //public List<MarkDB> Marks { get; set; }
    }
}
