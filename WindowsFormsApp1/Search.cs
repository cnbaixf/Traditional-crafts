using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Data;


namespace FilesManager
{
    public enum FilterType
    {
        /// <summary>
        /// 所有
        /// </summary>
        All,
        /// <summary>
        /// 文件  除文件夹以外的所有文件
        /// </summary>
        File,
        /// <summary>
        /// 文件夹
        /// </summary>
        Folder,
        /// <summary>
        /// 音频  aac;ac3;aif;aifc;aiff;au;cda;dts;fla;flac;it;m1a;m2a;m3u;m4a;mid;midi;mka;mod;mp2;mp3;mpa;ogg;ra;rmi;spc;rmi;snd;umx;voc;wav;wma;xm
        /// </summary>
        Audio,
        /// <summary>
        /// 图片  ani;bmp;gif;ico;jpe;jpeg;jpg;pcx;png;psd;tga;tif;tiff;webp;wmf
        /// </summary>
        Picture,
        /// <summary>
        /// 视频  3g2;3gp;3gp2;3gpp;amr;amv;asf;avi;bdmv;bik;d2v;divx;drc;dsa;dsm;dss;dsv;evo;f4v;flc;fli;flic;flv;hdmov;ifo;ivf;m1v;m2p;m2t;m2ts;m2v;m4b;m4p;m4v;mkv;mp2v;mp4;mp4v;mpe;mpeg;mpg;mpls;mpv2;mpv4;mov;mts;ogm;ogv;pss;pva;qt;ram;ratdvd;rm;rmm;rmvb;roq;rpm;smil;smk;swf;tp;tpr;ts;vob;vp6;webm;wm;wmp;wmv
        /// </summary>
        Video,
        /// <summary>
        /// 可执行文件   bat;cmd;exe;msi;msp;scr
        /// </summary>
        ExecutableFile,
        /// <summary>
        /// 文档  c;chm;cpp;csv;cxx;doc;docm;docx;dot;dotm;dotx;h;hpp;htm;html;hxx;ini;java;lua;mht;mhtml;odt;pdf;potx;potm;ppam;ppsm;ppsx;pps;ppt;pptm;pptx;rtf;sldm;sldx;thmx;txt;vsd;wpd;wps;wri;xlam;xls;xlsb;xlsm;xlsx;xltm;xltx;xml
        /// </summary>
        Document
    }


    static class Search
    {
        #region Everything
        const int EVERYTHING_OK = 0;
        const int EVERYTHING_ERROR_MEMORY = 1;
        const int EVERYTHING_ERROR_IPC = 2;
        const int EVERYTHING_ERROR_REGISTERCLASSEX = 3;
        const int EVERYTHING_ERROR_CREATEWINDOW = 4;
        const int EVERYTHING_ERROR_CREATETHREAD = 5;
        const int EVERYTHING_ERROR_INVALIDINDEX = 6;
        const int EVERYTHING_ERROR_INVALIDCALL = 7;

        const int EVERYTHING_REQUEST_FILE_NAME = 0x00000001;
        const int EVERYTHING_REQUEST_PATH = 0x00000002;
        const int EVERYTHING_REQUEST_FULL_PATH_AND_FILE_NAME = 0x00000004;
        const int EVERYTHING_REQUEST_EXTENSION = 0x00000008;
        const int EVERYTHING_REQUEST_SIZE = 0x00000010;
        const int EVERYTHING_REQUEST_DATE_CREATED = 0x00000020;
        const int EVERYTHING_REQUEST_DATE_MODIFIED = 0x00000040;
        const int EVERYTHING_REQUEST_DATE_ACCESSED = 0x00000080;
        const int EVERYTHING_REQUEST_ATTRIBUTES = 0x00000100;
        const int EVERYTHING_REQUEST_FILE_LIST_FILE_NAME = 0x00000200;
        const int EVERYTHING_REQUEST_RUN_COUNT = 0x00000400;
        const int EVERYTHING_REQUEST_DATE_RUN = 0x00000800;
        const int EVERYTHING_REQUEST_DATE_RECENTLY_CHANGED = 0x00001000;
        const int EVERYTHING_REQUEST_HIGHLIGHTED_FILE_NAME = 0x00002000;
        const int EVERYTHING_REQUEST_HIGHLIGHTED_PATH = 0x00004000;
        const int EVERYTHING_REQUEST_HIGHLIGHTED_FULL_PATH_AND_FILE_NAME = 0x00008000;

