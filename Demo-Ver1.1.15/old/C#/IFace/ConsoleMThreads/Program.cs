/**********************************************************
 * Demo for Standalone SDK.Created by Darcy on Dec.15 2009*
***********************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using zkemkeeper;
using System.Data.OleDb;

namespace ConsoleMThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            int iWorkCount = 254;//the ultimate count of devices in LAN
            WorkThread[] Device=new WorkThread[iWorkCount];
            bool bSetMaxThread = ThreadPool.SetMaxThreads(iWorkCount, 500);
            if (!bSetMaxThread)
            {
                Console.WriteLine("Setting max threads of the threadpool failed!");
            }
            for (int i = 173; i < iWorkCount; i++)
            {
                Device[i] = new WorkThread("192.168.0." + ((int)(1 + i)).ToString(), 4370);//You can custom the LAN Segment.
                ThreadPool.QueueUserWorkItem(Device[i].ThreadPoolCallBack);//Put the method into the queue to implement.
            }
            Console.WriteLine("Pls Wait for a moment......Current Time:" + DateTime.Now.ToLongTimeString());

            //Wait for keyboard input before exiting the program. In order to see the debugging output. If there is no this sentence, the command window will flash by.
            Console.ReadKey();

        }
    }

    //class of work thread
    class WorkThread
    {
        string sIP = "0.0.0.0";
        int iPort = 4370;
        int iMachineNumber = 1;
        int iThreadID = 0;
        int iLastTry = 0;//the former trying time(in mimutes) 
        int iDelay=2;//to control the times connecting device 
        private static int iCounter = 0;
        private static int iConnectedCount = 0;

        public zkemkeeper.CZKEMClass sdk = new CZKEMClass();//create Standalone SDK class dynamicly
        private static Object myObject = new Object();//create a new Object for the database operation

        //work thread
        public WorkThread(string swIP, int iwPort)
        {
            sIP = swIP;
            iPort = iwPort;
            iThreadID = ++iCounter;
        }

        //call back function of threadpool
        public void ThreadPoolCallBack(Object oThreadContext)
        {
            int iCurrentTime = 0;
            iLastTry = GetTimeInMinute();
            while (true)
            {
                iCurrentTime = GetTimeInMinute();
                //sleep until the minute ticks
                while (iLastTry == iCurrentTime)
                {
                    Thread.Sleep(30);
                    iCurrentTime = GetTimeInMinute();
                }
                iLastTry = iCurrentTime;
                iDelay--;
                if (iDelay==1)
                {
                    this.WakeUp();
                }
            }
        }

        public void WakeUp()
        {
            bool bResult = sdk.Connect_Net(sIP, iPort);

            if (!bResult)//Connecting device failed.
            {
                Console.WriteLine("*********Connecting " + sIP + " Failed......Current Time:" + DateTime.Now.ToLongTimeString());
                return;
            }
            iConnectedCount++;//count of connected devices

            System.Console.WriteLine("*********IP:" + sIP + " " + "ThreadID:" + iThreadID.ToString() + " ConnectedCount:" + iConnectedCount.ToString() + " ConnectedTime:" + DateTime.Now.ToLongTimeString());
            System.Console.WriteLine("*********Successfully Connect " + sIP);
            int iLogCount = 0;
            int idwErrorCode = 0;

            sdk.EnableDevice(iMachineNumber, false);//disable the device
            if (sdk.ReadAllGLogData(iMachineNumber))
            {
                string sdwEnrollNumber = "";
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkCode = 0;

                String connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\data\AttLogs.mdb";

                while(sdk.SSR_GetGeneralLogData(iMachineNumber,out sdwEnrollNumber,out idwVerifyMode,out idwInOutMode,out idwYear,out idwMonth,out idwDay,out idwHour,out idwMinute,out idwSecond,ref idwWorkCode))
                {
                    iLogCount++;//increase the number of attendance records
                    
                    lock (myObject)//make the object exclusive 
                    {
                        OleDbConnection conn = new OleDbConnection(connString);
                        string sTime = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString()+":"+idwSecond.ToString();
                        string sql = "insert into TFTAttLogs([IP],[EnrollNumber],[VerifyMode],[InOutMode],[Time],[WorkCode]) values('" + sIP + "','" + sdwEnrollNumber + "','" + idwVerifyMode + "','" + idwInOutMode + "','" + sTime + "','"+idwWorkCode.ToString()+"')";//
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        conn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch(Exception e)
                        {
                            System.Console.WriteLine("Error:"+e.Message);
                            break;
                        }
                        System.Console.WriteLine("ThreadID:" + iThreadID.ToString() + " IP:" + sIP + "," + iLogCount.ToString() + " Log(s) has(have) been inserted into database.");
                    }
                }
            }
            else
            {
                sdk.GetLastError(ref idwErrorCode);
                System.Console.WriteLine("ThreadID:" + iThreadID.ToString() + " General Log Data Count:0 ErrorCode=" + idwErrorCode.ToString());
            }
            sdk.EnableDevice(iMachineNumber, true);//enable the device
            sdk.Disconnect();
            System.Console.WriteLine("*********Successfully DisConnect " + sIP);
        }

        private int GetTimeInMinute()//return the time in mimutes
        {
            return((DateTime.Now.Hour*24)+DateTime.Now.Minute);
        }

    }
}
