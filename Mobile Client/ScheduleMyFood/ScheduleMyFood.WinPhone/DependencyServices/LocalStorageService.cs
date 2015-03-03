using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using ScheduleMyFood.Technical.DependencyServices;
using ScheduleMyFood.WinPhone.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalStorageServiceWinP))]
namespace ScheduleMyFood.WinPhone.DependencyServices
{
    class LocalStorageServiceWinP : ILocalStorageService
    {
        public async Task<string> LoadTextAsync(string filename)
        {
            var local = ApplicationData.Current.LocalFolder;
            if (local == null) return "";
            var file = await local.GetItemAsync(filename);
            using (var streamReader = new StreamReader(file.Path))
            {
                var text = streamReader.ReadToEnd();
                return text;
            }
        }
        public async Task SaveTextAsync(string filename, string text)
        {
            var local = ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (var writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(text);
            }
        }
    }
}
