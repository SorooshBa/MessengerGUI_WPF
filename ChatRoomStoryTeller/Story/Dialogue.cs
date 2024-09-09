using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller.Story
{
    public class Dialogue
    {
        public ChatMessage Message {  get; set; }
        public int UserId {  get; set; }
        public List<Question> Questions { get; set; }=new List<Question>();
        public List<TaskItem> Tasks { get; set; } =new List<TaskItem>();
        public bool isStartPoint { get; set; } = true;
        public Dialogue()
        {
            Tasks.Add(new TaskItem() {Type=TaskType.None });
        }
        public async void DoTasks()
        {
            foreach (var task in Tasks)
            {
                if (task.Type == TaskType.None)
                {
                    await Task.Delay(2000);
                    Message.DateTime = DateTime.Now;
                    MainWindow.users.Where(x=>x.id==UserId).First().Messages.Add(Message);
                    MainWindow._instance.LoadMessagesPage(UserId);
                }
                if(task.Type == TaskType.RemoveChat)
                {
                    await Task.Delay(5000);
                    foreach (var item in MainWindow.users.Where(x => x.id == UserId).First().Messages)
                    {
                        item.Message = "[deleted]";
                        MainWindow._instance.LoadMessagesPage(UserId);
                    }
                }
                if(task.Type==TaskType.NewUser)
                {
                    await Task.Delay(2000);
                    MainWindow.users.Add(new User() { id = task.userid, Name = task.userename, Image = task.image });
                    MainWindow._instance.loadUsers();
                }
                if(task.Type==TaskType.MakeAnotherUserSendMessage)
                {
                    await Task.Delay(2000);
                    var temp = MainWindow.users.Where(x => x.id == task.useridToSendMessage).First();
                    temp.Messages.Add(new ChatMessage() { Sender = Senders.you, Message = task.messageTextTosend, DateTime = DateTime.Now });
                    temp.LatestDialogue = task.param4;
                    temp.isNewMeesage = true;
                    MainWindow._instance.loadUsers();
                    if(task.userid==-1)
                    MainWindow._instance.LoadMessagesPage(task.useridToSendMessage);
                }
                
                MainWindow._instance.SaveDb();
            }
        }
    }
}
