using System;
using System.Collections.Generic;
using System.IO;

namespace Test_Core.Repositories
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }

    public class FileLogger : LogBase
    {
        public string filePath = @"D:\IDGLog.txt";
        public override void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }



}
