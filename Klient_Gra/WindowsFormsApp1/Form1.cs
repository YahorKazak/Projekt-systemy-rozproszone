using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static MemoryStream ms = new MemoryStream(new byte[256], 0, 256, true, true);
        BinaryWriter bw = new BinaryWriter(ms);
        BinaryReader br = new BinaryReader(ms);
        List<Label> lLabel = new List<Label>();
        List<string> list = new List<string>();    
        private void Labels()
        {
            lLabel.Add(label1);
            lLabel.Add(label2);
            lLabel.Add(label3);
            lLabel.Add(label4);
            lLabel.Add(label5);
            lLabel.Add(label6);
            lLabel.Add(label7);
            lLabel.Add(label8);
            lLabel.Add(label9);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            socket.Connect("192.168.1.106", 2048);
            textBox1.Text = "Start";
            Labels();
            Task.Run(() => { while (true) ReceivePacket(); });
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
            Label label = (Label)sender;
            if (label.Text == "")
            {
                    if (list.Count == 0)
                    {                  
                        list.Add("x");
                        
                    }
                 if (textBox1.Text == "Twoja kolejka" || textBox1.Text == "Start")
                 { 
                    if (list.Last() == "x")
                    {
                        label.Text = "o";
                        list.Add("o");
                        SendPacket(0, label.Name, "o", "Twoja kolejka");
                    }
                    else
                    {

                        label.Text = "x";
                        list.Add("x");
                        SendPacket(0, label.Name, "x", "Twoja kolejka");
                    }
                    Winner();
                 }
            }
        }
        private void DrawGame()
        {
            int n = 0;
            foreach (Label l in lLabel)
            {
                if (l.Text != "")
                {
                    n++;
                }               
            }
            if (n == 9)
            {
                SendPacket(2, "", "", "");
                MessageBox.Show("Gra skończona!");
                Close();
            }
        }
        private void Winner()
        {

            if (label1.Text=="o"|| label1.Text == "x") //label1
            {
                if (label2.Text==label1.Text)
                {
                    if (label3.Text == label2.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
                if (label4.Text == label1.Text)
                {
                    if (label7.Text == label4.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");
                        Close();

                        
                    }
                }
                if (label5.Text == label1.Text)
                {
                    if (label9.Text == label5.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
            }

            if (label7.Text == "o" || label7.Text == "x") //label7
            {
                if (label8.Text == label7.Text)
                {
                    if (label8.Text == label9.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
                if (label4.Text == label7.Text)
                {
                    if (label4.Text == label1.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
                if (label5.Text == label7.Text)
                {
                    if (label3.Text == label5.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();
                      
                    }
                }
            }

            if (label9.Text == "o" || label9.Text == "x") //label9
            {
                if (label8.Text == label9.Text)
                {
                    if (label8.Text == label7.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
                if (label9.Text == label6.Text)
                {
                    if (label6.Text == label3.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();
                      
                    }
                }
                if (label5.Text == label9.Text)
                {
                    if (label1.Text == label5.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
            }

            if (label3.Text == "o" || label3.Text == "x") //label3
            {
                if (label3.Text == label2.Text)
                {
                    if (label2.Text == label1.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();
                        
                    }
                }
                if (label3.Text == label6.Text)
                {
                    if (label6.Text == label9.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
                if (label5.Text == label3.Text)
                {
                    if (label7.Text == label5.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();
                      
                    }
                }
            }

            if (label2.Text == "o" || label2.Text == "x") //label2
            {
                if (label2.Text == label5.Text)
                {
                    if (label5.Text == label8.Text)
                    {
                        SendPacket(1, "", "", "");
                        MessageBox.Show("Wygrałeś!");

                        Close();

                    }
                }
            }

            if (label4.Text == "o" || label4.Text == "x") //label4
            {
                if (label4.Text == label5.Text)
                {
                    if (label5.Text == label6.Text)
                    {
                        SendPacket(1, "", "","");
                        MessageBox.Show("Wygrałeś!");

                        Close();
                       
                    }

                }
            }
            DrawGame();
         
        }
        private void SendPacket(int code,string label,string ostatni,string message)
        {
            switch(code)
            {
                case 0:

                    ms.Position = 0;
                    bw.Write(0);
                    bw.Write(label);
                    bw.Write(ostatni);
                    bw.Write(message);
                    socket.Send(ms.GetBuffer());
                break;

                case 1:
                    ms.Position = 0;
                    bw.Write(1);
                    socket.Send(ms.GetBuffer());
                break;
                     
                case 2:
                    ms.Position = 0;
                    bw.Write(2);
                    socket.Send(ms.GetBuffer());
                break;
            }
                    
        }
        private void ReceivePacket()
        {

            ms.Position = 0;
            socket.Receive(ms.GetBuffer());
            int code = br.ReadInt32();
            string label;
            string ostatni;
            string message;
            switch (code)
            {
                case 0:
                    label = br.ReadString();
                    ostatni = br.ReadString();
                    message = br.ReadString();
                    foreach (Label l in lLabel)
                    {
                        if (l.Name == label)
                        {
                            l.Invoke(new Action(() => l.Text = ostatni));
                           
                        }
                    }
                    list.Add(ostatni);
                    if (message == "")
                    {
                        textBox1.Invoke(new Action(() => textBox1.Text = "Czekaj na odpowiedź przeciwnika"));
                    }
                    else
                    {
                        textBox1.Invoke(new Action(() => textBox1.Text = message));
                    }
                  
                    

                    break;
                case 1:
                    MessageBox.Show("Przegrałeś!");
                    Invoke(new Action(() => Close()));
                    break;
                case 2:
                    MessageBox.Show("Gra skończona!");
                    Invoke(new Action(() => Close()));
                    break;

            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
