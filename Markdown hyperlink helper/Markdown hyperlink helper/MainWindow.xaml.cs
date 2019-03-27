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
using System.Windows.Media.Animation;
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
        private string _notation = "";

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
            ToastMessage("Copied");
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            tb_topic.Text = "";
            tb_link.Text = "";
            tb_vlink.Text = "";
            tb_glink.Text = "";
            _notation = "";
            SetSelectedNotation(btn_note_x);

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
            text_output.Text = GetPrefix() + GetNotation() + GetTopic() + GetLink() + GetVideoLink() + GetGalleryLink();
        }

        private string GetNotation()
        {
            return ((_notation.Length > 0) ? ("`" + _notation + "` ") : "");
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
            return ((tb_vlink.Text.Length > 0) ? (" ([video](" + tb_vlink.Text.Replace("_1000k.mp4", "_2250k.mp4") + "))") : "");
        }

        private string GetGalleryLink()
        {
            return  ((tb_glink.Text.Length > 0) ? (" ([gallery](" + tb_glink.Text + "))") : "");
        }

        private void btn_media_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Name.Equals("btn_topic_facebook"))
            {
                tb_topic.Text = "Facebook";
            }
            else if (btn.Name.Equals("btn_topic_twitter"))
            {
                tb_topic.Text = "Twitter";
            }
            else if (btn.Name.Equals("btn_topic_youtube"))
            {
                tb_topic.Text = "YouTube";
            }
            else if (btn.Name.Equals("btn_topic_instagram"))
            {
                tb_topic.Text = "Instagram";
            }
            else if (btn.Name.Equals("btn_note_facebook"))
            {
                _notation = "Facebook";
                SetSelectedNotation(btn);
            }
            else if (btn.Name.Equals("btn_note_twitter"))
            {
                _notation = "Twitter";
                SetSelectedNotation(btn);
            }
            else if (btn.Name.Equals("btn_note_youtube"))
            {
                _notation = "YouTube";
                SetSelectedNotation(btn);
            }
            else if (btn.Name.Equals("btn_note_instagram"))
            {
                _notation = "Instagram";
                SetSelectedNotation(btn);
            }
            else // btn_note_x
            {
                _notation = "";
                SetSelectedNotation(btn);
            }


            RefreshOutput();
        }

        private void SetSelectedNotation(Button btn)
        {
            btn_note_x.Background = Brushes.Transparent;
            btn_note_facebook.Background = Brushes.Transparent;
            btn_note_twitter.Background = Brushes.Transparent;
            btn_note_youtube.Background = Brushes.Transparent;
            btn_note_instagram.Background = Brushes.Transparent;

            btn.Background = Brushes.CadetBlue;
        }


        private void ToastMessage(string message)
        {
            label_message.Content = message;

            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 1);
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = 1.0;
            animation.To = 0.0;
            animation.Duration = new Duration(duration);
            Storyboard.SetTargetName(animation, label_message.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Control.OpacityProperty));
            storyboard.Children.Add(animation);

            storyboard.Begin(this);
        }
    }
}
