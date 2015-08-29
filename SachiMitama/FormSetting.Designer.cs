namespace sachimitama
{
    partial class FormSetting
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonWriteFile = new System.Windows.Forms.RadioButton();
            this.radioButtonWriteOnMemory = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonReadFile = new System.Windows.Forms.RadioButton();
            this.radioButtonReadOnMemory = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButtonOutputNextFile = new System.Windows.Forms.RadioButton();
            this.radioButtonOutputFileOverwrite = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSettingOutputDir = new System.Windows.Forms.Button();
            this.textBoxOutpuDir = new System.Windows.Forms.TextBox();
            this.radioButtonOutputSettingDir = new System.Windows.Forms.RadioButton();
            this.radioButtonOutputSameDir = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonDoubleClickChangeFileName = new System.Windows.Forms.RadioButton();
            this.radioButtonDoubleClickStartConvert = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonDoneSuspendSleep = new System.Windows.Forms.RadioButton();
            this.radioButtonDoneNoNotice = new System.Windows.Forms.RadioButton();
            this.radioButtonDoneShutdown = new System.Windows.Forms.RadioButton();
            this.radioButtonDoneDisplayDialog = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDragDropImmediateExecution = new System.Windows.Forms.RadioButton();
            this.radioButtonDragDropAddAndWait = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 334);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(353, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "処理方法";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonWriteFile);
            this.groupBox5.Controls.Add(this.radioButtonWriteOnMemory);
            this.groupBox5.Location = new System.Drawing.Point(15, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(322, 68);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ファイルの書き込み方法";
            // 
            // radioButtonWriteFile
            // 
            this.radioButtonWriteFile.AutoSize = true;
            this.radioButtonWriteFile.Location = new System.Drawing.Point(10, 40);
            this.radioButtonWriteFile.Name = "radioButtonWriteFile";
            this.radioButtonWriteFile.Size = new System.Drawing.Size(148, 16);
            this.radioButtonWriteFile.TabIndex = 1;
            this.radioButtonWriteFile.TabStop = true;
            this.radioButtonWriteFile.Text = "ファイルを逐次書き込む(&P)";
            this.radioButtonWriteFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonWriteOnMemory
            // 
            this.radioButtonWriteOnMemory.AutoSize = true;
            this.radioButtonWriteOnMemory.Location = new System.Drawing.Point(10, 18);
            this.radioButtonWriteOnMemory.Name = "radioButtonWriteOnMemory";
            this.radioButtonWriteOnMemory.Size = new System.Drawing.Size(212, 16);
            this.radioButtonWriteOnMemory.TabIndex = 0;
            this.radioButtonWriteOnMemory.TabStop = true;
            this.radioButtonWriteOnMemory.Text = "メモリ上で処理して一括して書き込む(&A)";
            this.radioButtonWriteOnMemory.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonReadFile);
            this.groupBox4.Controls.Add(this.radioButtonReadOnMemory);
            this.groupBox4.Location = new System.Drawing.Point(15, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 65);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ファイルの読み込み方法";
            // 
            // radioButtonReadFile
            // 
            this.radioButtonReadFile.AutoSize = true;
            this.radioButtonReadFile.Location = new System.Drawing.Point(10, 40);
            this.radioButtonReadFile.Name = "radioButtonReadFile";
            this.radioButtonReadFile.Size = new System.Drawing.Size(127, 16);
            this.radioButtonReadFile.TabIndex = 1;
            this.radioButtonReadFile.TabStop = true;
            this.radioButtonReadFile.Text = "ファイルを逐次読む(&F)";
            this.radioButtonReadFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonReadOnMemory
            // 
            this.radioButtonReadOnMemory.AutoSize = true;
            this.radioButtonReadOnMemory.Location = new System.Drawing.Point(10, 18);
            this.radioButtonReadOnMemory.Name = "radioButtonReadOnMemory";
            this.radioButtonReadOnMemory.Size = new System.Drawing.Size(152, 16);
            this.radioButtonReadOnMemory.TabIndex = 0;
            this.radioButtonReadOnMemory.TabStop = true;
            this.radioButtonReadOnMemory.Text = "メモリに一括で読み込む(&M)";
            this.radioButtonReadOnMemory.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(353, 308);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "ファイル";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButtonOutputNextFile);
            this.groupBox7.Controls.Add(this.radioButtonOutputFileOverwrite);
            this.groupBox7.Location = new System.Drawing.Point(12, 128);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(333, 71);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "出力ファイル";
            // 
            // radioButtonOutputNextFile
            // 
            this.radioButtonOutputNextFile.AutoSize = true;
            this.radioButtonOutputNextFile.Location = new System.Drawing.Point(12, 40);
            this.radioButtonOutputNextFile.Name = "radioButtonOutputNextFile";
            this.radioButtonOutputNextFile.Size = new System.Drawing.Size(144, 16);
            this.radioButtonOutputNextFile.TabIndex = 1;
            this.radioButtonOutputNextFile.TabStop = true;
            this.radioButtonOutputNextFile.Text = "上書きせずに次に進む(&N)";
            this.radioButtonOutputNextFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutputFileOverwrite
            // 
            this.radioButtonOutputFileOverwrite.AutoSize = true;
            this.radioButtonOutputFileOverwrite.Location = new System.Drawing.Point(12, 18);
            this.radioButtonOutputFileOverwrite.Name = "radioButtonOutputFileOverwrite";
            this.radioButtonOutputFileOverwrite.Size = new System.Drawing.Size(96, 16);
            this.radioButtonOutputFileOverwrite.TabIndex = 0;
            this.radioButtonOutputFileOverwrite.TabStop = true;
            this.radioButtonOutputFileOverwrite.Text = "上書き保存(&U)";
            this.radioButtonOutputFileOverwrite.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.buttonSettingOutputDir);
            this.groupBox6.Controls.Add(this.textBoxOutpuDir);
            this.groupBox6.Controls.Add(this.radioButtonOutputSettingDir);
            this.groupBox6.Controls.Add(this.radioButtonOutputSameDir);
            this.groupBox6.Location = new System.Drawing.Point(12, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(333, 107);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "MP3ファイルの出力先の指定";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "出力先ディレクトリ(&O)";
            // 
            // buttonSettingOutputDir
            // 
            this.buttonSettingOutputDir.Location = new System.Drawing.Point(299, 79);
            this.buttonSettingOutputDir.Name = "buttonSettingOutputDir";
            this.buttonSettingOutputDir.Size = new System.Drawing.Size(26, 18);
            this.buttonSettingOutputDir.TabIndex = 3;
            this.buttonSettingOutputDir.Text = "...";
            this.buttonSettingOutputDir.UseVisualStyleBackColor = true;
            this.buttonSettingOutputDir.Click += new System.EventHandler(this.buttonSettingOutputDir_Click);
            // 
            // textBoxOutpuDir
            // 
            this.textBoxOutpuDir.Location = new System.Drawing.Point(26, 79);
            this.textBoxOutpuDir.Name = "textBoxOutpuDir";
            this.textBoxOutpuDir.Size = new System.Drawing.Size(267, 19);
            this.textBoxOutpuDir.TabIndex = 2;
            // 
            // radioButtonOutputSettingDir
            // 
            this.radioButtonOutputSettingDir.AutoSize = true;
            this.radioButtonOutputSettingDir.Location = new System.Drawing.Point(12, 40);
            this.radioButtonOutputSettingDir.Name = "radioButtonOutputSettingDir";
            this.radioButtonOutputSettingDir.Size = new System.Drawing.Size(175, 16);
            this.radioButtonOutputSettingDir.TabIndex = 1;
            this.radioButtonOutputSettingDir.TabStop = true;
            this.radioButtonOutputSettingDir.Text = "出力先ディレクトリを指定する(&S)";
            this.radioButtonOutputSettingDir.UseVisualStyleBackColor = true;
            this.radioButtonOutputSettingDir.CheckedChanged += new System.EventHandler(this.radioButtonOutputSettingDir_CheckedChanged);
            // 
            // radioButtonOutputSameDir
            // 
            this.radioButtonOutputSameDir.AutoSize = true;
            this.radioButtonOutputSameDir.Location = new System.Drawing.Point(12, 18);
            this.radioButtonOutputSameDir.Name = "radioButtonOutputSameDir";
            this.radioButtonOutputSameDir.Size = new System.Drawing.Size(223, 16);
            this.radioButtonOutputSameDir.TabIndex = 0;
            this.radioButtonOutputSameDir.TabStop = true;
            this.radioButtonOutputSameDir.Text = "FLVファイルと同じディレクトリに出力する(&F)";
            this.radioButtonOutputSameDir.UseVisualStyleBackColor = true;
            this.radioButtonOutputSameDir.CheckedChanged += new System.EventHandler(this.radioButtonOutputSameDir_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(353, 308);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "その他";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonDoubleClickChangeFileName);
            this.groupBox3.Controls.Add(this.radioButtonDoubleClickStartConvert);
            this.groupBox3.Location = new System.Drawing.Point(12, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 72);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ダブルクリック";
            // 
            // radioButtonDoubleClickChangeFileName
            // 
            this.radioButtonDoubleClickChangeFileName.AutoSize = true;
            this.radioButtonDoubleClickChangeFileName.Location = new System.Drawing.Point(13, 43);
            this.radioButtonDoubleClickChangeFileName.Name = "radioButtonDoubleClickChangeFileName";
            this.radioButtonDoubleClickChangeFileName.Size = new System.Drawing.Size(161, 16);
            this.radioButtonDoubleClickChangeFileName.TabIndex = 1;
            this.radioButtonDoubleClickChangeFileName.TabStop = true;
            this.radioButtonDoubleClickChangeFileName.Text = "出力ファイル名を変更する(&C)";
            this.radioButtonDoubleClickChangeFileName.UseVisualStyleBackColor = true;
            // 
            // radioButtonDoubleClickStartConvert
            // 
            this.radioButtonDoubleClickStartConvert.AutoSize = true;
            this.radioButtonDoubleClickStartConvert.Location = new System.Drawing.Point(13, 21);
            this.radioButtonDoubleClickStartConvert.Name = "radioButtonDoubleClickStartConvert";
            this.radioButtonDoubleClickStartConvert.Size = new System.Drawing.Size(115, 16);
            this.radioButtonDoubleClickStartConvert.TabIndex = 0;
            this.radioButtonDoubleClickStartConvert.TabStop = true;
            this.radioButtonDoubleClickStartConvert.Text = "変換を開始する(&H)";
            this.radioButtonDoubleClickStartConvert.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonDoneSuspendSleep);
            this.groupBox2.Controls.Add(this.radioButtonDoneNoNotice);
            this.groupBox2.Controls.Add(this.radioButtonDoneShutdown);
            this.groupBox2.Controls.Add(this.radioButtonDoneDisplayDialog);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "変換完了時";
            // 
            // radioButtonDoneSuspendSleep
            // 
            this.radioButtonDoneSuspendSleep.AutoSize = true;
            this.radioButtonDoneSuspendSleep.Location = new System.Drawing.Point(13, 43);
            this.radioButtonDoneSuspendSleep.Name = "radioButtonDoneSuspendSleep";
            this.radioButtonDoneSuspendSleep.Size = new System.Drawing.Size(126, 16);
            this.radioButtonDoneSuspendSleep.TabIndex = 3;
            this.radioButtonDoneSuspendSleep.TabStop = true;
            this.radioButtonDoneSuspendSleep.Text = "サスペンド/スリープ(&S)";
            this.radioButtonDoneSuspendSleep.UseVisualStyleBackColor = true;
            // 
            // radioButtonDoneNoNotice
            // 
            this.radioButtonDoneNoNotice.AutoSize = true;
            this.radioButtonDoneNoNotice.Location = new System.Drawing.Point(13, 87);
            this.radioButtonDoneNoNotice.Name = "radioButtonDoneNoNotice";
            this.radioButtonDoneNoNotice.Size = new System.Drawing.Size(92, 16);
            this.radioButtonDoneNoNotice.TabIndex = 2;
            this.radioButtonDoneNoNotice.TabStop = true;
            this.radioButtonDoneNoNotice.Text = "通知しない(&N)";
            this.radioButtonDoneNoNotice.UseVisualStyleBackColor = true;
            // 
            // radioButtonDoneShutdown
            // 
            this.radioButtonDoneShutdown.AutoSize = true;
            this.radioButtonDoneShutdown.Location = new System.Drawing.Point(13, 65);
            this.radioButtonDoneShutdown.Name = "radioButtonDoneShutdown";
            this.radioButtonDoneShutdown.Size = new System.Drawing.Size(92, 16);
            this.radioButtonDoneShutdown.TabIndex = 1;
            this.radioButtonDoneShutdown.TabStop = true;
            this.radioButtonDoneShutdown.Text = "電源を切る(&P)";
            this.radioButtonDoneShutdown.UseVisualStyleBackColor = true;
            // 
            // radioButtonDoneDisplayDialog
            // 
            this.radioButtonDoneDisplayDialog.AutoSize = true;
            this.radioButtonDoneDisplayDialog.Location = new System.Drawing.Point(13, 21);
            this.radioButtonDoneDisplayDialog.Name = "radioButtonDoneDisplayDialog";
            this.radioButtonDoneDisplayDialog.Size = new System.Drawing.Size(140, 16);
            this.radioButtonDoneDisplayDialog.TabIndex = 0;
            this.radioButtonDoneDisplayDialog.TabStop = true;
            this.radioButtonDoneDisplayDialog.Text = "完了ダイアログを表示(&E)";
            this.radioButtonDoneDisplayDialog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDragDropImmediateExecution);
            this.groupBox1.Controls.Add(this.radioButtonDragDropAddAndWait);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ドラッグ＆ドロップ";
            // 
            // radioButtonDragDropImmediateExecution
            // 
            this.radioButtonDragDropImmediateExecution.AutoSize = true;
            this.radioButtonDragDropImmediateExecution.Location = new System.Drawing.Point(13, 40);
            this.radioButtonDragDropImmediateExecution.Name = "radioButtonDragDropImmediateExecution";
            this.radioButtonDragDropImmediateExecution.Size = new System.Drawing.Size(191, 16);
            this.radioButtonDragDropImmediateExecution.TabIndex = 1;
            this.radioButtonDragDropImmediateExecution.TabStop = true;
            this.radioButtonDragDropImmediateExecution.Text = "リストボックスに追加して即時実行(&I)";
            this.radioButtonDragDropImmediateExecution.UseVisualStyleBackColor = true;
            // 
            // radioButtonDragDropAddAndWait
            // 
            this.radioButtonDragDropAddAndWait.AutoSize = true;
            this.radioButtonDragDropAddAndWait.Location = new System.Drawing.Point(13, 18);
            this.radioButtonDragDropAddAndWait.Name = "radioButtonDragDropAddAndWait";
            this.radioButtonDragDropAddAndWait.Size = new System.Drawing.Size(172, 16);
            this.radioButtonDragDropAddAndWait.TabIndex = 0;
            this.radioButtonDragDropAddAndWait.TabStop = true;
            this.radioButtonDragDropAddAndWait.Text = "リストボックスに追加して待機(&A)";
            this.radioButtonDragDropAddAndWait.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(213, 351);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(294, 351);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(385, 376);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSetting";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.Shown += new System.EventHandler(this.FormSetting_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonDoneNoNotice;
        private System.Windows.Forms.RadioButton radioButtonDoneShutdown;
        private System.Windows.Forms.RadioButton radioButtonDoneDisplayDialog;
        private System.Windows.Forms.RadioButton radioButtonDragDropImmediateExecution;
        private System.Windows.Forms.RadioButton radioButtonDragDropAddAndWait;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonWriteFile;
        private System.Windows.Forms.RadioButton radioButtonWriteOnMemory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonReadFile;
        private System.Windows.Forms.RadioButton radioButtonReadOnMemory;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSettingOutputDir;
        private System.Windows.Forms.TextBox textBoxOutpuDir;
        private System.Windows.Forms.RadioButton radioButtonOutputSettingDir;
        private System.Windows.Forms.RadioButton radioButtonOutputSameDir;
        private System.Windows.Forms.RadioButton radioButtonOutputNextFile;
        private System.Windows.Forms.RadioButton radioButtonOutputFileOverwrite;
        private System.Windows.Forms.RadioButton radioButtonDoneSuspendSleep;
        private System.Windows.Forms.RadioButton radioButtonDoubleClickChangeFileName;
        private System.Windows.Forms.RadioButton radioButtonDoubleClickStartConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}