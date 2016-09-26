using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;



namespace Control_panel_application_1
{
    public partial class Form1 : Form
    {
        private bool debug = false;
          
        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
        }
        void getAvailablePorts()
        {
            serialPort1.Close();
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button1.Text = "Connect";
            textBox4.Text = Convert.ToString(vScrollBar1.Value);
            textBox3.Text = Convert.ToString(vScrollBar2.Value);
            textBox6.Text = Convert.ToString(vScrollBar4.Value);
            textBox5.Text = Convert.ToString(vScrollBar3.Value);
            textBox7.Text = Convert.ToString(vScrollBar5.Value);
            textBox8.Text = Convert.ToString(vScrollBar6.Value);
            textBox9.Text = Convert.ToString(vScrollBar7.Value);
            textBox10.Text = Convert.ToString(vScrollBar8.Value);
        }
        void cleanPort()
        {
            serialPort1.DiscardInBuffer(); // clear the RX line
            serialPort1.DiscardOutBuffer(); //clear the TX line
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Command for send the gui  the Encoder values
        {
            cleanPort();
            serialPort1.WriteLine("READ,E"); //READ,E
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button3_Click(object sender, EventArgs e)  //Will Reset Encoder
        {
            cleanPort();
            serialPort1.WriteLine("RESET,E"); //RESET,E
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)     // Refresh button
        {
            getAvailablePorts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    textBox13.Text = "Select Com port or Refresh the Control Panel.";

                }
                else if (comboBox2.Text == "")
                {

                }
                else
                {
                    if (button1.Text == "Connect")
                    {
                        serialPort1.PortName = comboBox1.Text;
                        serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                        serialPort1.Open();
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button8.Enabled = true;
                        button9.Enabled = true;
                        button10.Enabled = true;
                        button11.Enabled = true;
                        button12.Enabled = true;
                        button13.Enabled = true;
                        button14.Enabled = true;
                        button15.Enabled = true;
                        button16.Enabled = true;
                        button1.Text = "Disconnect";
                    }
                    else
                    {
                        getAvailablePorts(); 
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox13.Text = "Unauthorized Access Exception";
            }
        }

        private void button7_Click(object sender, EventArgs e) // sending PID parameters for left motor
        {
            cleanPort();
            serialPort1.WriteLine("MOTOR,H,"+ Convert.ToString(numericUpDown1.Value) +"," + Convert.ToString(numericUpDown2.Value) + "," + Convert.ToString(numericUpDown3.Value) + ",1");  //MOTOR,H,kp,ki,kd,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button10_Click(object sender, EventArgs e)// sending PID parameters for Right motor
        {
            cleanPort();
            serialPort1.WriteLine("MOTOR,H," + Convert.ToString(numericUpDown6.Value) + "," + Convert.ToString(numericUpDown5.Value) + "," + Convert.ToString(numericUpDown4.Value) + ",2");  //MOTOR,H,kp,ki,kd,1/2
            if (debug)
           {
               textBox13.Text = serialPort1.ReadLine();
           }
        }

        private void button5_Click(object sender, EventArgs e)          // Left motor max and min speed
        {
            cleanPort();
            serialPort1.WriteLine("MOTOR,M," + Convert.ToString(vScrollBar1.Value) + "," + Convert.ToString(vScrollBar2.Value) + ",1"); //MOTOR,M,Max,Min,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }
        private void button11_Click(object sender, EventArgs e)         // Right motor max and min speed
        {
            cleanPort();
            serialPort1.WriteLine("MOTOR,M," + Convert.ToString(vScrollBar4.Value) + "," + Convert.ToString(vScrollBar3.Value) + ",2"); //MOTOR,M,Max,Min,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e) //      
        {
            textBox4.Text=Convert.ToString(vScrollBar1.Value);
        }   
        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox3.Text = Convert.ToString(vScrollBar2.Value);
        }
        private void vScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            textBox6.Text = Convert.ToString(vScrollBar4.Value);
        }

        private void vScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            textBox5.Text = Convert.ToString(vScrollBar3.Value);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cleanPort();
            serialPort1.WriteLine("READ,H,1"); //READ,H,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cleanPort();
            serialPort1.WriteLine("READ,H,2"); //READ,H,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button15_Click(object sender, EventArgs e)  //Driving through Pwm
        {
            cleanPort();
            serialPort1.WriteLine("MOTOR,L," + Convert.ToString(vScrollBar8.Value) + "," + Convert.ToString(vScrollBar7.Value)); //MOTOR,L,Left motor,Right Motor
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button14_Click(object sender, EventArgs e) //Drive through mm/s
        {
            cleanPort();
            serialPort1.WriteLine("MOTOR,D," + Convert.ToString(vScrollBar6.Value) + "," + Convert.ToString(vScrollBar5.Value)); //MOTOR,D,Left motor,Right Motor
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void vScrollBar8_Scroll(object sender, ScrollEventArgs e)
        {
            textBox10.Text = Convert.ToString(vScrollBar8.Value);
        }

        private void vScrollBar7_Scroll(object sender, ScrollEventArgs e)
        {
            textBox9.Text = Convert.ToString(vScrollBar7.Value);
        }

        private void vScrollBar6_Scroll(object sender, ScrollEventArgs e)
        {
            textBox8.Text = Convert.ToString(vScrollBar6.Value);
        }

        private void vScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            textBox7.Text = Convert.ToString(vScrollBar5.Value);
        }
    }
}
