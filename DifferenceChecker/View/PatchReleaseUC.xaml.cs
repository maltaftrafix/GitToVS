using Trafix.Client.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using Trafix.ConfigCommon;
using DifferenceChecker.Helper;
using System.Configuration;
using Trafix.CLRCommon;
using static DifferenceChecker.Helper.SendAppMsg;
using Trafix.Client.Communication;
using Trafix.Client.Data;
using Trafix.CLRServerProxy;
using System.Threading.Tasks;
using System.Net.Http;
using Octokit;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Web.Script.Serialization;
using DifferenceChecker.BO;

namespace DifferenceChecker.View
{
    public partial class PatchReleaseUC : SKUserControl
    {
        Processor processor = new Processor();
        string basePath = System.Configuration.ConfigurationManager.AppSettings.Get("basePath");

        string dirDEMO = System.Configuration.ConfigurationManager.AppSettings.Get("dirDemo");
        string dirQA = System.Configuration.ConfigurationManager.AppSettings.Get("dirQA");
        string dirUAT = System.Configuration.ConfigurationManager.AppSettings.Get("dirUAT");
        string dirProduction = System.Configuration.ConfigurationManager.AppSettings.Get("dirProduction");
        string QASettingsXML = "QAsettings.xml";
        string UATSettingsXML = "UATsettings.xml";
        string ProdSettingsXML = "Prodsettings.xml";
        string DemoSettingsXML = "Demosettings.xml";


        CommunicationManager m_communicationMgr = new CommunicationManager();
        string appTypeSelected = "";

        public PatchReleaseUC()
        {
            InitializeComponent();


            Console.ReadLine();

            urlPath1.Text = basePath;
            workingDirectory.Text = System.Configuration.ConfigurationManager.AppSettings.Get("WorkingDir");
            additionalParams.Text = System.Configuration.ConfigurationManager.AppSettings.Get("AdditionalArgs");

            if (!string.IsNullOrEmpty(basePath))
            {
                baseDirectory.ItemsSource = Enum.GetValues(typeof(ENAppType)).Cast<ENAppType>();
            }
        }


      


