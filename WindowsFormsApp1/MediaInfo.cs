using MediaInfoLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilesManager
{
    public class MediaInfo
    {
        public string name = "";
        public string fullName = "";
        public string resolution = "";
        public string size = "";
        public string time = "-";
        public string type = "-";
        public string bitRate = "-";
        public string frameRate = "-";
        //public string format = "";
        public string videoLanguage = "-";
        public string Audio1Language = "-";
        public string Audio2Language = "-";


        public MediaInfo(string file)
        {
            FileInfo f = new FileInfo(file);
            getAllInfo(f);
        }

        public MediaInfo(string file, bool isPicture)
        {
            FileInfo fi = new FileInfo(file);
            MediaInfoLib.MediaInfo info = new MediaInfoLib.MediaInfo();
            info.Open(file);
            name = fi.Name;
            fullName = fi.FullName;
            string temStr = info.Inform();

            if (temStr == "")
                return;

            Dictionary<string, string> allInfo = StringToDictionary(temStr);
            allInfo.TryGetValue("File size", out size);
            type = fi.Extension.Remove(0, 1);
            if (isPicture)
            {
                resolution = info.Get(StreamKind.Video, 0, "Width") + "x" + info.Get(StreamKind.Video, 0, "Height");
                if (resolution == "x")
                    resolution = info.Get(StreamKind.Image, 0, "Width") + "x" + info.Get(StreamKind.Image, 0, "Height");
                if (resolution == "x")
                    resolution = "-";
            }
        }


        public void getAllInfo(FileInfo file)
        {
            MediaInfoLib.MediaInfo info = new MediaInfoLib.MediaInfo();
            info.Open(file.FullName);
            name = file.Name;
            fullName = file.FullName;
            resolution = info.Get(StreamKind.Video, 0, "Width") + "x" + info.Get(StreamKind.Video, 0, "Height");
            if (resolution == "x")
                resolution = info.Get(StreamKind.Image, 0, "Width") + "x" + info.Get(StreamKind.Image, 0, "Height");
            if (resolution == "x")
                resolution = "-";
            //time = Second2time(info.Get(StreamKind.Video, 0, "Duration"));
            //size = GetLength(file.Length);
            //type = info.Get(StreamKind.Video, 0, "Format");
            //bitRate = info.Get(StreamKind.Video, 0, "BitRate").ToString();
            //frameRate = info.Get(StreamKind.Video, 0, "FrameRate");
            //format = info.Get(StreamKind.Audio, 0, "Format");

            string temStr = info.Inform();

            if (temStr == "")
                return;

            Dictionary<string, string> allInfo = StringToDictionary(temStr);
            allInfo.TryGetValue("Duration", out time);
            allInfo.TryGetValue("File size", out size);
            allInfo.TryGetValue("Video_Format", out type);
            allInfo.TryGetValue("Bit rate", out bitRate);
            allInfo.TryGetValue("Frame rate", out frameRate);
            allInfo.TryGetValue("Language", out videoLanguage);
            allInfo.TryGetValue("Audio_Language", out Audio1Language);
            if (Audio1Language == null || Audio1Language == "")
                allInfo.TryGetValue("Audio #1_Language", out Audio1Language);
            allInfo.TryGetValue("Audio #2_Language", out Audio2Language);

            //if (time == null)
            //    time = "-";
            if (type == null || type == "-")
                type = file.Extension.Remove(0, 1);
            //if (bitRate == null)
            //    bitRate = "-";
            //if (frameRate == null)
            //    frameRate = "-";
            //if (videoLanguage == null)
            //    videoLanguage = "-";
            //if (Audio1Language == null)
            //    Audio1Language = "-";
            //if (Audio2Language == null)
            //    Audio2Language = "-";

            info.Close();
        }

        ////计算文件大小
        //static string GetLength(long lengthOfDocument)
        //{

        //    if (lengthOfDocument < 1024)
        //        return string.Format(lengthOfDocument.ToString() + 'B');
        //    else if (lengthOfDocument > 1024 && lengthOfDocument <= Math.Pow(1024, 2))
        //        return string.Format((lengthOfDocument / 1024.0).ToString("f2") + "KB");
        //    else if (lengthOfDocument > Math.Pow(1024, 2) && lengthOfDocument <= Math.Pow(1024, 3))
        //        return string.Format((lengthOfDocument / 1024.0 / 1024.0).ToString("f2") + "M");
        //    else
        //        return string.Format((lengthOfDocument / 1024.0 / 1024.0 / 1024.0).ToString("f2") + "GB");
        //}

        //static string Second2time(string time)
        //{
        //    if (time == "")
        //        return "";
        //    try
        //    {
        //        time = time.Substring(0, time.IndexOf('.'));
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //    int hour = 0;
        //    int minute = 0;
        //    int second = 0;
        //    second = Convert.ToInt32(time)/1000;
        //    if (second > 60)
        //    {
        //        minute = second / 60;
        //        second = second % 60;
        //    }
        //    if (minute > 60)
        //    {
        //        hour = minute / 60;
        //        minute = minute % 60;
        //    }
        //    return (hour + ":" + minute + ":"
        //        + second);
        //}


        Dictionary<string, string> StringToDictionary(string value)
        {
            if (value.Length < 1)
            {
                return null;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();

            string[] dicStrs = value.Split("\r\n".ToCharArray());
            List<String> tmp = new List<string>();
            foreach (String str in dicStrs)
            {
                if (str != null && str.Length > 1)
                {
                    if (str == "Menu")
                        break;
                    tmp.Add(str);
                }
            }
            dicStrs = tmp.ToArray();

            string group = "";
            string key = "";
            string val = "";
            try
            {
                foreach (string str in dicStrs)
                {
                    if (str.Contains(":"))
                    {
                        string[] strs = str.Split(':');
                        key = strs[0].Trim();
                        val = strs[1].Trim();
                        if (dic.ContainsKey(key))
                            key = group + "_" + key;
                        dic.Add(key, val);
                    }
                    else
                        group = str.Trim();
                }
            }
            catch (Exception e)
            {

            }
            return dic;
        }

    }
}
