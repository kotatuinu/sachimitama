using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sachimitama
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
            //parameter_ = new classParameter();
        }

        private classParameter parameter_;
        public classParameter parameter
        {
            get { return parameter_; }
            set { parameter_ = value; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // パラメタ変数に設定内容を入れる
            // ファイル読み込み時の処理
            if (radioButtonReadOnMemory.Checked)
            {
                parameter_.readMode = classDataReader.MODE.ONMEMORY;
            }
            else 
            {
                parameter_.readMode = classDataReader.MODE.FILE;
            }

            // ファイル書き込み時の処理
            if (radioButtonWriteOnMemory.Checked)
            {
                parameter_.writeMode = classDataWriter.MODE.ONMEMORY;
            }
            else
            {
                parameter_.writeMode = classDataWriter.MODE.FILE;
            }

            // MP3ファイル出力先の指定
            if (radioButtonOutputSameDir.Checked)
            {
                parameter_.outoutdir_mode = classParameter.OUTPUTDIR_MODE.SAMEDIR;
            }
            else
            {
                parameter_.outoutdir_mode = classParameter.OUTPUTDIR_MODE.SETTINGDIR;
            }
            parameter_.outputDir = textBoxOutpuDir.Text;

            // ファイルの出力
            if (radioButtonOutputFileOverwrite.Checked)
            {
                parameter_.outputfile_mode = classParameter.OUTPUTFILE_MODE.OVERWRITE;
            }
            else
            {
                parameter_.outputfile_mode = classParameter.OUTPUTFILE_MODE.SKIP;
            }

            // ドラッグ＆ドロップ時の処理
            if (radioButtonDragDropAddAndWait.Checked)
            {
                parameter_.dorp_mode = classParameter.DROP_MODE.BUNDLE;
            }
            else
            {
                parameter_.dorp_mode = classParameter.DROP_MODE.IMMEDIATE;
            }

            if (radioButtonDoneDisplayDialog.Checked)
            {
                parameter_.finished_mode = classParameter.FINISHEDCONVERT_MODE.DISPLAYDIALOG;
            }
            else if (radioButtonDoneSuspendSleep.Checked)
            {
                parameter_.finished_mode = classParameter.FINISHEDCONVERT_MODE.SUSPEND;
            }
            else if (radioButtonDoneShutdown.Checked)
            {
                parameter_.finished_mode = classParameter.FINISHEDCONVERT_MODE.SHUTDOWN;
            }
            else
            {
                parameter_.finished_mode = classParameter.FINISHEDCONVERT_MODE.NONOTICE;
            }


            // ダブルクリック時の処理
            if (radioButtonDoubleClickStartConvert.Checked)
            {
                parameter_.doubleclick_mode = classParameter.DOBULCLICK_MODE.STARTCONVERT;
            }
            else
            {
                parameter_.doubleclick_mode = classParameter.DOBULCLICK_MODE.CHANGEMP3FILENAME;
            }

            classParameter p = new classParameter(parameter_);
            parameter_.save();
            this.Close();
        }

        private void buttonSettingOutputDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = parameter_.outputDir;

            if(folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parameter_.outputDir = folderBrowserDialog1.SelectedPath;
                textBoxOutpuDir.Text = parameter_.outputDir;
            }
        }

        // MP3ファイル出力先の指定
        // FLVファイルと同じディレクトリに出力
        private void radioButtonOutputSameDir_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOutpuDir.Enabled = false;
            buttonSettingOutputDir.Enabled = false;
        }

        private void radioButtonOutputSettingDir_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOutpuDir.Enabled = true;
            buttonSettingOutputDir.Enabled = true;
        }

        private void FormSetting_Shown(object sender, EventArgs e)
        {
            // ファイル読み込み時の処理
            switch (parameter_.readMode)
            {
                case classDataReader.MODE.FILE:
                    radioButtonReadFile.Select();
                    break;
                default:
                    radioButtonReadOnMemory.Select();
                    break;
            }

            //ファイル書き込み時の処理
            switch (parameter_.writeMode)
            {
                case classDataWriter.MODE.FILE:
                    radioButtonWriteFile.Select();
                    break;
                default:
                    radioButtonWriteOnMemory.Select();
                    break;
            }

            // MP3ファイル出力先の指定
            switch (parameter_.outoutdir_mode)
            {
                case classParameter.OUTPUTDIR_MODE.SETTINGDIR:
                    radioButtonOutputSettingDir.Select();
                    textBoxOutpuDir.Enabled = true;
                    buttonSettingOutputDir.Enabled = true;
                    break;
                default:
                    radioButtonOutputSameDir.Select(); 
                    textBoxOutpuDir.Enabled = false;
                    buttonSettingOutputDir.Enabled = false;
                    break;
            }

            // ファイルの出力
            switch (parameter_.outputfile_mode)
            {
                case classParameter.OUTPUTFILE_MODE.OVERWRITE:
                    radioButtonOutputFileOverwrite.Select();
                    break;
                default:
                    radioButtonOutputNextFile.Select();
                    break;
            }

            // ドラッグ＆ドロップ時の処理
            switch (parameter_.dorp_mode)
            {
                case classParameter.DROP_MODE.IMMEDIATE:
                    radioButtonDragDropImmediateExecution.Select();
                    break;
                default:
                    radioButtonDragDropAddAndWait.Select();
                    break;
            }

            // 変換終了時の処理
            switch(parameter_.finished_mode)
            {
                case classParameter.FINISHEDCONVERT_MODE.SUSPEND:
                    radioButtonDoneSuspendSleep.Select();
                    break;
                case classParameter.FINISHEDCONVERT_MODE.SHUTDOWN:
                    radioButtonDoneShutdown.Select();
                    break;
                case classParameter.FINISHEDCONVERT_MODE.NONOTICE:
                    radioButtonDoneNoNotice.Select();
                    break;
                default:
                    radioButtonDoneDisplayDialog.Select();
                    break;
            }

            // ダブルクリック時の処理
            switch (parameter_.doubleclick_mode)
            {
                case classParameter.DOBULCLICK_MODE.CHANGEMP3FILENAME:
                    radioButtonDoubleClickChangeFileName.Select();
                    break;
                default:
                    radioButtonDoubleClickStartConvert.Select();
                    break;
            }


        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            // パラメタ変数に設定内容を入れる
            // ファイル読み込み時の処理
            switch (parameter_.readMode)
            {
                case classDataReader.MODE.FILE:
                    // ファイルを逐次読み込み
                    radioButtonReadOnMemory.Select();
                    break;
                default:
                    // メモリへ一括読み込み
                    radioButtonReadFile.Select();
                    break;
            }

            // ファイル書き込み時の処理
            switch (parameter_.writeMode)
            {
                case classDataWriter.MODE.FILE:
                    // ファイルへ逐次書き込み
                    radioButtonWriteFile.Select();
                    break;
                default:
                    // メモリから一括書き込み
                    radioButtonWriteOnMemory.Select();
                    break;
            }

            // MP3ファイル出力先の指定
            switch (parameter_.outoutdir_mode)
            {
                case classParameter.OUTPUTDIR_MODE.SETTINGDIR:
                    // 指定したディレクトリに出力
                    radioButtonOutputSettingDir.Select();
                    break;
                default:
                    // FLVファイルと同じディレクトリに出力
                    radioButtonOutputSameDir.Select();
                    break;
            }
            textBoxOutpuDir.Text = parameter_.outputDir;

            // ファイルの出力
            switch (parameter_.outputfile_mode)
            {
                case classParameter.OUTPUTFILE_MODE.SKIP:
                    // スキップ
                    radioButtonOutputNextFile.Select();
                    break;
                default:
                    // 上書き
                    radioButtonOutputFileOverwrite.Select();
                    break;
            }

            // ドラッグ＆ドロップ時の処理
            switch (parameter_.dorp_mode)
            {
                case classParameter.DROP_MODE.IMMEDIATE:
                    // 即時変換実行
                    radioButtonDragDropImmediateExecution.Select();
                    break;
                default:
                    // リストに追加
                    radioButtonDragDropAddAndWait.Select();
                    break;
            }

            // 変換終了時の処理
            switch (parameter_.finished_mode)
            {
                case classParameter.FINISHEDCONVERT_MODE.SUSPEND:
                    // サスペンド/スリープ
                    radioButtonDoneSuspendSleep.Select();
                    break;
                case classParameter.FINISHEDCONVERT_MODE.SHUTDOWN:
                    // シャットダウン
                    radioButtonDoneShutdown.Select();
                    break;
                case classParameter.FINISHEDCONVERT_MODE.NONOTICE:
                    // 通知しない
                    radioButtonDoneNoNotice.Select();
                    break;
                default:
                    // 完了ダイアログ表示
                    radioButtonDoneDisplayDialog.Select();
                    break;
            }

            // ダブルクリック時の処理
            switch (parameter_.doubleclick_mode)
            {
                case classParameter.DOBULCLICK_MODE.CHANGEMP3FILENAME:
                    // MP3ファイル名の変更
                    radioButtonDoubleClickChangeFileName.Select();
                    break;
                default:
                    // 変換開始
                    radioButtonDoubleClickStartConvert.Select();
                    break;
            }


        }

    }
}
