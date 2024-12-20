using System.Drawing;
using System.Drawing.Imaging;

namespace DeanFernandes.Dota2UltOverlay
{
    internal class ScreenCapture
    {
        static public Bitmap CaptureScreenBitmap()
        {
            Bitmap bitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(1920,1080), CopyPixelOperation.SourceCopy);
            }

            return bitmap;
        }
        static public void SaveBitmapToFilePng(Bitmap bitmap, string filePath)
        {
            bitmap.Save(filePath+".png", ImageFormat.Png);
        }
    }
}
