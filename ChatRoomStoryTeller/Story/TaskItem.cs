using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller.Story
{
    public class TaskItem
    {
        public TaskType Type { get; set; } = TaskType.None;
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public Dialogue param4 { get; set; }
        public Dialogue param5 { get; set; }
    }
    public enum TaskType
    {
        None,
        NewUser,
        RemoveChat,
        ReturnToThisDialogue,
        AddQuestionToDialogue,
        MakeAnotherUserSendMessage
    }
}