        public static void ExecuteAsync()
        {
            try
            {
                string ownerName = "maltaftrafix";
                string myRepoName = "GitToVS";                
                var client = new GitHubClient(new ProductHeaderValue("GitToVS"));                
                var getAllRepoRequest = client.Repository.Release.GetAll(ownerName, myRepoName);

                var getAllCommitsRequest = client.Repository.Commit.GetAll(ownerName, myRepoName);



                //List of releases
                List<CommitBO.RootObject> commitBOList = new List<CommitBO.RootObject>();
                

                for (int i = 0; i < getAllCommitsRequest.Result.Count(); i++)
                {
                    string commit_JsonData = JsonConvert.SerializeObject(getAllCommitsRequest.Result[i]);
                    CommitBO.RootObject commitBO = JsonConvert.DeserializeObject<CommitBO.RootObject>(commit_JsonData);
                    commitBOList.Add(commitBO);
                }


                //List of releases
                List<GitReleaseBO> releaseBOList = new List<GitReleaseBO>();

                for (int i = 0; i < getAllRepoRequest.Result.Count(); i++)
                {                    
                    string jsonData = JsonConvert.SerializeObject(getAllRepoRequest.Result[i]);                    
                    GitReleaseBO gitReleaseBO = JsonConvert.DeserializeObject<GitReleaseBO>(jsonData);
                    releaseBOList.Add(gitReleaseBO);
                }


                //var abcd = releaseBOList.OrderBy(x => x.TagName).ToList();


                Console.WriteLine("end");

            }
            catch (Exception ex)
            {

            }


            // var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            // var user = await github.User.Get("half-ogre");
            //string __Message = (user.Followers + " folks love the half ogre!");


            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://api.github.com");
            //var token = "<token>";

            //client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

            //var response = await client.GetAsync("/user");
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            ExecuteAsync();
            Dictionary<string, string> defaultPaths = new Dictionary<string, string>();
            bool isOverwrite = chkboxOverwrite.IsChecked == true ? true : false;
            if (chkboxQA.IsChecked == true)
            {
                defaultPaths.Add(dirQA, QASettingsXML);
            }
            if (chkboxUAT.IsChecked == true)
            {
                defaultPaths.Add(dirUAT, UATSettingsXML);
            }
            if (chkboxLIVE.IsChecked == true)
            {
                ProdSettingsXML = QASettingsXML;
                defaultPaths.Add(dirProduction, ProdSettingsXML);
            }
            if (chkboxDemo.IsChecked == true)
            {
                DemoSettingsXML = QASettingsXML;
                defaultPaths.Add(dirDEMO, DemoSettingsXML);
            }
            int chkboxCheckedCounts = 0;
            foreach (SKCheckBox sKCheckBox in customChkBox.Children)
            {
                if (sKCheckBox.IsChecked == true)
                {
                    chkboxCheckedCounts++;
                    processor.ExecutableFilesToCopy(sKCheckBox.Name + ".exe");
                }
            }

            if (customChkBox.Children.Count > 0 && chkboxCheckedCounts == 0)
            {
                StatusMessageSync("Please mark atleast 1 Executable Checkbox. \r\n");
                return;
            }


            statusBox.Document.Blocks.Clear();
            string sourceFile = "";
            if (releaseDirectory.EditValue == null)
            {
                StatusMessageSync("Please select version to upload. \r\n");
                return;
            }
            else
            {
                sourceFile = releaseDirectory.EditValue.ToString();// .SelectedText.ToString();
            }

            StatusMessageSync("Selected source directory " + sourceFile + "\r\n");
            StatusMessageSync("LOADING..........");

            List<string> extensionsToDownload = new List<string>();
            //extensionsToDownload.Add("*.exe");
            extensionsToDownload.Add("*.dll");
            processor.SettingDefaultExtensions(extensionsToDownload);


            if (defaultPaths.Count() == 0)
            {
                StatusMessageSync("Please atleast one target (Demo,QA,UAT or Production). \r\n");
                return;
            }



            foreach (KeyValuePair<string, string> targetPath in defaultPaths)
            {
                try
                {

                    string targetFile = targetPath.Key;
                    if (File.Exists(sourceFile))
                    {
                        processor.ProcessFile(sourceFile, targetFile);
                        //Trafix.Client.Controls.SKMessageBox.Show("File Successfully Transfered to target " + targetPath.ToString(), "Success", ENMessageBoxType.General);
                        StatusMessageSync("File Successfully Transfered to target " + targetPath.Key.ToString());
                    }
                    else if (Directory.Exists(sourceFile))
                    {

                        string s_filename = System.IO.Path.GetFileName(sourceFile);
                        string t_filename = System.IO.Path.GetFileName(targetFile);
                        string updated_target = "";
                        if (s_filename != t_filename)
                        {
                            updated_target = targetFile + "\\" + s_filename;
                        }
                        else
                        {
                            updated_target = targetFile;
                        }
                        if (!Directory.Exists(updated_target))
                        {
                            Directory.CreateDirectory(updated_target);
                        }
                        bool uploadResponse = processor.ProcessDirectory(sourceFile, updated_target, isOverwrite);
                        if (uploadResponse)
                        {
                            StatusMessageSync("Successfully Transfered to target " + targetFile);
                            bool msgSendResponse = SendAppMsg(targetPath.Key, sourceFile, targetPath.Value);
                            if (msgSendResponse)
                            {
                                StatusMessageSync("Successfully created executable with exe path :" + targetFile);
                            }
                            else
                            {
                                StatusMessageSync("Something went wrong while created executable with exe path :" + targetFile);
                            }
                        }
                        else
                        {
                            StatusMessageSync("Something went wrong while transfering to target " + targetFile);
                        }
                    }
                    else
                    {
                        //Trafix.Client.Controls.SKMessageBox.Show("!Wrong Selection of source " + sourceFile.ToString(), "Failed", ENMessageBoxType.General);
                        StatusMessageSync("!Wrong Selection of source " + sourceFile.ToString());
                    }
                }
                catch (Exception ex)
                {
                    //Trafix.Client.Controls.SKMessageBox.Show(ex.Message.ToString(), "Failed", ENMessageBoxType.General);
                    StatusMessageSync(ex.Message.ToString());
                }
            }


        }

        private void StatusMessageSync(string msg)
        {
            statusBox.AppendText("[" + DateTime.Now + "]" + " " + msg + Environment.NewLine);
        }

        private void BaseDirectory_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {

            string key = e.NewValue.ToString();
            appTypeSelected = key;
            string path = System.Configuration.ConfigurationManager.AppSettings.Get(key);
            //OMS 64
            if (Directory.Exists(path))
            {
                Dictionary<string, string> releaseDic = new Dictionary<string, string>();

                string[] subdirectoryEntries = Directory.GetDirectories(path);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    string _fileName = System.IO.Path.GetFileName(subdirectory);
                    releaseDic.Add(_fileName, subdirectory);
                }
                releaseDirectory.DisplayMember = "Key";
                releaseDirectory.ValueMember = "Value";
                releaseDirectory.ItemsSource = releaseDic;
                releaseDirectory.ItemsSource = releaseDic.OrderByDescending(x => x.Key);
            }
            else
            {
                Dictionary<string, string> releaseDic = new Dictionary<string, string>();
                releaseDirectory.DisplayMember = "Key";
                releaseDirectory.ValueMember = "Value";
                releaseDirectory.ItemsSource = releaseDic;
            }

        }

