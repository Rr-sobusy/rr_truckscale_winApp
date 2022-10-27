using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Flurl.Http;
using Flurl;
using NutriScience_truckscale.model;


namespace NutriScience_truckscale.view
{
    public partial class addNew : Form
    {
        public static BunifuLabel deflabel;
        public addNew()
        {
            InitializeComponent();
            deflabel = definitionLabel;
        }

        private void addNew_Load(object sender, EventArgs e)
        {

        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            //Customer
            if (loadWeightForm.customOptions == "customer")
            {
                if (MessageBox.Show("Save the inputted name to database?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var result = await $"{API._api}/api/postnewcustomer"
                   .PostJsonAsync(new
                   {
                       custName = bunifuTextBox1.Text,
                   });
                    loadWeightForm.drop1.Text = bunifuTextBox1.Text;
                    this.Close();
                }
                else
                {
                    loadWeightForm.drop1.Text = bunifuTextBox1.Text;
                    this.Close();
                }
            }

            //Commodity
            if (loadWeightForm.customOptions == "commodity")
            {
                if (globalvariables._mode == "pick-up")
                {

                    if (MessageBox.Show("Save the inputted name to database?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        var result = await $"{API._api}/api/postnewproduct"
                   .PostJsonAsync(new
                   {
                       productName = bunifuTextBox1.Text,
                   });
                        loadWeightForm.drop2.Text = bunifuTextBox1.Text;
                        this.Close();
                    }
                    else
                    {
                        loadWeightForm.drop2.Text = bunifuTextBox1.Text;
                        this.Close();
                    }
                }

                if (globalvariables._mode == "delivery")
                {
                    if (MessageBox.Show("Save the inputted material to database?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await $"{API._api}/api/postnewmaterial"
                   .PostJsonAsync(new
                   {
                       rawmatName = bunifuTextBox1.Text,
                   });
                        loadWeightForm.drop2.Text = bunifuTextBox1.Text;
                        this.Close();
                    }
                    else
                    {
                        loadWeightForm.drop2.Text = bunifuTextBox1.Text;
                        this.Close();
                    }
                }
              
            }



        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {

        }
    }
}
