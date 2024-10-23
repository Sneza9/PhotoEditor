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
    public partial class Gamma : Form
    {
        public Gamma()
        {
            InitializeComponent();

			btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
		public double red
		{
			get
			{
				return (Convert.ToDouble(tbRed.Text));
			}
			set { tbRed.Text = value.ToString(); }
		}

		public double green
		{
			get
			{
				return (Convert.ToDouble(tbGreen.Text));
			}
			set { tbGreen.Text = value.ToString(); }
		}

		public double blue
		{
			get
			{
				return (Convert.ToDouble(tbBlue.Text));
			}
			set { tbBlue.Text = value.ToString(); }
		}
    }
}