        const int EVERYTHING_SORT_NAME_ASCENDING = 1;
        const int EVERYTHING_SORT_NAME_DESCENDING = 2;
        const int EVERYTHING_SORT_PATH_ASCENDING = 3;
        const int EVERYTHING_SORT_PATH_DESCENDING = 4;
        const int EVERYTHING_SORT_SIZE_ASCENDING = 5;
        const int EVERYTHING_SORT_SIZE_DESCENDING = 6;
        const int EVERYTHING_SORT_EXTENSION_ASCENDING = 7;
        const int EVERYTHING_SORT_EXTENSION_DESCENDING = 8;
        const int EVERYTHING_SORT_TYPE_NAME_ASCENDING = 9;
        const int EVERYTHING_SORT_TYPE_NAME_DESCENDING = 10;
        const int EVERYTHING_SORT_DATE_CREATED_ASCENDING = 11;
        const int EVERYTHING_SORT_DATE_CREATED_DESCENDING = 12;
        const int EVERYTHING_SORT_DATE_MODIFIED_ASCENDING = 13;
        const int EVERYTHING_SORT_DATE_MODIFIED_DESCENDING = 14;
        const int EVERYTHING_SORT_ATTRIBUTES_ASCENDING = 15;
        const int EVERYTHING_SORT_ATTRIBUTES_DESCENDING = 16;
        const int EVERYTHING_SORT_FILE_LIST_FILENAME_ASCENDING = 17;
        const int EVERYTHING_SORT_FILE_LIST_FILENAME_DESCENDING = 18;
        const int EVERYTHING_SORT_RUN_COUNT_ASCENDING = 19;
        const int EVERYTHING_SORT_RUN_COUNT_DESCENDING = 20;
        const int EVERYTHING_SORT_DATE_RECENTLY_CHANGED_ASCENDING = 21;
        const int EVERYTHING_SORT_DATE_RECENTLY_CHANGED_DESCENDING = 22;
        const int EVERYTHING_SORT_DATE_ACCESSED_ASCENDING = 23;
        const int EVERYTHING_SORT_DATE_ACCESSED_DESCENDING = 24;
        const int EVERYTHING_SORT_DATE_RUN_ASCENDING = 25;
        const int EVERYTHING_SORT_DATE_RUN_DESCENDING = 26;

        const int EVERYTHING_TARGET_MACHINE_X86 = 1;
        const int EVERYTHING_TARGET_MACHINE_X64 = 2;
        const int EVERYTHING_TARGET_MACHINE_ARM = 3;

