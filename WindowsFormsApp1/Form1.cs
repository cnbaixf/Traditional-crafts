using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<MediaInfo> list;

            Search.GetFromDirectory(textBox1.Text, FilterType.Picture, out list);
            textBox2.AppendText(Search.filesCount.ToString()+"\r\n");

            Search.GetFromDirectory(textBox1.Text, FilterType.Audio, out list);
            textBox2.AppendText(Search.filesCount.ToString() + "\r\n");

            //Search.GetFromDirectory(textBox1.Text, FilterType.Video, out list);
            //textBox2.AppendText(Search.filesCount.ToString() + "\r\n");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Functions.ReadIniData("Animation", "Library", "", @"..\..\Config\Config.ini");
        }
    }
}
