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
        public string LoadText(string filename)
        {
            return LoadTextLocal(filename);
        }

        public void SaveText(string filename, string text)
        {
            SaveTextLocal(filename, text);
        }

        private void SaveTextLocal(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
        }
        private string LoadTextLocal(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            if(File.Exists(filePath)) return File.ReadAllText(filePath);
            throw new FileNotFoundException();
        }

        public Task<string> LoadTextAsync(string filename)
        {
            return Task.Run(() => LoadText(filename));
        }
    }
}