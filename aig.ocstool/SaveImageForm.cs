using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace aig.ocstool
{
    public partial class SaveImageForm : Form
    {

#region Define

        // 機能を改修せず、ロジック最適化のみ時に使用(DEBUG)
        private const string CON_OPT_VER = "";
        //private const string CON_OPT_VER = "";

        // private const int CON_COB_URL_CNT = 20;
        private const int CON_COB_URL_CNT = 99;

        // private string[] CON_EXTENSE = { CON_EXTENSE_JPG, CON_EXTENSE_PNG, CON_EXTENSE_TIFF, CON_EXTENSE_GIF, CON_EXTENSE_XPS };
        public string[] CON_EXTENSE = { SaveImageCommon.CON_EXTENSE_JPG, SaveImageCommon.CON_EXTENSE_PNG,
                                        SaveImageCommon.CON_EXTENSE_TIFF, SaveImageCommon.CON_EXTENSE_GIF };

        private string pImageType;
        private int pImageVerticalScorllSize;

        // Add Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 Start 
        private long pAvoidTwiceEventCount;  // WebBrowserのPreviewKeyDown 2回実行回避フラグ
        // Add Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 End

        private bool pSaveUrlList;
        private string pSelUrlText;
        private string[] pUrlExclusionList;

        private bool pDontNavigateNow;

        // エディタ
        private ControlViewer pCtrlViewer;

        private string[] pCommondArgs;

#endregion Define

#region Initialization

        public SaveImageForm()
        {
            InitializeComponent();
            // テストモード時にログ出力(DEBUG)
            //CommonLogger.pComLogFlag = true;
            CommonLogger.pComLogFlag = false;
        }

#endregion Initialization

#region Form Control Event

        private void SaveImageForm_Load(object sender, EventArgs e)
        {
            fnc_GetCommondArgs();
            //MessageBox.Show(SaveImageCommon.CON_SAVEIMAGE_INI);

            fnc_ClearStatus();                  // 初期化
            fnc_GetFormSize();                  // 画面サイズ設定
            fnc_GetUrlList();                   // URL情報取得設定
            fnc_SetImageExtenseCombox();        // URL除外情報取得設定
            fnc_GetImageVerticalScorllSize();   // 縦分割値取得
            // Add Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 Start 
            this.pAvoidTwiceEventCount = 0;
            // Add Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 End
            this.pSaveUrlList = false;

            if (cob_url.Items.Count > 0) { TargetWebBrowser.Navigate(cob_url.Items[0].ToString()); }
            else { TargetWebBrowser.GoHome(); }

            // コントロールパンネル
            //this.tsb_ctrl_panel.Visible = true;
            this.tsb_ctrl_panel.Visible = false;

            StatusTimer.Interval = 3000; // 3秒待ち
        }

        private void SaveImageForm_Closed(object sender, EventArgs e)
        {
            try
            { 
                fnc_ClearStatus();
                fnc_SetFormSize();
                fnc_SetUrlList();
                fnc_SetImageExtense();
            }
            catch (Exception ex)  { CommonLogger.WriteLine(ex.Message); }
        }

        private void tsb_GoBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (TargetWebBrowser.CanGoBack == true)
                {
                    fnc_ClearStatus();
                    TargetWebBrowser.GoBack();
                }
            }
            catch (Exception ex) { CommonLogger.WriteLine(ex.Message); }
        }

        private void tsb_GoAhead_Click(object sender, EventArgs e)
        {
            try
            {
                if (TargetWebBrowser.CanGoForward  == true)
                {
                    fnc_ClearStatus();
                    TargetWebBrowser.GoForward();
                }
            }
            catch (Exception ex) { CommonLogger.WriteLine(ex.Message); }
        }

        private void tsb_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                fnc_ClearStatus();
                UrlTimer.Enabled = false;
                TargetWebBrowser.Stop();
                this.Text = TargetWebBrowser.DocumentTitle + SaveImageCommon.GetVersionInfo();
            }
            catch (Exception ex) { CommonLogger.WriteLine(ex.Message); }
        }

        private void tsb_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                fnc_ClearStatus();
                TargetWebBrowser.Refresh();
            }
            catch (Exception ex) { CommonLogger.WriteLine(ex.Message); }
        }

        private void tsb_GoHome_Click(object sender, EventArgs e)
        {
            try
            {
                fnc_ClearStatus();
                TargetWebBrowser.GoHome();
            }
            catch (Exception ex) { CommonLogger.WriteLine(ex.Message); }
        }
        
        private void tsb_SaveImageToFile_Click(object sender, EventArgs e)
        {
            string strMsg;
            string strImageFile;

            fnc_ClearStatus();
            strImageFile = fnc_SaveImageToFile();
            if (strImageFile != "")
            { strMsg = "Save image file [ " + strImageFile + " ] finshed."; }
            else
            { strMsg = "Save image file [ " + strImageFile + " ] failed."; }

            tsl_msg.Text = strMsg;
            StatusTimer.Start();          
        }

        private void txt_SetVerticalScrollSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') { }
            else
            {
                if (e.KeyChar == '\b') { }
                else
                { e.Handled = true; }                
            }
        }

        private void txt_SetVerticalScrollSize_LostFocus(object sender, EventArgs e)
        {
            try
            {
                this.pImageVerticalScorllSize = int.Parse(txt_SetVerticalScrollSize.Text);
            }
            catch (Exception ex)
            {
                this.pImageVerticalScorllSize = 0;
                txt_SetVerticalScrollSize.Text = this.pImageVerticalScorllSize.ToString();
                CommonLogger.WriteLine(ex.Message);
            }
            fnc_SetImageVerticalScorllSize();
        }

        private void tsb_SaveToClipboard_Click(object sender, EventArgs e)
        {
            string strMsg;
            bool blRes;

            fnc_ClearStatus();
            blRes = fnc_SaveIamgeToClip();
            if (blRes == true)
            { strMsg = "Save image to clipboard finshed."; }
            else
            { strMsg = "Save image to clipboard failed."; }

            tsl_msg.Text = strMsg;
            StatusTimer.Start();
        }

        private void tsb_ImageFile_ExtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 画像拡張子INIファイルに設定
                this.pImageType = tsb_ImageFile_ExtList.Text;
                SaveImageCommon.SetIniValue("Option", "FileExtense", this.pImageType, SaveImageCommon.CON_SAVEIMAGE_INI);
            }
            catch (Exception ex)
            {
                // SaveImageCommon.SetIniValue("Option", "FileExtense", CON_EXTENSE_PNG, SaveImageCommon.CON_SAVEIMAGE_INI);
                SaveImageCommon.SetIniValue("Option", "FileExtense", SaveImageCommon.CON_EXTENSE_JPG, SaveImageCommon.CON_SAVEIMAGE_INI);
                CommonLogger.WriteLine(ex.Message);
            }
        }

        private void UrlTimer_Tick(object sender, EventArgs e)
        {
            if (TargetWebBrowser.IsBusy == false)
            {
                UrlTimer.Enabled = false;
                this.Text = TargetWebBrowser.DocumentTitle + SaveImageCommon.GetVersionInfo(); 
            }
            else
            {
                this.Text = "Connecting..." + SaveImageCommon.GetVersionInfo(); 
            }
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            fnc_ClearStatus();
            StatusTimer.Stop();
        }

        private void TargetWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //CommonLogger.WriteLine("TargetWebBrowser_Navigating : Do Nothing");
            Console.WriteLine("TargetWebBrowser_Navigating : Do Nothing");
        }

        private void TargetWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            int i;
            bool bFound;
            string sUrl;

            fnc_ClearStatus();
            this.Text = TargetWebBrowser.DocumentTitle + SaveImageCommon.GetVersionInfo(); 

            sUrl = TargetWebBrowser.Url.ToString();

            // Enterキー押下時のみURLを保存
            if (this.pSaveUrlList == true)
            {
                bFound = false;
                for (i = 0; i < cob_url.Items.Count; i++)
                {
                    if (cob_url.Items[i].ToString() == sUrl)
                    { bFound = true;  break; }
                }

                this.pDontNavigateNow = true;
                if (bFound == false)  { cob_url.Items.Add(sUrl); }
                this.pDontNavigateNow = false;

                this.pSaveUrlList = false;
            }

            cob_url.Text = sUrl;
            TargetWebBrowser.Select();                     
        }

        private void TargetWebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                // Del Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 Start 
                //e.IsInputKey = true;
                // Del Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 End
                if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                {
                    // And Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 Start 
                    // 偶数回で実行
                    if (this.pAvoidTwiceEventCount % 2 == 0)
                    {  
                    // And Webbrowser状でTabキー効かない不具合(B002)対応 2019/05/20 End
                    
                        if (e.KeyCode == Keys.C)  { tsb_SaveToClipboard_Click(sender, e); }
                        else if (e.KeyCode == Keys.D)  { tsb_SaveImageToFile_Click(sender, e); }
                        this.pAvoidTwiceEventCount = 0;
                    }
                    this.pAvoidTwiceEventCount = this.pAvoidTwiceEventCount + 1;
                }
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
            }
        }
        
        private void TargetWebBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            string strURL = wb.StatusText;
            if (strURL != "")
            {
                //開こうとしていたページに移る
                if (strURL.Length > 4 && strURL.Substring(0, 4) == "http")
                { TargetWebBrowser.Navigate(strURL);  }
            }
            //ここで標準ブラウザで開くのをキャンセルしている
            e.Cancel = true;
        }
        
        private void cob_url_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
               if (e.KeyChar.ToString() == "\r")
                {
                    //comboBox1_Click(sender, e);
                    if (this.pDontNavigateNow == false)
                    {
                        this.pSaveUrlList = true;
                        UrlTimer.Enabled = true;
                        if (cob_url.Text != "") { TargetWebBrowser.Navigate(cob_url.Text); }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
            }
        }

        private void cob_url_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                {
                    if (e.KeyCode == Keys.T)
                    {
                        fnc_ResetListItem(cob_url.SelectedIndex);
                    }
                    else if (e.KeyCode == Keys.Delete)
                    { fnc_DeleteListItem(cob_url.SelectedIndex); }
                }
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
            }
        }

        private void cob_url_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.pSelUrlText != null && this.pSelUrlText != "")
                {
                    cob_url.Text = this.pSelUrlText;
                    this.pSelUrlText = "";
                }
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
            }
        }

        private void tsb_Setting_Info_Click(object sender, EventArgs e)
        {
            UrlExclusionDialog ueDialog;
            ueDialog = new UrlExclusionDialog();
            ueDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            ueDialog.ShowDialog(this);
        }

        private void tsb_ctrl_panel_Click(object sender, EventArgs e)
        {
            if (this.pCtrlViewer == null || this.pCtrlViewer.IsDisposed ==true)
            {
                this.pCtrlViewer = new ControlViewer(this, this.TargetWebBrowser);
                this.pCtrlViewer.Show();
            }
            else
            {
                this.pCtrlViewer.Activate();
            }
        }

        private void tsb_Opt_Info_Click(object sender, EventArgs e)
        {
            fnc_ShowVersion(CON_OPT_VER);
        }

