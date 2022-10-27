using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Bunifu.UI.WinForms;
using NutriScience_truckscale.model;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace NutriScience_truckscale.view
{
    public partial class truckScaleManagement : UserControl
    {
        private string _custNames;
        private string _productName;
        private string _rawmatName;

        public truckScaleManagement()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void truckScaleManagement_Load(object sender, EventArgs e)
        {
            //For Customers Names
            _custNames = await $"{API._api}/api/getcustomers".GetStringAsync();
            var custNames = JsonConvert.DeserializeObject<List<customers>>(_custNames);
            int i = 1;
            int j = 1;
            int k = 1;
            if (_custNames.Length != 0)
                bunifuLoader1.Hide();
            foreach (var result in custNames)
            {
                customerTable.Rows.Add(i, result.cust_name);
                i++;
            }

            //FOr Product Names
            _productName = await $"{API._api}/api/getproducts".GetStringAsync();
            var productNames = JsonConvert.DeserializeObject<List<products>>(_productName);
            if (_productName.Length != 0)
                bunifuLoader2.Hide();
            foreach (var result in productNames)
            {
                productTable.Rows.Add(j, result.product_name);
                j++;
            }

            //For Rawmat Names
            _rawmatName = await $"{API._api}/api/getrawmats".GetStringAsync();
            var rawmatName = JsonConvert.DeserializeObject<List<materials>>(_rawmatName);
            if (_rawmatName.Length != 0)
                bunifuLoader3.Hide();
            foreach (var result in rawmatName)
            {
                rawmatTable.Rows.Add(k, result.rawmat_name);
                k++;
            }
        }
    }
}
