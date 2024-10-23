using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MMSDomaci
{
	
	public struct FloatPoint
	{
		public double X;
		public double Y;
	}
	public class Filters
    {
		public static bool Gamma(Bitmap image, double red, double green, double blue)
		{
			if (red < .2 || red > 5) return false;
			if (green < .2 || green > 5) return false;
			if (blue < .2 || blue > 5) return false;

			byte[] redGamma = new byte[256];
			byte[] greenGamma = new byte[256];
			byte[] blueGamma = new byte[256];

			for (int i = 0; i < 256; ++i)
			{
				redGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / red)) + 0.5));
				greenGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / green)) + 0.5));
				blueGamma[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / blue)) + 0.5));
			}

			BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				//24b format 
				int nOffset = stride - image.Width * 3;

				for (int y = 0; y < image.Height; ++y)
				{
					for (int x = 0; x < image.Width; ++x)
					{
						p[2] = redGamma[p[2]];
						p[1] = greenGamma[p[1]];
						p[0] = blueGamma[p[0]];

						p += 3;
					}
					p += nOffset;
				}
			}

			image.UnlockBits(bmData);

			return true;
		}

		public static bool Sharpen(Bitmap image)
		{
			int filterWidth = 3;
			int filterHeight = 3;
			int w = image.Width;
			int h = image.Height;

			double[,] filter = new double[filterWidth, filterHeight];

			filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
			filter[1, 1] = 9;

			double factor = 1.0;
			double bias = 0.0;

			Color[,] result = new Color[image.Width, image.Height];

			for (int x = 0; x < w; ++x)
			{
				for (int y = 0; y < h; ++y)
				{
					double red = 0.0, green = 0.0, blue = 0.0;

					for (int filterX = 0; filterX < filterWidth; filterX++)
					{

						for (int filterY = 0; filterY < filterHeight; filterY++)
						{
							int imageX = (x - filterWidth / 2 + filterX + w) % w;
							int imageY = (y - filterHeight / 2 + filterY + h) % h;

							Color imageColor = image.GetPixel(imageX, imageY);

							red += imageColor.R * filter[filterX, filterY];
							green += imageColor.G * filter[filterX, filterY];
							blue += imageColor.B * filter[filterX, filterY];
						}
						int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
						int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
						int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

						result[x, y] = Color.FromArgb(r, g, b);
					}
				}
			}
			for (int i = 0; i < w; ++i)
			{
				for (int j = 0; j < h; ++j)
				{
					image.SetPixel(i, j, result[i, j]);
				}
			}
			return true;
		}

		public static Bitmap ConvertTo256Colors(Bitmap image)
		{
			var ms = new System.IO.MemoryStream();
			//The GIF encoder, a file format that has 256 colors
			image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
			ms.Position = 0;
			return new Bitmap(ms);
		}


		public static Bitmap OrderDithering(Bitmap image)
        {
			float[,] dither2x2Matrix =new float[,] { { 1, 3 },{ 4, 2 } };

			float[,] bayerMatrix;
			bayerMatrix = new float[2, 2];
			for (int i = 0; i < 2; ++i)
				for (int j = 0; j < 2; ++j)
					bayerMatrix[i, j] = dither2x2Matrix[i, j] / 5;

			if (GrayscaleFilters.GrayscaleAVG(image))
			{
				
				for (int i = 1; i < image.Width-1; i++)
				{
					for (int j = 0; j < image.Height - 1; j++)
					{
						Color color = image.GetPixel(i, j);

						//The lightness ranges from 0.0 through 1.0, where 0.0 represents black and 1.0 represents white
						float colorIntensity = color.GetBrightness();

						float tempValue = (float)(Math.Floor(colorIntensity));

						float re = colorIntensity + tempValue;

						if (re >= bayerMatrix[i % 2, j % 2])
							tempValue++;

						if (tempValue == 0)
							image.SetPixel(i, j, Color.Black);
						else
							image.SetPixel(i, j, Color.White); 
					}
				}
			}
			return image;
        }
		/*public static Bitmap JJDither(Bitmap image)
        {
			Bitmap dest = (Bitmap)image.Clone();
			Bitmap tmp = (Bitmap)dest.Clone();
			for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
					Color colorO = dest.GetPixel(i, j);
					Color colorQ = tmp.GetPixel(i, j);
					int r = colorQ.R;
					int g = colorQ.G;
					int b = colorQ.B;

					if (r < 128)
						tmp.SetPixel(i, j, Color.Black);
					else
						tmp.SetPixel(i, j, Color.White);
					if (g < 128)
						tmp.SetPixel(i, j, Color.Black);
					else
						tmp.SetPixel(i, j, Color.White);
					if (b < 128)
						tmp.SetPixel(i, j, Color.Black);
					else
						tmp.SetPixel(i, j, Color.White);
				}
            }
			for (int i = 1; i < image.Width-1; i++)
			{
				for (int j = 1; j < image.Height-1; j++)
				{
					Color colorO = dest.GetPixel(i, j);
					Color colorQ = tmp.GetPixel(i, j);
					int[] error =
					{
						Math.Abs(colorO.R-colorQ.R),
						Math.Abs(colorO.G-colorQ.G),
						Math.Abs(colorO.B-colorQ.B)
					};

					dest.SetPixel(i, j, colorQ);

					Color c = dest.GetPixel(i + 1, j + 0);
					int[] k1 = { c.R, c.G, c.B };
					float errBias = 7.0f / 16.0f;
					k1[0] += (int)((float)error[0] * errBias);
					k1[1] += (int)((float)error[1] * errBias);
					k1[2] += (int)((float)error[2] * errBias);

					k1[0] %= 255;
					k1[1] %= 255;
					k1[2] %= 255;

					string r = Color.FromArgb(k1[0], 0, 255).ToString();

					dest.SetPixel(i + 1, j + 0, Color.FromArgb(k1[0], k1[1], k1[2]));

					c = dest.GetPixel(i - 1, j + 1);
					int[] k2 = { c.R, c.G, c.B };
					errBias = 3.0f / 16.0f;
					k2[0] += (int)((float)error[0] * errBias);
					k2[1] += (int)((float)error[1] * errBias);
					k2[2] += (int)((float)error[2] * errBias);

					k2[0] %= 255;
					k2[1] %= 255;
					k2[2] %= 255;

					dest.SetPixel(i + 1, j + 0, Color.FromArgb(k2[0], k2[1], k2[2]));

					c = dest.GetPixel(i + 0, j + 1);
					int[] k3 = { c.R, c.G, c.B };
					errBias = 5.0f / 16.0f;
					k3[0] += (int)((float)error[0] * errBias);
					k3[1] += (int)((float)error[1] * errBias);
					k3[2] += (int)((float)error[2] * errBias);

					k3[0] %= 255;
					k3[1] %= 255;
					k3[2] %= 255;

					dest.SetPixel(i + 1, j + 0, Color.FromArgb(k3[0], k3[1], k3[2]));

					c = dest.GetPixel(i + 1, j + 1);
					int[] k4 = { c.R, c.G, c.B };
					errBias = 1.0f / 16.0f;
					k4[0] += (int)((float)error[0] * errBias);
					k4[1] += (int)((float)error[1] * errBias);
					k4[2] += (int)((float)error[2] * errBias);

					k4[0] %= 255;
					k4[1] %= 255;
					k4[2] %= 255;

					

					dest.SetPixel(i + 1, j + 0, Color.FromArgb(k4[0], k4[1], k4[2]));
				}
			}
			return dest;
		}*/
	}
}


