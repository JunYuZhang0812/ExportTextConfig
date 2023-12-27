namespace ExportTextConfig
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.m_srcFilePath = new System.Windows.Forms.TextBox();
            this.m_btnSelectSrcFile = new System.Windows.Forms.Button();
            this.m_exportText = new System.Windows.Forms.Button();
            this.m_btnReplaceText = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_textReplaceText = new System.Windows.Forms.TextBox();
            this.m_btnSelectReplaceFile = new System.Windows.Forms.Button();
            this.m_comMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnOpenCfgDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "源文件路径";
            // 
            // m_srcFilePath
            // 
            this.m_srcFilePath.AllowDrop = true;
            this.m_srcFilePath.Location = new System.Drawing.Point(98, 34);
            this.m_srcFilePath.Name = "m_srcFilePath";
            this.m_srcFilePath.Size = new System.Drawing.Size(335, 21);
            this.m_srcFilePath.TabIndex = 1;
            this.m_srcFilePath.TextChanged += new System.EventHandler(this.m_srcFilePath_TextChanged);
            this.m_srcFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_srcFilePath_DragEnter);
            this.m_srcFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_srcFilePath_DragDrop);
            // 
            // m_btnSelectSrcFile
            // 
            this.m_btnSelectSrcFile.Location = new System.Drawing.Point(439, 32);
            this.m_btnSelectSrcFile.Name = "m_btnSelectSrcFile";
            this.m_btnSelectSrcFile.Size = new System.Drawing.Size(75, 23);
            this.m_btnSelectSrcFile.TabIndex = 2;
            this.m_btnSelectSrcFile.Text = "选择文件";
            this.m_btnSelectSrcFile.UseVisualStyleBackColor = true;
            this.m_btnSelectSrcFile.Click += new System.EventHandler(this.m_btnSelectSrcFile_Click);
            // 
            // m_exportText
            // 
            this.m_exportText.Location = new System.Drawing.Point(358, 6);
            this.m_exportText.Name = "m_exportText";
            this.m_exportText.Size = new System.Drawing.Size(75, 23);
            this.m_exportText.TabIndex = 3;
            this.m_exportText.Text = "导出文字";
            this.m_exportText.UseVisualStyleBackColor = true;
            this.m_exportText.Click += new System.EventHandler(this.m_exportText_Click);
            // 
            // m_btnReplaceText
            // 
            this.m_btnReplaceText.Location = new System.Drawing.Point(439, 6);
            this.m_btnReplaceText.Name = "m_btnReplaceText";
            this.m_btnReplaceText.Size = new System.Drawing.Size(75, 23);
            this.m_btnReplaceText.TabIndex = 4;
            this.m_btnReplaceText.Text = "替换文字";
            this.m_btnReplaceText.UseVisualStyleBackColor = true;
            this.m_btnReplaceText.Click += new System.EventHandler(this.m_btnReplaceText_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "替换文本路径";
            // 
            // m_textReplaceText
            // 
            this.m_textReplaceText.AllowDrop = true;
            this.m_textReplaceText.Location = new System.Drawing.Point(98, 61);
            this.m_textReplaceText.Name = "m_textReplaceText";
            this.m_textReplaceText.Size = new System.Drawing.Size(335, 21);
            this.m_textReplaceText.TabIndex = 6;
            this.m_textReplaceText.TextChanged += new System.EventHandler(this.m_textReplaceText_TextChanged);
            this.m_textReplaceText.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_textReplaceText_DragEnter);
            this.m_textReplaceText.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_textReplaceText_DragDrop);
            // 
            // m_btnSelectReplaceFile
            // 
            this.m_btnSelectReplaceFile.Location = new System.Drawing.Point(439, 59);
            this.m_btnSelectReplaceFile.Name = "m_btnSelectReplaceFile";
            this.m_btnSelectReplaceFile.Size = new System.Drawing.Size(75, 23);
            this.m_btnSelectReplaceFile.TabIndex = 7;
            this.m_btnSelectReplaceFile.Text = "选择文件";
            this.m_btnSelectReplaceFile.UseVisualStyleBackColor = true;
            this.m_btnSelectReplaceFile.Click += new System.EventHandler(this.m_btnSelectReplaceFile_Click);
            // 
            // m_comMode
            // 
            this.m_comMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comMode.FormattingEnabled = true;
            this.m_comMode.Location = new System.Drawing.Point(98, 8);
            this.m_comMode.Name = "m_comMode";
            this.m_comMode.Size = new System.Drawing.Size(121, 20);
            this.m_comMode.TabIndex = 8;
            this.m_comMode.SelectedIndexChanged += new System.EventHandler(this.m_comMode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "操作模式";
            // 
            // m_btnOpenCfgDir
            // 
            this.m_btnOpenCfgDir.Location = new System.Drawing.Point(277, 6);
            this.m_btnOpenCfgDir.Name = "m_btnOpenCfgDir";
            this.m_btnOpenCfgDir.Size = new System.Drawing.Size(75, 23);
            this.m_btnOpenCfgDir.TabIndex = 10;
            this.m_btnOpenCfgDir.Text = "配置文件夹";
            this.m_btnOpenCfgDir.UseVisualStyleBackColor = true;
            this.m_btnOpenCfgDir.Click += new System.EventHandler(this.m_btnOpenCfgDir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 91);
            this.Controls.Add(this.m_btnOpenCfgDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_comMode);
            this.Controls.Add(this.m_btnSelectReplaceFile);
            this.Controls.Add(this.m_textReplaceText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_btnReplaceText);
            this.Controls.Add(this.m_exportText);
            this.Controls.Add(this.m_btnSelectSrcFile);
            this.Controls.Add(this.m_srcFilePath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "导出文字";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_srcFilePath;
        private System.Windows.Forms.Button m_btnSelectSrcFile;
        private System.Windows.Forms.Button m_exportText;
        private System.Windows.Forms.Button m_btnReplaceText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_textReplaceText;
        private System.Windows.Forms.Button m_btnSelectReplaceFile;
        private System.Windows.Forms.ComboBox m_comMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_btnOpenCfgDir;
    }
}

