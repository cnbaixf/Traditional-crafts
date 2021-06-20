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
    public partial class AddLibrary : Form
    {
        List<string> Anima;
        List<string> Movie;
        List<string> Comic;
        bool FlagForChanged = false;

        public AddLibrary()
        {
            InitializeComponent();
        }


        private string configFile = @"..\..\Config\Config.ini";
        private Dictionary<string, List<string>> libraryLists = new Dictionary<string, List<string>>();



        private void ReadConfig()
        {
            Anima = new List<string>();
            Movie = new List<string>();
            Comic = new List<string>();

            //从INI中读取每类的库路径，添加到对应的list中

            libraryLists.Add("Animation", Anima);
            libraryLists.Add("Movie", Movie);
            libraryLists.Add("Comic", Comic);
        }

        private void SaveConfig()
        { 
        }










        private void myButton11_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (ListBox lb in tabControl1.SelectedTab.Controls)
                {
                    lb.Items.Add(folderBrowserDialog1.SelectedPath);
                    break;
                }
            }
        }




        private void AddLibrary_Load(object sender, EventArgs e)
        {
            ReadConfig();

            foreach (string s in Anima)
                listBox1.Items.Add(s);
            foreach (string s in Movie)
                listBox2.Items.Add(s);


        }


        private void AddLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FlagForChanged)
            {
                SaveConfig();
                DialogResult = DialogResult.Yes;
            }
            else
                DialogResult = DialogResult.No;
        }
    }
}
