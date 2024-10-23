using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMSDomaci
{
    public partial class HSV : Form
    {
        public HSV()
        {
            InitializeComponent();

            label1.Text = "Hue\n(values between -1 and 5)";
            label2.Text = "Saturation\n(values between 0 and 1)";

            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

		public double hue
		{
			get
			{
				return (Convert.ToDouble(tbHue.Text));
			}
			set { tbHue.Text = value.ToString(); }
		}

		public double saturation
		{
			get
			{
                if (tbSatuation.Text=="")
                {
					return Convert.ToDouble(2);
                }
                else
                {
					return (Convert.ToDouble(tbSatuation.Text));
				}
			}
			set { tbSatuation.Text = value.ToString(); }
		}
	}
}
