using DevExpress.Xpf.Core;
using DifferenceChecker.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trafix;
using Trafix.Client.Controls;
using Trafix.Client.Downloader;
using Trafix.Client.Uploader;
using Settings = Trafix.Client.Downloader.Settings;

namespace DifferenceChecker
{
    /// <summary>
    /// Interaction logic for TransferFiles.xaml
    /// </summary>
    public partial class TransferFiles : SKWindow
    {      
        public TransferFiles()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Theme theme = new Theme("MetroDarkCustom", "DevExpress.Xpf.Themes.MetroDarkCustom.v16.2");
            theme.AssemblyName = "DevExpress.Xpf.Themes.MetroDarkCustom.v16.2";
            Theme.RegisterTheme(theme);
            ThemeManager.SetTheme(this, theme); 
            InitializeComponent();
        }                    


    }
}
