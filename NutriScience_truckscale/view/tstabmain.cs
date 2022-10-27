using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using NutriScience_truckscale.model;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Flurl.Http;

namespace NutriScience_truckscale.view
{
    public partial class tstabmain : UserControl
    {
        private const int BaudRate = 9600;
        public static SerialPort _serialPort1;
        public static Guna2Button pickupbtn;
        public static Guna2Button deliverybtn;
  
     
        public tstabmain()
        {
            InitializeComponent();
            fetchSerial();
            pickupbtn = guna2Button1;
            deliverybtn = guna2Button2;
            bunifuDatePicker1.Text = DateTime.Now.ToShortDateString();
           
        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuRadioButton2_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {

        }

        private void loadWeightevent(object sender, EventArgs e)
        {
            if (pickupOption.Checked != false || deliveryOption.Checked != false)
            {
                loadWeightForm lw = new loadWeightForm();
                lw.Show();
            }
            else
            {
                MessageBox.Show("Please select mode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static Panel pnl;
        private void tstabmain_Load(object sender, EventArgs e)
        {
            pickUpdgv pu = new pickUpdgv();
            switchPanel.dispuc(pu, dgvPanel);
            pnl = dgvPanel;
        }

        private delegate void Closure();
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }

        //Fetch the datas coming from serial port
        private void fetchSerial()
        {
            try
            {
                if (_serialPort1 != null && _serialPort1.IsOpen)
                    _serialPort1.Close();
                if (_serialPort1 != null)
                    _serialPort1.Dispose();

               
                _serialPort1 = new SerialPort("COM1", BaudRate, Parity.None, 8, StopBits.One);
                _serialPort1.Handshake = Handshake.None;

               // this event happens everytime when new data is received by the ComPort
                _serialPort1.DataReceived += new SerialDataReceivedEventHandler(_serialPort1_DataReceived);
                _serialPort1.RtsEnable = true;
                _serialPort1.DtrEnable = true;
                _serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (InvokeRequired) // makes sure the function is invoked to work properly in the UI-Thread
                BeginInvoke(new Closure(() => { _serialPort1_DataReceived(sender, e); })); //<-- Function invokes itself
            else
                while (_serialPort1.BytesToRead > 0)
                {
                    try
                    {
                        string data = _serialPort1.ReadExisting();
                        string data1 = data.Remove(6);
                        string data2 = data1.Remove(0, 1);
                        string rvrse = data2;
                        char[] textArray = rvrse.ToCharArray();
                        Array.Reverse(textArray);
                        globalvariables._serialPort = new string(textArray);
                        if (_serialPort1.BytesToRead != 0)
                        {
                            serialData.Text = "No data received";
                        }
                        else
                        {
                            serialData.Text = globalvariables._serialPort + " " + "kgs.";
                        }
                    }
                    catch
                    {
                    }
                }
        }

      
        public void bunifuButton21_Click_1(object sender, EventArgs e)
        {
           
        }
        public EventHandler click;

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
          
           
        }

        public string _mode;

        private void setMode(string mode)
        {
            _mode = mode;
        }

        private void pickupOption_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            setMode("pick-up");
        }

        private void deliveryOption_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(globalvariables._mode);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            setMode("delivery");
        }

        private void deliveryOption_CheckedChanged(object sender, EventArgs e)
        {
            globalvariables._mode = "delivery";
        }

        private void pickupOption_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bunifuButton21_Click_1(this, EventArgs.Empty);
        }

        private void pickupOption_CheckedChanged_1(object sender, EventArgs e)
        {
            globalvariables._mode = "pick-up";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            deliverydgv dv = new deliverydgv();
            switchPanel.dispuc(dv, dgvPanel);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pickUpdgv pu = new pickUpdgv();
            switchPanel.dispuc(pu, dgvPanel);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicked");
        }
    }
}
