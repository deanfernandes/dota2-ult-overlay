using System.IO;

namespace DeanFernandes.Dota2UltOverlay.Models
{
    class Hero
    {
        public string Name { get; set; }
        public string HeroImagePath { get; set; }
        public Ultimate Ultimate { get; set; }

        public Hero(string name)
        {
            Name = name;
            HeroImagePath = ImageManager.MakeImagePathApplicationRelative(ImageManager.GetHeroImagePath(Name));

            Ultimate = new Ultimate(GetHeroUltimateName(Name));
        }

        static string GetHeroUltimateName(string heroName)
        {
            var files = Directory.GetFiles("Resources/Images/Ultimates/", $"{heroName}_*.png");

            if (files.Length == 0)
            {
                throw new FileNotFoundException($"Ultimate for hero '{heroName}' not found in the directory.");
            }

            // assume 1st match is correct
            string fullPath = files[0];
            string fileName = Path.GetFileNameWithoutExtension(fullPath);

            // +1 to skip '_'
            return fileName.Substring(heroName.Length + 1);
        }
    }
}
