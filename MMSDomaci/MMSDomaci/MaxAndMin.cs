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
    public partial class MaxAndMin : Form
    {
        public MaxAndMin()
        {
            InitializeComponent();


            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public double redMin
        {
            get
            {
                return (Convert.ToDouble(tbRedMin.Text));
            }
            set { tbRedMin.Text = value.ToString(); }
        }

        public double redMax
        {
            get
            {
                return (Convert.ToDouble(tbRedMax.Text));
            }
            set { tbRedMax.Text = value.ToString(); }
        }

        public double greenMin
        {
            get
            {
                return (Convert.ToDouble(tbGreenMin.Text));
            }
            set { tbGreenMin.Text = value.ToString(); }
        }

        public double greenMax
        {
            get
            {
                return (Convert.ToDouble(tbGreenMax.Text));
            }
            set { tbGreenMax.Text = value.ToString(); }
        }

        public double blueMin
        {
            get
            {
                return (Convert.ToDouble(tbBlueMin.Text));
            }
            set { tbBlueMin.Text = value.ToString(); }
        }

        public double blueMax
        {
            get
            {
                return (Convert.ToDouble(tbBlueMax.Text));
            }
            set { tbBlueMax.Text = value.ToString(); }
        }
        private void MaxAndMin_Load(object sender, EventArgs e)
        {

            tbRedMin.Text = "50";
            tbRedMax.Text = "150";
            tbGreenMin.Text = "80";
            tbGreenMax.Text = "255";
            tbBlueMin.Text = "90";
            tbBlueMax.Text = "110";
        }
    }
}
