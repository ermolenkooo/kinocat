using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.ModelsForDB
{
    [Table("Marks")]
    public class MarkDB
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int Id_film { get; set; }
        public int Id_user { get; set; }
        public int Mark { get; set; }
    }
}