#endregion Form Control Event

#region Form Private Method

        private void fnc_GetCommondArgs()
        {
            this.pCommondArgs = Environment.GetCommandLineArgs();
            // MessageBox.Show(this.pCommondArgs.Length.ToString());
            // TODO
        }

        private void fnc_ClearStatus()
        {
            tsl_msg.Text = ""; 
        }

        private bool fnc_GetFormSize()
        {
            bool blRes;
            string strTemp;
            int intTop;
            int intLeft;
            int intWidth;
            int intHight;

            try
            {
                intTop = 0;
                intLeft = 0;
                intWidth = 0;
                intHight = 0;

                strTemp = SaveImageCommon.GetIniValue("FormSize", "Top", SaveImageCommon.CON_SAVEIMAGE_INI);
                intTop = int.Parse(strTemp);
                strTemp = SaveImageCommon.GetIniValue("FormSize", "Left", SaveImageCommon.CON_SAVEIMAGE_INI);
                intLeft = int.Parse(strTemp);
                strTemp = SaveImageCommon.GetIniValue("FormSize", "Width", SaveImageCommon.CON_SAVEIMAGE_INI);
                intWidth = int.Parse(strTemp);
                strTemp = SaveImageCommon.GetIniValue("FormSize", "Hight", SaveImageCommon.CON_SAVEIMAGE_INI);
                intHight = int.Parse(strTemp);

                if (intTop >= 0 && intLeft >= 0 && intWidth >= 0 && intHight >= 0)
                {
                    this.Top = intTop;
                    this.Left = intLeft;
                    this.Width = intWidth;
                    this.Height = intHight;
                }

                blRes = true;
            }
            catch (Exception ex)
            {
                intTop = 0;
                intLeft = 0;
                intWidth = 0;
                intHight = 0;
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_SetFormSize()
        {
            bool blRes;
            int intTop;
            int intLeft;
            int intWidth;
            int intHight;

            try
            {
                intTop = this.Top;
                intLeft = this.Left;
                intWidth = this.Width;
                intHight = this.Height;

                if (intTop < 0) intTop = 0;
                if (intLeft < 0) intLeft = 0;
                if (intWidth < 0) intWidth = 0;
                if (intHight < 0) intHight = 0;

                SaveImageCommon.SetIniValue("FormSize", "Top", intTop.ToString(), SaveImageCommon.CON_SAVEIMAGE_INI);
                SaveImageCommon.SetIniValue("FormSize", "Left", intLeft.ToString(), SaveImageCommon.CON_SAVEIMAGE_INI);
                SaveImageCommon.SetIniValue("FormSize", "Width", intWidth.ToString(), SaveImageCommon.CON_SAVEIMAGE_INI);
                SaveImageCommon.SetIniValue("FormSize", "Hight", intHight.ToString(), SaveImageCommon.CON_SAVEIMAGE_INI);

                blRes = true;
            }
            catch (Exception ex)
            {
                intTop = 0;
                intLeft = 0;
                intWidth = 0;
                intHight = 0;
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_ResetListItem(int int_sel_idx)
        {
            bool blRes;
            int intCnt;
            string[] strTempList;
            string strSelText;

            try
            {
                strTempList = new string[CON_COB_URL_CNT];

                intCnt = 0;
                strSelText = "";

                // コンボアイテム取得
                for (intCnt = 0; intCnt < CON_COB_URL_CNT; intCnt++)
                {
                    if (intCnt < cob_url.Items.Count)
                    {
                        strTempList[intCnt] = cob_url.Items[intCnt].ToString().Trim();
                        // 指定されたアイテムを記憶
                        if (intCnt == int_sel_idx) { strSelText = strTempList[intCnt]; }
                    }
                    else { strTempList[intCnt] = ""; }
                }

                cob_url.Items.Clear();
                // 選択されたURLをトップにセット
                cob_url.Items.Add(strSelText);
                for (intCnt = 0; intCnt < CON_COB_URL_CNT; intCnt++)
                {
                    if (strTempList[intCnt] != "")
                    {
                        if (intCnt != int_sel_idx) { cob_url.Items.Add(strTempList[intCnt]); }
                        else { strSelText = strTempList[intCnt]; }
                    }
                }
                this.pSelUrlText = strSelText;

                blRes = true;
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_DeleteListItem(int int_sel_idx)
        {
            bool blRes;
            int intCnt;
            string[] strTempList;
            string strSelText;
            string strMsg;

            try
            {
                strTempList = new string[CON_COB_URL_CNT];

                intCnt = 0;
                // コンボアイテム取得
                for (intCnt = 0; intCnt < CON_COB_URL_CNT; intCnt++)
                {
                    if (intCnt < cob_url.Items.Count) { strTempList[intCnt] = cob_url.Items[intCnt].ToString().Trim(); }
                    else { strTempList[intCnt] = ""; }
                }

                // 指定されたアイテムをコンボリストから削除
                strSelText ="";
                cob_url.Items.Clear();
                for (intCnt = 0; intCnt < CON_COB_URL_CNT; intCnt++)
                {
                    if (strTempList[intCnt] != "")
                    {
                        if (intCnt != int_sel_idx) {　cob_url.Items.Add(strTempList[intCnt]); }
                        else {  strSelText = strTempList[intCnt]; }
                    }
                }

                // URL再設定
                if (int_sel_idx == 0) { cob_url.Text = cob_url.Items[0].ToString(); }
                else { cob_url.Text = cob_url.Items[int_sel_idx - 1].ToString(); }

                // 削除されたURLをステータスバーに表示
                strMsg = "Delete Url [" + strSelText + "] From List ComboBox.";
                tsl_msg.Text = strMsg;
                StatusTimer.Start();

                //// 設定されたURLに遷移
                //if (cob_url.Text.Trim() != "")
                //{
                //    TargetWebBrowser.Navigate(cob_url.Text);
                //}

                blRes = true;
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_GetUrlList()
        {
            bool blRes;
            int intCnt;
            string strUrl;

            try
            {
                intCnt = 0;
                for (intCnt = 0; intCnt < CON_COB_URL_CNT ; intCnt++)
                {
                    strUrl = SaveImageCommon.GetIniValue("UrlList", "List" + (intCnt + 1).ToString("00"), SaveImageCommon.CON_SAVEIMAGE_INI);
                    if (strUrl.Trim() != "")
                    {
                        cob_url.Items.Add(strUrl);
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

        private bool fnc_SetUrlList()
        {
            bool blRes;
            int intCnt;
            int intList, intExcList;
            string[] strTempUrl, strUrl;
            string strExc;
            
            try
            {   
                // 保存除外キーを含む対象を取得
                fnc_GetUrlExclusionList();

                strTempUrl = new string[cob_url.Items.Count];
                intList = 0;
                // コンボボックスからアイテムを取得
                for (intList = 0; intList < cob_url.Items.Count ; intList++)
                {
                    if (intList < CON_COB_URL_CNT)
                    {
                        strTempUrl[intList] = cob_url.Items[intList].ToString().Trim();
                    }
                }

                // 保存除外キーを含む対象を除外
                intCnt = 0;
                strUrl = new string[cob_url.Items.Count];
                for (intList = 0; intList < strTempUrl.Length; intList++)
                {
                    strExc = "";
                    for (intExcList = 0; intExcList < this.pUrlExclusionList.Length; intExcList++)
                    {
                        strExc = this.pUrlExclusionList[intExcList].Trim();
                        if (strExc == "") { break; }

                        // 両端は「*」の場合
                        if (strExc[0] == char.Parse("*") && strExc[strExc.Length - 1] == char.Parse("*"))
                        {
                            strExc = strExc.Substring(1, strExc.Length - 2);
                            if (strExc != "")
                            {
                                if (strTempUrl[intList].Contains(strExc) == false)
                                { strUrl[intCnt] = strTempUrl[intList].Trim(); intCnt = intCnt + 1; }
                            }
                        }
                        else
                        {
                            // 先頭は「*」の場合
                            if (strExc[0] == char.Parse("*"))
                            {
                                strExc = strExc.Substring(1, strExc.Length - 1);
                                if (strExc != "")
                                {
                                    if (strTempUrl[intList].EndsWith(strExc) == false)
                                    { strUrl[intCnt] = strTempUrl[intList].Trim(); intCnt = intCnt + 1; }
                                }
                            }
                            // 最後は「*」の場合
                            else if (strExc[strExc.Length - 1] == char.Parse("*"))
                            {
                                strExc = strExc.Substring(0, strExc.Length - 1);
                                if (strExc != "")
                                {
                                    if (strTempUrl[intList].StartsWith(strExc) == false)
                                    { strUrl[intCnt] = strTempUrl[intList].Trim(); intCnt = intCnt + 1; }
                                }
                            }
                            else
                            {   
                                // 両端は「*」以外の場合
                                if (strTempUrl[intList] != strExc)
                                { strUrl[intCnt] = strTempUrl[intList].Trim(); intCnt = intCnt + 1; }
                            }
                        }                       
                    }
                }
                
                // INIファイル定義をいったん削除
                SaveImageCommon.SetIniValue("UrlList", null, null, SaveImageCommon.CON_SAVEIMAGE_INI);

                // 保存対象をINIファイルに出力
                if (intCnt == 0)
                {
                    // 除外キー情報は存在しない場合
                    intCnt = 0;
                    for (intList = 0; intList < strTempUrl.Length; intList++)
                    {
                        if (strTempUrl[intList] != null && strTempUrl[intList] != "")
                        {
                            intCnt = intCnt + 1;
                            SaveImageCommon.SetIniValue("UrlList", "List" + (intCnt).ToString("00"), strTempUrl[intList], SaveImageCommon.CON_SAVEIMAGE_INI);
                        }
                    }
                }
                else
                {
                    // 除外キー情報は存在し、突合せ実施した場合
                    intCnt = 0;
                    for (intList = 0; intList < strUrl.Length; intList++)
                    {
                        if (strUrl[intList] != null && strUrl[intList] != "")
                        {
                            intCnt = intCnt + 1;
                            SaveImageCommon.SetIniValue("UrlList", "List" + (intCnt).ToString("00"), strUrl[intList], SaveImageCommon.CON_SAVEIMAGE_INI);
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

        private bool fnc_GetUrlExclusionList()
        {
            bool blRes;
            int intCnt;
            string strUrl;

            try
            {
                this.pUrlExclusionList = new string[CON_COB_URL_CNT];
                intCnt = 0;
                for (intCnt = 0; intCnt < CON_COB_URL_CNT; intCnt++)
                {
                    strUrl = SaveImageCommon.GetIniValue("UrlExclusion", "Key" + (intCnt + 1).ToString("00"), SaveImageCommon.CON_SAVEIMAGE_INI);
                    this.pUrlExclusionList[intCnt] = strUrl;
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

        private bool fnc_GetImageVerticalScorllSize()
        {
            bool blRes;
            string strSize;
            int intSize;

            try
            {
                // INIファイルから縦スクロールサイズ取得
                strSize = SaveImageCommon.GetIniValue("Option", "VerticalScorllSize", SaveImageCommon.CON_SAVEIMAGE_INI);
                // 
                if (int.TryParse(strSize, out intSize) == true)
                {
                    this.pImageVerticalScorllSize = intSize;
                }
                else
                {
                    this.pImageVerticalScorllSize = 0;
                    fnc_SetImageVerticalScorllSize();
                }
                txt_SetVerticalScrollSize.Text = this.pImageVerticalScorllSize.ToString();

                blRes = true;
            }
            catch (Exception ex)
            {
                this.pImageVerticalScorllSize = 0;
                fnc_SetImageVerticalScorllSize();
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_SetImageVerticalScorllSize()
        {
            bool blRes;

            try
            {
                SaveImageCommon.SetIniValue("Option", "VerticalScorllSize", this.pImageVerticalScorllSize.ToString(), SaveImageCommon.CON_SAVEIMAGE_INI);
                blRes = true;
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_SetImageExtenseCombox()
        {
            bool blRes;
            string strImageType;

            try
            {
                this.pImageType = "";
                // INIファイルから画像拡張子取得
                strImageType = SaveImageCommon.GetIniValue("Option", "FileExtense", SaveImageCommon.CON_SAVEIMAGE_INI);
                strImageType = strImageType.ToUpper();

                tsb_ImageFile_ExtList.Items.Clear();
                foreach (string strExt in CON_EXTENSE)
                {
                    // 画像拡張子値設定
                    tsb_ImageFile_ExtList.Items.Add(strExt);
                    // デフォルト（ユーザ指定）取得
                    if (this.pImageType == "" && strImageType == strExt) { this.pImageType = strExt; }
                }
                if (this.pImageType == ""){ this.pImageType = SaveImageCommon.CON_EXTENSE_JPG; }

                // 画像拡張子デフォルト（ユーザ指定）値設定
                tsb_ImageFile_ExtList.Text = this.pImageType;

                blRes = true;
            }
            catch (Exception ex)
            {
                // this.pImageType = CON_EXTENSE_PNG; // TODO
                this.pImageType = SaveImageCommon.CON_EXTENSE_JPG;
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private bool fnc_SetImageExtense()
        {
            bool blRes;

            try
            {
                SaveImageCommon.SetIniValue("Option", "FileExtense", this.pImageType, SaveImageCommon.CON_SAVEIMAGE_INI);
                blRes = true;
            }
            catch (Exception ex)
            {
                blRes = false;
                CommonLogger.WriteLine(ex.Message);
            }
            return blRes;
        }

        private Bitmap fnc_GetWebImage(Bitmap srcBitmap, int intLeft, int intTop, int intWidth, int intHeight)
        {
            Bitmap desBitmap = null;
            Graphics desGraphics = null;
            Rectangle srcRect;
            Rectangle desRect;

            try
            {
                // 切り取る部分の範囲を決定
                srcRect = new Rectangle(intLeft, intTop, intWidth, intHeight);
                // 描画する部分の範囲を決定
                desRect = new Rectangle(0, 0, intWidth, intHeight);
    
                //画像の一部を描画
                desBitmap = new Bitmap(intWidth, intHeight);
                desGraphics = Graphics.FromImage(desBitmap);
                desGraphics.DrawImage(srcBitmap, desRect, srcRect, GraphicsUnit.Pixel);
                desGraphics.Dispose();
                
                // 取得したbmp情報を返す
                return desBitmap;
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        private Bitmap fnc_GetWebImageFullScreen()
        {
            int intWbWidthDefault;
            int intWbHeightDefault;
            int intBodyWidth;
            int intBodyHeight;

            Bitmap bitmap = null;

            try
            {
                intWbWidthDefault = TargetWebBrowser.Width;
                intWbHeightDefault = TargetWebBrowser.Height;

                // キャプチャサイズを指定                
                intBodyWidth = TargetWebBrowser.Document.Body.ScrollRectangle.Width;
                intBodyHeight = TargetWebBrowser.Document.Body.ScrollRectangle.Height;
                TargetWebBrowser.Width = intBodyWidth;
                TargetWebBrowser.Height = intBodyHeight;

                // キャプチャの保存先bitmapを生成
                bitmap = new Bitmap(intBodyWidth, intBodyHeight);

                Graphics graphic = null;
                IntPtr ptrObj = IntPtr.Zero;
                IntPtr ptrHdc = IntPtr.Zero;
                try
                {
                    graphic = Graphics.FromImage(bitmap);
                    ptrHdc = graphic.GetHdc();
                    ptrObj = Marshal.GetIUnknownForObject(TargetWebBrowser.ActiveXInstance);
                    Rectangle rect = new Rectangle(0, 0, intBodyWidth, intBodyHeight);

                    // ptrObj画像内のrectで指定した領域を,HDCのエリアに貼付
                    SaveImageCommon.OleDraw(ptrObj, (int)DVASPECT.DVASPECT_CONTENT, ptrHdc, ref rect);
                }
                finally
                {
                    if (ptrObj != IntPtr.Zero) { Marshal.Release(ptrObj); }
                    if (ptrHdc != IntPtr.Zero) { graphic.ReleaseHdc(ptrHdc); }
                    if (graphic != null) { graphic.Dispose(); }

                    TargetWebBrowser.Width = intWbWidthDefault;
                    TargetWebBrowser.Height = intWbHeightDefault;
                }

                // 取得したbmp情報を返す
                return bitmap;
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private bool fnc_SaveIamgeToClip()
        {
            bool blRes;
            Bitmap bitmap;

            bitmap = fnc_GetWebImageFullScreen();
            if (bitmap != null)
            {
                Clipboard.SetImage(bitmap);
                blRes = true;
            }
            else { blRes = false; }

            return blRes;
        }

        private string fnc_SaveImageToFile()
        {
            string strRes;
            if (this.pImageVerticalScorllSize == 0) { strRes = fnc_SaveImageToOneFile(); }
            else { strRes = fnc_SaveImageToDivFile(); }
            return strRes;
        }

        private string fnc_SaveImageToOneFile()
        {
            string strCurrentDir;
            string strFileName;
            Bitmap bmpImage;

            try
            {
                // フル画面画像取得
                bmpImage = fnc_GetWebImageFullScreen();
                // ファイルに出力
                strFileName = fnc_GetImageFileMainNo();
                strFileName = strFileName.Replace("_YY", "");
                strCurrentDir = Directory.GetCurrentDirectory();
                switch (this.pImageType)
                {
                    case SaveImageCommon.CON_EXTENSE_JPG:
                        bmpImage.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Jpeg); break;
                    case SaveImageCommon.CON_EXTENSE_PNG:
                        bmpImage.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Png); break;
                    case SaveImageCommon.CON_EXTENSE_TIFF:
                        bmpImage.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Tiff); break;
                    case SaveImageCommon.CON_EXTENSE_GIF:
                        bmpImage.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Gif); break;
                    // case CON_EXTENSE_XPS:
                    //     break;
                    default:
                        bmpImage.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Jpeg); break;
                }
            }
            catch (Exception ex)
            {
                strFileName = "";
                CommonLogger.WriteLine(ex.Message);
            }

            return strFileName;
        }

        private string fnc_SaveImageToDivFile()
        {
            string strCurrentDir;
            string strTempFileName;
            string strFileName;
            Bitmap srcBitmap, expBitmap;

            int intWbWidth, intWbHeight;
            int intCnt, intPageCount;
            int intLeft, intTop, intWidth, intHeight;
            
            try
            {
                // フル画面画像取得
                srcBitmap = fnc_GetWebImageFullScreen();
                // 出力ファイル名取得
                strCurrentDir = Directory.GetCurrentDirectory();
                strTempFileName = fnc_GetImageFileMainNo();
                // ステータスバーに表示する文言のため
                strFileName = strTempFileName.Replace("_YY", "_XX");

                // 分割ページ数計算
                intWbWidth = TargetWebBrowser.Document.Body.ScrollRectangle.Width;
                intWbHeight = TargetWebBrowser.Document.Body.ScrollRectangle.Height;
                if (intWbHeight % this.pImageVerticalScorllSize == 0) { intPageCount = intWbHeight / this.pImageVerticalScorllSize; }
                else { intPageCount = intWbHeight / this.pImageVerticalScorllSize + 1; }
                // 分割ページ（MAX：99）超える場合、MAX値設定
                if (intPageCount > 99) { intPageCount = 99; }

                intLeft = 0;
                intTop = 0;
                intWidth = TargetWebBrowser.Document.Body.ScrollRectangle.Width;
                intHeight = this.pImageVerticalScorllSize;
                for (intCnt = 0; intCnt < intPageCount; intCnt++)
                {
                    strFileName = strTempFileName.Replace("_YY", (intCnt + 1).ToString("_00"));
                    // （X,Y）位置計算
                    intTop = intCnt * this.pImageVerticalScorllSize;
                    // 画像ファイル出力
                    if (intCnt == intPageCount - 1 )
                    {
                        // 最後の（分割）1ページの縦幅再計算
                        intHeight = intWbHeight - intTop;
                        expBitmap = fnc_GetWebImage(srcBitmap, intLeft, intTop, intWidth, intHeight);
                        if (intCnt == 0) { strFileName = strFileName.Replace("_01", ""); }
                    }
                    else{ expBitmap = fnc_GetWebImage(srcBitmap, intLeft, intTop, intWidth, intHeight); }
                    

                    switch (this.pImageType)
                    {
                        case SaveImageCommon.CON_EXTENSE_JPG:
                            expBitmap.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Jpeg); break;
                        case SaveImageCommon.CON_EXTENSE_PNG:
                            expBitmap.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Png); break;
                        case SaveImageCommon.CON_EXTENSE_TIFF:
                            expBitmap.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Tiff); break;
                        case SaveImageCommon.CON_EXTENSE_GIF:
                            expBitmap.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Gif); break;
                        // case CON_EXTENSE_XPS:
                        //     break;
                        default:
                            expBitmap.Save(strCurrentDir + "\\" + strFileName, ImageFormat.Jpeg); break;
                    }
                }

                // ステータスバーに表示する文言のため（複数ファイルの場合）
                if (intCnt > 0 ) { strFileName = " ～ " + strFileName; }
            }
            catch (Exception ex)
            {
                strFileName = "";
                CommonLogger.WriteLine(ex.Message);
            }

            return strFileName;
        }

        private string fnc_GetImageFileMainNo()
        {
            string strTemp;
            string strFile;
            int intCnt;

            try
            {
                strFile = SaveImageCommon.CON_IAMGE_FILE;
                strTemp = SaveImageCommon.CON_IAMGE_FILE;

                for (intCnt = 1; intCnt <= 999; intCnt++)
                {
                    strTemp = strFile.Replace("XXX", intCnt.ToString("000"));
                    if (fnc_CheckImageFile(strTemp) == false)
                    {
                        strFile = strTemp;
                        break;
                    }
                }

                //MessageBox.Show(strFile);
                CommonLogger.WriteLine(strFile);

                // 拡張子設定
                foreach (string strExt in CON_EXTENSE)
                {
                    if (this.pImageType == strExt) { strFile = strFile + "." + strExt; }
                }
            }
            catch (Exception ex)
            {
                strFile = "";
                CommonLogger.WriteLine(ex.Message);
            }

            return strFile;
        }

        private bool fnc_CheckImageFile(string strFileName)
        {
            string strCurrentDir;
            string strTemp;
            DirectoryInfo di;
            FileInfo[] fiFiles;
            bool blRes;

            strCurrentDir = Directory.GetCurrentDirectory();
            strTemp = strFileName.Replace("_YY", "");

            di = new System.IO.DirectoryInfo(@strCurrentDir);
            fiFiles = di.GetFiles(strTemp + "*.*", System.IO.SearchOption.TopDirectoryOnly);
            if (fiFiles.Length > 0) { blRes = true; }
            else { blRes = false; }

            return blRes;
        }

        private void fnc_ShowVersion(string strDraftVersion = "")
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            // app情報
            string appInfog;
            //appInfog = asm.GetName().Name;
            //appInfog = Application.ProductName + " (" + asm.GetName().Name + ".exe)";
            appInfog = Application.ProductName;

            // 自身バージョン情報取得
            System.Version ver = asm.GetName().Version;
            string strVersion = " Version : " + ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString();
            if (strDraftVersion != "") { strVersion = strVersion + "." + strDraftVersion; }

            // システム情報
            string sysInfo;
            sysInfo = "Based on Original Development\r\n";
            sysInfo += "by Claim Group, Tomita Kouki\r\n";
            AssemblyCopyrightAttribute asmcpr = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            sysInfo += asmcpr.Copyright;    

            VersionDialog verDialog;
            verDialog = new VersionDialog(appInfog, strVersion, sysInfo);
            verDialog.MaximizeBox = false;
            verDialog.MinimizeBox = false;
            verDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            verDialog.ShowDialog();
        }

#endregion Form Private Method

#region Test Method
       
        private void lbl_address_Info_DoubleClick(object sender, EventArgs e)
        {
            //this.tsb_ctrl_panel.Visible = true;
        }

#endregion Test Method

    }
}
