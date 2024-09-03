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
    /// Interaction logic for ChatImageItem.xaml
    /// </summary>
    public partial class ChatImageItem : UserControl
    {
        public string SendedTime { get { return lblTime.Content.ToString(); } set { lblTime.Content = value; } }
        public Senders sender
        {
            set
            {
                if (value == Senders.me)
                {
                    brdr.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#7289da");
                }
                else
                {
                    brdr.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#282B30");
                }
            }
        }
        public ImageSource Image { set {

                imgl.ImageSource = value;

            }
            get { return imgl.ImageSource; }
        }

        public ChatImageItem()
        {
            InitializeComponent();
            
        }
    }
}
