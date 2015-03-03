using System;
using System.IO;
using System.Threading.Tasks;
using ScheduleMyFood.Droid.DependencyServices;
using ScheduleMyFood.Technical.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalStorageServiceAndroid))]
namespace ScheduleMyFood.Droid.DependencyServices
{
    class LocalStorageServiceAndroid : ILocalStorageService
    {
        public Task<string> LoadTextAsync(string filename)
        {
            return Task.Run(() => LoadText(filename));
        }

        public Task SaveTextAsync(string filename, string text)
        {
            return Task.Run(() => SaveText(filename, text));
        }

        private void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        private string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }
    }
}