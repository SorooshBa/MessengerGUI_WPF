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
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ChatRoomStoryTeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            chatPageGrid.Visibility = Visibility.Hidden;
            textList.Add("text1");
            textList.Add("text2");
            textList.Add("text3");
            textList.Add("text4");
            //for (int i = 0; i < 50; i++)
            //{
            //    stackPnlUsers.Children.Add(new UserinList()
            //    {
            //        Margin = new Thickness(10),
            //        Width = 370,
            //        Height = 80,
            //        Username = $"UserName{i}",
            //        ChatPreview = "LoremIpsum LoremIpsum LoremIpsum",
            //        ProflePic = new BitmapImage(new Uri(Environment.CurrentDirectory+"/profile.jpg", UriKind.Relative))

            //    });
            //    var temp = ((UserinList)stackPnlUsers.Children[stackPnlUsers.Children.Count - 1]);
            //    temp.MouseDown += User_MouseDown;

            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    if(i%2==0)
            //    stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = "lorem ipsum hello" , HorizontalAlignment=HorizontalAlignment.Right , SendedTime =$"10:0{i}",  sender=Senders.me });
            //    else
            //        stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = "lorem ipsum hello", HorizontalAlignment = HorizontalAlignment.Left, SendedTime = $"10:0{i}", sender = Senders.you });

            //}
            ////--------------------------------------------
            //users.Add(new User()
            //{
            //    Name = "Ali",
            //    Image ="profile.jpg",
            //    id = 1
            //});
            //List<ChatMessage> messages = new List<ChatMessage>();
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "Hello" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "hiii" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "how you doing?" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "im good" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "what about you?" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "nothing" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "have a good day" });
            //users[users.Count - 1].Messages = messages;
            //users.Add(new User()
            //{
            //    Name = "Reza",
            //    id = 2,
            //    Image = "profile2.jpg"
            //});
            //List<ChatMessage> messages2 = new List<ChatMessage>();
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "yo" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "wazap" });
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "yo fine?" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "im good" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "what about you?" });
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "nothing" });
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "have a nice day" });
            //users[users.Count - 1].Messages = messages2;
            //users[users.Count - 1].isNewMeesage = true;
            //////-------------
            //System.IO.File.WriteAllText("backup.db", JsonConvert.SerializeObject(users, Formatting.Indented));
            users =JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText("backup.db"));

            loadUsers();
            
        }
        bool tempbool = true;
        private void User_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var temp = ((UserinList)sender);
            LoadMessagesPage(temp.id);
            temp.SetAsReaded();
        }
        private void LoadMessagesPage(int id)
        {
            chatPageGrid.Visibility = Visibility.Visible;
            stckPnlChats.Children.Clear();
            var user = users.Where(x=>x.id == id).First();
            if (user != null)
            {
                imgProf.ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + "/"+ user.Image, UriKind.Relative)) ;
                lblName.Content=user.Name;
                foreach (var message in user.Messages)
                {
                    if(message.Sender==Senders.me)
                    {
                         stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = message.Message , HorizontalAlignment=HorizontalAlignment.Right , SendedTime =message.DateTime.ToShortTimeString(),  sender=Senders.me });
                    }
                    else if(message.Sender==Senders.you)
                    {
                        stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = message.Message, HorizontalAlignment = HorizontalAlignment.Left, SendedTime = message.DateTime.ToShortTimeString(), sender = Senders.you });

                    }
                }
                scrlChat.ScrollToEnd();
            }
        }
        private void Send_clicked(object sender, MouseButtonEventArgs e)
        {
            stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = txtToSend.Text, HorizontalAlignment = HorizontalAlignment.Right, SendedTime = DateTime.Now.ToShortTimeString(), sender = Senders.me });
            txtToSend.Clear();
            scrlChat.ScrollToEnd();
        }
        private List<string> textList = new List<string>();
        int enumarator = -1;
        private void arrowUpSelectChat(object sender, RoutedEventArgs e)
        {
            if (textList.Count - 1 > enumarator)
            {
                enumarator++;
                txtToSend.Text = textList[enumarator];          

            }
            else
            {
                enumarator = 0;
                txtToSend.Text = textList[enumarator];
            }
        }

        private void arrowDownSelectChat(object sender, RoutedEventArgs e)
        {
            if (enumarator>0)
            {
                enumarator--;
                txtToSend.Text = textList[enumarator];

            }
            else
            {
                enumarator = textList.Count-1;
                txtToSend.Text = textList[enumarator];
            }
        }
        private void loadUsers()
        {
            foreach (var item in users)
            {
                stackPnlUsers.Children.Add(new UserinList()
                {
                    Margin = new Thickness(10),
                    Width = 370,
                    Height = 80,
                    Username = item.Name,
                    ChatPreview = item.Messages[item.Messages.Count-1].Message,
                    ProflePic = new BitmapImage(new Uri(Environment.CurrentDirectory + "/"+item.Image, UriKind.Relative)),
                    id =item.id
                });
                var temp = ((UserinList)stackPnlUsers.Children[stackPnlUsers.Children.Count - 1]);
                if(item.isNewMeesage)
                {
                    temp.SetAsNotReaded();
                }
                temp.MouseDown += User_MouseDown;
            }
        }
        
    }
}