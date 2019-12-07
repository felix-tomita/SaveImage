using System;
using System.Drawing;
using System.Windows.Forms;

namespace aig.ocstool
{
    public partial class UrlExclusionDialog : Form
    {

#region Define

        private const int CON_EXT_URL_CNT = 20;

        private bool pUpdateFlag;

#endregion Define

#region Initialization

        public UrlExclusionDialog()
        {
            InitializeComponent();
        }

#endregion Initialization

#region Form Control Event

        private void UrlExclusionDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Owner.Location.X + 50, this.Owner.Location.Y + 50);

            txt_edit.Text = "";
            fnc_GetUrlExclusionList();
            this.pUpdateFlag = false;
        }

        private void UrlExclusionDialog_Closed(object sender, EventArgs e)
        {
            if (this.pUpdateFlag == true)
            {
                if (MessageBox.Show("Update Or Not? (Y / N)","Confirm", MessageBoxButtons.YesNo, 
                                                                        MessageBoxIcon.Exclamation,
                                                                        MessageBoxDefaultButton.Button2 ) == DialogResult.Yes)
                {
                    fnc_SetUrlExclusionList();
                }

            }
         }

        private void btn_add_Click(object sender, EventArgs e)
        {
            fnc_AddUrlExclusionItem();
            this.pUpdateFlag = true;
        }

        private void lst_url_exclustion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_url_exclustion.SelectedIndex > -1)
            { txt_edit.Text = lst_url_exclustion.Items[lst_url_exclustion.SelectedIndex].ToString(); }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            txt_edit.Text = "";
            fnc_DelUrlExclusionItem();
            this.pUpdateFlag = true;
        }

        private void btn_default_Click(object sender, EventArgs e)
        {
            txt_edit.Text = "";
            lst_url_exclustion.Items.Clear();
            lst_url_exclustion.Items.Add(SaveImageCommon.CON_DEF_EXC_KEY);
            this.pUpdateFlag = true;
        }

#endregion Form Control Event

#region Form Private Method
        
        private bool fnc_AddUrlExclusionItem()
        {
            bool blRes;
            int intCnt;
            string strAddUrl;

            try
            {
                blRes = true;

                strAddUrl = txt_edit.Text.Trim();
                if (strAddUrl != "")
                {
                    for (intCnt = 0; intCnt < lst_url_exclustion.Items.Count; intCnt++)
                    {
                        if (strAddUrl == lst_url_exclustion.Items[intCnt].ToString())
                        {
                            blRes = false;
                        }
                    }

                    if (blRes == true)
                    {
                        lst_url_exclustion.Items.Add(strAddUrl);
                        txt_edit.Text = "";
                        txt_edit.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_DelUrlExclusionItem()
        {
            bool blRes;
            int intDelUrl;

            try
            {
                blRes = true;

                intDelUrl = lst_url_exclustion.SelectedIndex;
                if (intDelUrl > -1)
                {
                    lst_url_exclustion.Items.RemoveAt(intDelUrl);
                    txt_edit.Text = "";
                    txt_edit.Select();
                }
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_GetUrlExclusionList()
        {
            bool blRes;
            int intCnt;
            string strExcUrl;

            try
            {
                lst_url_exclustion.Items.Clear();
                intCnt = 0;
                for (intCnt = 0; intCnt < CON_EXT_URL_CNT; intCnt++)
                {
                    strExcUrl = SaveImageCommon.GetIniValue("UrlExclusion", "Key" + (intCnt + 1).ToString("00"), SaveImageCommon.CON_SAVEIMAGE_INI);
                    if (strExcUrl != null && strExcUrl.Trim() != "")
                    {
                        lst_url_exclustion.Items.Add(strExcUrl.Trim());
                    }
                }

                blRes = true;
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_SetUrlExclusionList()
        {
            bool blRes;
            int intCnt, intList;
            string strExcUrl;
            
            try
            {
                // INIファイル定義をいったん削除
                SaveImageCommon.SetIniValue("UrlExclusion", null, null, SaveImageCommon.CON_SAVEIMAGE_INI);

                if (lst_url_exclustion.Items.Count <= 0)
                {
                    SaveImageCommon.SetIniValue("UrlExclusion", "Key01", SaveImageCommon.CON_DEF_EXC_KEY, SaveImageCommon.CON_SAVEIMAGE_INI);
                }
                else
                { 
                    // 保存対象をINIファイルに出力
                    intCnt = 0;
                    for (intList = 0; intList < lst_url_exclustion.Items.Count; intList++)
                    {
                        strExcUrl = lst_url_exclustion.Items[intList].ToString().Trim();
                        if (lst_url_exclustion.Items[intList].ToString().Trim() != "")
                        {
                            intCnt = intCnt + 1;
                            SaveImageCommon.SetIniValue("UrlExclusion", "Key" + (intCnt).ToString("00"), strExcUrl, SaveImageCommon.CON_SAVEIMAGE_INI);
                        }
                    }
                }

                blRes = true;
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
                blRes = false;
            }
            return blRes;
        }

#endregion Form Private Method

    }
}
