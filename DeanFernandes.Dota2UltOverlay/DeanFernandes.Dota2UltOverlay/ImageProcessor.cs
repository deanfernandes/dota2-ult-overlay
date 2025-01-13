using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace DeanFernandes.Dota2UltOverlay
{
    public static class ImageProcessor
    {
        private const double MatchThreshold = .78, MinScale = .25, MaxScale = .5, ScaleStep = .25;

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static bool PerformTemplateMatch(string imagePath, string templatePath)
        {
            using Mat image = CvInvoke.Imread(imagePath, ImreadModes.Color);
            using Mat template = CvInvoke.Imread(templatePath, ImreadModes.Color);

            for (double scale = MinScale; scale <= MaxScale; scale+= ScaleStep)
            {
                int newWidth = (int)(template.Width * scale);
                int newHeight = (int)(template.Height * scale);

                using Mat resizedTemplate = new Mat();
                CvInvoke.Resize(template, resizedTemplate, new Size(newWidth, newHeight));

                Mat result = new Mat();
                CvInvoke.MatchTemplate(image, resizedTemplate, result, TemplateMatchingType.CcoeffNormed);

                double minVal = 0D, maxVal = 0D;
                Point minLoc = default, maxLoc = default;
                CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                if (maxVal >= MatchThreshold)
                {
                    Logger.Info($"match: {Path.GetFileName(templatePath)}, confidence: {maxVal}, scale: {scale}, width: {newWidth}, height: {newHeight}");

                    Debug.WriteLine($"match: {Path.GetFileName(templatePath)}, confidence: {maxVal}, scale: {scale}, width: {newWidth}, height: {newHeight}");

                    return true;
                }
            }

            return false;
        }

        public static bool PerformTemplateMatchNoScaling(string imagePath, string templatePath)
        {
            using Mat image = CvInvoke.Imread(imagePath, ImreadModes.Color);
            using Mat template = CvInvoke.Imread(templatePath, ImreadModes.Color);

            Mat result = new Mat();
            CvInvoke.MatchTemplate(image, template, result, TemplateMatchingType.CcoeffNormed);

            double minVal = 0D, maxVal = 0D;
            Point minLoc = default, maxLoc = default;
            CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

            if (maxVal >= MatchThreshold)
            {
                Logger.Info($"match: {Path.GetFileName(templatePath)}, confidence: {maxVal}");

                Debug.WriteLine($"match: {Path.GetFileName(templatePath)}, confidence: {maxVal}");

                return true;
            }

            return false;
        }

        private static void Preprocess(ref Mat image, ref Mat template)
        {
            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
            CvInvoke.CvtColor(template, template, ColorConversion.Bgr2Gray);

            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
            CvInvoke.CvtColor(template, template, ColorConversion.Bgr2Gray);

            CvInvoke.Normalize(image, image, 0, 255, NormType.MinMax);
            CvInvoke.Normalize(template, template, 0, 255, NormType.MinMax);
        }
    }
}