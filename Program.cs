using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CsharpDemoWC
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Frzhujiemian());
            // Application.Run(new FrmDemoWC());

        }
        public static void JsonToDataTable(string strJson)
        {
            //JArray array = (JObject)JsonConvert.DeserializeObject(strJson);
            //MessageBox.Show(strJson.Length+"");
            //int i = 1;
        }

        public static String JsonRemoveSymbols(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("");
                        break;
                    case '\\':
                        sb.Append("");
                        break;
                    case '/':
                        sb.Append("");
                        break;
                    case '\b':
                        sb.Append("");
                        break;
                    case '\f':
                        sb.Append("");
                        break;
                    case '\n':
                        sb.Append("");
                        break;
                    case '\r':
                        sb.Append("");
                        break;
                    case '\t':
                        sb.Append("");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
