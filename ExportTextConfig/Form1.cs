using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportTextConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InsertFileMode();
        }
        private void InsertFileMode()
        {
            foreach (SelectFileModeEnum mode in Enum.GetValues(typeof(SelectFileModeEnum)))
            {
                InsertFileMode(mode);
            }
            m_comMode.SelectedIndex = (int)Logic.SelectFileMode;
        }
        private void InsertFileMode(SelectFileModeEnum mode)
        {
            string strMode = Logic.GetEnumDescription<SelectFileModeEnum>(mode);
            m_comMode.Items.Add(strMode);
        }

        private void m_srcFilePath_TextChanged(object sender, EventArgs e)
        {
            Logic.SourceFilePath = m_srcFilePath.Text;
        }

        private void m_textReplaceText_TextChanged(object sender, EventArgs e)
        {
            Logic.ReplaceFilePath = m_textReplaceText.Text;
        }

        private void m_btnSelectSrcFile_Click(object sender, EventArgs e)
        {
            if (Logic.IsFileMode)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Title = "请选择源文件";
                dialog.Filter = "lua文件(*.lua)|*.lua";
                var paths = m_srcFilePath.Text.Split(';');
                var path = m_srcFilePath.Text;
                if (paths.Length >= 1)
                {
                    path = paths[0];
                }
                if (File.Exists(path))
                {
                    dialog.FileName = path;
                    dialog.InitialDirectory = Path.GetDirectoryName(path);
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePath = dialog.FileNames;
                    bool bFirst = true;
                    StringBuilder strFileNames = new StringBuilder();
                    for (int i = 0; i < filePath.Length; i++)
                    {
                        if (!bFirst)
                            strFileNames.Append(";");
                        else
                            bFirst = false;
                        strFileNames.Append(filePath[i]);
                    }
                    string str = strFileNames.ToString();
                    m_srcFilePath.Text = str;
                }
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择源文件夹路径";
                dialog.SelectedPath = m_srcFilePath.Text;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string str = dialog.SelectedPath;
                    Logic.SourceFilePath = str;
                    m_srcFilePath.Text = str;
                }
            }
        }

        private void m_btnSelectReplaceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择源文件";
            dialog.Filter = "Excel文件(*.xlsx)|*.xlsx";
            var path = m_textReplaceText.Text;
            if (File.Exists(path))
            {
                dialog.FileName = path;
                dialog.InitialDirectory = Path.GetDirectoryName(path);
            }
            else
            {
                dialog.InitialDirectory = Logic.APPDataPath;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePath = dialog.FileNames;
                bool bFirst = true;
                StringBuilder strFileNames = new StringBuilder();
                for (int i = 0; i < filePath.Length; i++)
                {
                    if (!bFirst)
                        strFileNames.Append(";");
                    else
                        bFirst = false;
                    strFileNames.Append(filePath[i]);
                }
                string str = strFileNames.ToString();
                m_textReplaceText.Text = str;
            }
        }

        private void m_exportText_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            if( Logic.IsFileMode )
            {
                list.Add(m_srcFilePath.Text);
            }
            else
            {
                var files = Directory.GetFiles(m_srcFilePath.Text ,"*.lua");
                for (int i = 0; i < files.Length; i++)
                {
                    list.Add(files[i]);
                }
            }
            Logic.ExportText(list);
        }

        private void m_btnReplaceText_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            if (Logic.IsFileMode)
            {
                list.Add(m_srcFilePath.Text);
            }
            else
            {
                var files = Directory.GetFiles(m_srcFilePath.Text, "*.lua");
                for (int i = 0; i < files.Length; i++)
                {
                    list.Add(files[i]);
                }
            }
            Logic.ReplaceFile(list);
        }

        private void m_comMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.SelectFileMode = (SelectFileModeEnum)m_comMode.SelectedIndex;
        }

        private void m_btnOpenCfgDir_Click(object sender, EventArgs e)
        {
            Process.Start(Logic.APPDataPath);
        }
    }
}
