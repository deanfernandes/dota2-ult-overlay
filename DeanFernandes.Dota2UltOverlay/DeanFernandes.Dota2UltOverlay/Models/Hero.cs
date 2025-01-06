using NLog;
using System.IO;

namespace DeanFernandes.Dota2UltOverlay.Models
{
    class Hero
    {
        public string Name { get; set; }
        public Ultimate Ult { get; set; }

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public Hero(string name)
        {
            Name = name;

            Ult = new Ultimate(GetUltimateName(Name), 0);
        }

        static string GetUltimateName(string heroName)
        {
            var files = Directory.GetFiles("Resources/Images/Ultimates/", $"{heroName}_*.png");

            if (files.Length == 0)
            {
                Logger.Error($"Ultimate for hero '{heroName}' not found in the directory.");

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
