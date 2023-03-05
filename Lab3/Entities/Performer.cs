using SQLite;

namespace MauiApp1.Lab3.Entities
{

    [Table("Performers")]
    public class Performer
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
