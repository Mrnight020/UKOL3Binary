using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UKOL3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string veta = "";
            FileStream data = new FileStream("texty.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cti= new BinaryReader(data,Encoding.GetEncoding("UTF-8"));

            cti.BaseStream.Position = 0;
            while(cti.BaseStream.Position < cti.BaseStream.Length)
            {
                char znak = cti.ReadChar();
                veta+= znak;
                if(znak == '.' || znak == '!')
                {
                    listBox1.Items.Add(veta);
                    veta = "";
                }
            }

            data.Close();
            //button1.Enabled= false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string veta = "";
            FileStream data = new FileStream("texty.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader cti = new BinaryReader(data, Encoding.GetEncoding("UTF-8"));
            BinaryWriter zapis = new BinaryWriter(data, Encoding.GetEncoding("UTF-8"));

            cti.BaseStream.Position = 0;
            while (cti.BaseStream.Position < cti.BaseStream.Length)
            {
                char znak = cti.ReadChar();
                if (znak == '.')
                {
                    cti.BaseStream.Position -= 1;
                    zapis.Write('!');

                    
                    veta += '!';
                    listBox2.Items.Add(veta);
                    veta = "";
                }
                else
                {
                    veta += znak;
                }
            }

            data.Close();
            button2.Enabled= false;
        }
    }
}
