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

namespace Markdown_hyperlink_helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _windowTitle = "Markdown Hyperlink Helper";

        public MainWindow()
        {
            InitializeComponent();
            this.Title = _windowTitle;
            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshOutput();
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            textBox.Text = GetClipboard();
            RefreshOutput();
        }

        private void cb_prefix_CheckChanged(object sender, RoutedEventArgs e)
        {
            RefreshOutput();
        }

        private void text_output_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SetClipboard(text_output.Text);
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            tb_topic.Text = "";
            tb_link.Text = "";
            tb_vlink.Text = "";
            tb_glink.Text = "";
            RefreshOutput();
        }

        private string GetClipboard()
        {
            return Clipboard.GetText(TextDataFormat.UnicodeText);
        }

        private void SetClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        private void RefreshOutput()
        {
            text_output.Text = GetPrefix() + GetTopic() + GetLink() + GetVideoLink() + GetGalleryLink();
        }

        private string GetPrefix()
        {
            return (cb_prefix.IsChecked == true) ? tb_prefix.Text : "";
        }

        private string GetTopic()
        {
            return "[" + tb_topic.Text + "]";
        }

        private string GetLink()
        {
            return "(" + tb_link.Text + ")";
        }

        private string GetVideoLink()
        {
            return " " + ((tb_vlink.Text.Length > 0) ? ("([video](" + tb_vlink.Text.Replace("_1000k.mp4", "_2250k.mp4") + "))") : "");
        }

        private string GetGalleryLink()
        {
            return  " " + ((tb_glink.Text.Length > 0) ? ("([gallery](" + tb_glink.Text + "))") : "");
        }

        
    }
}
