using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trafix.Client.Downloader;

namespace DifferenceChecker.Helper
{
    public class Processor
    {
        List<string> extensionsToDownload = new List<string>();
        List<string> executableFilesToCopy = new List<string>();

        public void SettingDefaultExtensions(List<string> exList)
        {
            extensionsToDownload = new List<string>();
            extensionsToDownload.AddRange(exList);
        }

        public void ExecutableFilesToCopy(string exeCheckBox)
        {
            executableFilesToCopy = new List<string>();
            executableFilesToCopy.Add(exeCheckBox);
        }

        public bool ProcessDirectory(string targetDirectory, string targetFile, bool isOverwrite)
        {
            bool result = false;
            List<string> fileEntries = new List<string>();

            try
            {
                string[] allFiles = Directory.GetFiles(targetDirectory, "*.exe");

                //other extensions right now default (.DLL)
                foreach (string extension in extensionsToDownload)
                {
                    string[] fileEx = Directory.GetFiles(targetDirectory, extension);
                    fileEntries.AddRange(fileEx);
                }
                //executable extensions(.exe)
                foreach (string item in allFiles)
                {
                    string _filename = System.IO.Path.GetFileName(item);
                    if (executableFilesToCopy.Contains(_filename))
                    {
                        List<string> abclist = allFiles.Where(x => x.Contains(item)).ToList();
                        fileEntries.AddRange(abclist);
                    }
                }
                //uploading files
                foreach (string fileName in fileEntries)
                {
                    string _filename = System.IO.Path.GetFileName(fileName);

                    if (isOverwrite == true)
                    {
                        if (File.Exists(targetFile + "\\" + _filename))
                        {
                            File.Delete(targetFile + "\\" + _filename);
                        }
                    }
                    int a = Downloader(fileName, targetFile + "\\" + _filename);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                
            }            
            return result;
        }

        public void ProcessFile(string sourceFile, string targetFile)
        {
            // This path is a file
            string _filename = System.IO.Path.GetFileName(sourceFile);
            int a = Downloader(sourceFile, targetFile + _filename);
        }

        private int Downloader(string sourcePath, string targetPath)
        {
            int result = 1;
            try
            {
                NetworkCredential GetCredential = new NetworkCredential();
                Settings settings = new Settings(ENServerType.FTP, GetCredential, ENConfigFlags.None);
                var fileDownloader = FileDownloader.Create(settings);
                Uri uri = new Uri(sourcePath);
                fileDownloader.AddFile(uri, targetPath);
                fileDownloader.Download();
            }
            catch (Exception ex)
            {
                result = 0;
            }

            return result;
        }
    }
}
