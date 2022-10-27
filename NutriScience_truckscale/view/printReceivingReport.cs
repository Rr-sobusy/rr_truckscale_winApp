using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using NutriScience_truckscale.model;
using Newtonsoft.Json;
using Flurl.Http;

namespace NutriScience_truckscale.view
{
    public partial class printReceivingReport : UserControl
    {
       public static List<string> _contents = new List<string>();
        private string _names;
        private string result;
        public printReceivingReport()
        {
            InitializeComponent();

        }

        private async void printReceivingReport_Load(object sender, EventArgs e)
        {
            hide4panel();
            _names = await $"{API._api}/api/getcustomers"
               .GetStringAsync();
            var names = JsonConvert.DeserializeObject<List<customers>>(_names);

            foreach (var result in names)
            {
                supplier.Items.Add(result.cust_name);
            }
        
        }



        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void showPanel(Panel pnl)
        {
            pnl.Show();
        }

        private void hide4panel()
        {
            panel1.Hide();
            panel2.Hide();
            bunifuPanel2.Hide();
            bunifuPanel3.Hide();
            bunifuPanel4.Hide();
            bunifuButton22.Hide();
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private int fields { get; set; }
        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            bunifuButton22.Show();
             fields = Convert.ToInt32(fieldNumber.Text);
           
            if (Convert.ToInt32(fieldNumber.Text) == 0)
            {
                MessageBox.Show("Can't accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (fields)
                {
                    default:
                        MessageBox.Show("Maximum fields is set to 5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1:
                        panel1.Show();
                        panel2.Hide();
                        bunifuPanel2.Hide();
                        bunifuPanel3.Hide();
                        bunifuPanel4.Hide();
                        break;
                    case 2:
                        panel1.Show();
                        panel2.Show();
                        bunifuPanel2.Hide();
                        bunifuPanel3.Hide();
                        bunifuPanel4.Hide();
                        break;
                    case 3:
                        panel1.Show();
                        panel2.Show();
                        bunifuPanel2.Show();
                        bunifuPanel3.Hide();
                        bunifuPanel4.Hide();
                        break;
                    case 4:
                        panel1.Show();
                        panel2.Show();
                        bunifuPanel2.Show();
                        bunifuPanel3.Show();
                        bunifuPanel4.Hide();

                        break;
                    case 5:
                        panel1.Show();
                        panel2.Show();
                        bunifuPanel2.Show();
                        bunifuPanel3.Show();
                        bunifuPanel4.Show();
                        break;
                }
            }
           

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public string rex;
        private async void bunifuButton22_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(fieldNumber.Text) == 0)
            {
                MessageBox.Show("Can't accept 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (fields)
                {
                    case 1:
                        _contents.Add($"1. {description1.Text} {quantity1.Text}{unit1.Text}");
                        break;

                    case 2:
                        _contents.Add($"1. {description1.Text} {quantity1.Text}{unit1.Text} 2. {description2.Text} {quantity2.Text}{unit2.Text}");
                        break;
                    case 3:
                        _contents.Add($"1. {description1.Text} {quantity1.Text}{unit1.Text} 2. {description2.Text} {quantity2.Text}{unit2.Text} 3. {description3.Text} {quantity3.Text}{unit3.Text}");
                        break;
                    case 4:
                        _contents.Add($"1. {description1.Text} {quantity1.Text}{unit1.Text} 2. {description2.Text} {quantity2.Text}{unit2.Text} 3. {description3.Text} {quantity3.Text}{unit3.Text} 4. {description4.Text} {quantity4.Text}{unit4.Text}");
                        break;
                    case 5:
                        _contents.Add($"1. {description1.Text} {quantity1.Text}{unit1.Text} 2. {description2.Text} {quantity2.Text}{unit2.Text} 3. {description3.Text} {quantity3.Text}{unit3.Text} 4. {description4.Text} {quantity4.Text}{unit4.Text} 5. {description5.Text} {quantity5.Text}{unit5.Text}");
                        break;

                }
                foreach (var res in _contents)
                {
                    var result = await $"{API._api}/api/postreceivingreportrecords"
        .PostJsonAsync(new
        {
            receiptNumber = receiptNo.Text,
            supplier = supplier.Text,
            poNumber = poNumber.Text,
            siNumber = siNumber.Text,
            drNumber = drNumber.Text,
            date = date.Value.ToShortDateString(),
            content = res
        });
                }
                _contents.Clear();

                rex = drNumber.Text;



                forPostrr form = new forPostrr();
                form.Show();

            

               
                form._quantity1.Text = quantity1.Text;
                form._unit1.Text = unit1.Text;
                form._description1.Text = description1.Text;
                form._quantity2.Text = quantity2.Text.ToString();
                form._unit2.Text = unit2.Text.ToString();
                form._description2.Text = description2.Text.ToString();
                form._quantity3.Text = quantity3.Text;
                form._unit3.Text = unit3.Text;
                form._description3.Text = description3.Text;
                form._quantity4.Text = quantity4.Text;
                form._unit4.Text = unit4.Text;
                form._description4.Text = description4.Text;
                form._quantity5.Text = quantity5.Text;
                form._unit5.Text = unit5.Text;
                form._description5.Text = description5.Text;

                //
                form._supplier.Text = supplier.Text;
                form._date.Text = date.Value.ToShortDateString();
                form._poNumber.Text = poNumber.Text;
                form._drNumber.Text = drNumber.Text;
                form._siNumber.Text = siNumber.Text;

                


                /*
                form._quantity3.Text = quantity3.Text;
                form._unit3.Text = unit3.Text;
                form._description3.Text = description3.Text;
                form._quantity4.Text = quantity4.Text;
                form._unit4.Text = unit4.Text;
                form._description4.Text = description4.Text;
                form._quantity5.Text = quantity5.Text;
                form._unit5.Text = unit5.Text;
                form._description5.Text = description5.Text;

                //
                form._supplier.Text = supplier.Text;
                form._date.Text = date.Text;
                form._poNumber.Text = poNumber.Text;
                form._drNumber.Text = drNumber.Text;
                form._siNumber.Text = siNumber.Text;
                */
            }

        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
           foreach(var results in _contents)
            {
                MessageBox.Show(results);
            }
        }

        private void fieldNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void quantity1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    


}
