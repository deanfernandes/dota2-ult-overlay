namespace DeanFernandes.Dota2UltOverlay.Models
{
    class Hero
    {
        public string Name { get; set; }
        public Ultimate Ult { get; set; }

        public Hero(string name, Ultimate ult)
        {
            Name = name;
            Ult = ult;
        }
    }
}
