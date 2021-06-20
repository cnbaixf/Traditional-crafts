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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void myButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void myButton11_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadXML();

            //读取XML  根据XML中的内容往treeview和listbox中添加item
        }

        private void ReadXML()
        { }

        private void myButton110_Click(object sender, EventArgs e)
        {
            DialogResult result = new AddLibrary().ShowDialog();
            if (result == DialogResult.Yes)
            {
                //根据更改后的ini中的路径   更新xml   然后treeview和listbox 添加或删除
            }
        }





    }
}
