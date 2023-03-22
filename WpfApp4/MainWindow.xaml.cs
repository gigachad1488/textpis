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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using Microsoft.Win32;
namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FontChangeComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(s => s.Source);
            for (int i = 0; i < 72;)
            {
                i += 2;
                FontSizeComboBox.Items.Add(i);
            }
            for (double i = 1; i <= 2;)
            {
                IntComboBox.Items.Add(i);
                i += 0.5;
            }
            var timer = new System.Windows.Threading.DispatcherTimer();
            RichTextBox.Document.Blocks.Clear();
            timer.Interval = new TimeSpan(500000);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
        }

        public void timerTick(object sender, EventArgs e)
        {
            Random r1 = new Random();
            Thread.Sleep(1);
            Random r2 = new Random();
            Thread.Sleep(2);
            Random r3 = new Random();
            RichTextBox.BorderBrush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r1.Next(0, 255)), Convert.ToByte(r2.Next(0, 255)), Convert.ToByte(r3.Next(0, 255))));
            //Thread.Sleep(5);
            //b66.BorderBrush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r1.Next(0, 255)), Convert.ToByte(r2.Next(0, 255)), Convert.ToByte(r3.Next(0, 255))));

        }

        public void SaveSelection()
        {
            RichTextBox.Focus();
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Color color = (Color)ColorPicker.SelectedColor;
            RichTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(color));
        }
        private void CurvButton_Click(object sender, RoutedEventArgs e)
        {

            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, RichTextBox.Selection.GetPropertyValue(TextElement.FontStyleProperty).Equals(FontStyles.Italic) ? FontStyles.Normal : FontStyles.Italic);
        }

        private void FocButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, RichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty).Equals(TextDecorations.Underline) ? null : TextDecorations.Underline);
        }

        private void StrButton_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, RichTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty).Equals(FontWeights.Bold) ? FontWeights.Normal : FontWeights.Bold);
        }

        private void FontChangeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontChangeComboBox.SelectedItem);
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(FontSizeComboBox.SelectedItem));
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange textrange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "текстовый документ (*.txt)|*.txt";
            savefile.Title = "сохранение";
            if (savefile.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    sw.Write(textrange.Text);
                }
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "текстовый документ (*.txt)|*.txt";
            openfile.Title = "сохранение";
            if (openfile.ShowDialog() == true)
            {
                using (StreamReader sw = new StreamReader(openfile.FileName))
                {
                    string s = sw.ReadToEnd();
                    RichTextBox.Document.Blocks.Add(new Paragraph(new Run(s)));
                }
            }
        }

        private void IntComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
