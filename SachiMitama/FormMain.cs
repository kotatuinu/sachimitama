using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace sachimitama
{
    public partial class FormMain : Form
    {
        private classParameter parameter_;
        private FormSetting settingForm_;

        private ColumnHeader columnName;
        private ColumnHeader columnType;
        private ColumnHeader columnData;

        private classConvertManager convertManager;

        public FormMain()
        {
            InitializeComponent();

            buttonConvert.Enabled = false;

            // Drag & Drop
            //lvFileList.Dock = DockStyle.Fill;
            lvFileList.AllowDrop = true;
            lvFileList.DragEnter += new DragEventHandler(listbox1_DragEnter);
            lvFileList.DragDrop += new DragEventHandler(listbox1_DragDrop);

            this.Controls.Add(lvFileList);

            // ListView 項目追加
            //http://www.atmarkit.co.jp/fdotnet/dotnettips/258listviewadd/listviewadd.html
            // ListViewコントロールのプロパティを設定
            lvFileList.GridLines = true;
            lvFileList.Sorting = SortOrder.Ascending;
            lvFileList.View = View.Details;

            // 列（コラム）ヘッダの作成
            columnName = new ColumnHeader();
            columnType = new ColumnHeader();
            columnData = new ColumnHeader();
            columnName.Text = "FLV";
            columnName.Width = (int)((double)lvFileList.Width * 0.38);
            columnType.Text = "MP3";
            columnType.Width = (int)((double)lvFileList.Width * 0.38);
            columnData.Text = "状態";
            columnData.Width = (int)((double)lvFileList.Width * 0.2);
            ColumnHeader[] colHeaderRegValue =
                { this.columnName, this.columnType, this.columnData };
            lvFileList.Columns.AddRange(colHeaderRegValue);

            settingForm_ = new FormSetting();
            parameter_ = new classParameter();
            parameter_.load();

            convertManager = new classConvertManager();
            convertManager.parameter = parameter_;
            convertManager.callback = this.setFlv2ConvertReuslt;
            convertManager.completeCallback = this.completeCallback;

            buttonConvert.Enabled = (lvFileList.Items.Count > 0);
            flvListSaveToolStripMenuItem.Enabled = (lvFileList.Items.Count > 0);
            flvListClearToolStripMenuItem.Enabled = (lvFileList.Items.Count > 0);

        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            convertFLV2MP3();
        }

        private void setFlv2ConvertReuslt(classFLV2MP3Thread.classResult result)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(
                    (MethodInvoker)delegate()
                    {
                        if (lvFileList.Items.ContainsKey(result.flvfile))
                        {
                            lvFileList.Items[result.flvfile].SubItems[2].Text = result.result ? "完了" : "エラー";
                        }
                    });
            }
        }

        // 変換終了時のcallback
        private void completeCallback()
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(
                    (MethodInvoker)delegate()
                    {
                        switch (parameter_.finished_mode)
                        {
                            case classParameter.FINISHEDCONVERT_MODE.NONOTICE:  // 何もしない
                                break;
                            case classParameter.FINISHEDCONVERT_MODE.SHUTDOWN:  // シャットダウン
                                break;
                            case classParameter.FINISHEDCONVERT_MODE.SUSPEND:   // サスペンド
                                Application.SetSuspendState(PowerState.Hibernate, false, false);
                                break;
                            default:    // デフォルト：完了ダイアログを表示
                                MessageBox.Show("FLV→MP3変換が完了しました。", "変換完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    });
            }
        }

        // ドラッグ ＆ドロップ
        //http://www.atmarkit.co.jp/fdotnet/csharptips/003dragdrop/003dragdrop.html
        protected void listbox1_DragEnter(object s, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        protected void listbox1_DragDrop(object s, DragEventArgs e)
        {
            bool isExist = false;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (!lvFileList.Items.ContainsKey(fileName))
                    {
                        ListViewItem item = lvFileList.Items.Add(new ListViewItem(new string[]{fileName, parameter_.getMP3File(fileName),""}));
                        item.Name = fileName;

                        // 即時実行
                        if (parameter_.dorp_mode == classParameter.DROP_MODE.IMMEDIATE)
                        {
                            item.SubItems[2].Text = "変換中";
                            convertManager.add(item.Text, item.SubItems[1].Text);
                            /*
                            classFLV2MP3Thread flv2mp3 = new classFLV2MP3Thread();

                            flv2mp3.readMode = parameter_.readMode;
                            flv2mp3.writeMode = parameter_.writeMode;

                            flv2mp3.flvFile = item.Text;
                            flv2mp3.mp3File = item.SubItems[1].Text;
                            flv2mp3.callback = new classFLV2MP3Thread.delegate_callback(this.setFlv2ConvertReuslt);
                            flv2mp3.run();
                            */ 
                        }
                    }
                    else
                    {
                        isExist = true;
                    }
                }
                if (isExist)
                {
                    MessageBox.Show("同じFLVファイルは、指定できません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if(lvFileList.Items.Count > 0)
                {
                    if (parameter_.dorp_mode == classParameter.DROP_MODE.IMMEDIATE)
                    {
                        // 変換開始
                        convertManager.startThread();
                    }
                }

                flvListSaveToolStripMenuItem.Enabled = (lvFileList.Items.Count > 0);
                flvListClearToolStripMenuItem.Enabled = (lvFileList.Items.Count > 0);
                buttonConvert.Enabled = (lvFileList.Items.Count > 0);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            columnName.Width = (int)((double)lvFileList.Width * 0.38);
            columnType.Width = (int)((double)lvFileList.Width * 0.38);
            columnData.Width = (int)((double)lvFileList.Width * 0.2);
        }

        //メニュー
        // メニュー：ファイル：FLV一覧取得
        private void flvListLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            int errorCount = 0;
            string fileName = "";

            if (MessageBox.Show("FLVファイルリストを読み込みます。\nリストをクリアしますがよろしいですか？", "ファイルリストの読み込み", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // リストをクリア
                lvFileList.Clear();

                StreamReader sr = new StreamReader(ofd.OpenFile());
                while (sr.EndOfStream)
                {
                    fileName = sr.ReadLine();

                    if (fileName.Trim() != "")
                    {
                        FileInfo info = new FileInfo(fileName);
                        if (info.Exists)
                        {
                            ListViewItem item = lvFileList.Items.Add(new ListViewItem(new string[] { fileName, parameter_.getMP3File(fileName) }));
                            item.Name = fileName;
                            count++;
                        }
                        else
                        {
                            errorCount++;
                        }
                    }
                }
            }

            if (errorCount > 0)
            {
                if (count == 0)
                {
                    // すべてファイルとして正しくない
                    MessageBox.Show("正しいファイルが有りません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // ファイルとして正しくないものがあった
                    MessageBox.Show("ファイルがないデータ行がありました。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // メニュー：ファイル：FLVファイルの書き込み
        private void flvListSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter( sfd.OpenFile() );
                foreach (ListViewItem item in lvFileList.Items)
                {
                    sw.WriteLine(item.Name);
                }
                sw.Close();
            }
        }

        // メニュー：ファイル：ログ出力
        private void ログ出力OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream st = sfd.OpenFile();
                foreach (ListViewItem item in lvFileList.Items)
                {

                }
            }
        }

        private void 終了EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endApplication();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            endApplication();
        }

        private void endApplication()
        {
            if (!convertManager.isComplete)
            {
                MessageBox.Show("変換中です。終了できません。", "終了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("終了しますか？", "終了", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void 設定EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingForm_.parameter = parameter_;
            settingForm_.ShowDialog(this);
        }

        private void toolStripDropDownButtonFile_Click(object sender, EventArgs e)
        {

        }

        private void 削除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFileNameForFileList();
        }

        private void 変換CToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 出力ファイル名の変更SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 一番上の物だけ変更
            ListViewItem item = lvFileList.SelectedItems[0];
            item.SubItems[1].Text = changeMP3FileName(item.SubItems[1].Text);
        }

        // マウスダブルクリック
        private void lvFileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item2;

            switch (parameter_.doubleclick_mode)
            {
                case classParameter.DOBULCLICK_MODE.STARTCONVERT:
                    if (lvFileList.SelectedItems.Count > 0)
                    {
                        foreach (ListViewItem item1 in lvFileList.SelectedItems)
                        {
                            item1.SubItems[2].Text = "変換中";
                            convertManager.add(item1.Text, item1.SubItems[1].Text);
                        }
                        convertManager.startThread();
                    }
                    break;
                default:
                    item2 = lvFileList.SelectedItems[0];
                    item2.SubItems[1].Text = changeMP3FileName(item2.SubItems[1].Text);
                    break;
            }

        }
        // MP3の出力ファイル名の変更
        private string changeMP3FileName(string filename)
        {
            string changeName = filename;
            // MP3ファイルの出力先を指定する

            
            return changeName;
        }

        // メニュー：ファイル：リストをクリア
        private void flvListClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFileList.Items.Clear();
            buttonConvert.Enabled = false;
            flvListSaveToolStripMenuItem.Enabled = false;
            flvListClearToolStripMenuItem.Enabled = false;
        }


        // リストへの操作
        // ファイルリストからItemを削除する
        private void lvFileList_KeyUp(object sender, KeyEventArgs e)
        {
            // DELキーを押したとき、ItemListに選択されていたItemが１つでもあれば削除を行う
            switch (e.KeyValue)
            {
                case 46:// del
                    deleteFileNameForFileList();
                    break;

                default:
                    break;
            }
        }


        private void convertFLV2MP3()
        {
            // すべて変換実行依頼するまで、ボタンを不活性にする
            buttonConvert.Enabled = false;

            foreach (ListViewItem item in lvFileList.Items)
            {
                item.SubItems[2].Text = "変換中";
                convertManager.add(item.Text, item.SubItems[1].Text);
            }
            convertManager.startThread();

            buttonConvert.Enabled = true;
        }

        private void deleteFileNameForFileList()
        {
            if (lvFileList.SelectedItems.Count > 0)
            {
                // 削除確認
                if (MessageBox.Show("選択したファイルをリストから削除しますか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int max = lvFileList.Items.Count;
                    for (int i = max - 1; i >= 0; i--)
                    {
                        if (lvFileList.Items[i].Selected)
                        {
                            //
                            lvFileList.Items[i].Remove();
                        }
                    }
                    if (lvFileList.Items.Count == 0)
                    {
                        buttonConvert.Enabled = false;
                        flvListSaveToolStripMenuItem.Enabled = false;
                        flvListClearToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }

        // シャットダウン実行
        private void shutdown()
        {
            classShutdown.AdjustToken();
            classShutdown.ExitWindowsEx(classShutdown.ExitWindows.EWX_POWEROFF, 0);
        }

        private void バージョン情報VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersion formVerstion = new FormVersion();
            formVerstion.ShowDialog(this);
        }
    }
}