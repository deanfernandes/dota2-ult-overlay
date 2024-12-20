namespace deanfernandes.dota2_ult_overlay
{
    class ImageManager
    {
        const string HeroImageDir = "/Resources/Images/Heroes/";
        const string HeroUltImageDir = "/Resources/Images/Ultimates/";

        public static string GetHeroImagePath(string heroName)
        {
            return HeroImageDir + heroName.ToLower() + ".png";
        }

        public static string GetHeroUltimateImagePath(string heroName, string ultName)
        {
            return HeroUltImageDir + heroName.ToLower() + "_" + ultName.ToLower() + ".png";
        }
    }
}
