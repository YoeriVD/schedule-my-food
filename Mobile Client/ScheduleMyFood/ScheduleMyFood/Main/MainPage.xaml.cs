using Xamarin.Forms;

namespace ScheduleMyFood.Main
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            this.BindingContext = mainViewModel;
        }
    }
}
