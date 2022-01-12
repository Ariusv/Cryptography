using Criptology;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

namespace TabMenu
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    /// 
    public delegate void ButtonC(object sender, RoutedEventArgs e);

    public partial class MainWindow : Window
    {

        private int shriftIndex;
        private string text;
        private string codeText;
        private ButtonC click1;
        private ButtonC click2;
        ICriptyzator cr;


        public MainWindow()
        {
            InitializeComponent();
            cr = new CaeserCriptyzator();
            click1 = Button1_Click;
            click2 = Button2_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shriftIndex = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * shriftIndex), 0, 0, 0);

            switch(shriftIndex)
            {
                case 0:
                    GridMain.Background = Brushes.AliceBlue;
                    cr = new CaeserCriptyzator();
                    ReplacePanel.Visibility = Visibility.Hidden;
                    KeyPanel.Visibility = Visibility.Visible;
                    EnCodeButton.Visibility = Visibility.Visible;
                    CodeTableButton.Visibility = Visibility.Hidden;
                    XPanel.Visibility = Visibility.Hidden;
                    YPanel.Visibility = Visibility.Hidden;
                    gPanel.Visibility = Visibility.Hidden;
                    click1 = Button1_Click;
                    click2 = Button2_Click;
                    break;
                case 1:
                    GridMain.Background = Brushes.Khaki;
                    cr = new FCriptyzator(@"frequency.txt");
                    ReplacePanel.Visibility = Visibility.Visible;
                    KeyPanel.Visibility = Visibility.Hidden;
                    EnCodeButton.Visibility = Visibility.Hidden;
                    CodeTableButton.Visibility = Visibility.Hidden;
                    XPanel.Visibility = Visibility.Hidden;
                    YPanel.Visibility = Visibility.Hidden;
                    gPanel.Visibility = Visibility.Hidden;
                    click1 = Button1_Click;
                    click2 = Button2_Click;
                    break;
                case 2:
                    GridMain.Background = Brushes.CadetBlue;
                    cr = new VCriptyzator();
                    ReplacePanel.Visibility = Visibility.Hidden;
                    KeyPanel.Visibility = Visibility.Visible;
                    EnCodeButton.Visibility = Visibility.Visible;
                    CodeTableButton.Visibility = Visibility.Hidden;
                    XPanel.Visibility = Visibility.Hidden;
                    YPanel.Visibility = Visibility.Hidden;
                    gPanel.Visibility = Visibility.Hidden;
                    click1 = Button1_Click;
                    click2 = Button2_Click;
                    break;
                case 3:
                    GridMain.Background = Brushes.LightGray;
                    cr = new HCriptizator();
                    ReplacePanel.Visibility = Visibility.Hidden;
                    KeyPanel.Visibility = Visibility.Hidden;
                    EnCodeButton.Visibility = Visibility.Visible;
                    CodeTableButton.Visibility = Visibility.Visible;
                    XPanel.Visibility = Visibility.Hidden;
                    YPanel.Visibility = Visibility.Hidden;
                    gPanel.Visibility = Visibility.Hidden;
                    click1 = Button1_Click;
                    click2 = Button2_Click;
                    break;
                case 4:
                    cr = new ElHamalCriptizator();
                    GridMain.Background = Brushes.LightSteelBlue;
                    ReplacePanel.Visibility = Visibility.Hidden;
                    KeyPanel.Visibility = Visibility.Visible;
                    EnCodeButton.Visibility = Visibility.Visible;
                    CodeTableButton.Visibility = Visibility.Hidden;
                    XPanel.Visibility = Visibility.Visible;
                    gPanel.Visibility = Visibility.Visible;
                    YPanel.Visibility = Visibility.Visible;
                    Key1.Text = "2147483647";
                    gKey1.Text = MathOpers.BigRandom(2, BigInteger.Parse(Key1.Text) - 1).ToString();
                    XKey1.Text = MathOpers.BigRandom(2, BigInteger.Parse(Key1.Text) - 1).ToString();
                    YKey1.Text = BigInteger.ModPow(BigInteger.Parse(gKey1.Text), BigInteger.Parse(XKey1.Text), BigInteger.Parse(Key1.Text)).ToString();
                    click1 = Button_ClickRE;
                    click2 = Button_ClickRD;
                    break;
            }
        }

        private void OpenButton_MouseMove(object sender, MouseEventArgs e)
        {
            OpenButton.Foreground = Brushes.IndianRed;
        }

        private void OpenButton_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenButton.Foreground = Brushes.Gray;
        }
        private void SaveButton_MouseMove(object sender, MouseEventArgs e)
        {
            SaveButton.Foreground = Brushes.IndianRed;
        }

        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            SaveButton.Foreground = Brushes.Gray;
        }
        private void ExitButton_MouseMove(object sender, MouseEventArgs e)
        {
            Picon.Foreground = Brushes.Red;
        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Picon.Foreground = Brushes.Gray;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(EnCodeBox.Document.ContentStart, EnCodeBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(DeCodeBox.Document.ContentStart, DeCodeBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }
        private void BCE(object sender, RoutedEventArgs e)
        {
            click1(sender, e);
        }

        private void BCD(object sender, RoutedEventArgs e)
        {
            click2(sender, e);
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                text = new TextRange(EnCodeBox.Document.ContentStart, EnCodeBox.Document.ContentEnd).Text;
                object k = Key1.Text;
                codeText = cr.Ecrypt(text, k);
                DeCodeBox.Document.Blocks.Clear();
                DeCodeBox.Document.Blocks.Add(new Paragraph(new Run(codeText)));
            }
            catch
            {

            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                text = new TextRange(EnCodeBox.Document.ContentStart, EnCodeBox.Document.ContentEnd).Text;
                object k = Key1.Text;
                codeText = cr.Dcrypt(text, k);
                DeCodeBox.Document.Blocks.Clear();
                DeCodeBox.Document.Blocks.Add(new Paragraph(new Run(codeText)));
            }
            catch
            {

            }
        }


        private void Button_ClickRE(object sender, RoutedEventArgs e)
        {
            try
            {
                text = new TextRange(EnCodeBox.Document.ContentStart, EnCodeBox.Document.ContentEnd).Text;

                codeText = cr.Ecrypt(text, new BigInteger[4] {  BigInteger.Parse(Key1.Text), BigInteger.Parse(gKey1.Text), BigInteger.Parse(XKey1.Text), BigInteger.Parse(YKey1.Text) });
                DeCodeBox.Document.Blocks.Clear();
                DeCodeBox.Document.Blocks.Add(new Paragraph(new Run(codeText)));
            }
            catch
            {

            }
        }

        private void Button_ClickRD(object sender, RoutedEventArgs e)
        {
            try
            {
                text = new TextRange(EnCodeBox.Document.ContentStart, EnCodeBox.Document.ContentEnd).Text;


                codeText = cr.Dcrypt(text, new BigInteger[2] { BigInteger.Parse(Key1.Text), BigInteger.Parse(XKey1.Text) });
                DeCodeBox.Document.Blocks.Clear();
                DeCodeBox.Document.Blocks.Add(new Paragraph(new Run(codeText)));
            }
            catch
            {

            }
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            string str1 = ReplaceFromBox.Text;
            string str2 = ReplaceToBox.Text;
            text = new TextRange(DeCodeBox.Document.ContentStart, DeCodeBox.Document.ContentEnd).Text;
            codeText = cr.Replace(text, str1, str2);

            
            DeCodeBox.Document.Blocks.Clear();
            DeCodeBox.Document.Blocks.Add(new Paragraph(new Run(codeText)));
            }
            catch
            {

            }


        }

        private void OpenButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ArrowButton_Click(object sender, RoutedEventArgs e)
        {


            string tempstr= new TextRange(EnCodeBox.Document.ContentStart, EnCodeBox.Document.ContentEnd).Text;
            string tempstr2 = new TextRange(DeCodeBox.Document.ContentStart, DeCodeBox.Document.ContentEnd).Text;
            DeCodeBox.Document.Blocks.Clear();
            EnCodeBox.Document.Blocks.Clear();

            DeCodeBox.Document.Blocks.Add(new Paragraph(new Run(tempstr)));
            EnCodeBox.Document.Blocks.Add(new Paragraph(new Run(tempstr2)));
        }



        private void EnCodeButton_MouseMove(object sender, MouseEventArgs e)
        {
            EnCodeIcon.Foreground = Brushes.Red;
        }

        private void EnCodeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            EnCodeIcon.Foreground = Brushes.Black;
        }

        private void DeCodeButton_MouseMove(object sender, MouseEventArgs e)
        {
            DeCodeIcon.Foreground = Brushes.Red;
        }

        private void DeCodeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DeCodeIcon.Foreground = Brushes.Black;
        }

        private void ArrowButton_MouseMove(object sender, MouseEventArgs e)
        {
            ArrowIcon.Foreground = Brushes.Red;
        }

        private void ArrowButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ArrowIcon.Foreground = Brushes.Black;
        }

        private void KeyButton_MouseMove(object sender, MouseEventArgs e)
        {
            KeyIcon.Foreground = Brushes.Red;
        }

        private void KeyButton_MouseLeave(object sender, MouseEventArgs e)
        {
            KeyIcon.Foreground = Brushes.Black;
        }



        private void ReplaceButton_MouseMove(object sender, MouseEventArgs e)
        {
            ReplaceIcon.Foreground = Brushes.Red;
        }

        private void ReplaceButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ReplaceIcon.Foreground = Brushes.Black;
        }

        private void CodeTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableWindow window = new TableWindow((cr as HCriptizator).hTree.GetLettersCodes());
                window.Show();
            }
            catch
            {

            }
        }

        private void CodeTableButton_MouseMove(object sender, MouseEventArgs e)
        {
            CodeTableIcon.Foreground = Brushes.Red;
        }

        private void CodeTableButton_MouseLeave(object sender, MouseEventArgs e)
        {
            CodeTableIcon.Foreground = Brushes.Black;
        }
    }
}
