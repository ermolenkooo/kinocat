using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App1.ModelsForDB
{
    [Table("Followers")]
    public class FollowerDB
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int Id_follower { get; set; }
        public int Id_following { get; set; }
    }
}
