using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Lab3.Entities
{
    [Table("Songs")]
    public class Song
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int SongId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        [Indexed]
        public int PerfomerId { get; set; }
    }
}
