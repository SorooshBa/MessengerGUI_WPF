using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ChatRoomStoryTeller.Story;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            textList.Add("text1");
            textList.Add("text2");
            textList.Add("text3");
            textList.Add("text4");

            //users.Add(new User()
            //{
            //    Name = "Ali",
            //    Image = "profile.jpg",
            //    id = 1
            //});
            //List<ChatMessage> messages = new List<ChatMessage>();
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "Hello" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "hiii" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "how you doing?" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "im good" });
            //messages.Add(new ChatMessage() { Sender = Senders.you, DateTime = DateTime.Now, Message = "what about you?" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Message = "nothing" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Image= "template.jpg" });
            //messages.Add(new ChatMessage() { Sender = Senders.me, DateTime = DateTime.Now, Image= "profile2.jpg" });
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
            LoadDb();
            Dialogue d1 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "hello", DateTime = DateTime.Now } };
            Dialogue d2 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "im ali", DateTime = DateTime.Now } };
            Dialogue d3 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "okay", DateTime = DateTime.Now } };
            Dialogue d4 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "go to hell", DateTime = DateTime.Now } };
            Dialogue d5 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "okay", DateTime = DateTime.Now } };


            d5.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, param1 = "2", param2 = "Helllooo" });
            d1.Tasks.Add(new TaskItem() { Type = TaskType.ReturnToThisDialogue });
            d2.Tasks.Add(new TaskItem() { Type = TaskType.ReturnToThisDialogue });
            d3.Tasks.Add(new TaskItem() { Type = TaskType.NewUser, param1 = "3", param2 = "user3", param3 = "profile.jpg" });
            d3.Tasks.Add(new TaskItem() { Type = TaskType.ReturnToThisDialogue });
            d4.Tasks.Add(new TaskItem() { Type = TaskType.RemoveChat });
            d1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "hello who are you?", DateTime = DateTime.Now }, Answer = d2 });
            d1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "shut the fuck up bitch", DateTime = DateTime.Now }, Answer = d4 });
            d1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "tell user3 to text me", DateTime = DateTime.Now }, Answer = d3 });
            d1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "tell user3 to send a message to me", DateTime = DateTime.Now }, Answer = d5 });

            users[0].LatestDialogue = d1;
            loadUsers();

        }
        bool tempbool = true;
        private void User_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var temp = ((UserinList)sender);
            LoadMessagesPage(temp.id);
            temp.SetAsReaded();
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

                                stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = message.Message, HorizontalAlignment = HorizontalAlignment.Right, SendedTime = message.DateTime.ToShortTimeString(), sender = Senders.me });
                            }
                            else if (message.Sender == Senders.you)
                            {
                                stckPnlChats.Children.Add(new ChatItem() { Margin = new Thickness(10), Text = message.Message, HorizontalAlignment = HorizontalAlignment.Left, SendedTime = message.DateTime.ToShortTimeString(), sender = Senders.you });

                            }
                        }
                        else
                        {
                            if (message.Sender == Senders.me)
                            {
                                stckPnlChats.Children.Add(new ChatImageItem() { Height = 350, Margin = new Thickness(10), HorizontalAlignment = HorizontalAlignment.Right, Image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + message.Image, UriKind.Relative)), SendedTime = message.DateTime.ToShortTimeString(), sender = Senders.me });
                            }
                            else if (message.Sender == Senders.you)
                            {
                                stckPnlChats.Children.Add(new ChatImageItem() { Height = 350, Margin = new Thickness(10), HorizontalAlignment = HorizontalAlignment.Left, Image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + message.Image, UriKind.Relative)), SendedTime = message.DateTime.ToShortTimeString(), sender = Senders.you });

                            }

                        }
                    }
                scrlChat.ScrollToEnd();
                loadUsers();
            }
        }
        private void Send_clicked(object sender, MouseButtonEventArgs e)
        {
            var tttmp = users.Where(x => x.id == currentChatid).First();
            tttmp.Messages.Add(new ChatMessage() { Sender = Senders.me, Message = txtToSend.Text, DateTime = DateTime.Now });
            var tttttttt = tttmp.LatestDialogue.Questions.Where(x => x.Message.Message == txtToSend.Text).First();
            tttttttt.Answer.DoTasks();
            tttttttt.isAlreadyUsed = true;
            if (!tttmp.LatestDialogue.Tasks.Any(x => x.Type == TaskType.ReturnToThisDialogue))
                tttmp.LatestDialogue = tttmp.LatestDialogue.Questions.Where(x => x.Message.Message == txtToSend.Text).First().Answer;

            txtToSend.Clear();
            LoadMessagesPage(currentChatid);
            SaveDb();
        }
        public void SaveDb()
        {
            System.IO.File.WriteAllText("backup.db", JsonConvert.SerializeObject(users, Formatting.Indented));
        }
        public void LoadDb()
        {
            users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText("backup.db"));
            loadUsers();
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
                if (item.Messages != null)
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