        /// <summary>
        /// 设置搜索使用的字符串
        /// </summary>
        /// <param name="lpSearchString"></param>
        /// <returns></returns>
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern UInt32 Everything_SetSearchW(string lpSearchString);
        /// <summary>
        /// 设置是否匹配路径。
        /// 是否也在路径中进行搜索。默认禁用。
        /// 启用后，不仅会搜索文件名含指定字符串的项目，还会搜到目录名含指定指定字符串的所有文件
        /// </summary>
        /// <param name="bEnable"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetMatchPath(bool bEnable);
        /// <summary>
        /// 设置是否区分大小写。默认不区分。
        /// </summary>
        /// <param name="bEnable"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetMatchCase(bool bEnable);
        /// <summary>
        /// 设置是否全字匹配。默认禁用。
        /// 只进行全字匹配，还是可以在文件名中匹配。
        /// </summary>
        /// <param name="bEnable"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetMatchWholeWord(bool bEnable);
        /// <summary>
        /// 设置是否使用正则表达式
        /// </summary>
        /// <param name="bEnable"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetRegex(bool bEnable);
        /// <summary>
        /// 设置搜索结果的数量上限
        /// </summary>
        /// <param name="dwMax"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetMax(UInt32 dwMax);
        /// <summary>
        /// 设置偏移量。默认为0，即返回第一个可用结果
        /// </summary>
        /// <param name="dwOffset"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetOffset(UInt32 dwOffset);
        /// <summary>
        /// 判断是否匹配路径
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetMatchPath();
        /// <summary>
        /// 判断是否区分大小写
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetMatchCase();
        /// <summary>
        /// 判断是否全字匹配   
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetMatchWholeWord();
        /// <summary>
        /// 判断是否使用正则表达式
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetRegex();
        /// <summary>
        /// 获取搜索结果的数量上限
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetMax();
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetOffset();
        [DllImport("Everything64.dll")]
        private static extern IntPtr Everything_GetSearchW();
        /// <summary>
        /// 获取最后一个错误码
        /// 0：操作成功完成
        /// 1：未能为搜索查询分配内存
        /// 2：IPC 不可用（IPC:Inter Process Communication 进程间通信，即允许应用程序从“ Everything ”数据库查询和获取搜索结果）
        /// 3：未能注册搜索查询窗口类
        /// 4：未能创建搜索查询窗口
        /// 5：未能创建搜索查询线程
        /// 6：索引无效。索引必须大于或等于 0 且小于结果的数量
        /// 7：无效的调用
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetLastError();
        /// <summary>
        /// 执行搜索
        /// </summary>
        /// <param name="bWait"></param>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_QueryW(bool bWait);
        /// <summary>
        /// 将搜索结果按路径排序
        /// </summary>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SortResultsByPath();
        /// <summary>
        /// 获取搜索结果中的文件数量    
        /// 当使用Everything_SetRequestFlags时不能使用此函数，需要使用Everything_GetNumResults获取搜索结果数量
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetNumFileResults();
        /// <summary>
        /// 获取搜索结果中的文件夹数量
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetNumFolderResults();
        /// <summary>
        /// 获取搜索结果中的文件和文件夹数量
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetNumResults();
        /// <summary>
        /// 获取搜索结果中文件的总数
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetTotFileResults();
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetTotFolderResults();
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetTotResults();
        /// <summary>
        /// 判断指定的结果是否为根目录，如C:
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_IsVolumeResult(UInt32 nIndex);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_IsFolderResult(UInt32 nIndex);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_IsFileResult(UInt32 nIndex);
        /// <summary>
        /// 获取指定结果的完整路径和文件名
        /// </summary>
        /// <param name="nIndex"></param>
        /// <param name="lpString">用来存储完整路径和文件名的缓冲区</param>
        /// <param name="nMaxCount">指定要复制到缓冲区的最大字符数，包括 NULL 字符。如果文本超过此限制，则会被截断。</param>
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]

        private static extern void Everything_GetResultFullPathName(UInt32 nIndex, StringBuilder lpString, UInt32 nMaxCount);
        /// <summary>
        /// 将结果列表和搜索状态重置为默认状态，释放库分配的任何内存
        /// </summary>
        [DllImport("Everything64.dll")]
        private static extern void Everything_Reset();
        /// <summary>
        /// 获取指定结果的文件名
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr Everything_GetResultFileName(UInt32 nIndex);

