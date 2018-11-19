using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace CsharpDemoWC.utilcommon
{
   public class util
    {
        public DataTable getdata(string cangkubiaohao)
        {
            string postString = "REQ_MESSAGE= { \"REQ_HEAD\":{\"version\": \"1.0\",\"encoding\": \"UTF-8\"},\"REQ_BODY\": {\"LGNUM\":\""+ cangkubiaohao+"\"}}";
            // string postString = "REQ_MESSAGE = { \"REQ_HEAD\": { \"version\": \"1.0\"，\"encoding\": \"UTF -8\"，}}";
            byte[] postData = Encoding.UTF8.GetBytes(postString);
            string url = "http://221.178.208.46:48092/warehousemngpd/listWzInfo.tran";
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流  
            string srcString = Encoding.UTF8.GetString(responseData);//解码


            var jo = (JObject)JsonConvert.DeserializeObject(srcString);
            JsonToDataTable(jo["REP_BODY"]["RSPDATA"].ToString());
            JArray array = (JArray)jo["REP_BODY"]["RSPDATA"];
            DataTable db = new DataTable();
            db = JsonConvert.DeserializeObject<DataTable>(array.ToString());
            //DataTable zone = JsonToDataTable(jo["REP_BODY"]["RSPDATA"].ToString());
            return db;
        }
        public void senddata(string LGNUM, string MAKBH, string RFIDNO, string CHARG, string BQ, string PT, string BT)
        {
            string postString = "REQ_MESSAGE= { \"REQ_HEAD\":{\"version\": \"1.0\",\"encoding\": \"UTF-8\"},\"REQ_BODY\": {\"LGNUM\":\"" + LGNUM + "\",\"MAKBH\":\"" + MAKBH + "\",\"RFIDNO\":\"" + RFIDNO+ "\",\"CHARG\":\"" + CHARG + "\",\"BQ\":\"" + BQ + "\",\"PT\":\"" + PT + "\",\"BT\":\"" + BT + "\"}}";
            byte[] postData = Encoding.UTF8.GetBytes(postString);
            string url = "http://221.178.208.46:48092/warehousemngpd/updateWzZt.tran";
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流  
            string srcString = Encoding.UTF8.GetString(responseData);//解码


            var jo = (JObject)JsonConvert.DeserializeObject(srcString);
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
