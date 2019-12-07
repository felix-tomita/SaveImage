using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace aig.ocstool
{
    public static class SaveImageCommon
    {

#region Define

        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileString(
                                                        string lpApplicationName,
                                                        string lpKeyName,
                                                        string lpDefault,
                                                        StringBuilder lpReturnedstring,
                                                        int nSize,
                                                        string lpFileName);

        [DllImport("KERNEL32.DLL")]
        private static extern uint WritePrivateProfileString(
                                                        string lpAppName,
                                                        string lpKeyName,
                                                        string lpString,
                                                        string lpFileName);

        [DllImport("ole32.dll")]
        public static extern int OleDraw( IntPtr pUnk, int dwAspect, IntPtr hdcDraw, ref Rectangle lprcBounds );
                                                       
#endregion Define

#region Define (Public Const)

        public static string CON_SAVEIMAGE_INI = Environment.GetCommandLineArgs()[0].Replace("exe", "ini");

        // public const string CON_DEF_EXC_KEY = "*siteminderagent*";
        public const string CON_DEF_EXC_KEY = "*siteminderagent/formsja/loginandpwchange*";

        public const string CON_SUCCESS = "SUCCESS";
        public const string CON_FAIL = "FAIL";

        public const string CON_EXTENSE_JPG = "JPG";
        public const string CON_EXTENSE_PNG = "PNG";
        public const string CON_EXTENSE_TIFF = "TIFF";
        public const string CON_EXTENSE_GIF = "GIF";
        public const string CON_EXTENSE_XPS = "XPS";

        public static string CON_IAMGE_FILE = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0].ToString()) + "_XXX_YY";

#endregion Define (Public Const)

#region Public Static Method

        public static string GetIniValue(string lpSection, string lpKeyName, string lpFileName)
        {
            try
            {
                StringBuilder strValue = new StringBuilder(1024);
                uint sLen = GetPrivateProfileString(lpSection, lpKeyName, "", strValue, 1024, lpFileName);
                return strValue.ToString();
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
                return "";
            }
        }

        public static bool SetIniValue(string lpSection, string lpKeyName, string lpValue, string lpFileName)
        {
            try
            {
                long result = WritePrivateProfileString(lpSection, lpKeyName, lpValue, lpFileName);
                return result != 0;
            }
            catch (Exception ex)
            {
                CommonLogger.WriteLine(ex.Message);
                return false;
            }
        }
    
        public static string GetVersionInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName asmName = assembly.GetName();
            Version version = asmName.Version;
            string strVer = " [OCS : Ver." + version.ToString() + "]";
            return strVer;
        }

#endregion Public Static Method

    }
}
