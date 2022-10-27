using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NutriScience_truckscale.model;
using Flurl.Http;

namespace NutriScience_truckscale.view
{
    public partial class deliverydgv : UserControl
    {
        private string responseString;

        public deliverydgv()
        {
            InitializeComponent();
        }

        private async void deliverydgv_Load(object sender, EventArgs e)
        {


            //Collecting datas from API in initial render
            responseString = await $"{API._api}/api/pending2"
             .GetStringAsync();
            var names = JsonConvert.DeserializeObject<List<deliverymodel>>(responseString);
            if (responseString.Length > 0)
            {
                bunifuLoader1.Hide();
            }
            foreach (var res in names)
            {
                guna2DataGridView1.Rows.Add(res.plate_no, res.cust_name, res.commodity, res.gross_weight, res.date, res.entry_time);

            }
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.SelectedCells[0].Value == null)
                {
                    MessageBox.Show("Please select the vehicle to move out", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    string plate_no = this.guna2DataGridView1.SelectedCells[0].Value.ToString();
                    string commodity = this.guna2DataGridView1.SelectedCells[2].Value.ToString();

                    if (MessageBox.Show($"Proceed for weigh-out." +
                       $" Vehicle Plate No : {plate_no} , Commodity : {commodity}", "Weigh-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        var result = await $"{API._api}/api/deletedelivery"
                      .PostJsonAsync(new
                      {
                          plateNo = plate_no
                      });
                        tstabmain.pickupbtn.PerformClick();
                        weighOutDelivery form = new weighOutDelivery();
                        form.Show();

                        //This code block performs for computing the net weight
                        int number = Int32.Parse(globalvariables._serialPort.ToString());
                        int difference = Convert.ToInt32(this.guna2DataGridView1.SelectedCells[3].Value.ToString()) - number;
                        weighOutDelivery.plate_no.Text = plate_no;
                        weighOutDelivery.gross.Text = this.guna2DataGridView1.SelectedCells[3].Value.ToString();
                        weighOutDelivery.tare.Text = number.ToString();
                        weighOutDelivery.net.Text = difference.ToString();
                        weighOutDelivery._date.Text = this.guna2DataGridView1.SelectedCells[4].Value.ToString();
                        weighOutDelivery.entry_time.Text = this.guna2DataGridView1.SelectedCells[5].Value.ToString();
                        weighOutDelivery.exit_time.Text = DateTime.Now.ToShortTimeString();
                        weighOutDelivery.customer.Text = this.guna2DataGridView1.SelectedCells[1].Value.ToString();
                        weighOutDelivery._commodity.Text = this.guna2DataGridView1.SelectedCells[2].Value.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
