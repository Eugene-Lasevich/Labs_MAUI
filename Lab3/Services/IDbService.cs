using MauiApp1.Lab3.Entities;

namespace MauiApp1.Lab3.Services
{
    public interface IDbService
    {
        IEnumerable<Performer> GetAllPerformers();
        IEnumerable<Song> GetExecutableSongs(int id);
        void Init();
    }
}
