using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FilesManager
{
    public partial class MainForm : Form
    {
        private string xmlFile = @"..\..\Config\Files.xml";
        private DataSet DataSet = new DataSet();
        private DataSet temp = new DataSet();

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
        {
            DataSet.ReadXml(xmlFile);



        }

        private void myButton110_Click(object sender, EventArgs e)
        {
            DialogResult result = new AddLibrary().ShowDialog();
            if (result == DialogResult.Yes)
            {
                //根据更改后的ini中的路径   更新xml   然后treeview和listbox 添加或删除
                XmlDocument xml = new XmlDocument();
                xml.Load(xmlFile);

                for (int i = 0; i < 7; i++)
                {
                    if (Convert.ToBoolean(Functions.ReadIniData(Enum.GetName(AddLibrary.t, i), "Update", "FALSE", AddLibrary.configFile)))
                    {
                        //使用EVERYTHING 根据路径读取文件  更新xml    


                        string[] pathes = Functions.ReadIniData(Enum.GetName(AddLibrary.t, i), "Library", "", AddLibrary.configFile).Split(',');
                        List<string> pathList = new List<string>();

                        foreach (string s in pathes)
                        {
                            if (s == "")
                                break;
                            if (i == 0 || i == 1)
                                Search.GetFromDirectory(s, FilterType.Video, ref pathList);
                            else if (i == 2 || i == 3)
                                Search.GetFromDirectory(s, FilterType.Picture, ref pathList);
                            else if (i == 4)
                                Search.GetFromDirectory(s, FilterType.Document, ref pathList);
                            else if (i == 5)
                                Search.GetFromDirectory(s, FilterType.Audio, ref pathList);
                            else
                                Search.GetFromDirectory(s, FilterType.ExecutableFile, ref pathList);

                            int deep = 0;
                            int minDeep = 0;
                            for (int r = 0; r < pathList.Count; r++)
                            {
                                deep = Regex.Matches(pathList[r].Replace(s, ""), @"\\").Count;
                                if (minDeep == 0)
                                    minDeep = deep;
                                else
                                {
                                    if (deep < minDeep)
                                        minDeep = deep;
                                }
                                Functions.WriteXML(xml, Enum.GetName(AddLibrary.t, i) + "Info", s,
                                                 "path", pathList[r],
                                                 "deep", deep.ToString(),
                                                 "name", new DirectoryInfo(pathList[r]).Name,
                                                 "parentName", new DirectoryInfo(pathList[r]).Parent.Name,
                                                 "grandparentName", new DirectoryInfo(pathList[r]).Parent.Parent.Name
                                                 );
                                
                            }
                            Functions.WriteXML(xml, Enum.GetName(AddLibrary.t, i) + "Info", s, "LibraryDeep", true, "minDeep", minDeep.ToString());
                        }
                    }
                }
                xml.Save(xmlFile);
            }
        }

        private void myButton111_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);
            for (int i = 0; i < 7; i++)
            {
                //使用EVERYTHING 根据路径读取文件
                string library = Functions.ReadIniData(Enum.GetName(AddLibrary.t, i), "Library", "", AddLibrary.configFile);
                string[] pathes = library.Split(',');
                List<string> pathList = new List<string>();

                XmlNode InfoNode = xml.SelectSingleNode("//" + Enum.GetName(AddLibrary.t, i) + "Info");
                if (InfoNode != null)
                    InfoNode.RemoveAll();

                foreach (string s in pathes)
                {
                    if (s == "")
                        break;
                    if (i == 0 || i == 1)
                        Search.GetFromDirectory(s, FilterType.Video, ref pathList);
                    else if (i == 2 || i == 3)
                        Search.GetFromDirectory(s, FilterType.Picture, ref pathList);
                    else if (i == 4)
                        Search.GetFromDirectory(s, FilterType.Document, ref pathList);
                    else if (i == 5)
                        Search.GetFromDirectory(s, FilterType.Audio, ref pathList);
                    else
                        Search.GetFromDirectory(s, FilterType.ExecutableFile, ref pathList);

                    int deep = 0;
                    int minDeep = 0;
                    for (int r = 0; r < pathList.Count; r++)
                    {
                        deep = Regex.Matches(pathList[r].Replace(s, ""), @"\\").Count;
                        if (minDeep == 0)
                            minDeep = deep;
                        else
                        {
                            if (deep < minDeep)
                                minDeep = deep;
                        }
                        Functions.WriteXML(xml, Enum.GetName(AddLibrary.t, i) + "Info", s,
                                         "path", pathList[r],
                                         "deep", deep.ToString(),
                                         "name", new DirectoryInfo(pathList[r]).Name,
                                         "parentName", new DirectoryInfo(pathList[r]).Parent.Name,
                                         "grandparentName", new DirectoryInfo(pathList[r]).Parent.Parent.Name
                                         );
                        
                    }
                    Functions.WriteXML(xml, Enum.GetName(AddLibrary.t, i) + "Info", s,"LibraryDeep",true, "minDeep", minDeep.ToString());
                }
            }
            xml.Save(xmlFile);

            AddTreeByXML(treeView1, xmlFile, "AnimationInfo");



        }

        private void AddTreeByXML(TreeView tree, string xmlPath, string tagName)
        {
            XmlDocument xd = new XmlDocument();
            if (File.Exists(xmlPath))
            {
                xd.Load(xmlPath);
                XmlNodeList nodeList = xd.GetElementsByTagName(tagName)[0].ChildNodes;

                foreach (XmlNode node in nodeList)
                {
                    XmlNodeList nodes = node.ChildNodes;
                    int minDeep = Convert.ToInt32(node.LastChild.Attributes["minDeep"].Value);

                    foreach (XmlNode nd in nodes)
                    {
                        if (nd.Name == "LibraryDeep")
                            break;
                        if (nd.Attributes["deep"].Value == minDeep.ToString())
                            tree.Nodes.Add(nd.Attributes["name"].Value, nd.Attributes["name"].Value);
                        else if (Convert.ToInt32(nd.Attributes["deep"].Value) - minDeep == 1)
                        {
                            if(tree.Nodes[nd.Attributes["parentName"].Value]==null)
                                tree.Nodes.Add(nd.Attributes["parentName"].Value,nd.Attributes["parentName"].Value);
                            TreeNode parentNode = tree.Nodes[nd.Attributes["parentName"].Value];
                            parentNode.Nodes.Add(nd.Attributes["name"].Value, nd.Attributes["name"].Value);
                        }
                        else if (Convert.ToInt32(nd.Attributes["deep"].Value) - minDeep == 2)
                        {
                            if (tree.Nodes[nd.Attributes["grandparentName"].Value]==null)
                                tree.Nodes.Add(nd.Attributes["grandparentName"].Value, nd.Attributes["grandparentName"].Value);
                            TreeNode grandparentNode = tree.Nodes[nd.Attributes["grandparentName"].Value];
                            if (grandparentNode.Nodes[nd.Attributes["parentName"].Value]==null)
                                grandparentNode.Nodes.Add(nd.Attributes["parentName"].Value, nd.Attributes["parentName"].Value);
                            TreeNode parentNode = grandparentNode.Nodes[nd.Attributes["parentName"].Value];
                            parentNode.Nodes.Add(nd.Attributes["name"].Value, nd.Attributes["name"].Value);
                        }
                        //tree.Refresh();
                        tree.Invalidate();
                    }
                }
                tree.Sort();

            }
        }





    }
}
