using System.Threading.Tasks;

namespace ScheduleMyFood.Technical.DependencyServices
{
    public interface ILocalStorageService
    {
        string LoadText(string filename);
        void SaveText(string filename, string text);
        Task<string> LoadTextAsync(string filename);
    }
}
