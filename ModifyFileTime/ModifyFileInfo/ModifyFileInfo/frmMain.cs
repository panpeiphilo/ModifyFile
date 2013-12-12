using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ModifyFileInfo
{
    public partial class frmMain : Form
    {
        string filename = "";
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofdFile.FileName;
                if (!string.IsNullOrEmpty(txtFileName.Text))
                {
                    filename = txtFileName.Text;
                    InitFileInfo();
                }
            }
        }

        private void InitFileInfo()
        {
            if (File.Exists(filename))
            {
                FileInfo fiinfo = new FileInfo(filename);
                //��������
                lblCreateTime.Text = fiinfo.CreationTime.ToString();
                txtCreateTime.Text = fiinfo.CreationTime.ToString();
                //�޸�����
                lblUpdateTime.Text = fiinfo.LastWriteTime.ToString();
                txtUpdateTime.Text = fiinfo.LastWriteTime.ToString();
                //������ʱ��
                lblAccessTime.Text = fiinfo.LastAccessTime.ToString();
                txtAccessTime.Text = fiinfo.LastAccessTime.ToString();
            }
            else
            {
                MessageBox.Show("�ļ������ڣ�");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                FileInfo fiinfo = new FileInfo(filename);
                try
                {
                    fiinfo.CreationTime = Convert.ToDateTime(txtCreateTime.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("����ʱ���ʽ����");
                    return;
                }
                try
                {
                    fiinfo.LastWriteTime = Convert.ToDateTime(txtUpdateTime.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("����ʱ���ʽ����");
                    return;
                }
                try
                {
                    fiinfo.LastAccessTime = Convert.ToDateTime(txtAccessTime.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("����ʱ���ʽ����");
                    return;
                }

                InitFileInfo();
                MessageBox.Show("�޸ĳɹ���");
            }
            else
            {
                MessageBox.Show("��δѡ���ļ���");
            }

            
        }
    }
}