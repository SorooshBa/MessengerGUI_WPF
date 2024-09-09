using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ChatRoomStoryTeller.Story;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StoryMaker;

namespace ChatRoomStoryTeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<User> users = new List<User>();
        public static MainWindow _instance;
        public MainWindow()
        {
            _instance = this;
            InitializeComponent();
            chatPageGrid.Visibility = Visibility.Hidden;


            //users.Add(new User()
            //{
            //    Name = "Olivia Richardson",
            //    Image = "/img/oli.png",
            //    id = 1
            //});
            //List<ChatMessage> messages = new List<ChatMessage>();
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now-new TimeSpan(36,24,12), Message = "This new app look dope" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(36, 12, 12), Message = "helllo " });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(36, 8, 12), Message = "me and Jacob gonna go to a theater. comin?" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(36, 7, 12), Message = "not sure." });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(36, 6, 12), Message = "You two guys have fun" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(36, 5, 12), Message = "Okay.Tnx" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(31, 24, 12), Image = "/img/theater.webp" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(31, 24, 12), Image = "/img/orig.jpg" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(31, 24, 12), Message = "it was so good" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(30, 32, 12), Message = "WOW" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now , Message = "Hey Cassy Where have you been? Im a bit worried about you." });

            //users[users.Count - 1].Messages = messages;
            //users.Add(new User()
            //{
            //    Name = "My Love ❤️",
            //    id = 2,
            //    Image = "/img/jacob.jpg"
            //});
            //List<ChatMessage> messages2 = new List<ChatMessage>();
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(23, 24, 12), Message = "{deleted message}" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(23, 23, 12), Message = "{deleted message}" });
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(23, 12, 12), Message = "{deleted message}" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(23, 11, 12), Message = "{deleted message}" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(23, 10, 12), Message = "Is it removed on both sides?" });
            //messages2.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now - new TimeSpan(23, 10, 8), Message = "Yes ma love" });
            //messages2.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now - new TimeSpan(21, 24, 12), Message = "very well. no worries" });
            //users[users.Count - 1].Messages = messages2;
            //////-------------
            //System.IO.File.WriteAllText("backup.db", JsonConvert.SerializeObject(users, Formatting.Indented));
            //LoadDb();


            //StoryManager.LoadDailogus();
            LoadBackup();
            loadUsers();

        }
        public void LoadBackup()
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog()==true)
            {
                var bytes = File.ReadAllBytes(op.FileName);
                var back =  MessagePackSerializer.Deserialize<BackUp>(bytes, ContractlessStandardResolver.Options);
                users= back.Users;
                foreach (var user in users)
                {
                    user.Messages.Add(user.LatestDialogue.Message);
                }
            }
        }
        bool tempbool = true;
        private void User_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var temp = ((UserinList)sender);
            LoadMessagesPage(temp.id);
            temp.SetAsReaded();
            users.Where(x => x.id == temp.id).First().isNewMeesage = false;
            loadUsers();
        }
        private int currentChatid;
        public void LoadMessagesPage(int id)
        {
            currentChatid = id;
            chatPageGrid.Visibility = Visibility.Visible;
            stckPnlChats.Children.Clear();
            var user = users.Where(x => x.id == id).First();
            if (user != null)
            {
                textList.Clear();
                txtToSend.Clear();
                if (user.LatestDialogue != null)
                    if (user.LatestDialogue.Questions != null)
                        foreach (var item in user.LatestDialogue.Questions)
                        {
                            if (!item.isAlreadyUsed)
                                textList.Add(item.Message.Message);
                        }
                imgProf.ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + user.Image, UriKind.Relative));
                lblName.Content = user.Name;
                if (user.Messages != null)
                    foreach (var message in user.Messages)
                    {
                        if (message.Image == "nap")
                        {
                            if (message.Sender == Senders.me)
                            {

                                stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = message.Message, HorizontalAlignment = HorizontalAlignment.Right, SendedTime = message.DateTime.ToShortDateString()+" " + message.DateTime.ToShortTimeString(), sender = Senders.me });
                            }
                            else if (message.Sender == Senders.you)
                            {
                                stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = message.Message, HorizontalAlignment = HorizontalAlignment.Left, SendedTime = message.DateTime.ToShortDateString() + " " + message.DateTime.ToShortTimeString(), sender = Senders.you });

                            }
                        }
                        else
                        {
                            if (message.Sender == Senders.me)
                            {
                                stckPnlChats.Children.Add(new ChatImageItem() { Height = 350, Margin = new Thickness(10), HorizontalAlignment = HorizontalAlignment.Right, Image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + message.Image, UriKind.Relative)), SendedTime = message.DateTime.ToShortDateString() + " " + message.DateTime.ToShortTimeString(), sender = Senders.me });
                            }
                            else if (message.Sender == Senders.you)
                            {
                                stckPnlChats.Children.Add(new ChatImageItem() { Height = 350, Margin = new Thickness(10), HorizontalAlignment = HorizontalAlignment.Left, Image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + message.Image, UriKind.Relative)), SendedTime = message.DateTime.ToShortDateString() + " " + message.DateTime.ToShortTimeString(), sender = Senders.you });

                            }

                        }
                    }
                scrlChat.ScrollToEnd();
                loadUsers();
            }
        }
        private void Send_clicked(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var tttmp = users.Where(x => x.id == currentChatid).First();
                //tttmp.Messages.Add(new ChatMessage() { Sender = Senders.me, Message = txtToSend.Text, DateTime = DateTime.Now });
                tttmp.LatestDialogue.Questions.Where(x => x.Message.Message == txtToSend.Text).First().Message.DateTime = DateTime.Now;
                tttmp.Messages.Add(tttmp.LatestDialogue.Questions.Where(x=>x.Message.Message==txtToSend.Text).First().Message);
                var tttttttt = tttmp.LatestDialogue.Questions.Where(x => x.Message.Message == txtToSend.Text).First();
                tttttttt.Answer.DoTasks();
                tttttttt.isAlreadyUsed = true;
                if (!tttmp.LatestDialogue.Tasks.Any(x => x.Type == TaskType.ReturnToThisDialogue))
                    tttmp.LatestDialogue = tttmp.LatestDialogue.Questions.Where(x => x.Message.Message == txtToSend.Text).First().Answer;

                txtToSend.Clear();
                LoadMessagesPage(currentChatid);
                SaveDb();
            }
            catch { }
        }
        public void SaveDb()
        {
            //System.IO.File.WriteAllText("backup.db", JsonConvert.SerializeObject(users, Formatting.Indented));
        }
        public void LoadDb()
        {
             // JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText("backup.db"));
            //loadUsers();
        }
        private List<string> textList = new List<string>();
        int enumarator = -1;
        private void arrowUpSelectChat(object sender, RoutedEventArgs e)
        {
            if (textList.Count > 0)
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
        }

        private void arrowDownSelectChat(object sender, RoutedEventArgs e)
        {
            if (textList.Count > 0)
            {
                if (enumarator > 0)
                {
                    enumarator--;
                    txtToSend.Text = textList[enumarator];

                }
                else
                {
                    enumarator = textList.Count - 1;
                    txtToSend.Text = textList[enumarator];
                }
            }
        }
        public void loadUsers()
        {
            stackPnlUsers.Children.Clear();
            foreach (var item in users)
            {
                if (item.Messages != null &&item.Messages.Count > 0)
                {
                    
                    stackPnlUsers.Children.Add(new UserinList()
                    {
                        Margin = new Thickness(10),
                        Width = 370,
                        Height = 80,
                        Username = item.Name,
                        ChatPreview = item.Messages[item.Messages.Count - 1].Message,
                        ProflePic = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + item.Image, UriKind.Relative)),
                        id = item.id
                    });
                }
                else
                {
                    stackPnlUsers.Children.Add(new UserinList()
                    {
                        Margin = new Thickness(10),
                        Width = 370,
                        Height = 80,
                        Username = item.Name,
                        ProflePic = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + item.Image, UriKind.Relative)),
                        id = item.id
                    });
                }
                var temp = ((UserinList)stackPnlUsers.Children[stackPnlUsers.Children.Count - 1]);
                if (item.isNewMeesage)
                {
                    temp.SetAsNotReaded();
                }
                temp.MouseDown += User_MouseDown;
            }
        }

    }
}