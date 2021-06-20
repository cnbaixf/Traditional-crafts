using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;

namespace FilesManager
{
    public struct csvContent
    {
        public string name;
        public string[,] content;
    }



    public class Functions
    {
        #region API函数声明

        [DllImport("kernel32", CharSet = CharSet.Unicode)]//返回0表示失败，非0为成功
        private static extern int WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]//返回取得字符串缓冲区的长度
        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]//返回取得字符串缓冲区的长度
        private static extern int GetPrivateProfileString(string section, string key,
            string def, byte[] retVal, int size, string filePath);

        #endregion

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public static int ReadIniData(string Section, string Key, string NoText, byte[] buffer, int size, string iniFilePath)
        {
            int length = -1;
            if (File.Exists(iniFilePath))
                length = GetPrivateProfileString(Section, Key, NoText, buffer, size, iniFilePath);
            return length;
        }


        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (!File.Exists(iniFilePath))
            {
                FileStream fs = File.Create(iniFilePath);
                fs.Close();
            }

            long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
            if (OpStation == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void WriteIniSection(StreamWriter sw, string section)
        {
            sw.WriteLine();
            sw.WriteLine("[" + section + "]");
        }

        public static void WriteIniData(StreamWriter sw, string Key, string Value)
        {
            sw.WriteLine(Key + "=" + Value);
        }

        #endregion

        #region 读XML文件
        public static XmlNodeList ReadXML(string FilePath,string Type)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(FilePath);

            XmlNode xn = xml.SelectSingleNode("root");
            XmlNodeList nl = xn.SelectSingleNode(Type).SelectNodes(Type.Replace("Info",""));
            return nl;
        }

        public static string ReadValueFromXML(string FilePath, string Type, string targetAttribute, string targetValue, string wantedAttribute)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(FilePath);
            XmlNode xn = xml.SelectSingleNode(Type + "/" + Type.Replace("Info", "") + "[@" + targetAttribute + "='" + targetValue + "']");
            return xn.Attributes[wantedAttribute].Value;
        }



        #endregion

        #region 写XML文件
        public static void WriteXML(string FilePath,string Type,params string[] AttributeAndValue)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(FilePath);

            XmlNode parent = xml.SelectSingleNode(Type);

            XmlElement element = xml.CreateElement(Type.Replace("Info", ""));
            
            for(int i=0;i< AttributeAndValue.Length; i+=2)
                element.SetAttribute(AttributeAndValue[i],AttributeAndValue[i+1]);

            parent.AppendChild(element);
        }

        public static void WriteXML(string FilePath, string Type, string targetAttribute, string targetValue, string writenAttribute,string writenValue)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(FilePath);
            XmlNode xn = xml.SelectSingleNode(Type + "/" + Type.Replace("Info", "") + "[@" + targetAttribute + "='" + targetValue + "']");
            xn.Attributes[writenAttribute].Value = writenValue;
        }


        #endregion










        /// <summary>
        /// copy content of srcDir to destDir
        /// </summary>
        /// <param name="srcDir"></param>
        /// <param name="destDir"></param>
        public static void CopyDir(string srcDir, string destDir)
        {
            if (!Directory.Exists(srcDir))
                return;

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            string[] files = Directory.GetFiles(srcDir);
            foreach (string formFileName in files)
            {
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(destDir, fileName);
                File.Copy(formFileName, toFileName, true);
            }
            string[] fromDirs = Directory.GetDirectories(srcDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(destDir, dirName);
                CopyDir(fromDirName, toDirName);
            }
        }

        public static string ValidCSVString(string element)
        {
            if (element == null)
                return element;
            if (element.Contains('\r') || element.Contains('\n') || element.Contains(',') || element.Contains('\"'))
            {
                if (element.Contains('\"'))
                    element = element.Replace("\"", "\"\"");
                element = '\"' + element + '\"';
            }
            return element;
        }

        public static DataTable GetDataTableFromCsv(string csvFile, bool firstRowAsTitle = false)
        {
            DataTable table = new DataTable();
            StreamReader sr = new StreamReader(csvFile, Encoding.Default);
            List<string> rowData = new List<string>();
            Regex csvReg = new Regex("^((\"(([^\"]*)|(\"\"))*\")|([^\",\\r\\n]*))((\\r\\n)|$|\\r|\\n|,)");
            int index = 0;
            int colIndex = 0;
            string element;
            bool error = false;
            bool firstRow = true;
            string linestr = "";
            bool lineProcFinished = true;
            while (!sr.EndOfStream)
            {
                if (lineProcFinished)
                {
                    linestr = sr.ReadLine() + "\r";
                    lineProcFinished = false;
                }
                else
                    linestr += sr.ReadLine() + "\r";
                while (true)
                {
                    Match mt = csvReg.Match(linestr);
                    if (!mt.Success)
                        break;
                    element = mt.Value.Trim().TrimEnd(',').Replace("\"\"", "\"").Replace("\r", "\n");
                    if (element.Length > 0 && element[0] == '\"')
                        element = element.Substring(1, element.Length - 2);
                    index = mt.Index + mt.Length;
                    if (firstRow && firstRowAsTitle)
                        table.Columns.Add(element);
                    else
                    {
                        if (firstRow)
                        {
                            colIndex++;
                            table.Columns.Add("Col" + colIndex.ToString());
                        }
                        rowData.Add(element);
                    }
                    if (mt.Length == 0 || linestr[index - 1] != ',')
                    {
                        if (!firstRow || !firstRowAsTitle)
                        {
                            table.Rows.Add().ItemArray = rowData.ToArray();
                            rowData.Clear();
                        }
                        firstRow = false;
                        lineProcFinished = true;
                    }
                    if (index == linestr.Length)
                        break;
                    linestr = linestr.Substring(index);
                }
            }
            sr.Close();
            return table;
        }

        public static DataTable GetDataTableFromCsv_ReadAll(string csvFile, bool firstRowAsTitle = false)
        {
            DataTable table = new DataTable();
            StreamReader sr = new StreamReader(csvFile);
            bool firstRow = true;
            string allContent;
            List<string> rowData = new List<string>();
            Regex csvReg = new Regex("((\"(([^\"]*)|(\"\"))*\")|([^\",\\r\\n]*))((\\r\\n)|$|\\r|\\n|,)");
            allContent = sr.ReadToEnd();
            sr.Close();
            int index = 0;
            int colIndex = 0;
            string element;
            bool error = false;
            while (true)
            {
                Match mt = csvReg.Match(allContent, index);
                if (mt.Success == true)
                {
                    element = mt.Value.Trim().TrimEnd(',').Replace("\"\"", "\"");
                    if (element.Length > 0 && element[0] == '\"')
                        element = element.Substring(1, element.Length - 2);
                    index = mt.Index + mt.Length;
                    if (firstRow && firstRowAsTitle)
                        table.Columns.Add(element);
                    else
                    {
                        if (firstRow)
                        {
                            colIndex++;
                            table.Columns.Add("Col" + colIndex.ToString());
                        }
                        rowData.Add(element);
                    }
                    if (mt.Length == 0 || allContent[index - 1] != ',')
                    {
                        if (!firstRow || !firstRowAsTitle)
                        {
                            table.Rows.Add().ItemArray = rowData.ToArray();
                            rowData.Clear();
                        }
                        firstRow = false;
                    }
                    if (index == allContent.Length)
                        break;
                }
                else
                {
                    error = true;
                    break;
                }
            }
            return table;
        }

        public static csvContent GetCsvContent(string csvFile)
        {
            csvContent fileContent = new csvContent();
            fileContent.name = Path.GetFileName(csvFile);
            try
            {
                DataTable table = GetDataTableFromCsv(csvFile);
                fileContent.content = new string[table.Rows.Count, table.Columns.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                    for (int j = 0; j < table.Columns.Count; j++)
                        fileContent.content[i, j] = (string)table.Rows[i][j];
            }
            catch (Exception)
            {

            }
            return fileContent;
        }

        public static void WriteCSVFile(string csvFile, csvContent csv)
        {
            StreamWriter sw = new StreamWriter(csvFile, false);
            for (int i = 0; i < csv.content.Rank; i++)
            {
                for (int j = 0; j < csv.content.GetLength(1); j++)
                    sw.Write(ValidCSVString(csv.content[i, j]) + ((j == csv.content.GetLength(1) - 1) ? "" : ","));
                sw.WriteLine();
            }
            sw.Close();
        }

        public static void GetResultsContent(string dirPath, ref List<csvContent> csvContents)
        {
            csvContents.Clear();
            if (!Directory.Exists(dirPath))
                return;
            string[] csvFiles = Directory.GetFiles(dirPath, "*.csv", SearchOption.AllDirectories).ToArray();
            csvContent fileContent;
            foreach (string csvFile in csvFiles)
            {
                fileContent.name = Path.GetFileName(csvFile);
                string[] allcontent = File.ReadAllLines(csvFile);
                fileContent = GetCsvContent(csvFile);
                csvContents.Add(fileContent);
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        const uint SC_CLOSE = 0xF060;//关闭
        const uint MF_BYCOMMAND = 0x00; //按命令方式
        const uint MF_GRAYED = 0x01;    //灰掉
        const uint MF_DISABLED = 0x02;  //不可用

        public static bool DisableCloseButton(System.Windows.Forms.Form form)
        {

            IntPtr hMenu = GetSystemMenu(form.Handle, false); //获取程序窗体的句柄

            if (hMenu != IntPtr.Zero)
            {
                return EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED | MF_DISABLED); //禁用关闭功能
            }
            else
                return false;
        }

        public static bool EnableCloseButton(System.Windows.Forms.Form form)
        {

            IntPtr hMenu = GetSystemMenu(form.Handle, false); //获取程序窗体的句柄

            if (hMenu != IntPtr.Zero)
            {
                return EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND); //允许关闭功能
            }
            else
                return false;
        }

        public static string ReplaceInvalidPathCharacter(string path, string replaceStr)
        {
            StringBuilder rBuilder = new StringBuilder(path);
            foreach (char rInvalidChar in Path.GetInvalidPathChars())
                rBuilder.Replace(rInvalidChar.ToString(), replaceStr);
            return rBuilder.ToString();
        }

        public static string ReplaceInvalidFileCharacter(string file, string replaceStr)
        {
            StringBuilder rBuilder = new StringBuilder(file);
            foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
                rBuilder.Replace(rInvalidChar.ToString(), replaceStr);
            return rBuilder.ToString();
        }

        

        public static string StringToEscapeFormat(string str)
        {
            if (str == null)
                return null;
            return str.Replace("\n", "\\n").Replace("\r", "\\r").Replace("\t", "\\t").Replace(" ", "\\s");
        }

        public static string EscapeFormatToString(string str)
        {
            return str.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t").Replace("\\s", " ");
        }

    }
}