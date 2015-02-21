using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
