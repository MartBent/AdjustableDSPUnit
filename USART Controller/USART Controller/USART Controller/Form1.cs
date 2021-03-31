using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace USART_Controller
{
    public partial class Form1 : Form
    {
        SerialPort port;
        List<Term> equation = new List<Term>();

        public Form1()
        {
            InitializeComponent();

            //Create any combobox option for every availble system port
            foreach(string str in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(str);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                port = new SerialPort(comboBox1.Text, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                
                //This will throw a exception if the port is already in use.
                port.Open();

                //Disable the connect button since we're already connected
                comboBox1.Enabled = false;
                btnConnect.Enabled = false;
                port.DataReceived += setADCVal;
                port.DiscardInBuffer();
            }
            catch (Exception)
            {
                //dont do anything if connection failed
                return;
            }
        }

        private void setADCVal(Object sender, EventArgs e)
        {
            byte[] buffer = new byte[5000];
            int len = port.Read(buffer, 0, port.ReadBufferSize);
            
            for(int i = 0; i < len; i++)
            {
                Console.Write(buffer[i] + " ");
            }
            Console.WriteLine(" ");
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCoef.Text.Length == 0 || txtExp.Text.Length == 0 || (!chbX.Checked && !chbY.Checked))
            {
                lblErr.Text = "Vul alle velden in!";
                return;
            }
            lblErr.Text = "";

            double coeff = Convert.ToDouble(txtCoef.Text.Replace('.',','));
            int exp = int.Parse(txtExp.Text);

            if (exp >= 1)
            {
                lblErr.Text = "Niet Causaal!";
                return;
            }
            
            Term newTerm = new Term(exp, coeff, chbY.Checked);
            bool found = false;

            equation.ForEach((Term term) =>
            {
                if(newTerm.getExponent() == term.getExponent() && term.getIsOutput() == newTerm.getIsOutput())
                {
                    found = true;
                    term.setCoefficient(term.getCoefficient() + newTerm.getCoefficient());
                }
            });
            if(!found)
            {
                equation.Add(newTerm);
            }    
            printEquation();
        }
        private void printEquation()
        {
            textBox3.Clear();
            textBox3.Text = "Y(k) = ";
            equation.ForEach((Term term) =>
            {
                if (textBox3.Text.Length == 7)
                {
                    if (term.getCoefficient() > 0)
                    {
                        textBox3.Text += term.ToString().Substring(2);
                    }
                    else
                    {
                        textBox3.Text += term.ToString();
                    }
                }
                else
                {
                    textBox3.Text += term.ToString();
                }
            });
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            equation.Clear();
            textBox3.Clear();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //Send length.
            int length = equation.Count;
            if(length > 0)
            {
                byte[] lenthByte = { (byte)length };
                port.Write(lenthByte, 0, 1);

                equation.ForEach((Term term) =>
                {
                    Int16 coef = (Int16)(term.getCoefficient() * 100);
                    Int16 exp = (short)term.getExponent();

                    byte[] data = { (byte)(coef >> 8), (byte)coef, (byte)(exp >> 8), (byte)exp, (byte)Convert.ToByte(term.getIsOutput()) };
                    port.Write(data, 0, 5);
                });
            }
        }

        private void chbX_CheckedChanged(object sender, EventArgs e)
        {
            if(chbX.Checked)
            {
                chbY.Checked = false;
            }
        }

        private void chbY_CheckedChanged(object sender, EventArgs e)
        {
            if(chbY.Checked)
            {
                chbX.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMAF_Click(object sender, EventArgs e)
        {
            equation.Clear();
            textBox3.Clear();

            equation.Add(new Term(0,0.25,false));
            equation.Add(new Term(-1,0.25, false));
            equation.Add(new Term(-2,0.25, false));
            equation.Add(new Term(-3,0.25, false));

            printEquation();
        }
    }
}
