using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//选择文件模式
public enum SelectFileModeEnum
{
    [Description("选择文件")]
    SelectFiles,  //选择文件模式
    [Description("选择文件夹")]
    SelectFolder,//选择文件夹模式
}
public class Logic
{
    private static bool _IsFileMode;
    public static bool IsFileMode
    {
        get
        {
            return _IsFileMode;
        }
        set
        {
            _IsFileMode = value;
        }
    }
    public static SelectFileModeEnum SelectFileMode
    {
        get
        {
            return (SelectFileModeEnum)FileOP.Instance.ReadInt("Config", "SelectFileMode", 0);
        }
        set
        {
            FileOP.Instance.WriteInt("Config", "SelectFileMode", (int)value);
            IsFileMode = value == SelectFileModeEnum.SelectFiles;
        }
    }

    public static string SourceFilePath { get; set; }
    public static string ReplaceFilePath { get; set; }

    private static List<string> m_errorList = new List<string>();

    private static List<string> m_strList = new List<string>();

    private static Regex m_regStr = new Regex("(?:\"@(.*?)\")+");
    public static void ExportText(List<string> pathList)
    {
        m_strList.Clear();
        for (int i = 0; i < pathList.Count; i++)
        {
            string str = pathList[i];
            if( File.Exists(str) )
            {
                ParseFile(str);
            }
        }
        string nameEx = Path.GetFileNameWithoutExtension(SourceFilePath);
        var exportPath = APPDataPath + "\\文字导出-" + nameEx + ".txt";
        if (File.Exists(exportPath))
        {
            File.Delete(exportPath);
        }
        var sm = new FileStream(exportPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
        StreamWriter writer = new StreamWriter(sm);
        try
        {
            for (int i = 0;i< m_strList.Count; i++)
            {
                writer.WriteLine(m_strList[i]);
            }
        }
        finally
        {
            writer.Close();
            sm.Close();
        }
        MessageBox.Show("导出完成");
        Process.Start(exportPath);
    }
    private static void ParseFile( string path)
    {
        var rs = new StreamReader(path);
        try
        {
            string line;
            while ((line = rs.ReadLine()) != null)
            {
                if (m_regStr.IsMatch(line))
                {
                    var matches = m_regStr.Matches(line);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var match = matches[i];
                        var str = match.Groups[1].Value;
                        if (!m_strList.Contains(str))
                        {
                            m_strList.Add(str);
                        }
                    }
                }
            }
        }
        finally
        {
            rs.Close();
        }
    }

