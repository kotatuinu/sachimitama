namespace sachimitama
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonConvert = new System.Windows.Forms.Button();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flvListLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flvListSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.flvListClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ログ出力OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.終了EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.contextMenuStripSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.設定EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.contextMenuStripHelp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.バージョン情報VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.lvFileList = new System.Windows.Forms.ListView();
            this.contextMenuStripRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.変換CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.出力ファイル名の変更SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.削除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.リストをすべて削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.contextMenuStripFile.SuspendLayout();
            this.toolStripMainMenu.SuspendLayout();
            this.contextMenuStripSetting.SuspendLayout();
            this.contextMenuStripHelp.SuspendLayout();
            this.contextMenuStripRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Location = new System.Drawing.Point(317, 242);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(81, 23);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.Text = "変換実行(&R)";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flvListLoadToolStripMenuItem,
            this.flvListSaveToolStripMenuItem,
            this.toolStripMenuItem5,
            this.flvListClearToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ログ出力OToolStripMenuItem,
            this.toolStripMenuItem2,
            this.終了EToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStrip1";
            this.contextMenuStripFile.OwnerItem = this.toolStripDropDownButtonFile;
            this.contextMenuStripFile.Size = new System.Drawing.Size(196, 132);
            // 
            // flvListLoadToolStripMenuItem
            // 
            this.flvListLoadToolStripMenuItem.Name = "flvListLoadToolStripMenuItem";
            this.flvListLoadToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.flvListLoadToolStripMenuItem.Text = "FLV一覧のLOAD...(&L)";
            this.flvListLoadToolStripMenuItem.Click += new System.EventHandler(this.flvListLoadToolStripMenuItem_Click);
            // 
            // flvListSaveToolStripMenuItem
            // 
            this.flvListSaveToolStripMenuItem.Name = "flvListSaveToolStripMenuItem";
            this.flvListSaveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.flvListSaveToolStripMenuItem.Text = "FLV一覧のSAVE...(&S)";
            this.flvListSaveToolStripMenuItem.Click += new System.EventHandler(this.flvListSaveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(192, 6);
            // 
            // flvListClearToolStripMenuItem
            // 
            this.flvListClearToolStripMenuItem.Name = "flvListClearToolStripMenuItem";
            this.flvListClearToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.flvListClearToolStripMenuItem.Text = "リストをクリア(&D)";
            this.flvListClearToolStripMenuItem.Click += new System.EventHandler(this.flvListClearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // ログ出力OToolStripMenuItem
            // 
            this.ログ出力OToolStripMenuItem.Name = "ログ出力OToolStripMenuItem";
            this.ログ出力OToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ログ出力OToolStripMenuItem.Text = "ログ出力...(&O)";
            this.ログ出力OToolStripMenuItem.Click += new System.EventHandler(this.ログ出力OToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
            // 
            // 終了EToolStripMenuItem
            // 
            this.終了EToolStripMenuItem.Name = "終了EToolStripMenuItem";
            this.終了EToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.終了EToolStripMenuItem.Text = "終了(&E)";
            this.終了EToolStripMenuItem.Click += new System.EventHandler(this.終了EToolStripMenuItem_Click);
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonFile,
            this.toolStripDropDownButtonSetting,
            this.toolStripDropDownButtonHelp});
            this.toolStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Size = new System.Drawing.Size(491, 25);
            this.toolStripMainMenu.TabIndex = 3;
            // 
            // contextMenuStripSetting
            // 
            this.contextMenuStripSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定EToolStripMenuItem});
            this.contextMenuStripSetting.Name = "contextMenuStrip1";
            this.contextMenuStripSetting.OwnerItem = this.toolStripDropDownButtonSetting;
            this.contextMenuStripSetting.Size = new System.Drawing.Size(131, 26);
            // 
            // 設定EToolStripMenuItem
            // 
            this.設定EToolStripMenuItem.Name = "設定EToolStripMenuItem";
            this.設定EToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.設定EToolStripMenuItem.Text = "設定...(&S)";
            this.設定EToolStripMenuItem.Click += new System.EventHandler(this.設定EToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonHelp
            // 
            this.toolStripDropDownButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonHelp.DropDown = this.contextMenuStripHelp;
            this.toolStripDropDownButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonHelp.Name = "toolStripDropDownButtonHelp";
            this.toolStripDropDownButtonHelp.Size = new System.Drawing.Size(80, 22);
            this.toolStripDropDownButtonHelp.Text = "ヘルプ (&H)";
            // 
            // contextMenuStripHelp
            // 
            this.contextMenuStripHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョン情報VToolStripMenuItem});
            this.contextMenuStripHelp.Name = "contextMenuStripHelp";
            this.contextMenuStripHelp.OwnerItem = this.toolStripDropDownButtonHelp;
            this.contextMenuStripHelp.Size = new System.Drawing.Size(179, 26);
            // 
            // バージョン情報VToolStripMenuItem
            // 
            this.バージョン情報VToolStripMenuItem.Name = "バージョン情報VToolStripMenuItem";
            this.バージョン情報VToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.バージョン情報VToolStripMenuItem.Text = "バージョン情報(&V)";
            this.バージョン情報VToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報VToolStripMenuItem_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(404, 242);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "終了(&E)";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // lvFileList
            // 
            this.lvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileList.ContextMenuStrip = this.contextMenuStripRightMenu;
            this.lvFileList.Location = new System.Drawing.Point(12, 39);
            this.lvFileList.Name = "lvFileList";
            this.lvFileList.Size = new System.Drawing.Size(466, 197);
            this.lvFileList.TabIndex = 5;
            this.lvFileList.UseCompatibleStateImageBehavior = false;
            this.lvFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFileList_MouseDoubleClick);
            this.lvFileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvFileList_KeyUp);
            // 
            // contextMenuStripRightMenu
            // 
            this.contextMenuStripRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.変換CToolStripMenuItem,
            this.toolStripMenuItem3,
            this.出力ファイル名の変更SToolStripMenuItem,
            this.toolStripMenuItem4,
            this.削除DToolStripMenuItem,
            this.リストをすべて削除ToolStripMenuItem});
            this.contextMenuStripRightMenu.Name = "contextMenuStripRightMenu";
            this.contextMenuStripRightMenu.Size = new System.Drawing.Size(215, 104);
            // 
            // 変換CToolStripMenuItem
            // 
            this.変換CToolStripMenuItem.Name = "変換CToolStripMenuItem";
            this.変換CToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.変換CToolStripMenuItem.Text = "変換実行(&R)";
            this.変換CToolStripMenuItem.Click += new System.EventHandler(this.変換CToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(211, 6);
            // 
            // 出力ファイル名の変更SToolStripMenuItem
            // 
            this.出力ファイル名の変更SToolStripMenuItem.Name = "出力ファイル名の変更SToolStripMenuItem";
            this.出力ファイル名の変更SToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.出力ファイル名の変更SToolStripMenuItem.Text = "出力ファイル名の変更(&S)";
            this.出力ファイル名の変更SToolStripMenuItem.Click += new System.EventHandler(this.出力ファイル名の変更SToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(211, 6);
            // 
            // 削除DToolStripMenuItem
            // 
            this.削除DToolStripMenuItem.Name = "削除DToolStripMenuItem";
            this.削除DToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.削除DToolStripMenuItem.Text = "リストから削除(&D)";
            this.削除DToolStripMenuItem.Click += new System.EventHandler(this.削除DToolStripMenuItem_Click);
            // 
            // リストをすべて削除ToolStripMenuItem
            // 
            this.リストをすべて削除ToolStripMenuItem.Name = "リストをすべて削除ToolStripMenuItem";
            this.リストをすべて削除ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.リストをすべて削除ToolStripMenuItem.Text = "リストをすべて削除(&D)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 279);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(491, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButtonFile
            // 
            this.toolStripDropDownButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonFile.DropDown = this.contextMenuStripFile;
            this.toolStripDropDownButtonFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonFile.Image")));
            this.toolStripDropDownButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFile.Name = "toolStripDropDownButtonFile";
            this.toolStripDropDownButtonFile.Size = new System.Drawing.Size(86, 22);
            this.toolStripDropDownButtonFile.Text = "ファイル(&F)";
            this.toolStripDropDownButtonFile.Click += new System.EventHandler(this.toolStripDropDownButtonFile_Click);
            // 
            // toolStripDropDownButtonSetting
            // 
            this.toolStripDropDownButtonSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonSetting.DropDown = this.contextMenuStripSetting;
            this.toolStripDropDownButtonSetting.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonSetting.Image")));
            this.toolStripDropDownButtonSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSetting.Name = "toolStripDropDownButtonSetting";
            this.toolStripDropDownButtonSetting.Size = new System.Drawing.Size(75, 22);
            this.toolStripDropDownButtonSetting.Text = "ツール(&T)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(491, 301);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvFileList);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.toolStripMainMenu);
            this.Controls.Add(this.buttonConvert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "幸魂";
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.contextMenuStripFile.ResumeLayout(false);
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.contextMenuStripSetting.ResumeLayout(false);
            this.contextMenuStripHelp.ResumeLayout(false);
            this.contextMenuStripRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolStripMenuItem flvListLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flvListSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ログ出力OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 終了EToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSetting;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFile;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSetting;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報VToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonHelp;
        private System.Windows.Forms.ListView lvFileList;
        private System.Windows.Forms.ToolStripMenuItem 設定EToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightMenu;
        private System.Windows.Forms.ToolStripMenuItem 変換CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 出力ファイル名の変更SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem リストをすべて削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flvListClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    }
}

