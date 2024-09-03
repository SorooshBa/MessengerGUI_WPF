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
                    await Task.Delay(3000);
                    MainWindow.users.Where(x=>x.id==UserId).First().Messages.Add(Message);
                    MainWindow._instance.LoadMessagesPage(UserId);
                }
                if(task.Type == TaskType.RemoveChat)
                {
                    foreach (var item in MainWindow.users.Where(x => x.id == UserId).First().Messages)
                    {
                        item.Message = "[deleted]";
                        MainWindow._instance.LoadMessagesPage(UserId);
                    }
                }
                if(task.Type==TaskType.NewUser)
                {
                    MainWindow.users.Add(new User() { id = Int32.Parse(task.param1), Name = task.param2, Image = task.param3 });
                    MainWindow._instance.loadUsers();
                }
                if(task.Type==TaskType.MakeAnotherUserSendMessage)
                {
                    var temp = MainWindow.users.Where(x => x.id == Int32.Parse(task.param1)).First();
                    temp.Messages.Add(new ChatMessage() { Sender = Senders.you, Message = task.param2, DateTime = DateTime.Now });
                    temp.LatestDialogue = task.param4;
                }
                
                MainWindow._instance.SaveDb();
            }
        }
    }
}
