using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounts.UI
{
    public partial class frmbarcodetest : Form
    {
        public frmbarcodetest()
        {
            InitializeComponent();
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(DateTime.Now.Second.ToString());
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(DateTime.Now.Second.ToString());
        }
    }
}
