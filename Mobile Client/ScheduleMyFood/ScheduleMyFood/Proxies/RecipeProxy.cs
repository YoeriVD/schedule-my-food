using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ScheduleMyFood.Annotations;
using ScheduleMyFood.Technical;
using SharedSchema;

namespace ScheduleMyFood.Proxies
{
    public interface IRecipeProxy : INotifyPropertyChanged
    {
        Task<IEnumerable<Recipe>> Get();
        Task<Recipe> Get(string name);
        ObservableCollection<Recipe> LocalCollection { get; set; }
    }

    class RecipeProxy : IRecipeProxy
    {
        private readonly HttpClient _httpClient;
        private ObservableCollection<Recipe> _localCollection;
        private const string RecipesResourceName = "recipes";

        public ObservableCollection<Recipe> LocalCollection
        {
            get
            {
                RetrieveDataIfNeeded();
                return _localCollection;
            }
            set
            {
                _localCollection = value;
                OnPropertyChanged();
            }
        }

        private async void RetrieveDataIfNeeded()
        {
            if (_localCollection == null)
            {
                LocalCollection = new ObservableCollection<Recipe>(collection: await this.Get());
            }
        }

        public RecipeProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Recipe>> Get()
        {
            return await _httpClient.GetAsync<List<Recipe>>(RecipesResourceName);
        }
        public async Task<Recipe> Get(string name)
        {
            return await _httpClient.GetAsync<Recipe>(string.Format("{0}/{1}", RecipesResourceName, name));
        }
        public async Task Create(Recipe recipe)
        {
            var addedRecipe = await _httpClient.PostAsync(RecipesResourceName, recipe);
            this.LocalCollection.Add(addedRecipe);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
