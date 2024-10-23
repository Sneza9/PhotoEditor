using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSDomaci
{
    public class GrayscaleFilters
    {
        public static bool GrayscaleAVG(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            Color color;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    color = image.GetPixel(x, y);

                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int avg = (r + g + b) / 3;

                    image.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                } 
            }
            return true;
        }

        public static bool GrayscaleMax(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            Color color;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    color = image.GetPixel(x, y);

                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int max = Math.Max(r, g);
                    max = Math.Max(max, b);

                    image.SetPixel(x, y, Color.FromArgb(a, max, max, max));
                }
            }
            return true;
        }
        public static bool GrayscaleCustom(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            Color color;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    color = image.GetPixel(x, y);

                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    double Cr = 0.3, Cg = 0.59, Cb = 0.11;
                    int gray = (int)(r * Cr + g * Cg + b * Cb);

                    image.SetPixel(x, y, Color.FromArgb(a, gray, gray, gray)); 
                }
            }
            return true;
        }

    }
}
