using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller.Story
{
    public class StoryManager
    {
        public static void LoadDailogus()
        {
            Dialogue olid1 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "Hey Cassy Where have you been? Im a bit worried about you." } };
            MainWindow.users[0].LatestDialogue = olid1;
            Dialogue olid2 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "Where is Cassy? She was absent today again at school" } };
            Dialogue olid3 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "What happened cassy? Oh god just tell me" } };
            Dialogue olid4 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "Oh god, I hope she's fine." } };
            Dialogue olid5 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "I saw her yesterday at the school. She was happy nothing abnormal" } };
            Dialogue olid6 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "She was also absent the day before yesterday" } };
            Dialogue olid7 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "You mean Jacob?" } };
            Dialogue olid8 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "They were hanging out, but Jacob was a bit nervous this week " } };
            Dialogue olid9 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "What happened Mr.Hall?" } };
            Dialogue olid10 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "Cassey you'r making fun of me? Send a picture asap" } };
            Dialogue olid11 = new Dialogue() { UserId=1,Message= new ChatMessage() {Sender=Senders.you,Message= "Oh god, I'm scared. I dont want No more troubles because of cassey.\r\nI think there is a bullet inside your face. How it didn't kill you? \r\nWith that amount of infection on your blood you should be numb\r\nOn all of your body" } };
            Dialogue olid12 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "Cant help you Mr.Hall. I hope someone else help you. My parents\r\nCan not take another problem because of you'r daughter cassey\r\n" } };


            Dialogue sar1 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "I'm Sara, Jacob's sister. Is he with you?" } };
            Dialogue sar2 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "He should attend yum kipur in our house. You know my parent's\r\nDon't like you from the first day. Don’t make it worse." } };
            Dialogue sar3 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "I always thought my parent are ultraorthodox,  but it seems they \r\nThey were right about you" } };
            Dialogue sar4 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "Yesterday morning, and he was so nervous, he did hug me and my\r\nMom while he's hand was shaking before going to school. Now \r\nWe don’t know where he is, thanks to you " } };
            Dialogue sar5 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "Oh god Cassey. Some mob came to our house for Jacob. Wtf \r\nAre guys doing? Don’t make trouble again" } };
            sar3.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, messageTextTosend = "Oh god Cassey. Some mob came to our house for Jacob. Wtf \r\nAre guys doing? Don’t make trouble again", useridToSendMessage = 3,userid=-1, param4 = sar5 });
            sar4.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, messageTextTosend = "Oh god Cassey. Some mob came to our house for Jacob. Wtf \r\nAre guys doing? Don’t make trouble again", useridToSendMessage = 3,userid=-1, param4 = sar5 });
            Dialogue sar6 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "He said Jacoob should pay him 560$, otherwise he will harm us" } };
            Dialogue sar7 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "My family doesn't want troubles. Jacoob not responding my text.\r\nI will give your phone number to the mob. Handle it yourselves." } };
            Dialogue sar8 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "Hi, we are so worried about jacoob please tell him to comeback." } };
            Dialogue sar9 = new Dialogue() { UserId = 3, Message = new ChatMessage() { Sender = Senders.you, Message = "Oh god Mr.Hall they arrested my brother at the party.\r\nHe asked me to record his voice for you and he gave me a letter \r\nFor you" } };
            sar9.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, messageTextTosend = "Jacoob voice:\r\nI'm sorry Mr.Hall. So sorry. The mob killed Cassey.\r\nI wanted to stop her from shooting you. I also putted my hand Infront of the \r\nWeapon. But cassey shot anyway. My hand got a hole inside of it.\r\nJust like…\r\nOh god she shot you anyway. I think my hand decreased the damage of the bullet\r\nSo you are alive. But I don’t know how to beg you to pardon me.\r\nThis is her last letter she wrote it for you.", useridToSendMessage = 3, userid = -1 });
            sar9.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, messageTextTosend = "Cassandra's Letter:\r\nJacob didn't let me see you at the last second of you're life.\r\nBut I saw your face when I shot. It was a hole inside your right cheek.\r\nYou were so beautiful. You always like the red color. Now you half face was red.\r\nI always asked you this question , did you actually love me because of myself.\r\nOr just because I came out from the womb that you were came before.\r\nI hate having thing's that I made no effort to gain. Even the love of father.\r\nI could simply ask for all of your money. And you would give it to me.\r\nBut as I said without any effort. So gross. Now I have all of your money that I made\r\nWith effort. I even made a hole in my jacob's hand. But it's all a part of my effort.\r\nBut even after I killed you. You don't stop to bothering me. I feel your sprit everywhere.\r\nJacob told me to write my thoughts on paper so it comes out of my mind. And then\r\nI can put that paper inside a toilet and flush it off…\r\nJust like how I did with your body.", useridToSendMessage = 3, userid = -1 });




            Dialogue mob1 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "Give my fucking money back you whore." } };
            Dialogue mob2 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "The guy who will shoot you in the face if you don’t pay him \r\nsoon enough" } };
            Dialogue mob3 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "You idiot or something? 5g of what?" } };
            Dialogue mob4 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "Haha. I ain't a drug dealer. But I con give you more of something\r\nBetter With that money." } };
            Dialogue mob5 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "Another fucking Ruger Lightweight Compact Pistol.\r\nBut after you gave me my fucking moneyyyy." } };
            Dialogue mob6 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "There's a party btw this week wanna join?\r\nThere's people you probably like." } };
            Dialogue mob7 = new Dialogue() { UserId = 4, Message = new ChatMessage() { Sender = Senders.you, Message = "It's 17T 331009.9555788 4687546.6416017. Don’t be a pussy." } };

            mob7.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, useridToSendMessage = 3, messageTextTosend = "Hi, we are so worried about jacoob please tell him to comeback.", param4 = sar8 });
            sar7.Tasks.Add(new TaskItem() { Type = TaskType.NewUser, userid = 4, userename = "Unknown Number", image = "/img/profile.jpg" });
            sar7.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, useridToSendMessage=4,messageTextTosend= "Give my fucking money back you whore.",param4=mob1 });

            olid12.Tasks.Add(new TaskItem() { Type = TaskType.RemoveChat });
            olid12.Tasks.Add(new TaskItem() { Type = TaskType.NewUser,userid=3,image= "/img/sara.jpg",userename="Sara Adams" });
            olid12.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage,useridToSendMessage=3,messageTextTosend= "I'm Sara, Jacob's sister. Is he with you?",param4=sar1 });
            Dialogue olid13 = new Dialogue() { UserId = 1, Message = new ChatMessage() { Sender = Senders.you, Message = "What wrong with you cassy? You keep making troubles for me\r\nPut me out of this." } };
            olid13.Tasks.Add(new TaskItem() { Type = TaskType.RemoveChat });
            olid13.Tasks.Add(new TaskItem() { Type = TaskType.NewUser, userid = 3, image = "/img/sara.jpg", userename = "Sara Adams" });
            olid13.Tasks.Add(new TaskItem() { Type = TaskType.MakeAnotherUserSendMessage, useridToSendMessage = 3, messageTextTosend = "I'm Sara, Jacob's sister. Is he with you?", param4 = sar1 });


            olid1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "This is Andrew Hall, Cassandra's Father" } });
            olid1.Questions.Last().Answer = olid2;
            olid1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I need help" } });
            olid1.Questions.Last().Answer = olid3;
            olid1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Call you'r parents" } });
            olid1.Questions.Last().Answer = olid3;


            olid2.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "She's missing." } });
            olid2.Questions.Last().Answer= olid4;
            olid2.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I wanted to ask you about Cassandra." } });
            olid2.Questions.Last().Answer = olid5;

            olid3.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "This is Andrew Hall, Cassandra's Father" } });
            olid3.Questions.Last().Answer = olid9;
            olid3.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Can't tell you right now" } });
            olid3.Questions.Last().Answer = olid13;

            olid4.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Look Olivia I need your help" } });
            olid4.Questions.Last().Answer = olid9;

            olid5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "She's missing" } });
            olid5.Questions.Last().Answer = olid4;
            olid5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "What about before that?" } });
            olid5.Questions.Last().Answer = olid6;

            olid6.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "What about the boyfriend of Her?" } });
            olid6.Questions.Last().Answer = olid7;

            olid7.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Yes, Jacob Adams." } });
            olid7.Questions.Last().Answer = olid8;
            olid7.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Yes, The boy with beard" } });
            olid7.Questions.Last().Answer = olid8;

            olid8.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I can't type anymore I need your help" } });
            olid8.Questions.Last().Answer = olid9;

            olid9.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "My whole body is numb" } });
            olid9.Questions.Last().Answer = olid10;
            olid9.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "There is blood everywhere" } });
            olid9.Questions.Last().Answer = olid10;

            olid10.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "{send image}", Image= "/img/bulletface.png" } });
            olid10.Questions.Last().Answer = olid11;

            olid11.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Help me olivia" } });
            olid11.Questions.Last().Answer = olid12;
            olid11.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Call your parents. I'm begging you" } });
            olid11.Questions.Last().Answer = olid12;

            sar1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "No, He's not" } });
            sar1.Questions.Last().Answer = sar2;
            sar1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Yes, He is" } });
            sar1.Questions.Last().Answer = sar2;

            sar2.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I don't care what you or you'r family think about us" } });
            sar2.Questions.Last().Answer = sar3;
            sar2.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "When you saw him last time?" } });
            sar2.Questions.Last().Answer = sar4;

            sar5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Why who?" } });
            sar5.Questions.Last().Answer = sar6;
            sar5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "What happened?" } });
            sar5.Questions.Last().Answer = sar6;
            sar5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Do I look like I give a shit about you're family?" } });
            sar5.Questions.Last().Answer = sar7;

            sar6.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "For what?" } });
            sar6.Questions.Last().Answer = sar7;
            sar6.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "How was he look like?" } });
            sar6.Questions.Last().Answer = sar7;

            mob1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Who the hell are ya?" } });
            mob1.Questions.Last().Answer = mob2;
            mob1.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I need 5 more grams." } });
            mob1.Questions.Last().Answer = mob3;

            mob2.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Don’t worry I just want 5 more grams." } });
            mob2.Questions.Last().Answer = mob3;

            mob3.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Cocaine" } });
            mob3.Questions.Last().Answer = mob4;

            mob4.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Like What?" } });
            mob4.Questions.Last().Answer = mob5;
            mob4.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Sound's good" } });
            mob4.Questions.Last().Answer = mob5;

            mob5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I will pay you soon" } });
            mob5.Questions.Last().Answer = mob6;
            mob5.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Let me see what I can do for ya" } });
            mob5.Questions.Last().Answer = mob6;

            mob6.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "No I don’t want to" } });
            mob6.Questions.Last().Answer = mob7;
            mob6.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "Give me the location" } });
            mob6.Questions.Last().Answer = mob7;

            sar8.Questions.Add(new Question() { Message = new ChatMessage() { Sender = Senders.me, Message = "I'm Cassey's father there is going to be a party at 17T 331009.9555788 4687546.6416017 \r\nSend police after the mob they may find a clue" } });
            sar8.Questions.Last().Answer = sar9;


        }
    }
}
