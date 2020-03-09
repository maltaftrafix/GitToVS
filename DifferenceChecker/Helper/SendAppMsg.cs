using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trafix.Client.Communication;
using Trafix.Client.Controls;
using Trafix.Client.Framework;
using Trafix.CLRCommon;
using Trafix.ConfigCommon;


namespace DifferenceChecker.Helper
{
    public class SendAppMsg
    {      
        //public bool SendMsg(AppInfo app, ENSubMsgType enSubMsgType)
        //{
        //    //Services services = new Services();

        //    CommunicationManager m_communicationMgr = (CommunicationManager)Services.GetService<ICommunicationService>();

        //    //CommunicationManager m_commManager = (CommunicationManager)services.GetService<ICommunicationService>();
        //    //m_communicationMgr = m_commManager;

        //    Trafix.CLRCommon.Message msg = new Trafix.CLRCommon.Message();
        //    msg.SetMessageType((uint)ENMsgType.CONFIG_APP);
        //    msg.SetField((uint)ENConfigField.SUB_MSG_TYPE, (int)enSubMsgType);

        //    msg.SetField((uint)ENConfigField.APP_ID, app.AppId);
        //    msg.SetField((uint)ENConfigField.APP_TYPE, (int)app.AppType);
        //    msg.SetField((uint)ENConfigField.EXECUTABLE_PATH, app.ExecutablePath);
        //    msg.SetField((uint)ENConfigField.WORKING_DIR, app.WorkingDir);
        //    msg.SetField((uint)ENConfigField.DESCRIPTION, app.Description);
        //    msg.SetField((uint)ENConfigField.ADDITIONAL_PARAMS, app.AdditionalParams);

        //    Trafix.CLRCommon.Message replyMsg = null;
        //    m_communicationMgr.RequestSync(ENAppType.CONFIG, "", msg, out replyMsg);
        //    return ProcessConfigReply(replyMsg);
        //}
        public class AppInfo
        {
            public string AppId { get; set; }
            public string Description { get; set; }
            public ENAppType AppType { get; set; }
            public string ExecutablePath { get; set; }
            public string WorkingDir { get; set; }
            public string AdditionalParams { get; set; }
        }
        bool ProcessConfigReply(Trafix.CLRCommon.Message replyMsg)
        {
            if (replyMsg == null)
            {
                SKMessageBox.Show("Unable to send request to server", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }

            if (replyMsg.GetMessageType() == (uint)ENMsgType.ERROR_)
            {
                int errorCode = replyMsg.GetField<int>((uint)ENConfigField.ERROR_CODE);
                string stErrorMsg = string.Empty;
                replyMsg.GetField((uint)ENConfigField.ERROR_TEXT, out stErrorMsg);

                SKMessageBox.Show(string.Format("Server error {0}: {1}", errorCode, stErrorMsg), "Request Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
            replyMsg.Dispose();
            return true;
        }
       
    }
}
