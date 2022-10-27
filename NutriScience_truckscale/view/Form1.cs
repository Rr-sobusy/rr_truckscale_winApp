using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NutriScience_truckscale.view;
using NutriScience_truckscale.model;
using Flurl.Http;

namespace NutriScience_truckscale
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            bunifuLoader1.Show();
            var result = await $"{API._api}/api/authenticateuser"
          .PostJsonAsync(new
          {
              userName = bunifuTextBox1.Text,
              passWord = bunifuTextBox2.Text
             
          }).Result.GetStringAsync();

           if(result == "User authenticated")
            {
                bunifuLoader1.Hide();
                Mainwindow form = new Mainwindow();
                form.Show();
                this.Hide();
                
               
            }
            else
            {
                MessageBox.Show("Log-in Failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuLoader1.Hide();
            }
            
        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bunifuLoader1.Hide();
        }
    }
}
