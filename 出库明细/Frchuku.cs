using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using CsharpDemoWC.utilcommon;
using System.Drawing.Printing;

namespace CsharpDemoWC.出库明细
{
    public partial class Frchuku : DevExpress.XtraEditors.XtraForm
    {
        Reader Reader = new Reader();

        public UInt16 res;
        public int m_hScanner = -1, _OK = 0;
        public int ComMode = 0;//0--TCP/IP, 1--RS232,2--RS485, 3--USB
        //输入参数:	lOpt 为何种方式通信(0--TCP/IP, 1--RS232,2--RS485, 3--USB)
        public long lopt = 0;
        public string szPort;
        public byte connect_OK = 0;////0--no connect, 1--connected
        public int HardVersion, SoftVersion;
        int RS485Address = 0;

        //基本参数和自动参数
        public Reader.ReaderBasicParam gBasicParam = new Reader.ReaderBasicParam();
        public Reader.ReaderAutoParam gAutoParam = new Reader.ReaderAutoParam();
        public Reader.SimParam Param = new Reader.SimParam();//自模下仿真参数


        byte gFre = 0;	//取哪个国家的频率

        public byte[] gReaderID = new byte[33];			//读写器ID

        public Reader.tagReaderFreq[] stuctFreqCountry = new Reader.tagReaderFreq[25];


        //================ISO 18000 6C============================================
        int m_Word = 0;//数据位数
        int m_WriteMode = 0; //选中EPC---0, 选中用户区---1, 选中密码区---2
        int iFlagProtectOpt;//0---不保护(不锁), 1---使用密码锁，2---永远锁住(死了)
        //开启线程
        Thread tdThreadEPC = null;
        Thread tdThreadWrite = null;
        bool nStop = false;

        Thread teThreadEPC = null;//6c读线程
        public int nidEvent, mem, ptr, len;
        public int Read_times;
        public int m_antenna_sel;
        public byte[] AccessPassWord = new byte[4];
        public int nBaudRate = 0, Interval, EPC_Word;
        public byte[] IDTemp = new byte[120];
        string id = "";
        string MAKBH = "";
        string RFIDNO = "";
        string CHARG = "";
        string MAKTX = "";

        private void radioButton2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //连接读写器
            int i = 0;
            ComMode = 0;
            if (radioButton1.Checked == true)
            {
                ComMode = 1;//RS232
            }
            if (radioButton2.Checked == true)
            {
                ComMode = 3;//USB
            }

            //COM口
            szPort = comboBox1.Text;

            switch (ComMode)
            {
                case 1:
                    res = Reader.ConnectScanner(ref m_hScanner, szPort, 0);
                    break;
                case 3:
                    res = Reader.VH_ConnectScannerUsb(ref m_hScanner);
                    break;

            }

