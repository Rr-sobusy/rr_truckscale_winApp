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
using Flurl.Http;
using Flurl;
using NutriScience_truckscale.model;

namespace NutriScience_truckscale.view
{
    public partial class pickUpdgv : UserControl
    {
        private string responseString { get; set; }
        public static DataGridView dgv;
        public pickUpdgv()
        {
            InitializeComponent();
            dgv = guna2DataGridView1;
        }

        private async void pickUpdgv_LoadAsync(object sender, EventArgs e)
        {

            responseString = await $"{API._api}/api/pending1"
             .GetStringAsync();
            var names = JsonConvert.DeserializeObject<List<pickupmodel>>(responseString);
            if (responseString.Length > 0)
            {
                bunifuLoader1.Hide();
            }
            foreach (var res in names)
            {
                guna2DataGridView1.Rows.Add(res.plate_no, res.cust_name, res.commodity, res.gross_weight, res.date, res.entry_time);

            }
        }

        private void bunifuLoader1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
          
        }

        private async void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.SelectedCells[0].Value == null)
                {
                    MessageBox.Show("Please select the vehicle to move out", "Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string plate_no = this.guna2DataGridView1.SelectedCells[0].Value.ToString();
                    string commodity = this.guna2DataGridView1.SelectedCells[2].Value.ToString();

                    //Delete from pending and move to weighing out
                    if (MessageBox.Show($"Proceed for weigh-out." +
                        $" Vehicle Plate No : {plate_no} , Commodity : {commodity}", "Weigh-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await $"{API._api}/api/deletepickup"
                      .PostJsonAsync(new
                      {
                          plateNo = plate_no
                      });
                        tstabmain.deliverybtn.PerformClick();
                        weighOutForm wf = new weighOutForm();
                        wf.Show();

                        //This code block performs for computing the net weight
                        int number = Int32.Parse(globalvariables._serialPort.ToString());
                        int difference = number - Convert.ToInt32(this.guna2DataGridView1.SelectedCells[3].Value.ToString());
                        weighOutForm.plate_no.Text = plate_no;
                        weighOutForm.gross.Text = this.guna2DataGridView1.SelectedCells[3].Value.ToString();
                        weighOutForm.tare.Text = number.ToString();
                        weighOutForm.net.Text = difference.ToString();
                        weighOutForm._date.Text = this.guna2DataGridView1.SelectedCells[4].Value.ToString();
                        weighOutForm.entry_time.Text = this.guna2DataGridView1.SelectedCells[5].Value.ToString();
                        weighOutForm.exit_time.Text = DateTime.Now.ToShortTimeString();
                        weighOutForm.customer.Text = this.guna2DataGridView1.SelectedCells[1].Value.ToString();
                        weighOutForm._commodity.Text = this.guna2DataGridView1.SelectedCells[2].Value.ToString();

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
    }
}
