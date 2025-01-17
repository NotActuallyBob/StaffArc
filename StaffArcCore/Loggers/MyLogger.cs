using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffArcCore.Loggers
{
    public class MyLogger
    {
        private string filePath;

        public MyLogger(string fileName)
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
            Initialize();
        }

        private void Initialize()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath).Close();
        }

        private string GetTimeString()
        {
            DateTime now = DateTime.Now;
            string timeString = now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second.ToString() + " ";
            return timeString;
        }

        public void Log(string message)
        {
            File.AppendAllText(filePath, GetTimeString() + message + "\n");
        }

        public void Error(string message)
        {
            File.AppendAllText(filePath, GetTimeString() + "ERROR: " + message + "\n");
        }

        public void Warning(string message)
        {
            File.AppendAllText(filePath, GetTimeString() + "Warning: " + message + "\n");
        }
    }
}
