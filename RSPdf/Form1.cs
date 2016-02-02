using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace RSPdf
{
    /*
     * 本來想重構這個專案，但時間不足
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 選擇EML壓縮檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Filter = "eml檔、zip檔(*.eml,*.zip)|*.eml;*.zip";
                OFD.Title = "選取檔案";
                OFD.Multiselect = false;

                if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
                {
                    txtEMLPath.Text = OFD.FileName;
                }

            }
        }

        /// <summary>
        /// 選擇PDF壓縮檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Filter = "pdf檔、zip檔(*.pdf,*.zip)|*.pdf;*.zip";
                OFD.Title = "選取檔案";
                OFD.Multiselect = false;

                if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
                {
                    txtPDFPath.Text = OFD.FileName;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //切換至SMTP頁籤  帶預設值
            if (tabControl1.SelectedIndex == 1)
            {

            }
        }

        /// <summary>
        /// 寄送EML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            int errCount = 0;
            int sucCount = 0;
            List<string> emlFiles = new List<string>();

            if ( string.IsNullOrEmpty(txtEMLPath.Text.Trim()) ||
                string.IsNullOrEmpty(txtPDFPath.Text.Trim()) )
            {
                MessageBox.Show("請選擇寄送檔案!", "警告視窗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //檔案解壓
            }
            catch (Exception ex)
            {
                string exMSG = ex.Message;
                txtMSG.Text += "發生錯誤：" + exMSG + Environment.NewLine;
            }
        }

        /// <summary>
        /// 解壓縮檔案
        /// </summary>
        /// <param name="ZipToUnpack"></param>
        /// <returns></returns>
        private string ExtractZip(string ZipToUnpack)
        {
            try
            {
                string unZipDir = ZipToUnpack.Split('.')[0];
                ZipFile Zips = ZipFile.Read(ZipToUnpack);

                //處理相同檔案的問題
                Zips.ExtractProgress += Zips_ExtractProgress;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "";
        }

        /// <summary>
        /// 事件：處理重覆檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Zips_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Extracting_ExtractEntryWouldOverwrite)
            {
                ZipEntry entry = e.CurrentEntry;

                string MSG = entry.FileName + Environment.NewLine + "檔案已存在，是否覆蓋？";
                if (MessageBox.Show(MSG, "詢問視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.OK)
                {
                    entry.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                }
                else
                {
                    entry.ExtractExistingFile = ExtractExistingFileAction.DoNotOverwrite;
                }
            }
        }

        /// <summary>
        /// 清除畫面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEMLPath.Clear();
            txtPDFPath.Clear();

            txtMSG.ForeColor = Color.Black;
            txtMSG.Clear();
        }

        /// <summary>
        /// 離開程式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您是否確定離開本程式？", "詢問視窗", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void txtMSG_TextChanged(object sender, EventArgs e)
        {
            //自動捲動
            txtMSG.SelectionStart = txtMSG.TextLength;
            txtMSG.ScrollToCaret();
        }

        /// <summary>
        /// 儲存輸入的STMP設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSmtpOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SettingHost = txtSmtpHost.Text.Trim();
            Properties.Settings.Default.SettingPort = int.Parse(txtSmtpPort.Text.Trim() );
            //Properties.Settings.Default.SettingSSL = chkSmtpSSL.Checked;
            Properties.Settings.Default.SettingAcc = txtUserAcc.Text.Trim();
            Properties.Settings.Default.SettingPw = txtUserPw.Text.Trim();

            if (MessageBox.Show("您是否確定儲存SMTP設定？", "詢問視窗", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == System.Windows.Forms.DialogResult.Yes)
            {
                //儲存設定並切換至系統訊息頁籤
                Properties.Settings.Default.Save();
                tabControl1.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 清除SMTP設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSmtpReset_Click(object sender, EventArgs e)
        {
            txtSmtpHost.Clear();
            txtSmtpPort.Text = "25";
        }


        
    }
}
