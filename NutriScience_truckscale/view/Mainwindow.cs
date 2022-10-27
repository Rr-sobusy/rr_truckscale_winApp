using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using NutriScience_truckscale.model;
using Newtonsoft.Json;
using Guna.UI2.WinForms;

namespace NutriScience_truckscale.view
{
    public partial class Mainwindow : Form
    {
        string responseString;
        public static Guna2Button generate;
        public Mainwindow()
        {
            InitializeComponent();
            generate = guna2Button8;
        }

        private async void Mainwindow_LoadAsync(object sender, EventArgs e)
        {
            isPanelHidden = true;
            tssidebarPanel.Hide();
            isPanel2Hidden = true;
            panel2.Hide();

             //Start with Truckscale UserControl
             tstabmain ts = new tstabmain();
            switchPanel.dispuc(ts, truckscaletab);
            
          
           
           
        }

        private void bunifuToolTip1_Popup(object sender, Bunifu.UI.WinForms.BunifuToolTip.PopupEventArgs e)
        {

        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
           

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting in to the server");
            }

        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            tstabmain._serialPort1.Close();
            Application.Exit();
        }

        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
      
        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void mainPanel_Click(object sender, EventArgs e)
        {

        }
        private bool isPanelHidden { get; set; }
        private bool isPanel2Hidden { get; set; }



        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            tstabmain tab = new tstabmain();
            switchPanel.dispuc(tab, truckscaletab);
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (isPanelHidden == true)
            {
                tssidebarPanel.Show();
                isPanelHidden = !isPanelHidden;
            }
            else
            {
                tssidebarPanel.Hide();
                isPanelHidden = !isPanelHidden;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            weighingHistoryTab tab = new weighingHistoryTab();
            switchPanel.dispuc(tab, truckscaletab);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            truckScaleManagement tab = new truckScaleManagement();
            switchPanel.dispuc(tab, truckscaletab);
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if(isPanel2Hidden == true)
            {
                panel2.Show();
                isPanel2Hidden = !isPanel2Hidden;
            }
            else
            {
                panel2.Hide();
                isPanel2Hidden = !isPanel2Hidden;
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            printReceivingReport tab = new printReceivingReport();
            switchPanel.dispuc(tab, truckscaletab);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            receivingReportHistory tab = new receivingReportHistory();
            switchPanel.dispuc(tab, truckscaletab);
        }

        private void truckscaletab_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            truckScaleManagement tab = new truckScaleManagement();
            switchPanel.dispuc(tab, truckscaletab);
        }
    }
}
