using Emgu.CV.CvEnum;
using Emgu.CV;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV.Structure;
using System.Reflection;

namespace DeanFernandes.Dota2UltOverlay
{
    public class ImageProcessor
    {
        private const double MatchThreshold = 0.7;
        public static bool PerformTemplateMatch(string imageAPath, string imageBPath)
        {
            using Mat imageA = CvInvoke.Imread(imageAPath, Emgu.CV.CvEnum.ImreadModes.Color);
            using Mat imageB = CvInvoke.Imread(imageBPath, Emgu.CV.CvEnum.ImreadModes.Color);

            Mat result = new Mat();
            CvInvoke.MatchTemplate(imageA, imageB, result, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);
            double minVal = 0, maxVal = 0;
            Point minLoc = default, maxLoc = default;
            CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

            return maxVal >= MatchThreshold;
        }
    }
}
