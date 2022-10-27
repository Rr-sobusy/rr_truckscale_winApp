using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Newtonsoft.Json;
using NutriScience_truckscale.model;
using RestSharp;
using Bunifu.UI.WinForms;

namespace NutriScience_truckscale.view
{
    public partial class loadWeightForm : Form
    {
     
        private string _rawmats;

        private string _names;
        private string _products;
        private string responseString;
        public static BunifuDropdown drop1;
        public static BunifuDropdown drop2;
        public loadWeightForm()
        {
            InitializeComponent();
            drop1 = customertxt;
            drop2 = commoditytxt;
        }

       
        private async void loadWeightForm_Load(object sender, EventArgs e)
        {
            try
            {
             

                _names = await $"{API._api}/api/getcustomers"
                 .GetStringAsync();
                var names = JsonConvert.DeserializeObject<List<customers>>(_names);
               
                _products = await $"{API._api}/api/getproducts"
              .GetStringAsync();
                var products = JsonConvert.DeserializeObject<List<products>>(_products);

                _rawmats = await $"{API._api}/api/getrawmats"
              .GetStringAsync();
                var rawmats = JsonConvert.DeserializeObject<List<materials>>(_rawmats);

                foreach (var res in names)
                {
                    //Map customer names in the customer dropdown options
                    customertxt.Items.Add(res.cust_name);
                }

                if (globalvariables._mode == "pick-up")
                {
                    foreach (var res in products)
                    {
                        //Map the products if pickup is selected
                        commoditytxt.Items.Add(res.product_name);
                    }
                }

                if(globalvariables._mode == "delivery")
                {
                    foreach (var res in rawmats)
                    {
                        //Map rawmats if delivery is selected
                        commoditytxt.Items.Add(res.rawmat_name);
                    }
                }
                entryWeight.Text = globalvariables._serialPort;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (plateNo.Text == "" || customertxt.Text == "" || commoditytxt.Text == "")
            {
                MessageBox.Show("Please validate missing fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (globalvariables._mode == "pick-up")
                    {
                        var result = await $"{API._api}/api/postpendingpickup"
                   .PostJsonAsync(new
                   {
                       plateNo = plateNo.Text,
                       grossWeight = entryWeight.Text,
                       custName = customertxt.Text,
                       commodity = commoditytxt.Text,
                       date = DateTime.Now.ToShortDateString().ToString(),
                       entryTime = DateTime.Now.ToShortTimeString().ToString()
                   });
                        this.Close();
                    }

                    if (globalvariables._mode == "delivery")
                    {

                        var result = await $"{API._api}/api/postpendingdelivery"
                   .PostJsonAsync(new
                   {
                       plateNo = plateNo.Text,
                       grossWeight = entryWeight.Text,
                       custName = customertxt.Text,
                       commodity = commoditytxt.Text,
                       date = DateTime.Now.ToShortDateString().ToString(),
                       entryTime = DateTime.Now.ToShortTimeString().ToString()
                   });
                        this.Close();
                    }

                }
                catch (FlurlHttpException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                pickUpdgv pu = new pickUpdgv();
                switchPanel.dispuc(pu, tstabmain.pnl);
            }
        }
        public static string customOptions { get; set; }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            addNew add = new addNew();
            add.Show();
            customOptions = "customer";
            addNew.deflabel.Text = "Set Customer name";
        }

        private void guna2PictureBox1_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            customOptions = "commodity";
            addNew add = new addNew();
            add.Show();
            addNew.deflabel.Text = "Set Commodity";
        }
    }
}
