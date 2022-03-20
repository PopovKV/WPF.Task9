using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Task9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int bc = 0;
        int bc1 = 0;
        int bc2 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (string)(sender as ComboBox).SelectedItem;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int fontSize = (Int32)(sender as ComboBox).SelectedItem;
            if (textBox != null)
            {
                textBox.FontSize = fontSize;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if ((textBox != null) && (bc % 2 == 0))
            {
                textBox.FontWeight = FontWeights.Bold;
                ButtonBold.Background = Brushes.SkyBlue;
            }
            else
            {
                if ((textBox != null) && (bc % 2 != 0))
                {
                    textBox.FontWeight = FontWeights.Normal;
                    ButtonBold.Background = null;
                }
            }
            bc++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if ((textBox != null) && (bc1 % 2 == 0))
            {
                textBox.FontStyle = FontStyles.Italic;
                ButtonItalic.Background = Brushes.SkyBlue;
            }
            else
            {
                if ((textBox != null) && (bc1 % 2 != 0))
                {
                    textBox.FontStyle = FontStyles.Normal;
                    ButtonItalic.Background = null;
                }
            }
            bc1++;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if ((textBox != null) && (bc2 % 2 == 0))
            {
                textBox.TextDecorations = TextDecorations.Underline;
                ButtonUnderlined.Background = Brushes.SkyBlue;
            }
            else
            {
                if ((textBox != null) && (bc2 % 2 != 0))
                {
                    textBox.TextDecorations = null;
                    ButtonUnderlined.Background = null;
                }
            }
            bc2++;
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }
}