            if (_OK == res)
            {
                for (i = 0; i < 3; i++)
                {
                    //读版本
                    res = Reader.VH_GetVersion(m_hScanner, ref HardVersion, ref SoftVersion);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(VH_GetVersion)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2_Click(null, null);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //读基本参数
                    res = Reader.ReadBasicParam(m_hScanner, ref gBasicParam);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(ReadBasicParam)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2_Click(null, null);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //国家频率
                    res = Reader.GetFrequencyRange(m_hScanner, ref gFre);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(GetFrequencyRange)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2_Click(null, null);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //读auto参数
                    res = Reader.ReadAutoParam(m_hScanner, ref gAutoParam);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(ReadAutoParam)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2_Click(null, null);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //读ID
                    res = Reader.GetReaderID(m_hScanner, gReaderID);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(GetReaderID)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2_Click(null, null);
                    return;
                }



                for (i = 0; i < 3; i++)
                {
                    byte[] pPParam = new byte[26];
                    //读仿真参数
                    //res = Reader.ReadSimParam(m_hScanner, pPParam);
                    res = Reader.ReadSimParam(m_hScanner, ref Param);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(ReadSimParam)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    button2_Click(null, null);
                    return;
                }


                //弹出提示成功
                connect_OK = 1;//0--no connect, 1--connected

                button1.Enabled = false;//ConnectReader
                button2.Enabled = true;//DisconnectReader
                this.xtraTabControl1.SelectedTabPage= xtraTabPage2;//进入第3页,ISO18000-6C
                //this.tabControl1.SelectedIndex = 1;//进入第2页,param
                //this.tabControl1.SelectedIndex = 2;//进入第3页,ISO18000-6C
                //ParamSettoUI();
                MessageBox.Show("连接成功!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                button1.Enabled = true;//ConnectReader
                button2.Enabled = false;//DisconnectReader
                MessageBox.Show("连接失败!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        //================ISO 18000 6C============================================



        /// <summary>
        /// 日志文件的宏
        /// </summary>
        private const string LOGDIR = "\\Log\\";

        /// <summary>
        /// 写日志的扩展名
        /// </summary>
        private const string LOGEXT = ".log";
        private void ThreadEPC()
        {
            int t = 0;

            int i, j, k, nCounter = 0, ID_len = 0;// ID_len_temp = 0;
            string str, str_temp;
            byte[] temp = new byte[512];
            byte[] IDBuffer = new byte[30 * 256];

            byte[] mask = new byte[512];
            byte[] IDTemp = new byte[512];
            int mem, ptr, len, EPC_Word;
            byte[] AccessPassword = new byte[32];

            byte[] p = new byte[3];

            if (res == _OK)
            {
                string id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "RFIDNO").ToString();
                string id1=StringToHexString(id, System.Text.Encoding.UTF8);
               
                int nBLen = id1.Length;
                if ( (nBLen < 4)|| ((nBLen % 4) != 0))
                {
                //    MessageBox.Show("数据长度错误", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                //else{
                    str_temp = id1;
                    str = str_temp;
                    while (nStop) //写入数据的循环
                    {
                        for (i = 0; i < 512; i++) temp[i] = 0;
                        for (i = 0; i < 512; i++) mask[i] = 0;
                        for (i = 0; i < 512; i++) IDTemp[i] = 0;

                        //设置写入的数据
                        //WideCharToMultiByte( CP_ACP, 0, str.GetBuffer(), -1,(char *)temp,str.GetLength()*2,NULL,NULL );
                        len = str.Length;
                        for (i = 0; i < len / 2; i++)
                        {
                            mask[i] = (byte)Convert.ToInt16((str[i * 2].ToString() + str[i * 2 + 1].ToString()), 16);
                        }


                        len = str.Length / 4;
                        k = 0;
                        for (i = 0; i < (len * 2); i++)
                        {

                            k = k + 2;

                        }
                        for (i = 0; i < len * 2; i++) IDTemp[i] = mask[i];//memcpy(IDTemp,mask,len*2);//IDTemp为准备写的数据
                                                                          //memset(AccessPassword,0,4);

                        Thread.Sleep(30);
                        switch (ComMode)
                        {
                            case 0:
                                break;
                            case 1:
                                res = Reader.EPC1G2_WriteEPC(m_hScanner, (byte)len, mask, AccessPassword, RS485Address);
                                break;
                            case 3://usb
                                res = Reader.EPC1G2_WriteEPC(m_hScanner, (byte)len, mask, AccessPassword, 0);
                                break;
                        }

                        if (res == _OK) //写完后立即读取，以便检测写入数据是否正确
                        {

                            Icon iconx = new Icon("iconOK.ico", 32, 32);
                            pictureBox1.Image = iconx.ToBitmap();
                            label3.Text = ("写卡成功，请移开此卡");
                        }
                        else
                        {


                            //SendMessage(epcDlg->m_hWnd,WM_MSG,101,t);//等待写卡，请放入卡:%d-%d
                            Icon icon = new Icon("icoWait.ico", 32, 32);

                            Thread.Sleep(100);
                        }
                    }
                }
                

            }

            else
            {

                MessageBox.Show("写卡失败");

            }
        }

        private string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
        }
        private string HexStringToString(string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }
        private void 写入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean flag1 = true;
            nStop = true;
            //tdThreadEPC = new Thread(new ThreadStart(this.ThreadEPC));
            tdThreadEPC = new Thread(new ThreadStart(this.ThreadWrite));
            tdThreadEPC.Start();
           


        }
        private void ThreadWrite()
        {
          
            int mem, ptr, len, EPC_Word;
            int t = 0;
            len = 0;    //掩码长度LEN
            ptr = 0;    //掩码起始地址addr
            mem = 1;	//0--密码区,1-- EPC号,2-- TID标签ID号,3--用户区User
            int i, j, k, nCounter = 0, ID_len = 0;// ID_len_temp = 0;
            string str, str_temp;
            byte[] temp = new byte[512];
            byte[] IDBuffer = new byte[30 * 256];
            byte[] IDTemp = new byte[512];
            byte[] mask = new byte[512];
            byte[] AccessPassword = new byte[32];

            byte[] p = new byte[3];
            string LGNUM="";
            string MAKBH = "";
            string RFIDNO = "";
            string CHARG = "";
            string BQ = "";
            string PT = "";
            string BT = "";
     
              
            if (res == _OK)
            {
                 id = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "RFIDNO").ToString();
                 MAKBH = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "MAKBH").ToString();
                RFIDNO = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "RFIDNO").ToString();
                CHARG = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "CHARG").ToString();
                MAKTX = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "MAKTX").ToString();

                ID_len = (int)IDBuffer[0];  //IDBuffer[0]为Word总数;1word=2Byte
                for (i = 0; i < ID_len * 2; i++)
                {
                    temp[i] = IDBuffer[i];
                }

                string id1 = StringToHexString(id, System.Text.Encoding.UTF8);
                string id2 = HexStringToString(id1, System.Text.Encoding.UTF8);
                int nBLen = id1.Length;
                if ((nBLen < 4) || ((nBLen % 4) != 0))
                {
                    //    MessageBox.Show("数据长度错误", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}
                    //else{
                    str_temp = id1;
                    str = str_temp;
                    while (nStop) //写入数据的循环
                    {
                        Thread.Sleep(30);
                        res = Reader.EPC1G2_ReadLabelID(m_hScanner, mem, ptr, len, mask, IDBuffer, ref nCounter, 0);
                        for (i = 0; i < 512; i++) temp[i] = 0;
                        for (i = 0; i < 512; i++) mask[i] = 0;
                        for (i = 0; i < 512; i++) IDTemp[i] = 0;

                        //设置写入的数据
                        //WideCharToMultiByte( CP_ACP, 0, str.GetBuffer(), -1,(char *)temp,str.GetLength()*2,NULL,NULL );
                        len = str.Length;
                        for (i = 0; i < len / 2; i++)
                        {
                            mask[i] = (byte)Convert.ToInt16((str[i * 2].ToString() + str[i * 2 + 1].ToString()), 16);
                        }


                        len = str.Length / 4 + (0 == str.Length % 4? 0 : 1);
                        k = 0;
                        for (i = 0; i < (len * 2); i++)
                        {

                            k = k + 2;

                        }
                       

                        Thread.Sleep(30);
                        mem = 3; ptr = 0; j = 0;
                        switch (ComMode)
                        {
                            case 0:
                                break;
                            case 1:
                                res = Reader.EPC1G2_WriteWordBlock(m_hScanner, (byte)ID_len, IDTemp, (byte)mem, (byte)ptr, (byte)len, mask, AccessPassword, RS485Address);
                                break;
                            case 3://usb
                                res = Reader.EPC1G2_WriteWordBlock(m_hScanner, (byte)ID_len, temp, (byte)mem, (byte)ptr, (byte)len, mask, AccessPassword, 0);
                                int k1 = 1;
                                break;
                        }

                        if (res == _OK) //写完后立即读取，以便检测写入数据是否正确
                        {

                            Icon iconx = new Icon("iconOK.ico", 32, 32);
                            pictureBox1.Image = iconx.ToBitmap();
                            label3.Text = ("写卡成功，请移开此卡");
                            senddata("GA1", MAKBH, RFIDNO, CHARG, "0", "0", "0");
                            nStop = false;


                            foreach (string fPrinterName in PrinterSettings.InstalledPrinters)
                            {
                                if (fPrinterName.Equals("ZDesigner GK888t"))
                                {
                                    i = 1;
                                }
                            }
                            if (i == 0)
                            {
                                MessageBox.Show("打印错误");
                            }
                            else
                            {

                                printDialog1.Document = printDocument1;
                                this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 140, 100);
                                this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
                                printDocument1.PrinterSettings.PrinterName = "ZDesigner GK888t";
                                printDocument1.Print();

                            }

                        }
                        else
                        {


                            //SendMessage(epcDlg->m_hWnd,WM_MSG,101,t);//等待写卡，请放入卡:%d-%d
                            Icon icon = new Icon("icoWait.ico", 32, 32);

                          
                        }
                    }
                }


            }

            else
            {

                MessageBox.Show("写卡失败");

            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            //开始读取
            if (0 == connect_OK)
            {
                nStop = false;
                MessageBox.Show("读写器未连接!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            button22.Enabled = true;//停止按钮
            button21.Enabled = false;//开始按钮


            nStop = true;
            teThreadEPC = new Thread(new ThreadStart(this.ThreadReader));
            teThreadEPC.Start();
        }
        private void ThreadReader()
        {
            int t;

            int i = 0;
            int j, nCounter = 0, ID_len = 0;//ID_len_temp=0;
            string str, str_temp;
            byte[] temp = new byte[512];
            byte[] IDBuffer = new byte[30 * 256];
            byte[] DB = new byte[128];
            byte[] mask = new byte[512];
            byte[] IDTemp = new byte[512];
            int mem, ptr, len, EPC_Word;
            byte[] AccessPassword = new byte[4];

            //int nRow;


            string stEpc = "";
            string stTid = "";
            string stUsr = "";
            string stPass = "";

            while (nStop)
            {


                //stEpc = "";
                //stTid = "";
                //stUsr = "";
                //stPass = "";

                if (connect_OK == 0)
                {
                    nStop = false;
                    MessageBox.Show("读写器未连接!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    break;
                }

                len = 0; ptr = 0; mem = 3; ID_len = 0; j = 0;   //nRow=0;
                for (i = 0; i < 512; i++) mask[i] = 0;
                int len1 = 6;
                for (i = 0; i < 3; i++)
                {
                    Thread.Sleep(300);
                    switch (ComMode)
                    {
                        case 0:
                            break;
                        case 1:
                        case 3://usb,读EPC号
                            res = Reader.EPC1G2_ReadLabelID(m_hScanner, mem, ptr, len, mask, IDBuffer, ref nCounter, RS485Address);
                            break;
                    }
                    if (_OK == res)
                    {
                        break;
                    }
                }
                ID_len = IDBuffer[0];
                if (_OK == res)
                {
                    for (j = 0; j < ID_len * 2; j++) IDTemp[j] = IDBuffer[j + 1];
                    for (i = 0; i < 3; i++)
                    {
                                Thread.Sleep(300);
                                len = 12;
                                    EPC_Word = ID_len;
                                    res = Reader.EPC1G2_ReadWordBlock(m_hScanner, (byte)EPC_Word, IDTemp, 3, (byte)ptr, (byte)len, DB, AccessPassword, 0);
                               if (_OK == res)
                                    {
                                        str = "";
                                        for (j = 0; j < 512; j++) temp[j] = 0; //memset(temp, 0, 512);
                                        for (j = 0; j < len * 2; j++) temp[j] = DB[j]; //memcpy(temp, DB, len * 2);
                                        for (j = 0; j < len * 2; j++)
                                        {
                                            string db1 = string.Format("{0,0:X}", DB[j]);
                                            str_temp = string.Format("{0,0:X}", temp[j]);
                                            str = str + str_temp;

                                        }
                                        stUsr = str;
                                        string id2 = HexStringToString(stUsr, System.Text.Encoding.UTF8);
                                        label4.Text = id2;
                                break;
                                }
                      
                    }
                 
                }

                if (res == _OK)
                {
                }
                else
                {
                    j++;
                    t = res * 1000 + j;
                    //SendMessage(epcDlg->m_hWnd,WM_READISO6C,101,t);
                    //Sleep(500);
                    Icon icon = new Icon("icoWait.ico", 32, 32);
                    pictureBox1.Image = icon.ToBitmap();

                    //label32.Text = "有多张卡存在，请放入一张卡";
                    label44.Text = string.Format("等待读卡，请放入卡::{0,0:d}", t);
                    Thread.Sleep(500);

                }

                str = textBox29.Text;
                j = 0;
                int.TryParse(str, out j);//字符串转数字
                if ((j <= 0) || (j > 60))
                {
                    j = 1;
                }
                for (i = 0; i < (int)j; i++)
                {
                   
                    label44.Text = string.Format("等待读卡，请放入卡::{0,0:d}{1,0:s}{2,0:d}", i / 1000, "-", i % 1000);
                    Thread.Sleep(100);

                }
            }

            return;
        }
        private void ThreadReaderEPC()
        {
            //int t;

            //int i = 0;
            //int j, nCounter = 0, ID_len = 0;//ID_len_temp=0;
            //string str, str_temp;
            //byte[] temp = new byte[512];
            //byte[] IDBuffer = new byte[30 * 256];
            //byte[] DB = new byte[128];
            //byte[] mask = new byte[512];
            //byte[] IDTemp = new byte[512];
            //int mem, ptr, len, EPC_Word;
            //byte[] AccessPassword = new byte[4];

            ////int nRow;


            //string stEpc = "";
            //string stTid = "";
            //string stUsr = "";
            //string stPass = "";

            //while (nStop)
            //{
               

            //    //stEpc = "";
            //    //stTid = "";
            //    //stUsr = "";
            //    //stPass = "";

            //    if (connect_OK == 0)
            //    {
            //        nStop = false;
            //        MessageBox.Show("读写器未连接!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //        break;
            //    }

            //    len = 0; ptr = 0; mem = 1; ID_len = 0; j = 0;   //nRow=0;
            //    for (i = 0; i < 512; i++) mask[i] = 0;

            //    for (i = 0; i < 3; i++)
            //    {
            //        Thread.Sleep(300);
            //        switch (ComMode)
            //        {
            //            case 0:
            //                break;
            //            case 1:
            //            case 3://usb,读EPC号
            //                res = Reader.EPC1G2_ReadLabelID(m_hScanner, mem, ptr, len, mask, IDBuffer, ref nCounter, RS485Address);
            //                break;
            //        }
            //        if (_OK == res)
            //        {
            //            break;
            //        }
            //    }

            //    if (res == _OK)
            //    {
            //        string stroutput = string.Format("EPC1G2_ReadLabelID:OK({0,0:d})\r\n", nCounter);
            //        Reader.VH_WriteAppLogFile("", 0, stroutput);

            //        str = "";
            //        ID_len = (int)IDBuffer[0];  //IDBuffer[0]为Word总数;1word=2Byte
            //        for (j = 0; j < ID_len * 2; j++) temp[j] = IDBuffer[j + 1];

            //        for (j = 0; j < ID_len * 2; j++)
            //        {
            //            str_temp = string.Format("{0,0:X02}", temp[j]);
            //            str = str + str_temp;
            //        }
            //        stEpc = str;







            //        string strTemp;
            //        string tmp;
            //        int nS;

            //        nS = listView3.Items.Count;
            //        for (i = 0; i < nS; i++)
            //        {
            //            strTemp = listView3.Items[i].SubItems[1].Text;
            //            if (stEpc == strTemp)
            //            {
            //                strTemp = "";
            //                break;
            //            }
            //        }
            //        if (i == nS)
            //        {
            //            //新增
            //            ListViewItem item = new ListViewItem();
            //            item = listView3.Items.Add((nS + 1).ToString(), (nS + 1).ToString());
            //            item.SubItems.Add(stEpc);


            //            //if (checkBox13.Checked)
            //            {
            //                item.SubItems.Add("");
            //            }
            //            //if (checkBox11.Checked)
            //            {
            //                item.SubItems.Add("");

            //            }
            //            //if (checkBox12.Checked)
            //            {
            //                item.SubItems.Add("");
            //            }
            //        }
            //        //else
            //        {
                        
            //        }


            //        tmp = stEpc;
            //        label46.Text = tmp;


            //        int ichFlag = 0;






            //    }
            //    else
            //    {
            //        j++;
            //        t = res * 1000 + j;
            //        //SendMessage(epcDlg->m_hWnd,WM_READISO6C,101,t);
            //        //Sleep(500);
            //        Icon icon = new Icon("icoWait.ico", 32, 32);
            //        pictureBox1.Image = icon.ToBitmap();

            //        //label32.Text = "有多张卡存在，请放入一张卡";
            //        label44.Text = string.Format("等待读卡，请放入卡::{0,0:d}", t);
            //        Thread.Sleep(500);

            //    }

            //    str = textBox29.Text;
            //    j = 0;
            //    int.TryParse(str, out j);//字符串转数字
            //    if ((j <= 0) || (j > 60))
            //    {
            //        j = 1;
            //    }
            //    //for(i=0;i<(int)epcDlg->m_Time;i++)
            //    for (i = 0; i < (int)j; i++)
            //    {
            //        //Sleep(1000);
            //        //Sleep(100);
            //        //SendMessage(epcDlg->m_hWnd,WM_READISO6C,2,i);

            //        //Icon icon = new Icon("icoWait.ico", 32, 32);
            //        //pictureBox1.Image = icon.ToBitmap();

            //        //label32.Text = "有多张卡存在，请放入一张卡";
            //        label44.Text = string.Format("等待读卡，请放入卡::{0,0:d}{1,0:s}{2,0:d}", i / 1000, "-", i % 1000);
            //        Thread.Sleep(100);

            //    }
            //}

            //return;
    }

        private void button3_Click(object sender, EventArgs e)
        {
           
                getdata("GA1");
            
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        public static string g_AppLogFileName;

        private void button22_Click(object sender, EventArgs e)
        {
            button22.Enabled = false;//停止按钮
            button21.Enabled = true;//开始按钮
            nStop = false;
            Thread.Sleep(800);
            teThreadEPC.Abort();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string str1 = "物资识别码:" + id;
            e.Graphics.DrawString(str1, new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 0, 40);
            string str2 = "物资描述:低压开关,断路器,250A,四相" + MAKTX;
            e.Graphics.DrawString(str2, new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 0, 50);
            e.Graphics.DrawString("仓位:C01", new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 0, 60);
            e.Graphics.DrawString("批次:1404B03161", new Font("Arial", 5, FontStyle.Bold), Brushes.Black, 0, 70);
        }

        //unsafe public Reader.VH_fDechUsb fCallbackFunc = null;
        public Reader.VH_fDechUsb fCallbackFunc = null;
        public Frchuku()
        {
            InitializeComponent();

            //取当前年月日
            DateTime CurrentTime = System.DateTime.Now;
            g_AppLogFileName = System.Environment.CurrentDirectory;
            g_AppLogFileName += LOGDIR;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(g_AppLogFileName);
            di.Create();

            //DllComm.g_AppLogFileName += "\\20110414.log";
            //DllComm.g_AppLogFileName += "\\";
            g_AppLogFileName += CurrentTime.ToString("yyyyMMdd") + LOGEXT;
            Reader.VH_SetLogFile(g_AppLogFileName);

            fCallbackFunc = VH_fDechUsb;
            Reader.VH_InitUsb(fCallbackFunc);




            //{
            //      new Reader.tagReaderFreq {},new Reader.tagReaderFreq {}
            //{"00---FCC(American))", 63, 400, 902600},							//(0),{"00---FCC(American)", 50, 500, 902750},
            //{"01---ETSI EN 300-220(Europe300-220)", 11, 200, 865500},			//(1),{"01---ETSI EN 300-220(Europe300-220)", -1, -1, -1},
            //{"02---ETSI EN 302-208(Europe302-208)", 4, 600, 865700},			//(2)
            //{"03---HK920-925(Hong Kong)", 10, 500, 920250},						//(3)
            //{"04---TaiWan 922-928(Taiwan)", 12, 500, 922250},					//(4)
            //{"05---Japan 952-954(Japan)", 0, 0, 0},								//(5)
            //{"06---Japan 952-955(Japan)", 14,200, 952200},						//(6)
            //{"07---ETSI EN 302-208(Europe)", 4, 600, 865700},					//(7)
            //{"08---Korea 917-921(Korea)", 6, 600, 917300},						//(8)
            //{"09---Malaysia 919-923(Malaysia)", 8, 500, 919250},				//(9)
            //{"10--China 920-925(China)", 16, 250, 920625},						//(10)
            //{"11--Japan 952-956(Japan)", 4, 1200, 952400},						//(11)
            //{"12--South Africa 915-919(Poncho)", 17, 200, 915600},				//(12)
            //{"13--Brazil 902-907/915-928(Brazil)", 35, 500, 902750},			//(13)
            //{"14--Thailand 920-925(Thailand)", -1, -1, -1},						//(14)
            //{"15--Singapore 920-925(Singapore)", 10, 500, 920250},				//(15)
            //{"16--Australia 920-926(Australia)", 12, 500, 920250},				//(16)
            //{"17--India 865-867(India)", 4, 600, 865100},						//(17)
            //{"18--Uruguay 916-928(Uruguay)", 23, 500, 916250},					//(18)
            //{"19--Vietnam 920-925(Vietnam)", 10, 500, 920250},					//(19)
            //{"20--Israel 915-917", 1, 0, 916250},								//(20)
            //{"21--Philippines 918-920(Philippines)", 4, 500, 918250},			//(21)
            //{"22--Canada 902-928(Canada)", 42, 500, 902750},					//(22)
            //{"23--Indonesia 923-925(Indonesia)", 4, 500, 923250},				//(23)
            //{"24--New Zealand 921.5-928(New Zealand)", 11, 500, 922250},		//(24)
            //};

            stuctFreqCountry[0].chFreq = "00---FCC(American))";                     //国家频率字符串
            stuctFreqCountry[0].iGrade = 63;                                        //级数
            stuctFreqCountry[0].iSkip = 400;                                       //步进
            stuctFreqCountry[0].dwFreq = 902600;                                    //起始频率

            stuctFreqCountry[1].chFreq = "01---ETSI EN 300-220(Europe300-220)";                     //国家频率字符串
            stuctFreqCountry[1].iGrade = 11;                                        //级数
            stuctFreqCountry[1].iSkip = 200;                                       //步进
            stuctFreqCountry[1].dwFreq = 865500;                                    //起始频率

            stuctFreqCountry[2].chFreq = "02---ETSI EN 302-208(Europe302-208)";                     //国家频率字符串
            stuctFreqCountry[2].iGrade = 4;                                        //级数
            stuctFreqCountry[2].iSkip = 600;                                       //步进
            stuctFreqCountry[2].dwFreq = 865700;                                    //起始频率

            stuctFreqCountry[3].chFreq = "03---HK920-925(Hong Kong)";                     //国家频率字符串
            stuctFreqCountry[3].iGrade = 10;                                        //级数
            stuctFreqCountry[3].iSkip = 500;                                       //步进
            stuctFreqCountry[3].dwFreq = 920250;                                    //起始频率

            stuctFreqCountry[4].chFreq = "04---TaiWan 922-928(Taiwan)";                     //国家频率字符串
            stuctFreqCountry[4].iGrade = 12;                                        //级数
            stuctFreqCountry[4].iSkip = 500;                                       //步进
            stuctFreqCountry[4].dwFreq = 922250;                                    //起始频率

            stuctFreqCountry[5].chFreq = "05---Japan 952-954(Japan)";                     //国家频率字符串
            stuctFreqCountry[5].iGrade = 0;                                        //级数
            stuctFreqCountry[5].iSkip = 0;                                       //步进
            stuctFreqCountry[5].dwFreq = 0;                                    //起始频率

            stuctFreqCountry[6].chFreq = "06---Japan 952-955(Japan)";                     //国家频率字符串
            stuctFreqCountry[6].iGrade = 14;                                        //级数
            stuctFreqCountry[6].iSkip = 200;                                       //步进
            stuctFreqCountry[6].dwFreq = 952200;                                    //起始频率

            stuctFreqCountry[7].chFreq = "07---ETSI EN 302-208(Europe)";                     //国家频率字符串
            stuctFreqCountry[7].iGrade = 4;                                        //级数
            stuctFreqCountry[7].iSkip = 600;                                       //步进
            stuctFreqCountry[7].dwFreq = 865700;                                    //起始频率

            stuctFreqCountry[8].chFreq = "08---Korea 917-921(Korea)";                     //国家频率字符串
            stuctFreqCountry[8].iGrade = 6;                                        //级数
            stuctFreqCountry[8].iSkip = 600;                                       //步进
            stuctFreqCountry[8].dwFreq = 917300;                                    //起始频率

            stuctFreqCountry[9].chFreq = "09---Malaysia 919-923(Malaysia)";                     //国家频率字符串
            stuctFreqCountry[9].iGrade = 8;                                        //级数
            stuctFreqCountry[9].iSkip = 500;                                       //步进
            stuctFreqCountry[9].dwFreq = 919250;                                    //起始频率

            stuctFreqCountry[10].chFreq = "10--China 920-925(China)";                     //国家频率字符串
            stuctFreqCountry[10].iGrade = 16;                                        //级数
            stuctFreqCountry[10].iSkip = 250;                                       //步进
            stuctFreqCountry[10].dwFreq = 920625;                                    //起始频率

            stuctFreqCountry[11].chFreq = "11--Japan 952-956(Japan)";                     //国家频率字符串
            stuctFreqCountry[11].iGrade = 4;                                        //级数
            stuctFreqCountry[11].iSkip = 1200;                                       //步进
            stuctFreqCountry[11].dwFreq = 952400;                                    //起始频率

            stuctFreqCountry[12].chFreq = "12--South Africa 915-919(Poncho)";                     //国家频率字符串
            stuctFreqCountry[12].iGrade = 17;                                        //级数
            stuctFreqCountry[12].iSkip = 200;                                       //步进
            stuctFreqCountry[12].dwFreq = 915600;                                    //起始频率

            stuctFreqCountry[13].chFreq = "13--Brazil 902-907/915-928(Brazil)";                     //国家频率字符串
            stuctFreqCountry[13].iGrade = 35;                                        //级数
            stuctFreqCountry[13].iSkip = 500;                                       //步进
            stuctFreqCountry[13].dwFreq = 902750;                                    //起始频率

            stuctFreqCountry[14].chFreq = "14--Thailand 920-925(Thailand)";                     //国家频率字符串
            stuctFreqCountry[14].iGrade = -1;                                        //级数
            stuctFreqCountry[14].iSkip = -1;                                       //步进
            stuctFreqCountry[14].dwFreq = -1;                                    //起始频率

            stuctFreqCountry[15].chFreq = "15--Singapore 920-925(Singapore)";                     //国家频率字符串
            stuctFreqCountry[15].iGrade = 10;                                        //级数
            stuctFreqCountry[15].iSkip = 500;                                       //步进
            stuctFreqCountry[15].dwFreq = 920250;                                    //起始频率

            stuctFreqCountry[16].chFreq = "16--Australia 920-926(Australia)";                     //国家频率字符串
            stuctFreqCountry[16].iGrade = 12;                                        //级数
            stuctFreqCountry[16].iSkip = 500;                                       //步进
            stuctFreqCountry[16].dwFreq = 920250;                                    //起始频率

            stuctFreqCountry[17].chFreq = "17--India 865-867(India)";                     //国家频率字符串
            stuctFreqCountry[17].iGrade = 4;                                        //级数
            stuctFreqCountry[17].iSkip = 600;                                       //步进
            stuctFreqCountry[17].dwFreq = 865100;                                    //起始频率

            stuctFreqCountry[18].chFreq = "18--Uruguay 916-928(Uruguay)";                     //国家频率字符串
            stuctFreqCountry[18].iGrade = 23;                                        //级数
            stuctFreqCountry[18].iSkip = 500;                                       //步进
            stuctFreqCountry[18].dwFreq = 916250;                                    //起始频率

            stuctFreqCountry[19].chFreq = "19--Vietnam 920-925(Vietnam)";                     //国家频率字符串
            stuctFreqCountry[19].iGrade = 10;                                        //级数
            stuctFreqCountry[19].iSkip = 500;                                       //步进
            stuctFreqCountry[19].dwFreq = 920250;                                    //起始频率

            stuctFreqCountry[20].chFreq = "20--Israel 915-917";                     //国家频率字符串
            stuctFreqCountry[20].iGrade = 1;                                        //级数
            stuctFreqCountry[20].iSkip = 0;                                       //步进
            stuctFreqCountry[20].dwFreq = 916250;                                    //起始频率

            stuctFreqCountry[21].chFreq = "21--Philippines 918-920(Philippines)";                     //国家频率字符串
            stuctFreqCountry[21].iGrade = 4;                                        //级数
            stuctFreqCountry[21].iSkip = 500;                                       //步进
            stuctFreqCountry[21].dwFreq = 918250;                                    //起始频率

            stuctFreqCountry[22].chFreq = "22--Canada 902-928(Canada)";                     //国家频率字符串
            stuctFreqCountry[22].iGrade = 42;                                        //级数
            stuctFreqCountry[22].iSkip = 500;                                       //步进
            stuctFreqCountry[22].dwFreq = 902750;                                    //起始频率

            stuctFreqCountry[23].chFreq = "23--Indonesia 923-925(Indonesia)";                     //国家频率字符串
            stuctFreqCountry[23].iGrade = 4;                                        //级数
            stuctFreqCountry[23].iSkip = 500;                                       //步进
            stuctFreqCountry[23].dwFreq = 923250;                                    //起始频率

            stuctFreqCountry[24].chFreq = "24--New Zealand 921.5-928(New Zealand)";                     //国家频率字符串
            stuctFreqCountry[24].iGrade = 11;                                        //级数
            stuctFreqCountry[24].iSkip = 500;                                       //步进
            stuctFreqCountry[24].dwFreq = 922250;
        }
        public int VH_fDechUsb(bool bDech)
        {
            if (bDech)
            {
                MessageBox.Show("在线!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("不在线!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return 0;
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //连接读写器
            int i = 0;
            ComMode = 0;
            if (radioButton1.Checked == true)
            {
                ComMode = 1;//RS232
            }
            if (radioButton2.Checked == true)
            {
                ComMode = 3;//USB
            }

            //COM口
            szPort = comboBox1.Text;

            switch (ComMode)
            {
                case 1:
                    res = Reader.ConnectScanner(ref m_hScanner, szPort, 0);
                    break;
                case 3:
                    res = Reader.VH_ConnectScannerUsb(ref m_hScanner);
                    break;

            }

            if (_OK == res)
            {
                for (i = 0; i < 3; i++)
                {
                    //读版本
                    res = Reader.VH_GetVersion(m_hScanner, ref HardVersion, ref SoftVersion);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(VH_GetVersion)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //读基本参数
                    res = Reader.ReadBasicParam(m_hScanner, ref gBasicParam);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(ReadBasicParam)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //国家频率
                    res = Reader.GetFrequencyRange(m_hScanner, ref gFre);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(GetFrequencyRange)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //读auto参数
                    res = Reader.ReadAutoParam(m_hScanner, ref gAutoParam);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(ReadAutoParam)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                for (i = 0; i < 3; i++)
                {
                    //读ID
                    res = Reader.GetReaderID(m_hScanner, gReaderID);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(GetReaderID)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }



                for (i = 0; i < 3; i++)
                {
                    byte[] pPParam = new byte[26];
                    //读仿真参数
                    //res = Reader.ReadSimParam(m_hScanner, pPParam);
                    res = Reader.ReadSimParam(m_hScanner, ref Param);
                    if (_OK == res)
                    {
                        break;
                    }
                }
                if (res != _OK)
                {
                    MessageBox.Show("Connect Reader Fail!(ReadSimParam)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                //弹出提示成功
                connect_OK = 1;//0--no connect, 1--connected

             
                MessageBox.Show("Connect reader success!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
             
                MessageBox.Show("Connect Reader Fail!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Frchuku_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            //==第一页==========连接页面开始============================
            radioButton1.Checked = false;//RS232
            radioButton2.Checked = true;//USB
            getdata("GA1");
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }
        public void getdata(string cangkubiaohao)
        {
            util util = new util();
            DataTable dt = new DataTable();
            dt = util.getdata(cangkubiaohao);
            this.gridControl1.DataSource = dt;

           
            gridControl1.DataSource = dt;
        }
        public void senddata(string LGNUM,string MAKBH,string RFIDNO,string CHARG,string BQ,string PT,string BT)
        {
            util util = new util();
            util.senddata(LGNUM, MAKBH, RFIDNO, CHARG, BQ, PT, BT);
        }
    }
}