        private void DynamicExeCheckboxes(string chkBoxName, bool ischecked)
        {
            try
            {
                SKCheckBox traFixchkbox = new SKCheckBox();
                traFixchkbox.Content = chkBoxName + "  ";
                traFixchkbox.Name = chkBoxName;
                traFixchkbox.IsChecked = ischecked;

                customChkBox.Children.Add(traFixchkbox);
            }
            catch (Exception ex)
            {
                StatusMessageSync(ex.Message);
            }

        }

        public bool SendAppMsg(string targetPath, string sourceFile, string settingsXML)
        {
            ENSubMsgType enSubMsgType = ENSubMsgType.CONFIG_ADD;
            AppInfo app = new AppInfo();
            app.AppId = appTypeSelected + "_" + System.IO.Path.GetFileName(sourceFile);
            Enum.TryParse(appTypeSelected, out ENAppType myStatus);
            app.AppType = myStatus;

            string exePath = targetPath + "\\" + System.IO.Path.GetFileName(sourceFile);
            string[] files = System.IO.Directory.GetFiles(exePath, "*.exe");
            if (files.Count() > 0)
            {
                string fileName = System.IO.Path.GetFileName(files.First());
                app.ExecutablePath = appTypeSelected + "\\" + fileName;
            }
            else
            {
                app.ExecutablePath = appTypeSelected + "\\" + System.IO.Path.GetFileName(sourceFile);
            }




            LoginInfo loginInfo = new LoginInfo();
            LoginReply objLoginReply = null;
            loginInfo.UserName = "admin1";
            loginInfo.Password = "a";
            loginInfo.Topic = "";

            ProxySettings settings = new ProxySettings();
            m_communicationMgr = new CommunicationManager();
            m_communicationMgr.Init(null, ENAppType.ADMIN, ENClientType.API, settingsXML, null);
            m_communicationMgr.Authenticate(loginInfo, out objLoginReply);

            if (objLoginReply != null && objLoginReply.ErrorCode != 0 && !objLoginReply.Success)
            {
                return false;
            }

            Message msg = new Message();
            msg.SetMessageType((uint)ENMsgType.CONFIG_APP);
            msg.SetField((uint)ENConfigField.SUB_MSG_TYPE, (int)enSubMsgType);

            msg.SetField((uint)ENConfigField.APP_ID, app.AppId);
            msg.SetField((uint)ENConfigField.APP_TYPE, (int)app.AppType);
            msg.SetField((uint)ENConfigField.EXECUTABLE_PATH, app.ExecutablePath);
            //msg.SetField((uint)ENConfigField.WORKING_DIR, app.WorkingDir);
            //msg.SetField((uint)ENConfigField.ADDITIONAL_PARAMS, app.AdditionalParams);
            msg.SetField((uint)ENConfigField.DESCRIPTION, app.Description);


            msg.SetField((uint)ENConfigField.ADDITIONAL_PARAMS, additionalParams.Text);
            msg.SetField((uint)ENConfigField.WORKING_DIR, workingDirectory.Text);

            Message replyMsg = null;
            int result = m_communicationMgr.RequestSync(ENAppType.CONFIG, "", msg, out replyMsg);
            m_communicationMgr.Dispose();
            return ProcessConfigReply(replyMsg);
        }

        bool ProcessConfigReply(Message replyMsg)
        {
            if (replyMsg == null)
            {
                //SKMessageBox.Show("Unable to send request to server", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                StatusMessageSync("AdminClient Error, Unable to send request to server. Error!");
                return false;
            }

            if (replyMsg.GetMessageType() == (uint)ENMsgType.ERROR_)
            {
                int errorCode = replyMsg.GetField<int>((uint)ENConfigField.ERROR_CODE);
                string stErrorMsg = string.Empty;
                replyMsg.GetField((uint)ENConfigField.ERROR_TEXT, out stErrorMsg);
                //SKMessageBox.Show(string.Format("Server error {0}: {1}", errorCode, stErrorMsg), "Request Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                StatusMessageSync(string.Format("AdminClient Error, ErrorMsg: " + stErrorMsg));

                return false;
            }
            replyMsg.Dispose();
            return true;
        }

        public class AppInfo
        {
            public string AppId { get; set; }
            public string Description { get; set; }
            public ENAppType AppType { get; set; }
            public string ExecutablePath { get; set; }
            public string WorkingDir { get; set; }
            public string AdditionalParams { get; set; }
        }

        private void ReleaseDirectory_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            string currentValue = e.NewValue.ToString();

            //string exePath = fullPath + "\\" + System.IO.Path.GetFileName(fullPath);
            string[] files = System.IO.Directory.GetFiles(currentValue, "*.exe");
            customChkBox.Children.RemoveRange(0, 99);
            foreach (string item in files)
            {
                bool marked = false;
                if (files.Count() == 1)
                {
                    marked = true;
                }
                string fileName = System.IO.Path.GetFileName(item);
                DynamicExeCheckboxes(fileName.Split('.').First(), marked);
            }
        }
    }
}
