using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSDomaci
{
    public class ExtraFilters
    {
		public static bool EdgeEnhance(Bitmap bitmap, byte nThreshold)
		{
			Bitmap bitmapClone = (Bitmap)bitmap.Clone();

			// GDI+ still lies to us - the return format is BGR, NOT RGB.
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bitmapCloneData = bitmapClone.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bitmapData.Stride;
			System.IntPtr Scan0 = bitmapData.Scan0;
			System.IntPtr Scan02 = bitmapCloneData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				byte* p2 = (byte*)(void*)Scan02;

				int nOffset = stride - bitmap.Width * 3;
				int nWidth = bitmap.Width * 3;

				int nPixel = 0, nPixelMax = 0;

				p += stride;
				p2 += stride;

				for (int y = 1; y < bitmap.Height - 1; ++y)
				{
					p += 3;
					p2 += 3;

					for (int x = 3; x < nWidth - 3; ++x)
					{
						nPixelMax = Math.Abs((p2 - stride + 3)[0] - (p2 + stride - 3)[0]);

						nPixel = Math.Abs((p2 + stride + 3)[0] - (p2 - stride - 3)[0]);

						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs((p2 - stride)[0] - (p2 + stride)[0]);

						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs((p2 + 3)[0] - (p2 - 3)[0]);

						if (nPixel > nPixelMax) nPixelMax = nPixel;

						if (nPixelMax > nThreshold && nPixelMax > p[0])
							p[0] = (byte)Math.Max(p[0], nPixelMax);

						++p;
						++p2;
					}

					p += nOffset + 3;
					p2 += nOffset + 3;
				}
			}

			bitmap.UnlockBits(bitmapData);
			bitmapClone.UnlockBits(bitmapCloneData); 

			return true;
		}

		public static bool Pixelate(Bitmap bitmap, short pixel, bool bGrid)
		{
			int nWidth = bitmap.Width;
			int nHeight = bitmap.Height;

			Point[,] pt = new Point[nWidth, nHeight];

			int newX, newY;

			for (int x = 0; x < nWidth; ++x)
				for (int y = 0; y < nHeight; ++y)
				{
					newX = pixel - x % pixel;

					if (bGrid && newX == pixel)
						pt[x, y].X = -x;
					else if (x + newX > 0 && x + newX < nWidth)
						pt[x, y].X = newX;
					else
						pt[x, y].X = 0;

					newY = pixel - y % pixel;

					if (bGrid && newY == pixel)
						pt[x, y].Y = -y;
					else if (y + newY > 0 && y + newY < nHeight)
						pt[x, y].Y = newY;
					else
						pt[x, y].Y = 0;
				}

			OffsetFilter(bitmap, pt);

			return true;
		}

		public static bool OffsetFilter(Bitmap bitmap, Point[,] offset)
		{
			Bitmap bitmapSrc = (Bitmap)bitmap.Clone();

			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bitmapDataSrc = bitmapSrc.LockBits(new Rectangle(0, 0, bitmapSrc.Width, bitmapSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int scanline = bitmapData.Stride;

			System.IntPtr Scan0 = bitmapData.Scan0;
			System.IntPtr SrcScan0 = bitmapDataSrc.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				byte* pSrc = (byte*)(void*)SrcScan0;

				int nOffset = bitmapData.Stride - bitmap.Width * 3;
				int nWidth = bitmap.Width;
				int nHeight = bitmap.Height;

				int xOffset, yOffset;

				for (int y = 0; y < nHeight; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						xOffset = offset[x, y].X;
						yOffset = offset[x, y].Y;

						if (y + yOffset >= 0 && y + yOffset < nHeight && x + xOffset >= 0 && x + xOffset < nWidth)
						{
							p[0] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3)];
							p[1] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 1];
							p[2] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 2];
						}

						p += 3;
					}
					p += nOffset;
				}
			}

			bitmap.UnlockBits(bitmapData);
			bitmapSrc.UnlockBits(bitmapDataSrc);

			return true;
		} 

		public static Bitmap CrossDomainColorize(Bitmap image, double h, double s)
        {
			double hue;
			double saturation;
			double value;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
					Color color = image.GetPixel(i, j);

					RGBToHSV(color, out hue, out saturation, out value);

					color = RGBFromHSV(h, s, value); 

					image.SetPixel(i, j, color); 
                }
            }
			return image;
        }

		public static void RGBToHSV(Color color, out double hue, out double saturation, out double value)
		{
			int max = Math.Max(color.R, Math.Max(color.G, color.B));
			int min = Math.Min(color.R, Math.Min(color.G, color.B));

			hue = color.GetHue();
			saturation = (max == 0) ? 0 : 1d - (1d * min / max);
			value = max / 255d;
		}

		public static Color RGBFromHSV(double hue, double saturation, double value)
		{
			int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
			double f = hue / 60 - Math.Floor(hue / 60);

			value = value * 255;
			int v = Convert.ToInt32(value);
			int p = Convert.ToInt32(value * (1 - saturation));
			int q = Convert.ToInt32(value * (1 - f * saturation));
			int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

			if (hi == 0)
				return Color.FromArgb(v, t, p);
			else if (hi == 1)
				return Color.FromArgb(q, v, p);
			else if (hi == 2)
				return Color.FromArgb(p, v, t);
			else if (hi == 3)
				return Color.FromArgb(p, q, v);
			else if (hi == 4)
				return Color.FromArgb(t, p, v);
			else
				return Color.FromArgb(v, p, q);
		}

		public static Bitmap Downsampling422(Bitmap image)
        {

            for (int i = 0; i < image.Width; i++)
            {
				//4:2:2 
                for (int j = 0; j < image.Height; j++)
                {
					Color color = image.GetPixel(i, j);
					int r = color.R;
					int g = color.G;
					int b = color.B;

					image.SetPixel(i, j, Color.FromArgb(r, g, b));

					++j;
                    if (j < image.Height)
                    {
						image.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
            }
			return image;
        }

		//Downsample red
		public static Bitmap Downsampling422Red(Bitmap image)
		{

			for (int i = 0; i < image.Width; i++)
			{
				//4:2:2 
				for (int j = 0; j < image.Height; j++)
				{
					Color color = image.GetPixel(i, j);
					int r = color.R;
					int g = color.G;
					int b = color.B;

					image.SetPixel(i, j, Color.FromArgb(r, g, b));

					++j;
					if (j < image.Height)
					{
						Color c = image.GetPixel(i, j);
						int newG = c.G;
						int newB = c.B;
						image.SetPixel(i, j, Color.FromArgb(r, newG, newB));
					}
				}
			}
			return image;
		}

		//Just green 
		public static Bitmap Downsampling422Green(Bitmap image)
		{

			for (int i = 0; i < image.Width; i++)
			{
				//4:2:2 
				for (int j = 0; j < image.Height; j++)
				{
					Color color = image.GetPixel(i, j);
					int r = color.R;
					int g = color.G;
					int b = color.B;

					image.SetPixel(i, j, Color.FromArgb(r, g, b));

					++j;
					if (j < image.Height)
					{
						image.SetPixel(i, j, Color.FromArgb(r, g, b));
					}
				}
			}
			return image;
		}

		//Downsample blue
		public static Bitmap Downsampling422Blue(Bitmap image)
		{

			for (int i = 0; i < image.Width; i++)
			{
				//4:2:2 
				for (int j = 0; j < image.Height; j++)
				{
					Color color = image.GetPixel(i, j);
					int r = color.R;
					int g = color.G;
					int b = color.B;

					image.SetPixel(i, j, Color.FromArgb(r, g, b));

					++j;
					if (j < image.Height)
					{
						Color c = image.GetPixel(i, j);
						int newR = c.R;
						int newG = c.G;
						image.SetPixel(i, j, Color.FromArgb(r, g, b));
					}
				}
			}
			return image;
		}
	}
}