    private static Dictionary<string, string> m_replaceStrDic = new Dictionary<string, string>();
    public static void ReplaceFile(List<string> pathList)
    {
        m_errorList.Clear();
        InitReplaceStrDic();
        if (m_replaceStrDic.Count <= 0) return;
        for (int i = 0; i < pathList.Count; i++)
        {
            string str = pathList[i];
            if (File.Exists(str))
            {
                ReplaceFile(str);
            }
        }
        CreateErrorFile();
        MessageBox.Show("替换完成");
    }
    private static void InitReplaceStrDic()
    {
        m_replaceStrDic.Clear();
        var excelPath = ReplaceFilePath;
        if (!File.Exists(excelPath))
        {
            MessageBox.Show("未找到Excel文件");
            return;
        }
        var extension = Path.GetExtension(excelPath);
        if (extension != ".xlsx")
        {
            MessageBox.Show("请创建.xlsx类型的Excel文件");
            return;
        }
        var file = new FileStream(excelPath, FileMode.Open, FileAccess.Read,FileShare.Read);
        var workbook = new XSSFWorkbook(file);
        try
        {
            if (workbook != null)
            {
                var sheet = workbook.GetSheetAt(workbook.ActiveSheetIndex);
                if (sheet != null)
                {
                    for (int _rowIndex = 0; _rowIndex <= sheet.LastRowNum; _rowIndex++)
                    {
                        var rowIndex = _rowIndex;
                        IRow currentRow = sheet.GetRow(rowIndex);
                        if (currentRow != null)
                        {
                            var strValue = currentRow.GetCell(1).StringCellValue;
                            var textId = currentRow.GetCell(0).StringCellValue;
                            if (!m_replaceStrDic.ContainsKey(strValue))
                            {
                                m_replaceStrDic.Add(strValue, textId);
                            }
                            else
                            {
                                MessageBox.Show("文本id重复。" + textId);
                            }
                        }
                    }
                }
            }
        }
        finally
        {
            if (workbook != null)
            {
                workbook.Close();
            }
            file.Close();
        }
    }
    private static void ReplaceFile(string path)
    {
        List<string> lineList = new List<string>();
        var rs = new StreamReader(path);
        try
        {
            string line;
            while ((line = rs.ReadLine()) != null)
            {
                if (m_regStr.IsMatch(line))
                {
                    var matchs = m_regStr.Matches(line);
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        var match = matchs[i];
                        var str = match.Groups[1].Value;
                        if (m_replaceStrDic.ContainsKey(str))
                        {
                            var reg = new Regex("\"@(" + ExcapeCharacterTransform( str ) + ")\"");
                            line = reg.Replace(line, "\""+m_replaceStrDic[str] + "\"--[[$1]]");
                        }
                        else
                        {
                            m_errorList.Add("检测到导出文件未包含的字符串:  " + str + "    文件路径：" + path);
                        }
                    }
                }
                lineList.Add(line);
            }
        }
        finally
        {
            rs.Close();
        }
        var sm = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write);
        var fs = new StreamWriter(sm);
        try
        {
            for (int i = 0; i < lineList.Count; i++)
            {
                fs.WriteLine(lineList[i]);
            }
        }
        finally
        {
            fs.Close();
            sm.Close();
        }
    }

    private static void CreateErrorFile()
    {
        if (m_errorList.Count <= 0) return;
        string nameEx = Path.GetFileNameWithoutExtension(SourceFilePath);
        var path = APPDataPath + "\\替换错误LOG-" + nameEx + ".txt";
        if( File.Exists(path) )
        {
            File.Delete(path);
        }
        var sm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
        var fs = new StreamWriter(sm);
        try
        {
            for (int i = 0; i < m_errorList.Count; i++)
            {
                fs.WriteLine(m_errorList[i]);
            }
        }
        finally
        {
            fs.Close();
            sm.Close();
        }
    }

    private static Dictionary<char, string> ExcapeCharacter = new Dictionary<char, string>
    {
        ['{'] = @"\{",
        ['}'] = @"\}",
        ['['] = @"\[",
        [']'] = @"\]",
        ['/'] = @"\/",
        ['\\'] = @"\\",
        ['+'] = @"\+",
        ['*'] = @"\*",
        ['.'] = @"\.",
        ['$'] = @"\$",
        ['^'] = @"\^",
        ['|'] = @"\|",
        ['?'] = @"\?",
    };
    public static string ExcapeCharacterTransform(string str)
    {
        StringBuilder builder = new StringBuilder();
        var charArr = str.ToCharArray();
        for (int i = 0; i < charArr.Length; i++)
        {
            if (ExcapeCharacter.ContainsKey(charArr[i]))
            {
                builder.Append(ExcapeCharacter[charArr[i]]);
            }
            else
            {
                builder.Append(charArr[i]);
            }
        }
        return builder.ToString();
    }

    private static string[] drives = new string[] { "D:", "E:", "F:", "G:" };
    private static string _APPDataPath = null;
    public static string APPDataPath
    {
        get
        {
            if (_APPDataPath == null)
            {
                var addPath = @"\APPData\文字导出工具";
                for (int i = 0; i < drives.Length; i++)
                {
                    if (Directory.Exists(drives[i]))
                    {
                        _APPDataPath = drives[i] + addPath;
                        if (!Directory.Exists(_APPDataPath))
                        {
                            Directory.CreateDirectory(_APPDataPath);
                        }
                        break;
                    }
                }
            }
            return _APPDataPath;
        }
    }
    public static string GetEnumDescription<T>(T obj)
    {
        var type = obj.GetType();
        FieldInfo field = type.GetField(Enum.GetName(type, obj));
        DescriptionAttribute desAttr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        if (desAttr == null)
            return string.Empty;
        return desAttr.Description;
    }
}

