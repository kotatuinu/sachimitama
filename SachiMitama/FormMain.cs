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

            // ListView ���ڒǉ�
            //http://www.atmarkit.co.jp/fdotnet/dotnettips/258listviewadd/listviewadd.html
            // ListView�R���g���[���̃v���p�e�B��ݒ�
            lvFileList.GridLines = true;
            lvFileList.Sorting = SortOrder.Ascending;
            lvFileList.View = View.Details;

            // ��i�R�����j�w�b�_�̍쐬
            columnName = new ColumnHeader();
            columnType = new ColumnHeader();
            columnData = new ColumnHeader();
            columnName.Text = "FLV";
            columnName.Width = (int)((double)lvFileList.Width * 0.38);
            columnType.Text = "MP3";
            columnType.Width = (int)((double)lvFileList.Width * 0.38);
            columnData.Text = "���";
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
                            lvFileList.Items[result.flvfile].SubItems[2].Text = result.result ? "����" : "�G���[";
                        }
                    });
            }
        }

        // �ϊ��I������callback
        private void completeCallback()
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(
                    (MethodInvoker)delegate()
                    {
                        switch (parameter_.finished_mode)
                        {
                            case classParameter.FINISHEDCONVERT_MODE.NONOTICE:  // �������Ȃ�
                                break;
                            case classParameter.FINISHEDCONVERT_MODE.SHUTDOWN:  // �V���b�g�_�E��
                                break;
                            case classParameter.FINISHEDCONVERT_MODE.SUSPEND:   // �T�X�y���h
                                Application.SetSuspendState(PowerState.Hibernate, false, false);
                                break;
                            default:    // �f�t�H���g�F�����_�C�A���O��\��
                                MessageBox.Show("FLV��MP3�ϊ����������܂����B", "�ϊ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    });
            }
        }

        // �h���b�O ���h���b�v
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

                        // �������s
                        if (parameter_.dorp_mode == classParameter.DROP_MODE.IMMEDIATE)
                        {
                            item.SubItems[2].Text = "�ϊ���";
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
                    MessageBox.Show("����FLV�t�@�C���́A�w��ł��܂���B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if(lvFileList.Items.Count > 0)
                {
                    if (parameter_.dorp_mode == classParameter.DROP_MODE.IMMEDIATE)
                    {
                        // �ϊ��J�n
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

        //���j���[
        // ���j���[�F�t�@�C���FFLV�ꗗ�擾
        private void flvListLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            int errorCount = 0;
            string fileName = "";

            if (MessageBox.Show("FLV�t�@�C�����X�g��ǂݍ��݂܂��B\n���X�g���N���A���܂�����낵���ł����H", "�t�@�C�����X�g�̓ǂݍ���", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // ���X�g���N���A
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
                    // ���ׂăt�@�C���Ƃ��Đ������Ȃ�
                    MessageBox.Show("�������t�@�C�����L��܂���B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // �t�@�C���Ƃ��Đ������Ȃ����̂�������
                    MessageBox.Show("�t�@�C�����Ȃ��f�[�^�s������܂����B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ���j���[�F�t�@�C���FFLV�t�@�C���̏�������
        private void flvListSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //�_�C�A���O��\������
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

        // ���j���[�F�t�@�C���F���O�o��
        private void ���O�o��OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //�_�C�A���O��\������
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream st = sfd.OpenFile();
                foreach (ListViewItem item in lvFileList.Items)
                {

                }
            }
        }

        private void �I��EToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show("�ϊ����ł��B�I���ł��܂���B", "�I��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("�I�����܂����H", "�I��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void �ݒ�EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingForm_.parameter = parameter_;
            settingForm_.ShowDialog(this);
        }

        private void toolStripDropDownButtonFile_Click(object sender, EventArgs e)
        {

        }

        private void �폜DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteFileNameForFileList();
        }

        private void �ϊ�CToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void �o�̓t�@�C�����̕ύXSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ��ԏ�̕������ύX
            ListViewItem item = lvFileList.SelectedItems[0];
            item.SubItems[1].Text = changeMP3FileName(item.SubItems[1].Text);
        }

        // �}�E�X�_�u���N���b�N
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
                            item1.SubItems[2].Text = "�ϊ���";
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
        // MP3�̏o�̓t�@�C�����̕ύX
        private string changeMP3FileName(string filename)
        {
            string changeName = filename;
            // MP3�t�@�C���̏o�͐���w�肷��

            
            return changeName;
        }

        // ���j���[�F�t�@�C���F���X�g���N���A
        private void flvListClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvFileList.Items.Clear();
            buttonConvert.Enabled = false;
            flvListSaveToolStripMenuItem.Enabled = false;
            flvListClearToolStripMenuItem.Enabled = false;
        }


        // ���X�g�ւ̑���
        // �t�@�C�����X�g����Item���폜����
        private void lvFileList_KeyUp(object sender, KeyEventArgs e)
        {
            // DEL�L�[���������Ƃ��AItemList�ɑI������Ă���Item���P�ł�����΍폜���s��
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
            // ���ׂĕϊ����s�˗�����܂ŁA�{�^����s�����ɂ���
            buttonConvert.Enabled = false;

            foreach (ListViewItem item in lvFileList.Items)
            {
                item.SubItems[2].Text = "�ϊ���";
                convertManager.add(item.Text, item.SubItems[1].Text);
            }
            convertManager.startThread();

            buttonConvert.Enabled = true;
        }

        private void deleteFileNameForFileList()
        {
            if (lvFileList.SelectedItems.Count > 0)
            {
                // �폜�m�F
                if (MessageBox.Show("�I�������t�@�C�������X�g����폜���܂����H", "�폜", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        // �V���b�g�_�E�����s
        private void shutdown()
        {
            classShutdown.AdjustToken();
            classShutdown.ExitWindowsEx(classShutdown.ExitWindows.EWX_POWEROFF, 0);
        }

        private void �o�[�W�������VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersion formVerstion = new FormVersion();
            formVerstion.ShowDialog(this);
        }
    }
}