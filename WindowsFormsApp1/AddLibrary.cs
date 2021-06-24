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
        bool[] FlagForChanged =new bool[7] { false, false, false, false, false, false,false };
        public  static string configFile = @"..\..\Config\Config.ini";
        Dictionary<string, ListBox> listboxes = new Dictionary<string, ListBox>();
        private Dictionary<string, List<string>> libraryLists = new Dictionary<string, List<string>>();




        public AddLibrary()
        {
            InitializeComponent();

            List<string> Animation = new List<string>();
            List<string> Movie = new List<string>();
            List<string> Comic = new List<string>();
            List<string> Picture = new List<string>();
            List<string> Novel = new List<string>();
            List<string> Music = new List<string>();
            List<string> Game = new List<string>();


            Type t = typeof(FileType);
            int i = 1;
            Type l = typeof(List<string>);
            foreach (string s in Enum.GetNames(t))
            {
                listboxes.Add(s, (ListBox)tabControl1.Controls.Find("listBox" + i, true)[0]);
                i++;
            }
            libraryLists.Add("Animation", Animation);
            libraryLists.Add("Movie", Movie);
            libraryLists.Add("Comic", Comic);
            libraryLists.Add("Picture", Picture);
            libraryLists.Add("Novel", Novel);
            libraryLists.Add("Music", Music);
            libraryLists.Add("Game", Game);

            //listboxes.Add("Animation", listBox1);
            //listboxes.Add("Movie", listBox2);
            //listboxes.Add("Comic", listBox3);
            //listboxes.Add("Picture", listBox4);
            //listboxes.Add("Novel", listBox5);
            //listboxes.Add("Music", listBox6);
            //listboxes.Add("Game", listBox7);



        }



        public static Type t = typeof(FileType);

        private void ReadConfig()
        {
            //从INI中读取每类的库路径，添加到对应的list中
            string[] paths;
            foreach (string s in Enum.GetNames(t))
            {
                paths = Functions.ReadIniData(s, "Library", "", configFile).Split(',');
                if (paths[0].Length > 0)
                    foreach (string ss in paths)
                        if (ss != "")
                            libraryLists[s].Add(ss);
            }
        }

        private void SaveConfig()
        {
            for (int i = 0; i < libraryLists.Count; i++)
            {
                string key = Enum.GetName(t, i);
                string value = "";
                if (FlagForChanged[i])
                {
                    if (libraryLists[key].Count > 0)
                    {
                        foreach (string s in libraryLists[key])
                            value += s + ",";
                        Functions.WriteIniData(key, "Library", value, configFile);
                    }
                    else
                        Functions.WriteIniData(key, "Library", "", configFile);

                    Functions.WriteIniData(key, "Update", "TRUE", configFile);
                }
                else
                    Functions.WriteIniData(key, "Update", "FALSE", configFile);
            }
        }



        

        private void AddLibrary_Load(object sender, EventArgs e)
        {
            ReadConfig();
            Type t = typeof(FileType);
            foreach (string s in Enum.GetNames(t))
            {
                foreach (string ss in libraryLists[s])
                    listboxes[s].Items.Add(ss);
            }
        }


        private void AddLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                if (FlagForChanged[i])
                    break;
                else
                {
                    if (i == 6)
                    {
                        DialogResult = DialogResult.No;
                        return;
                    }
                }
            }
            DialogResult = DialogResult.Yes;
            SaveConfig();         
        }

        private void myButton11_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (ListBox lb in tabControl1.SelectedTab.Controls)
                {
                    lb.Items.Add(folderBrowserDialog1.SelectedPath);
                    libraryLists[tabControl1.SelectedTab.Text].Add(folderBrowserDialog1.SelectedPath);
                    FlagForChanged[tabControl1.SelectedIndex] = true;
                    break;
                }
            }
        }
        private void myButton12_Click(object sender, EventArgs e)
        {
            foreach (ListBox lb in tabControl1.SelectedTab.Controls)
            {
                if (lb.Items.Count > 0&& lb.SelectedIndex>=0)
                {
                    libraryLists[tabControl1.SelectedTab.Text].RemoveAt(lb.SelectedIndex);
                    lb.Items.RemoveAt(lb.SelectedIndex);
                    FlagForChanged[tabControl1.SelectedIndex] = true;
                    break;
                }
            }
        }
    }
}
