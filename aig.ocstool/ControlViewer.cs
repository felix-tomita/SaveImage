using System;
using System.Threading;
using System.Windows.Forms;

namespace aig.ocstool
{
    public partial class ControlViewer : Form
    {

#region Define

        private Form pParentForm;
        private WebBrowser pTargetWebBrowser;

#endregion Define

#region Initialization

        public ControlViewer()
        {
            InitializeComponent();
        }

        public ControlViewer(Form parent, WebBrowser webbrowser)
        {
            InitializeComponent();
            this.pParentForm = parent;
            this.pTargetWebBrowser = webbrowser;
        }

#endregion Initialization

#region Form Control Event

        private void ControlViewer_Load(object sender, EventArgs e)
        {
            fnc_SetDefualtPostion(this.pParentForm);
        }
        
        private void btn_exec_Click(object sender, EventArgs e)
        {
            // TODO
            fnc_DoTestEvent();
        }

#endregion Form Control Event

#region Form Private Method

        private void fnc_SetDefualtPostion(Form parent)
        {
            // TODO
        }
        
#endregion Form Private Method

#region Test Method

        private void fnc_DoTestEvent()
        {
            HtmlElementCollection all = this.pTargetWebBrowser.Document.All;
            HtmlElementCollection forms;

            forms = all.GetElementsByName("q");
            forms[0].InnerText = txt_input_value.Text.Trim(); // テキストボックスに「C#」を入力

            forms = all.GetElementsByName("f");
            forms[0].InvokeMember("submit"); // フォームのサブミット

            //HtmlElementCollection forms3 = all.GetElementsByName("btnG");
            //forms3[0].InvokeMember("click"); // ボタンのクリック

            // GIT Update
        }

        private void fnc_SetDataGridView()
        {

        }
        
#endregion Test Method
    }
}
