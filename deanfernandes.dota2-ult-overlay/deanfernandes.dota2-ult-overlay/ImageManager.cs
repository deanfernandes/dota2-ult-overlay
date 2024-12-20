using System.Text;

namespace deanfernandes.dota2_ult_overlay
{
    class ImageManager
    {
        const string HeroImageDir = "/Resources/Images/Heroes/";
        const string HeroUltImageDir = "/Resources/Images/Ultimates/";

        public static string GetHeroImagePath(string heroName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(HeroImageDir);
            builder.Append(heroName.ToLower());
            builder.Append(".png");
            return builder.ToString();
        }

        public static string GetHeroUltimateImagePath(string heroName, string ultName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(HeroUltImageDir);
            builder.Append(heroName.ToLower());
            builder.Append("_");
            builder.Append(ultName.ToLower());
            builder.Append(".png");
            return builder.ToString();
        }
    }
}
