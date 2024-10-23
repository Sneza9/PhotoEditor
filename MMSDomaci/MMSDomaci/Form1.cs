using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace MMSDomaci
{
    public partial class Form1 : Form
    {
        //The Invalidate command calls the Paint event of the Picture Box

        #region Variables
        private System.Drawing.Bitmap bitmap;
        private static int stackSize = 10;
        Stack<Bitmap> UndoStack;
        Stack<Bitmap> RedoStack;
        Bitmap red;
        Bitmap green;
        Bitmap blue;
        private int positionX;
        private int positionY; 
        #endregion

        #region FormInitialization 
        public Form1()
        {
            InitializeComponent();
            UndoStack = new Stack<Bitmap>(stackSize);
            RedoStack = new Stack<Bitmap>(stackSize);

            HidePictures();
        }
        #endregion

        #region Helpers
        private void ShowPictures()
        {
            pictureBox1.Hide();
            picture.Show();
            pictureR.Show();
            pictureG.Show();
            pictureB.Show();
            btnCanals.Enabled = true;
            btnHistogram.Enabled = true;
            HideHistogram();
            HideDownsampleSave();
        }
        private void HidePictures()
        {
            pictureBox1.Show();
            picture.Hide();
            pictureR.Hide();
            pictureG.Hide();
            pictureB.Hide();
            //btnHistogram.Enabled = false;
            btnCanals.Enabled = false;
            btnHistogram.Enabled = false;
            HideHistogram();
            HideDownsampleSave();
        }
        private void ShowGrayLabel()
        {
            lbRed.Text = "GrayscaleAVG";
            lbGreen.Text = "GrayscaleMax"; 
            lbBlue.Text = "GrayscaleCustom";
            lbRed.BackColor = Color.White;            
            lbGreen.BackColor = Color.White;
            lbBlue.BackColor = Color.White;
            lbRed.Show();
            lbGreen.Show();
            lbBlue.Show();
        }
        private void HideGrayLabel()
        {
            lbRed.Hide();
            lbGreen.Hide();
            lbBlue.Hide();
        }

        private void HideHistogram()
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            label1.Visible = false;
            Size = new Size(450, 500);
            this.StartPosition = FormStartPosition.Manual;
        }
        private void ShowHistogram()
        {
            chart1.Visible = true;
            chart2.Visible = true;
            chart3.Visible = true;
            label1.Visible = false;
            Size = new Size(1330, 500);
        }

        private void ShowDownsampleSave()
        {
            btnHistogram.Hide();
            btnCanals.Hide();
            rbRed.Show();
            rbGreen.Show();
            rbBlue.Show();
            button1.Show();
            rbRed.Checked = false;
            rbGreen.Checked = false;
            rbBlue.Checked = false;
        }

        private void HideDownsampleSave()
        {
            btnHistogram.Show();
            btnCanals.Show();
            rbRed.Hide();
            rbGreen.Hide();
            rbBlue.Hide();
            button1.Hide();
        }
        #endregion

        #region Events
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePictures();
            HideGrayLabel();

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Resources");

            openImage.InitialDirectory = Path.GetFullPath(path);
            openImage.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bmp/*.jpg/*.gif/*.png";
            //jpg
            openImage.FilterIndex = 2;

            if (DialogResult.OK == openImage.ShowDialog())
            {
                bitmap = (Bitmap)Bitmap.FromFile(openImage.FileName, false);
                pictureBox1.Image = bitmap;


                this.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePictures();
            HideGrayLabel();

            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            saveImage.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveImage.FilterIndex = 2;

            if (DialogResult.OK == saveImage.ShowDialog())
            {
                bitmap.Save(saveImage.FileName);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePictures();
            HideGrayLabel();

            if (UndoStack.Count == 0)
            {
                MessageBox.Show("There is nothing to undo");
                return;
            }
            else
            {
                RedoStack.Push((Bitmap)bitmap.Clone());

                bitmap = (Bitmap)UndoStack.Pop().Clone();
                pictureBox1.Image = bitmap;
                this.Invalidate();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePictures();
            HideGrayLabel();

            if (RedoStack.Count == 0)
            {
                MessageBox.Show("There is nothing to redo");
            }
            else
            {
                UndoStack.Push((Bitmap)bitmap.Clone());

                bitmap = (Bitmap)RedoStack.Pop().Clone();
                pictureBox1.Image = bitmap;
                this.Invalidate();
            }
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            Gamma g = new Gamma();
            g.red = g.green = g.blue = 1;

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            if (DialogResult.OK == g.ShowDialog())
            {
                if (Filters.Gamma(bitmap, g.red, g.green, g.blue))
                {
                    pictureBox1.Image = bitmap;
                    this.Invalidate();
                }
            }
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            if (Filters.Sharpen(bitmap))
            {
                pictureBox1.Image = bitmap;
                this.Invalidate();
            }
        }

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            ShowPictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            picture.Image = bitmap;


            int h = bitmap.Height;
            int w = bitmap.Width;

            red = new Bitmap(bitmap);
            green = new Bitmap(bitmap);
            blue = new Bitmap(bitmap);

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color color = bitmap.GetPixel(i, j);

                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    red.SetPixel(i, j, Color.FromArgb(a, r, 0, 0));
                    green.SetPixel(i, j, Color.FromArgb(a, 0, g, 0));
                    blue.SetPixel(i, j, Color.FromArgb(a, 0, 0, b));
                }
            }

            pictureR.Image = red;
            pictureG.Image = green;
            pictureB.Image = blue;
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            Bitmap bmp = (Bitmap)bitmap.Clone();
            bmp = Filters.ConvertTo256Colors(bitmap);
            pictureBox1.Image = bmp;
            label1.Visible = true;
            label1.ForeColor = Color.FromArgb(209, 32, 48);
            label1.Text = "For better notice, go first this filter (256 Colors) then Sharpen. ";
        }

        private void egdeEnhanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            Parameter parameter = new Parameter();
            parameter.Value = 10;

            if (DialogResult.OK == parameter.ShowDialog())
            {
                UndoStack.Push((Bitmap)bitmap.Clone());
                RedoStack.Clear();

                if (ExtraFilters.EdgeEnhance(bitmap, (byte)parameter.Value))
                {
                    pictureBox1.Image = bitmap;
                    this.Invalidate();
                }
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            if (ExtraFilters.Pixelate(bitmap, 15, true))
            {
                pictureBox1.Image = bitmap;
                this.Invalidate();
            }
        }

        private void noGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            if (ExtraFilters.Pixelate(bitmap, 15, false))
            {
                pictureBox1.Image = bitmap;
                this.Invalidate();
            }
        }

        private void grayscaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            ShowPictures();
            HideGrayLabel();

            btnHistogram.Enabled = false;
            btnCanals.Enabled = false;

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            Bitmap bmp = (Bitmap)bitmap.Clone();

            picture.Image = bitmap;

            if (GrayscaleFilters.GrayscaleAVG(bmp))
            {
                pictureR.Image = bmp;
                this.Invalidate();
            }

            bmp = (Bitmap)bitmap.Clone();
            if (GrayscaleFilters.GrayscaleMax(bmp))
            {
                pictureG.Image = bmp;
                this.Invalidate();
            }

            bmp = (Bitmap)bitmap.Clone();
            if (GrayscaleFilters.GrayscaleCustom(bmp))
            {
                pictureB.Image = bmp;
                this.Invalidate();
            }
            ShowGrayLabel();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HidePictures();
            HideGrayLabel();
            MessageBox.Show("This is Windows Forms Application photo editor, .NET project");
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To view histogram go to Filters->RGB Canals and after that click the button \"Histogram\"");
        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            if (red == null && green == null && blue == null)
            {
                MessageBox.Show("Please select first Filters->RGB Channels");
                return;
            }

            btnHistogram.Enabled = false;

            ShowHistogram();
            HideGrayLabel();

            int[] arrayR = new int[256];
            int[] arrayG = new int[256];
            int[] arrayB = new int[256];

            for (int i = 0; i < 256; i++)
            {
                arrayR[i] = 0;
                arrayG[i] = 0;
                arrayB[i] = 0;
            }

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            Bitmap rB = new Bitmap(red);
            Bitmap gB = new Bitmap(green);
            Bitmap bB = new Bitmap(blue);


            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color colorRed = rB.GetPixel(i, j);
                    Color colorGreen = gB.GetPixel(i, j);
                    Color colorBlue = bB.GetPixel(i, j);

                    int r = colorRed.R;
                    int g = colorGreen.G;
                    int b = colorBlue.B;

                    arrayR[r] += 1;
                    arrayG[g] += 1;
                    arrayB[b] += 1;
                }
            }

            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].Name = "Red";

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;

            for (int i = 0; i < 255; i++)
            {
                chart1.Series[0].Points.AddXY(i, (double)arrayR[i]);
            }


            chart2.Series[0].Color = Color.Green;
            chart2.Series[0].Name = "Green";

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 255;

            for (int i = 0; i < 255; i++)
            {
                chart2.Series[0].Points.AddXY(i, (double)arrayG[i]);
            }

            chart3.Series[0].Color = Color.Blue;
            chart3.Series[0].Name = "Blue";

            chart3.ChartAreas[0].AxisX.Minimum = 0;
            chart3.ChartAreas[0].AxisX.Maximum = 255;

            for (int i = 0; i < 255; i++)
            {
                chart3.Series[0].Points.AddXY(i, (double)arrayB[i]);
            }
        }

        private void btnCanals_Click(object sender, EventArgs e)
        {
            HideHistogram();
            ShowPictures();
            HideGrayLabel();
            btnHistogram.Enabled = true;
        }

        private void maxAndMinCanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HideGrayLabel();

            if (red == null && green == null && blue == null)
            {
                MessageBox.Show("Please select first Filters->RGB Channels");
                return;
            }

            ShowPictures();


            int[] arrayR = new int[256];
            int[] arrayG = new int[256];
            int[] arrayB = new int[256];

            for (int i = 0; i < 256; i++)
            {
                arrayR[i] = 0;
                arrayG[i] = 0;
                arrayB[i] = 0;
            }

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            MaxAndMin m = new MaxAndMin();
            m.redMin = m.redMax = m.greenMin = m.greenMax = m.blueMin = m.blueMax = 1;

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            red = new Bitmap(bitmap);
            green = new Bitmap(bitmap);
            blue = new Bitmap(bitmap);

            if (DialogResult.OK == m.ShowDialog())
            {
                pictureBox1.Image = bitmap;
            }

            Bitmap rB = new Bitmap(red);
            Bitmap gB = new Bitmap(green);
            Bitmap bB = new Bitmap(blue);

            ShowHistogram();

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color colorRed = rB.GetPixel(i, j);
                    Color colorGreen = gB.GetPixel(i, j);
                    Color colorBlue = bB.GetPixel(i, j);

                    int r = colorRed.R;
                    int g = colorGreen.G;
                    int b = colorBlue.B;

                    if (r < m.redMin)
                    {
                        r = (int)m.redMin;
                    }
                    if (r > m.redMax)
                    {
                        r = (int)m.redMax;
                    }
                    if (g < m.greenMin)
                    {
                        g = (int)m.greenMin;
                    }
                    if (g > m.redMax)
                    {
                        g = (int)m.greenMax;
                    }
                    if (b < m.blueMin)
                    {
                        b = (int)m.blueMin;
                    }
                    if (b > m.blueMax)
                    {
                        b = (int)m.blueMax;
                    }

                    rB.SetPixel(i, j, Color.FromArgb(r, 0, 0));
                    gB.SetPixel(i, j, Color.FromArgb(0, g, 0));
                    bB.SetPixel(i, j, Color.FromArgb(0, 0, b));

                    arrayR[r] += 1;
                    arrayG[g] += 1;
                    arrayB[b] += 1;
                }
            }

            pictureR.Image = rB;
            pictureG.Image = gB;
            pictureB.Image = bB;

            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].Name = "Red";

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;

            for (int i = 0; i < 255; i++)
            {
                chart1.Series[0].Points.AddXY(i, (double)arrayR[i]);
            }


            chart2.Series[0].Color = Color.Green;
            chart2.Series[0].Name = "Green";

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 255;

            for (int i = 0; i < 255; i++)
            {
                chart2.Series[0].Points.AddXY(i, (double)arrayG[i]);
            }

            chart3.Series[0].Color = Color.Blue;
            chart3.Series[0].Name = "Blue";

            chart3.ChartAreas[0].AxisX.Minimum = 0;
            chart3.ChartAreas[0].AxisX.Maximum = 255;

            for (int i = 0; i < 255; i++)
            {
                chart3.Series[0].Points.AddXY(i, (double)arrayB[i]);
            }

            label1.Show();
            label1.ForeColor = Color.FromArgb(209, 32, 48);
            label1.Text = "If you click Histogram RGB you will get histograms of original r, g and b channels (Filters->RBG Channels). Not from filter Min and Max Channels. ";
        }

        private void orderDitheringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }
            HidePictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            pictureBox1.Image = Filters.OrderDithering(bitmap);
        }

        private void crossDomainColorizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }
            HidePictures();
            HideGrayLabel();


            /*if (Filters.Gamma(bitmap, g.red, g.green, g.blue))
            {
                pictureBox1.Image = bitmap;
                this.Invalidate();
            }*/

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            HSV hsv = new HSV();
            hsv.hue = 1;
            hsv.saturation = 0.5;

            if (DialogResult.OK == hsv.ShowDialog())
            {
                if (hsv.saturation < 0 && hsv.saturation > 1)
                {
                    MessageBox.Show("Saturation is not between 0 and 1, please input value again");
                    return;
                }
                if (hsv.hue < -1 && hsv.hue > 5)
                {
                    MessageBox.Show("Hue is not between -1 and 5, please input value again");
                    return;
                }
                pictureBox1.Image = ExtraFilters.CrossDomainColorize(bitmap, hsv.hue, hsv.saturation);
            }
        }

        private void downsampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }
            HidePictures();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            pictureBox1.Image = ExtraFilters.Downsampling422(bitmap);
        }

        private void downsamplingChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }
            ShowPictures();
            ShowDownsampleSave();
            HideGrayLabel();

            UndoStack.Push((Bitmap)bitmap.Clone());
            RedoStack.Clear();

            picture.Image = bitmap;

            int h = bitmap.Height;
            int w = bitmap.Width;

            Bitmap rB = new Bitmap(bitmap);
            Bitmap gB = new Bitmap(bitmap);
            Bitmap bB = new Bitmap(bitmap);

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color color = bitmap.GetPixel(i, j);

                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    rB.SetPixel(i, j, Color.FromArgb(a, r, 0, 0));
                    gB.SetPixel(i, j, Color.FromArgb(a, 0, g, 0));
                    bB.SetPixel(i, j, Color.FromArgb(a, 0, 0, b));
                }
            }

            pictureR.Image = ExtraFilters.Downsampling422Red(rB);
            pictureG.Image = ExtraFilters.Downsampling422Green(gB);
            pictureB.Image = ExtraFilters.Downsampling422Blue(bB);

            label1.Visible = true;
            label1.ForeColor = Color.FromArgb(209, 32, 48);
            label1.Text = "Red and blue channels are downsampled, green is original.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Please load image");
                return;
            }

            HidePictures();
            HideGrayLabel();

            if (rbRed.Checked)
            {
                saveImage.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
                saveImage.FilterIndex = 2;
                if (DialogResult.OK == saveImage.ShowDialog())
                {
                    Bitmap rB = (Bitmap)pictureR.Image;
                    rB.Save(saveImage.FileName);
                }
            }
            else if (rbGreen.Checked)
            {
                saveImage.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
                saveImage.FilterIndex = 2;
                if (DialogResult.OK == saveImage.ShowDialog())
                {
                    Bitmap gB = (Bitmap)pictureG.Image;
                    Bitmap bB = (Bitmap)pictureB.Image;
                    gB.Save(saveImage.FileName);
                }
            }
            else if (rbBlue.Checked)
            {
                saveImage.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
                saveImage.FilterIndex = 2;
                if (DialogResult.OK == saveImage.ShowDialog())
                {
                    Bitmap bB = (Bitmap)pictureB.Image;
                    bB.Save(saveImage.FileName);
                }
            }
            else
            {
                MessageBox.Show("To save image, \nyou have to pick red, green or blue.");
            }
        }

        //private void colorEqualizationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (bitmap == null)
        //    {
        //        MessageBox.Show("Please load image");
        //        return;
        //    }
        //    MessageBox.Show("Select color from the palette");

        //    int S = 0;

        //    if (colorPicker.ShowDialog() == DialogResult.OK)
        //    {
        //        Color tmp;

        //        Color X = colorPicker.Color;

        //        Color Y = bitmap.GetPixel(positionX, positionY);
        //        tmp = Y;
        //        bitmap.SetPixel(positionX, positionY, X);

        //        Parameter parameter = new Parameter();
        //        parameter.Value = 1;

        //        MessageBox.Show("Input similarity threshold");

        //        if (DialogResult.OK == parameter.ShowDialog())
        //        {
        //            UndoStack.Push((Bitmap)bitmap.Clone());
        //            RedoStack.Clear();

        //            S = parameter.Value;
        //        }

        //        MessageBox.Show("Now you have to click on one point in the image");
        //    }
        //    this.Invalidate();

        //}

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            positionX = e.X;
            positionY = e.Y;
        }

        #endregion

    }
}
