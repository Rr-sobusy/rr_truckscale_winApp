using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriScience_truckscale.view
{
    public partial class Truckscale_tab : UserControl
    {
        Mainwindow mw;
        public Truckscale_tab()
        {
            InitializeComponent();
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tspanelMain_Click(object sender, EventArgs e)
        {

        }

        string[] items = { "rex", "randy" };
        private void Truckscale_tab_Load(object sender, EventArgs e)
        {
            dropDown.Items.Add(items);
        }
    }
}
