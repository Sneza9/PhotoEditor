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
    public partial class Parameter : Form
    {
        //Used in Edge enhance and Color equalization filters (ExtraFilters class)
        public Parameter()
        {
            InitializeComponent();

            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel; 
        }

        public int Value
        {
            get
            {
                return (Convert.ToInt32(tbValue.Text, 10));
            }
            set { tbValue.Text = value.ToString(); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
