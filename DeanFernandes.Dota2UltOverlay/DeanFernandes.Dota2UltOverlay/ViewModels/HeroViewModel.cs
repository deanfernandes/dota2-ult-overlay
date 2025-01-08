namespace DeanFernandes.Dota2UltOverlay.ViewModels
{
    using Models;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    class HeroViewModel
    {
        public Hero Hero { get; set; }

        public HeroViewModel(Hero hero)
        {
            Hero = hero;
        }
    }
}
