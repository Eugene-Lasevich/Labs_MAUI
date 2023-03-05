using MauiApp1.Lab3.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Lab3.Services
{
    public class SQLiteService:IDbService
    {

        public const string DatabaseFilename = "SQLiteDemo.db";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        private SQLiteConnection Database;



        public IEnumerable<Performer> GetAllPerformers()
        {
            return Database.Table<Performer>().ToList();
        }

        public IEnumerable<Song> GetExecutableSongs(int id)
        {
           return Database.Table<Song>().Where(t => t.PerfomerId == id).ToList();
        }

        public void Init()
        {
            Database = new SQLiteConnection(DatabasePath, Flags);
            if (Database == null) return;

            Database.DropTable<Performer>();
            Database.DropTable<Song>();

            Database.CreateTable<Performer>();
            Database.Insert(new Performer { Name = "Кино", Description = "Описание группы Кино" });
            Database.Insert(new Performer { Name = "Гр Об", Description = "Опсиание группы Грожданскя оборона" });
            Database.Insert(new Performer { Name = "Сетор Газа", Description ="Описание группы Сектор газа" });
            Database.Insert(new Performer { Name = "КиШ", Description = "Описание группы Король и Шут" });


            Database.CreateTable<Song>();
            Database.Insert(new Song { Name = "Пачка сигарет", Description = "TeamSupportDescription", PerfomerId = 1 });
            Database.Insert(new Song { Name = "Звезда по имени Солнце", Description = "RiskCalculationDescription", PerfomerId = 1 });
            Database.Insert(new Song { Name = "Перемен", Description = "Front-End-Description", PerfomerId = 1 });
            Database.Insert(new Song { Name = "Группа крови", Description = "Back-EndDescription", PerfomerId = 1 });

            Database.Insert(new Song { Name = "Все идет по плану", Description = "FullSatckDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Моя оборона", Description = "CheckErrorsDescription", PerfomerId = 2});
            Database.Insert(new Song { Name = "Солдатаи не рождаются", Description = "CheckPlatformDifferencesDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Государство", Description = "Back-EndDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Дурачок", Description = "FullSatckDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "На дальней станции сойду", Description = "CheckErrorsDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Все как у людей", Description = "CheckPlatformDifferencesDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Отрят не заметил потери бойца", Description = "Back-EndDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Философская песня о пуле", Description = "CheckErrorsDescription", PerfomerId = 2 });
            Database.Insert(new Song { Name = "Зоопрак", Description = "CheckPlatformDifferencesDescription", PerfomerId = 2 });

            Database.Insert(new Song { Name = "Лирика", Description = "TeamSupportDescription", PerfomerId = 3 });
            Database.Insert(new Song { Name = "Туман", Description = "RiskCalculationDescription", PerfomerId = 3 });
            Database.Insert(new Song { Name = "Пора домой", Description = "Front-End-Description", PerfomerId = 3 });
            Database.Insert(new Song { Name = "30 лет", Description = "Back-EndDescription", PerfomerId = 3 });
            Database.Insert(new Song { Name = "Ява", Description = "TeamSupportDescription", PerfomerId = 3 });
            Database.Insert(new Song { Name = "Бомж", Description = "RiskCalculationDescription", PerfomerId = 3 });
            Database.Insert(new Song { Name = "Демобилизация", Description = "Front-End-Description", PerfomerId = 3 });
            Database.Insert(new Song { Name = "Сектор Газа", Description = "Back-EndDescription", PerfomerId = 3 });

            Database.Insert(new Song { Name = "Разбежавшись прыгну со скалы", Description = "TeamSupportDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Кукла колдуна", Description = "RiskCalculationDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Лесник", Description = "Front-End-Description", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Смельчак и ветер", Description = "Back-EndDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Дурак и молния", Description = "TeamSupportDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Ром", Description = "RiskCalculationDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Матёрый волк", Description = "Front-End-Description", PerfomerId = 4});
            Database.Insert(new Song { Name = "Исповедь вампира", Description = "Back-EndDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Джокер", Description = "TeamSupportDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Мертвый анархист", Description = "RiskCalculationDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Бунт на корабле", Description = "Front-End-Description", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Фокусник", Description = "Back-EndDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Марионетки", Description = "TeamSupportDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Ели мясо мужики", Description = "RiskCalculationDescription", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Камнем по голове", Description = "Front-End-Description", PerfomerId = 4 });
            Database.Insert(new Song { Name = "Проклятый старый дом", Description = "Back-EndDescription", PerfomerId = 4 });

        }

  
    }
}
