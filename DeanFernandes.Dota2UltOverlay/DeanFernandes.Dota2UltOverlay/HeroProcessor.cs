using DeanFernandes.Dota2UltOverlay.ViewModels;
using NLog;
using System.Diagnostics;
using System.IO;

namespace DeanFernandes.Dota2UltOverlay
{
    public static class HeroProcessor
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public static List<string> ProcessHeroes(string heroesImagePath)
        {
#if DEBUG
            logger.Debug("function ProcessHeroes started");
            var stopwatch = Stopwatch.StartNew();
#endif

            List<string> heroes = new List<string>();

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images\Heroes\");
            try
            {
                foreach (string file in Directory.EnumerateFiles(directoryPath))
                {
                    bool match = ImageProcessor.PerformTemplateMatch(heroesImagePath, file);

                    if (match)
                    {
                        heroes.Add(Path.GetFileNameWithoutExtension(file));
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Error($"Directory not found: {ex.Message}");

                Debug.WriteLine($"Directory not found: {ex.Message}");
            }

#if DEBUG
            stopwatch.Stop();
            logger.Debug($"function ProcessHeroes finished: {stopwatch.ElapsedMilliseconds}ms");
#endif

            return heroes;
        }
    }
}
