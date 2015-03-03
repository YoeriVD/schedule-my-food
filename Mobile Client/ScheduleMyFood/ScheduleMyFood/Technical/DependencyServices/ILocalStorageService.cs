using System.Threading.Tasks;

namespace ScheduleMyFood.Technical.DependencyServices
{
    public interface ILocalStorageService
    {
        Task<string> LoadTextAsync(string filename);
        Task SaveTextAsync(string filename, string text);
    }
}
