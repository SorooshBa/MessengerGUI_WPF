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

namespace ChatRoomStoryTeller
{
    /// <summary>
    /// Interaction logic for ChatItem.xaml
    /// </summary>
    public partial class ChatItem : UserControl
    {
        public string Text { get { return txtMessage.Text; } set {  txtMessage.Text = value; } }    
        public string SendedTime { get { return lblTime.Content.ToString(); } set {  lblTime.Content = value; } }    
        public Senders sender { set { if(value==Senders.me)
                { brdr.Background= (SolidColorBrush)new BrushConverter().ConvertFrom("#7289da");
                    txtMessage.HorizontalAlignment= HorizontalAlignment.Right;
                }
        else
                {
                    brdr.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#282B30");
                    txtMessage.HorizontalAlignment = HorizontalAlignment.Left;
                }    
                        } }
        public ChatItem()
        {
            InitializeComponent();
            this.Height=txtMessage.Height + lblTime.Height;
                this.Width = txtMessage.Width;

        }
    }
    public enum Senders
    {
        me,
        you
    }
}
