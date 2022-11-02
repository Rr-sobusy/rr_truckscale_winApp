using Flurl.Http;
using Newtonsoft.Json;
using NutriScience_truckscale.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutriScience_truckscale.view
{
    public partial class addItems : Form
    {

        public addItems()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addItems_Load(object sender, EventArgs e)
        {
            if (truckScaleManagement.selectedButton == "customers")
            {
                nameLabel.Text = "Add New Customer";
                bunifuTextBox1.PlaceholderText = "New customer";
            }
            if (truckScaleManagement.selectedButton == "products")
            {
                nameLabel.Text = "Add New Product";
                bunifuTextBox1.PlaceholderText = "New product";
            }
            if (truckScaleManagement.selectedButton == "materials")
            {
                nameLabel.Text = "Add New Material";
                bunifuTextBox1.PlaceholderText = "New material";
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "")
            {
                MessageBox.Show("Can't leave the text-field empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (truckScaleManagement.selectedButton == "customers")
                {

                    var result = await $"{API._api}/api/postnewcustomer"
                  .PostJsonAsync(new
                  {
                      custName = bunifuTextBox1.Text
                  });
                    //
                    var _custNames = await $"{API._api}/api/getcustomers".GetStringAsync();
                    var customers = JsonConvert.DeserializeObject<List<customers>>(_custNames);

                    truckScaleManagement.dgv1.Rows.Clear();
                    int i = 1;
                    foreach (var res in customers)
                    {
                        truckScaleManagement.dgv1.Rows.Add(i, res.cust_name);
                        i++;
                    }
                    this.Close();
                }

                if (truckScaleManagement.selectedButton == "products")
                {

                    var result = await $"{API._api}/api/postnewproduct"
                  .PostJsonAsync(new
                  {
                      productName = bunifuTextBox1.Text
                  });
                    //
                    var _products = await $"{API._api}/api/getproducts".GetStringAsync();
                    var products = JsonConvert.DeserializeObject<List<products>>(_products);

                    truckScaleManagement.dgv2.Rows.Clear();
                    int i = 1;
                    foreach (var res in products)
                    {
                        truckScaleManagement.dgv2.Rows.Add(i, res.product_name);
                        i++;
                    }
                    this.Close();
                }

                if (truckScaleManagement.selectedButton == "materials")
                {

                    var result = await $"{API._api}/api/postnewmaterial"
                  .PostJsonAsync(new
                  {
                      rawmatName = bunifuTextBox1.Text
                  });
                    //
                    var _rawmats = await $"{API._api}/api/getrawmats".GetStringAsync();
                    var rawmats = JsonConvert.DeserializeObject<List<materials>>(_rawmats);

                    truckScaleManagement.dgv3.Rows.Clear();
                    int i = 1;
                    foreach (var res in rawmats)
                    {
                        truckScaleManagement.dgv3.Rows.Add(i, res.rawmat_name);
                        i++;
                    }
                    this.Close();
                }
            }
        }
    }
}
