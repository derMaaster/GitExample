using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.WindowManagement;
using Windows.Web.Syndication;

namespace Full_Arch_UWP_Autofac.Helpers
{
    //https://docs.microsoft.com/en-us/windows/uwp/files/quickstart-reading-and-writing-files

    public class UWPStorageFolder
    {

        public StorageFolder GetAppStorageFolder()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            return localFolder;
        }

        public async Task<string> CreateFileInStorageFolder()
        {
            StorageFolder storageFolder = GetAppStorageFolder();
            StorageFile sampleFile;
            try
            {
                sampleFile = await storageFolder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);
                return "Succcess, file 'sample.txt' created at " + storageFolder.ToString();
            }
            catch(Exception ex){return "Failed: " + ex;}
            
        }
        public async Task<string> WriteToFile()
        {
            StorageFolder storageFolder = GetAppStorageFolder();
            StorageFile sampleFile;

            // first get the file:
            try
            {
                sampleFile = await storageFolder.GetFileAsync("sample.txt");
            }
            catch(Exception ex) { return "failed to get file sample.txt" + ex; }

            // write to the file:
            try 
            {
                await FileIO.WriteTextAsync(sampleFile, "hos, het geskryf");
                return "success writing to file";
            }
            catch(Exception ex) { return "Failed to write to file " + ex; }
            
        }

        // ......
    }
}
