using System;
using System.Collections.Generic;
using System.Text;
using Test_Core.Application;
using System.IO;
using System.Diagnostics;

namespace Test_Core.Repositories
{
    public class FileAccess:IFileAccess
    {
        string path = @"C:\Users\dermeister\source\repos\LeerProjekte\UWP\Full_architecture_UWP_Autofac";

        public string CreateFileTest()
        {

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Debug.WriteLine(s);
                    }
                }
                return "success";
            }

            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
