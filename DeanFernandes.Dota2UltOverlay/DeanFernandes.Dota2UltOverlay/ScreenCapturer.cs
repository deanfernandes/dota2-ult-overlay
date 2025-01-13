using System.Drawing;
using System.Drawing.Imaging;

namespace DeanFernandes.Dota2UltOverlay
{
    internal class ScreenCapturer
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

        static public Bitmap CaptureScreenBitmap(int width, int height, int x=0, int y=0)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(x, y, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            }

            return bitmap;
        }

        static public void SaveBitmapToFilePng(Bitmap bitmap, string filePath)
        {
            bitmap.Save(filePath+".png", ImageFormat.Png);
        }
    }
}
