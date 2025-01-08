using System.IO;
using System.Text;

namespace DeanFernandes.Dota2UltOverlay
{
    public class ImageManager
    {
        public const string HeroImageDir = "Resources/Images/Heroes/";
        public const string UltImageDir = "Resources/Images/Ultimates/";

        public static string GetHeroImagePath(string heroName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(HeroImageDir);
            builder.Append(heroName.ToLower());
            builder.Append(".png");
            return builder.ToString();
        }

        public static string GetUltimateImagePath(string ultName)
        {
            //assume only 1 ult file for each hero in dir
            StringBuilder builder = new StringBuilder();
            builder.Append(UltImageDir);
            builder.Append(Directory.GetFiles(UltImageDir).Select(Path.GetFileName).FirstOrDefault(fileName => fileName.Contains(ultName, StringComparison.OrdinalIgnoreCase)));
            return builder.ToString();
        }

        //"If a leading backslash is used, however, the relative pack URI reference is then considered relative to the root of the application."
        //https://learn.microsoft.com/en-us/dotnet/desktop/wpf/app-development/pack-uris-in-wpf?view=netframeworkdesktop-4.8&redirectedfrom=MSDN#absolute-vs-relative-pack-uris
        public static string MakeImagePathApplicationRelative(string path)
        {
            return "\\" + path;
        }

        public static string GetHeroUltimateImagePath(string heroName, string ultName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(UltImageDir);
            builder.Append(heroName.ToLower());
            builder.Append("_");
            builder.Append(ultName.ToLower());
            builder.Append(".png");
            return builder.ToString();
        }
    }
}
