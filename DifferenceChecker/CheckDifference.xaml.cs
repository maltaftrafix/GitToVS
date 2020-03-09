using DevExpress.Xpf.Core;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Trafix.Client.Controls;

namespace CheckDifference
{
    /// <summary>
    /// Interaction logic for CheckDifference.xaml
    /// </summary>
    public partial class CheckDifference : SKWindow
    {
        public CheckDifference()
        {
            Theme theme = new Theme("MetroDarkCustom", "DevExpress.Xpf.Themes.MetroDarkCustom.v16.2");
            theme.AssemblyName = "DevExpress.Xpf.Themes.MetroDarkCustom.v16.2";
            Theme.RegisterTheme(theme);
            ThemeManager.SetTheme(this, theme);
            InitializeComponent();
        }

        private void Compare_Click(object sender, RoutedEventArgs e)
        {            
            string path_1 = File.ReadAllText(pnlOldFile.urlPath.Text);
            string path_2 = File.ReadAllText(pnlNewFile.urlPath.Text);

            path_1 = path_1.Replace("", "\n");
            path_2 = path_2.Replace("", "\n");

            var diffBuilder = new InlineDiffBuilder(new Differ());
            var diff = diffBuilder.BuildDiffModel(path_1, path_2);

            string o_string = "";
            string n_string = "";
            pnlOldFile.fileText.Document.Blocks.Clear();
            pnlNewFile.fileText.Document.Blocks.Clear();

            foreach (var line in diff.Lines)
            {
                switch (line.Type)
                {
                    case ChangeType.Inserted:
                        //Console.ForegroundColor = //ConsoleColor.Green;
                        n_string += "InsertedGreen" + line.Text + "?";
                        ////Console.Write("+ ");
                        break;
                    case ChangeType.Deleted:
                        //Console.ForegroundColor = //ConsoleColor.Red;
                        o_string += "DeletedRed" + line.Text + "?";
                        ////Console.Write("- ");
                        break;
                    default:
                        //Console.ForegroundColor = //ConsoleColor.White;
                        n_string += "UnchangedWhite" + line.Text + "?";
                        o_string += "UnchangedWhite" + line.Text + "?";
                        ////Console.Write("  ");
                        break;
                }
            }
            foreach (var item in o_string.Split('?'))
            {
                if (item.Contains("Green"))
                {
                    //Console.ForegroundColor = //ConsoleColor.Green;
                    //Console.Write(item.Replace("InsertedGreen", ""));
                    //Console.Write(" ");                                        
                    //pnlOldFile.fileText.AppendText(item.Replace("InsertedGreen", ""));                                        
                    pnlOldFile.HighlightWordInRichTextBox(pnlOldFile.fileText, item.Replace("InsertedGreen", ""), new SolidColorBrush(Colors.Green));
                    pnlOldFile.fileText.AppendText(" ");
                }
                else if (item.Contains("Red"))
                {
                    //Console.ForegroundColor = //ConsoleColor.Red;
                    //Console.Write(item.Replace("DeletedRed", ""));
                    //Console.Write(" ");
                    //pnlOldFile.fileText.AppendText(item.Replace("DeletedRed", ""));
                    pnlOldFile.HighlightWordInRichTextBox(pnlOldFile.fileText, item.Replace("DeletedRed", ""), new SolidColorBrush(Colors.Red));
                    pnlOldFile.fileText.AppendText(" ");
                }
                else if (item.Contains("White"))
                {
                    //Console.ForegroundColor = //ConsoleColor.White;
                    //Console.Write(item.Replace("UnchangedWhite", ""));
                    //Console.Write(" ");
                    //pnlOldFile.fileText.AppendText(item.Replace("UnchangedWhite", ""));
                    pnlOldFile.HighlightWordInRichTextBox(pnlOldFile.fileText, item.Replace("UnchangedWhite", ""), new SolidColorBrush(Colors.White));
                    pnlOldFile.fileText.AppendText(" ");
                }
            }

            foreach (var item in n_string.Split('?'))
            {
                if (item.Contains("Green"))
                {
                    //Console.ForegroundColor = //ConsoleColor.Green;
                    //Console.Write(item.Replace("InsertedGreen", ""));
                    //Console.Write(" ");                    
                    //pnlNewFile.fileText.AppendText(item.Replace("InsertedGreen", ""));
                    pnlNewFile.HighlightWordInRichTextBox(pnlNewFile.fileText, item.Replace("InsertedGreen", ""), new SolidColorBrush(Colors.Green));
                    pnlNewFile.fileText.AppendText(" ");
                }
                else if (item.Contains("Red"))
                {
                    //Console.ForegroundColor = //ConsoleColor.Red;
                    //Console.Write(item.Replace("DeletedRed", ""));
                    //Console.Write(" ");
                    //pnlNewFile.fileText.AppendText(item.Replace("DeletedRed", ""));
                    pnlNewFile.HighlightWordInRichTextBox(pnlNewFile.fileText, item.Replace("DeletedRed", ""), new SolidColorBrush(Colors.Red));
                    pnlNewFile.fileText.AppendText(" ");
                }
                else if (item.Contains("White"))
                {
                    //Console.ForegroundColor = //ConsoleColor.White;
                    //Console.Write(item.Replace("UnchangedWhite", ""));
                    //Console.Write(" ");
                    //pnlNewFile.fileText.AppendText(item.Replace("UnchangedWhite", ""));
                    pnlNewFile.HighlightWordInRichTextBox(pnlNewFile.fileText, item.Replace("UnchangedWhite", ""), new SolidColorBrush(Colors.White));
                    pnlNewFile.fileText.AppendText(" ");
                }
            }
        }
    }
}
