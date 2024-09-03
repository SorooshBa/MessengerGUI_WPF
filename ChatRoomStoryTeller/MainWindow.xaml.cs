using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 50; i++)
            {
                stackPnlUsers.Children.Add(new UserinList()
                {
                    Margin = new Thickness(10),
                    Width = 370,
                    Height = 80,
                    Username = $"UserName{i}",
                    ChatPreview = "LoremIpsum LoremIpsum LoremIpsum",
                    ProflePic = new BitmapImage(new Uri(Environment.CurrentDirectory+"/profile.jpg", UriKind.Relative))

                });
                var temp = ((UserinList)stackPnlUsers.Children[stackPnlUsers.Children.Count - 1]);
                temp.MouseDown += User_MouseDown;

            }
            for (int i = 0; i < 10; i++)
            {
                if(i%2==0)
                stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = "lorem ipsum hello" , HorizontalAlignment=HorizontalAlignment.Right , SendedTime =$"10:0{i}",  sender=Senders.me });
                else
                    stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = "lorem ipsum hello", HorizontalAlignment = HorizontalAlignment.Left, SendedTime = $"10:0{i}", sender = Senders.you });

            }
            scrlChat.ScrollToEnd();
        }
        bool tempbool = true;
        private void User_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var temp = ((UserinList)sender);
            if (tempbool)
            {
                temp.SetAsNotReaded();
                tempbool = false;
            }
            else
            {
                temp.SetAsReaded();
                tempbool = true;
            }

        }

        private void Send_clicked(object sender, MouseButtonEventArgs e)
        {
            stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = txtToSend.Text, HorizontalAlignment = HorizontalAlignment.Right, SendedTime = DateTime.Now.ToShortTimeString(), sender = Senders.me });
            txtToSend.Clear();
            scrlChat.ScrollToEnd();
        }
    }
}