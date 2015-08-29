using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sachimitama
{
    public partial class FormVersion : Form
    {
        public FormVersion()
        {
            InitializeComponent();
        }

        // LinkLabel の参考にしたところ
        // http://uchukamen.com/Programming1/LinkLabel/
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start("http://kotatuinu.cocolog-nifty.com/blog/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
