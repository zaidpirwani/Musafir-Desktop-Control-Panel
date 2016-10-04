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
        private bool pressed = false;

        public Form1()
        {
            InitializeComponent();
            
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
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
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
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Command for send the gui  the Encoder values
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,R"); //MOTOR,R
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button3_Click(object sender, EventArgs e)  //Will Reset Encoder
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,I"); //MOTOR,I
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
            getAvailablePorts();
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
                        button7.Enabled = true;
                        button8.Enabled = true;
                        button9.Enabled = true;
                        button10.Enabled = true;
                        button11.Enabled = true;
                        button14.Enabled = true;
                        button15.Enabled = true;
                        button1.Text = "Disconnect";
                        textBox13.Text = "";
                        serialPort1.NewLine="\n";
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
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,H,"+ Convert.ToString(numericUpDown1.Value) +"," + Convert.ToString(numericUpDown2.Value) + "," + Convert.ToString(numericUpDown3.Value) + ",1");  //MOTOR,H,kp,ki,kd,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button10_Click(object sender, EventArgs e)// sending PID parameters for Right motor
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,H," + Convert.ToString(numericUpDown6.Value) + "," + Convert.ToString(numericUpDown5.Value) + "," + Convert.ToString(numericUpDown4.Value) + ",2");  //MOTOR,H,kp,ki,kd,1/2
            if (debug)
           {
               textBox13.Text = serialPort1.ReadLine();
           }
        }

        private void button5_Click(object sender, EventArgs e)          // Left motor max and min speed
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,M," + Convert.ToString(vScrollBar1.Value) + "," + Convert.ToString(vScrollBar2.Value) + ",1"); //MOTOR,M,Max,Min,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }
        private void button11_Click(object sender, EventArgs e)         // Right motor max and min speed
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,M," + Convert.ToString(vScrollBar4.Value) + "," + Convert.ToString(vScrollBar3.Value) + ",2"); //MOTOR,M,Max,Min,1/2
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

        private void button8_Click(object sender, EventArgs e)  //command for slave to send the encoder reading
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,S,1"); //MOTOR,S,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button9_Click(object sender, EventArgs e)//command for slave to send the encoder reading
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,S,2"); //MOTOR,S,1/2
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button15_Click(object sender, EventArgs e)  //Driving through Pwm
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,L," + Convert.ToString(vScrollBar8.Value) + "," + Convert.ToString(vScrollBar7.Value)); //MOTOR,L,Left motor,Right Motor
            if (debug)
            {
                textBox13.Text = serialPort1.ReadLine();
            }
        }

        private void button14_Click(object sender, EventArgs e) //Drive through mm/s
        {
            serialPort1.DiscardOutBuffer(); //clear the TX line
            serialPrint("MOTOR,D," + Convert.ToString(vScrollBar6.Value) + "," + Convert.ToString(vScrollBar5.Value)); //MOTOR,D,Left motor,Right Motor
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
        private void serialPrint(String text)
        {
            textBox13.AppendText(">>" + text+"\n");
            serialPort1.WriteLine(text);
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String dataRead = serialPort1.ReadLine();
            textBox13.Invoke(new EventHandler(delegate
            {
                textBox13.AppendText("--"+dataRead+"\n");
            }));
            int a, b, c , d ;
            String s1 = "",s2 = "", s3 = "", s4 = "";
         
            if (dataRead.StartsWith("s"))
            {
                
                a = dataRead.IndexOf(",");
                b = dataRead.IndexOf(",", a + 1);
                c = dataRead.IndexOf(",", b + 1);
                d = dataRead.IndexOf(",", c + 1);
                s1 = dataRead.Substring(a + 1, b - a - 1);
                s2 = dataRead.Substring(b + 1, c - b - 1);
                s3 = dataRead.Substring(c + 1, d - c - 1);
                s4 = dataRead.Substring(d + 1);              
                if (s4.StartsWith("1"))
                {
                     numericUpDown1.Invoke(new EventHandler(delegate
                     {
                     numericUpDown1.Value=Convert.ToDecimal(s1);
                     }));
                    numericUpDown2.Invoke(new EventHandler(delegate
                    {
                        numericUpDown2.Value = Convert.ToDecimal(s2);
                    }));
                    numericUpDown3.Invoke(new EventHandler(delegate
                    {
                        numericUpDown3.Value = Convert.ToDecimal(s3);
                    }));
                }
                else if (s4.StartsWith("2"))
                {
                    numericUpDown6.Invoke(new EventHandler(delegate
                    {
                        numericUpDown6.Value = Convert.ToDecimal(s1);
                    }));
                    numericUpDown5.Invoke(new EventHandler(delegate
                    {
                        numericUpDown5.Value = Convert.ToDecimal(s2);
                    }));
                    numericUpDown4.Invoke(new EventHandler(delegate
                    {
                        numericUpDown4.Value = Convert.ToDecimal(s3);
                    }));
                }
            }
            else if (dataRead.StartsWith("r"))
            {
                a = dataRead.IndexOf(",");
                b = dataRead.IndexOf(",", a + 1);
                s1 = dataRead.Substring(a + 1, b - a - 1);
                s2 = dataRead.Substring(b + 1);
                textBox1.Invoke(new EventHandler(delegate
                {
                    textBox1.Text = s1;
                }));
                textBox2.Invoke(new EventHandler(delegate
                {
                    textBox2.Text = s2;
                }));
            }
            serialPort1.DiscardInBuffer(); //clear the RX line

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pressed)
            { return; }
            if (serialPort1.IsOpen)
            {
                int correctKey = 0;  
                switch (e.KeyCode) {
                    case Keys.Up:
                        vScrollBar8.Value = 100;
                        vScrollBar7.Value = 100;
                        correctKey = 1;
                        break;
                    case Keys.Down:
                        vScrollBar8.Value = -100;
                        vScrollBar7.Value = -100;
                        correctKey = 1;
                        break;
                    case Keys.Left:
                        vScrollBar8.Value = -100;
                        vScrollBar7.Value = 100;
                        correctKey = 1;
                        break;
                    case Keys.Right:
                        vScrollBar8.Value = 100;
                        vScrollBar7.Value = -100;
                        correctKey = 1;
                        break;
                }
                if (correctKey==1)
                    button15_Click(sender, e);
            }
            pressed = true;

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Right:
                        vScrollBar8.Value = 0;
                        vScrollBar7.Value = 0;
                        button15_Click(sender, e);
                        break;
                }
            }
            pressed = false;

        }


        /*private void Form1_KeyDown(object sender, KeyEventArgs e)
{
if (serialPort1.IsOpen)
{
int correctKey = 0;
switch (e.KeyCode)
{
case Keys.Up:
vScrollBar6.Value = 200;
vScrollBar5.Value = 200;
correctKey = 1;
break;
case Keys.Down:
vScrollBar6.Value = -200;
vScrollBar5.Value = -200;
correctKey = 1;
break;
case Keys.Left:
vScrollBar6.Value = -200;
vScrollBar5.Value = 200;
correctKey = 1;
break;
case Keys.Right:
vScrollBar6.Value = 200;
vScrollBar5.Value = -200;
correctKey = 1;
break;
}
if (correctKey == 1)
button14_Click(sender, e);
}
}

private void Form1_KeyUp(object sender, KeyEventArgs e)
{
if (serialPort1.IsOpen)
{
switch (e.KeyCode)
{
case Keys.Up:
case Keys.Down:
case Keys.Left:
case Keys.Right:
vScrollBar6.Value = 0;
vScrollBar5.Value = 0;
button14_Click(sender, e);
break;
}
}
}*/
    }
}

