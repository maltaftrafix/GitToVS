using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace DifferenceChecker.View
{
    /// <summary>
    /// Interaction logic for DifferencePanelUC.xaml
    /// </summary>
    public partial class DifferencePanelUC : SKUserControl
    {
        public DifferencePanelUC()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                urlPath.Text = openFileDlg.FileName;
                //TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
        }

        public void HighlightWordInRichTextBox(RichTextBox richTextBox, String word, SolidColorBrush color)
        {
            //Current word at the pointer
            TextRange tr = new TextRange(richTextBox.Document.ContentEnd, fileText.Document.ContentEnd);
            tr.Text = word;
            tr.ApplyPropertyValue(TextElement.BackgroundProperty, color);
        }
    }
}
