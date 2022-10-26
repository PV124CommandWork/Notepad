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
        private string fileName;
        private string fileNameTXT = "";

        private SaveFileDialog saveFileDialogTXT;
        private TextBox searchText = new TextBox();

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Text files (*.pdf)|*.pdf|All Files (*.*)|*.*";

            //if (saveFileDialog.ShowDialog() == true)
            //{
            //    PdfDocument doc = new PdfDocument();
            //    doc.Info.Title = "Create With PDFsharp";

            //    PdfPage page = doc.AddPage();
            //    XGraphics gfx = XGraphics.FromPdfPage(page);

            //    XFont font = new XFont("Arial", FontSize = 20);
            //    gfx.DrawString(txtEditor.Text, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);

            //    doc.Save(saveFileDialog.FileName);
            //}

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
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            
            searchText.Height = 22;
            searchText.Width = 120;

            Button search = new Button();
            search.Height = 22;
            search.Width = 70;
            search.Content = "Find";

            panel.Children.Add(searchText);
            panel.Children.Add(search);
            search.Click += Search_Click;
            
        }
      


        // Function to find a word or a sentence 
        private void Search_Click(object sender, RoutedEventArgs e)
        {

            if (txtEditor.Text.Contains(searchText.Text))
            {
                int counter1 = 0;
                int counter2 = 0;
                int num1 = txtEditor.Text.IndexOf(searchText.Text);
                for (int i = num1; i > 0; i--)
                {
                    counter1++;
                    if (txtEditor.Text[i] == '.' || txtEditor.Text[i] == '!' || txtEditor.Text[i] == '?' || i == 0)
                    {
                        counter1 -= 2;
                        break;
                    }
                }

                Console.WriteLine(counter1);
                for (int i = num1; i < txtEditor.Text.Length; i++)
                {
                    counter2++;
                    if (txtEditor.Text[i] == '.' || txtEditor.Text[i] == '!' || txtEditor.Text[i] == '?' || i == txtEditor.Text.Length)
                    {
                        break;
                    }
                }
                MessageBox.Show(txtEditor.Text.Substring(num1 - counter1, (num1 - (num1 - counter1)) + counter2));
            }
            else
            {
                searchText.Text = ("Error! Text does not contain given searchText.Text.");

            }

            //if (txtEditor.Text.Contains(searchText.Text))
            //{
            //    int count = 0;
            //    string[] mas = txtEditor.Text.Split(' ', '.', ',', '!', '?');
            //    foreach (string p in mas)
            //    {
            //        if (p == searchText.Text)
            //        {
            //            count++;
            //        }
            //    }

            //    int position = 0;
            //    for (int i = 0; i < count; i++)
            //    {
            //        int counter1 = 0;
            //        int counter2 = 0;
            //        int num1 = txtEditor.Text.IndexOf(searchText.Text, position);
            //        for (int q = num1; q > 0; q--)
            //        {
            //            counter1++;
            //            if (txtEditor.Text[q] == '.' || txtEditor.Text[q] == '!' || txtEditor.Text[q] == '?' || q == 0)
            //            {
            //                counter1 -= 2;
            //                break;
            //            }
            //        }
            //        for (int q = num1; q < txtEditor.Text.Length; q++)
            //        {
            //            counter2++;
            //            if (true)
            //            {
            //                break;
            //            }
            //        }
            //        position = num1 - (num1 - counter1) + counter2;
            //        MessageBox.Show(txtEditor.Text.Substring(num1 - counter1, (num1 - (num1 - counter1)) + counter2));
            //    }
            //}

            //else
            //{
            //   searchText.Text=("Error! Text does not contain given word.");
            //}
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.ShowDialog();
            fileName = openFileDialog.FileName;
            using (StreamReader reader = new StreamReader(fileName))
            {
                txtEditor.Text = reader.ReadToEnd();
            }

        }



        private void AboutTheProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the best text editor you've ever seen!\nThis amazing app was created by the most fabulous programmers in the world, by TeamPatron!\nEditors:\n- Max\n- Palvo Galitskiy(Knyazev)\n- Viktoriia Kychan\n- Max\n- Andriy Ripa\n");
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SaveTxtFile()
        {
            saveFileDialogTXT = new SaveFileDialog();
            fileNameTXT = saveFileDialogTXT.FileName;
            saveFileDialogTXT.Filter = "Txt files (*.txt)|*.txt";
            if (saveFileDialogTXT.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialogTXT.FileName, txtEditor.Text);
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(saveFileDialogTXT.FileName))
                {
                    SaveTxtFile();
                }
                else
                {
                    File.WriteAllText(saveFileDialogTXT.FileName, txtEditor.Text);
                }
            }
            catch (Exception)
            {
                SaveTxtFile();
            }
          
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
           
            if(MessageBox.Show("Do you want to save last changes?", "Exit the notepad", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SaveTxtFile();
            }
            else
            {
                this.Close();
            }
        }

        private void SavePDF_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialogPDF = new SaveFileDialog();
            saveFileDialogPDF.Filter = "Pdf files (*.pdf)|*.pdf|All Files (*.*)|*.*";

            if (saveFileDialogPDF.ShowDialog() == true)
            {
                PdfDocument doc = new PdfDocument();
                doc.Info.Title = "Create With PDFsharp";

                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font = new XFont("Arial", FontSize = 20);
                gfx.DrawString(txtEditor.Text, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);

                doc.Save(saveFileDialogPDF.FileName);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveTxtFile();
        }
    }







}
    
    

