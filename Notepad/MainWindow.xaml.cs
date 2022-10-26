using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using Microsoft.Win32;




namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //  System.Text.Encoding.ReferenceEquals()
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.pdf)|*.pdf|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                PdfDocument doc = new PdfDocument();
                doc.Info.Title = "Create With PDFsharp";

                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font = new XFont("Arial", FontSize = 20);
                gfx.DrawString(txtEditor.Text, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);

                doc.Save(saveFileDialog.FileName);
            }

        }

        private void OpenPdf(object sender, RoutedEventArgs e)
        {

        }

        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            int row = txtEditor.GetLineIndexFromCharacterIndex(txtEditor.CaretIndex);
            int col = txtEditor.CaretIndex - txtEditor.GetCharacterIndexFromLineIndex(row);
            lblCursorPosition.Text = "Line:" + (row + 1) + ", Char " + (col + 1);
        }
    }







}
    
    

