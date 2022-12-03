using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App1.ModelsForDB
{
    [Table("Marks")]
    public class MarkDB
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [ForeignKey(typeof(FilmDB))]
        public int Id_film { get; set; }
        [ForeignKey(typeof(UserDB))]
        public int Id_user { get; set; }
        public int Mark { get; set; }
    }
}
