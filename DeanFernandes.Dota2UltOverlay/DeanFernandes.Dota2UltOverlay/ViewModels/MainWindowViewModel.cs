using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeanFernandes.Dota2UltOverlay.ViewModels
{
    class MainWindowViewModel
    {
        public ObservableCollection<HeroUltViewModel> HeroUltViewModels { get; set; }

        public MainWindowViewModel()
        {
            HeroUltViewModels = new ObservableCollection<HeroUltViewModel>();

            //TODO: rm test/dummy code
            HeroUltViewModels.Add(new HeroUltViewModel(new Models.Hero("abaddon", new Models.Ultimate("borrowed_time", 90))));
        }
    }
}