        // Everything 1.4
        /// <summary>
        /// 设置搜索结果的排序方式
        /// EVERYTHING_SORT_***_ASCENDING为按***升序排列
        /// EVERYTHING_SORT_***_DESCENDING为按***降序排列
        /// </summary>
        /// <param name="dwSortType"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetSort(UInt32 dwSortType);
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetSort();
        /// <summary>
        /// 获取搜索结果的排序方式
        /// </summary>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetResultListSort();
        /// <summary>
        /// 设置期望获取的数据，包含文件名、路径、扩展名、大小、创建日期、修改日期等。
        /// 需要在执行搜索(Everything_Query)前调用。
        /// 若要获取多个数据，多个参数用 | 隔开。
        /// 例如请求文件名、路径和大小则为Everything_SetRequestFlags(EVERYTHING_REQUEST_FILE_NAME | EVERYTHING_REQUEST_PATH | EVERYTHING_REQUEST_SIZE);
        /// </summary>
        /// <param name="dwRequestFlags"></param>
        [DllImport("Everything64.dll")]
        private static extern void Everything_SetRequestFlags(UInt32 dwRequestFlags);
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetRequestFlags();
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetResultListRequestFlags();

        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr Everything_GetResultExtension(UInt32 nIndex);
        /// <summary>
        /// 获取指定搜索结果的大小
        /// </summary>
        /// <param name="nIndex"></param>
        /// <param name="lpFileSize"></param>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetResultSize(UInt32 nIndex, out long lpFileSize);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetResultDateCreated(UInt32 nIndex, out long lpFileTime);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetResultDateModified(UInt32 nIndex, out long lpFileTime);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetResultDateAccessed(UInt32 nIndex, out long lpFileTime);
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetResultAttributes(UInt32 nIndex);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr Everything_GetResultFileListFileName(UInt32 nIndex);
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetResultRunCount(UInt32 nIndex);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetResultDateRun(UInt32 nIndex, out long lpFileTime);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_GetResultDateRecentlyChanged(UInt32 nIndex, out long lpFileTime);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr Everything_GetResultHighlightedFileName(UInt32 nIndex);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr Everything_GetResultHighlightedPath(UInt32 nIndex);
        [DllImport("Everything64.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr Everything_GetResultHighlightedFullPathAndFileName(UInt32 nIndex);
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_GetRunCountFromFileName(string lpFileName);
        [DllImport("Everything64.dll")]
        private static extern bool Everything_SetRunCountFromFileName(string lpFileName, UInt32 dwRunCount);
        /// <summary>
        /// 将指定文件的运行计数+1
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("Everything64.dll")]
        private static extern UInt32 Everything_IncRunCountFromFileName(string lpFileName);
        #endregion



        public static uint filesCount;
        public static bool GetFromDirectory(string directory, FilterType filterType, ref List<string> value)
        {
            List<string> dir = new List<string>();
            switch (filterType)
            {
                //case FilterType.All:
                //    Everything_SetSearchW(directory);
                //    break;
                case FilterType.File:
                    Everything_SetSearchW("file:" + directory);
                    break;
                //case FilterType.Folder:
                //    Everything_SetSearchW("folder:" + directory);
                //    break;
                case FilterType.Audio:
                    Everything_SetSearchW("ext:aac;ac3;aif;aifc;aiff;au;cda;dts;fla;flac;it;m1a;m2a;m3u;m4a;mid;midi;mka;mod;mp2;mp3;mpa;ogg;ra;rmi;spc;rmi;snd;umx;voc;wav;wma;xm " + directory);
                    break;
                case FilterType.Picture:
                    Everything_SetSearchW("ext:ani;bmp;gif;ico;jpe;jpeg;jpg;pcx;png;psd;tga;tif;tiff;webp;wmf " + directory);
                    break;
                case FilterType.Video:
                    Everything_SetSearchW("ext:3g2;3gp;3gp2;3gpp;amr;amv;asf;avi;bdmv;bik;d2v;divx;drc;dsa;dsm;dss;dsv;evo;f4v;flc;fli;flic;flv;hdmov;ifo;ivf;m1v;m2p;m2t;m2ts;m2v;m4b;m4p;m4v;mkv;mp2v;mp4;mp4v;mpe;mpeg;mpg;mpls;mpv2;mpv4;mov;mts;ogm;ogv;pss;pva;qt;ram;ratdvd;rm;rmm;rmvb;roq;rpm;smil;smk;swf;tp;tpr;ts;vob;vp6;webm;wm;wmp;wmv " + directory);
                    break;
                case FilterType.ExecutableFile:
                    Everything_SetSearchW("ext:bat;cmd;exe;msi;msp;scr " + directory);
                    break;
                case FilterType.Document:
                    Everything_SetSearchW("ext:c;chm;cpp;csv;cxx;doc;docm;docx;dot;dotm;dotx;h;hpp;htm;html;hxx;ini;java;lua;mht;mhtml;odt;pdf;potx;potm;ppam;ppsm;ppsx;pps;ppt;pptm;pptx;rtf;sldm;sldx;thmx;txt;vsd;wpd;wps;wri;xlam;xls;xlsb;xlsm;xlsx;xltm;xltx;xml " + directory);
                    break;
                default:
                    Everything_SetSearchW("file:" + directory);
                    break;
            }

            //获取文件名、路径
            Everything_SetRequestFlags(EVERYTHING_REQUEST_FILE_NAME | EVERYTHING_REQUEST_PATH);
            //搜索结果按文件名称升序排列
            Everything_SetSort(EVERYTHING_SORT_NAME_ASCENDING);
            //执行搜索，成功则返回true
            if (Everything_QueryW(true))
            {
                filesCount = Everything_GetNumResults();
                if (filesCount == 0)
                    if (Everything_GetLastError() != EVERYTHING_OK)
                        return false;
                
                for (uint i = 0; i < filesCount; i++)
                {
                    //获取文件路径
                    StringBuilder stringBuilder = new StringBuilder(260);
                    Everything_GetResultFullPathName(i, stringBuilder, 260);    //Win10  路径长度限制260字符
                    
                    FileInfo fi = new FileInfo(stringBuilder.ToString());
                    if(!dir.Contains(fi.Directory.FullName))
                        dir.Add(fi.Directory.FullName);         
                }
                dir.Sort();
                value.AddRange(dir);
                return true;
            }
            else
                return false;
        }

        public static bool GetFromDirectory(string directory, FilterType filterType, ref DataTable table)
        {
            switch (filterType)
            {
                //case FilterType.All:
                //    Everything_SetSearchW(directory);
                //    break;
                case FilterType.File:
                    Everything_SetSearchW("file:" + directory);
                    break;
                //case FilterType.Folder:
                //    Everything_SetSearchW("folder:" + directory);
                //    break;
                case FilterType.Audio:
                    Everything_SetSearchW("ext:aac;ac3;aif;aifc;aiff;au;cda;dts;fla;flac;it;m1a;m2a;m3u;m4a;mid;midi;mka;mod;mp2;mp3;mpa;ogg;ra;rmi;spc;rmi;snd;umx;voc;wav;wma;xm " + directory);
                    break;
                case FilterType.Picture:
                    Everything_SetSearchW("ext:ani;bmp;gif;ico;jpe;jpeg;jpg;pcx;png;psd;tga;tif;tiff;webp;wmf " + directory);
                    break;
                case FilterType.Video:
                    Everything_SetSearchW("ext:3g2;3gp;3gp2;3gpp;amr;amv;asf;avi;bdmv;bik;d2v;divx;drc;dsa;dsm;dss;dsv;evo;f4v;flc;fli;flic;flv;hdmov;ifo;ivf;m1v;m2p;m2t;m2ts;m2v;m4b;m4p;m4v;mkv;mp2v;mp4;mp4v;mpe;mpeg;mpg;mpls;mpv2;mpv4;mov;mts;ogm;ogv;pss;pva;qt;ram;ratdvd;rm;rmm;rmvb;roq;rpm;smil;smk;swf;tp;tpr;ts;vob;vp6;webm;wm;wmp;wmv " + directory);
                    break;
                case FilterType.ExecutableFile:
                    Everything_SetSearchW("ext:bat;cmd;exe;msi;msp;scr " + directory);
                    break;
                case FilterType.Document:
                    Everything_SetSearchW("ext:c;chm;cpp;csv;cxx;doc;docm;docx;dot;dotm;dotx;h;hpp;htm;html;hxx;ini;java;lua;mht;mhtml;odt;pdf;potx;potm;ppam;ppsm;ppsx;pps;ppt;pptm;pptx;rtf;sldm;sldx;thmx;txt;vsd;wpd;wps;wri;xlam;xls;xlsb;xlsm;xlsx;xltm;xltx;xml " + directory);
                    break;
                default:
                    Everything_SetSearchW("file:" + directory);
                    break;
            }

            //获取文件名、路径
            Everything_SetRequestFlags(EVERYTHING_REQUEST_FILE_NAME | EVERYTHING_REQUEST_PATH);
            //全字匹配
            Everything_SetMatchWholeWord(true);
            //搜索结果按文件名称升序排列
            Everything_SetSort(EVERYTHING_SORT_NAME_ASCENDING);
            //执行搜索，成功则返回true
            if (Everything_QueryW(true))
            {
                filesCount = Everything_GetNumResults();
                if (filesCount == 0)
                    if (Everything_GetLastError() != EVERYTHING_OK)
                        return false;
                //MediaInfo mi;
                //MD5 md5 = new MD5CryptoServiceProvider();
                //StringBuilder sb = new StringBuilder();
                for (uint i = 0; i < filesCount; i++)
                {
                    //获取文件路径
                    StringBuilder stringBuilder = new StringBuilder(260);
                    Everything_GetResultFullPathName(i, stringBuilder, 260);    //Win10  路径长度限制260字符

                    FileInfo fi = new FileInfo(stringBuilder.ToString());

                    string parent = fi.Directory.Name;
                    
                    if(!table.Rows.Contains(parent))
                        table.Rows.Add(parent, fi.DirectoryName);
                }
                return true;
            }
            else
                return false;
        }



    }
}
