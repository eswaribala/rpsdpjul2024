using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace MediatorPatternApp
{

    // Mediator
    public interface IChatRoom
    {
        void Register(Participant participant);
        void Send(string from, string to, string message);
    }
    public class ChatRoom : IChatRoom
    {
        private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();
        public void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
                participant.ChatRoom = this;
            }
        }
        public void Send(string from, string to, string message)
        {
            Participant participant = _participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }
    // Colleague
    public class Participant
    {
        public string Name { get; private set; }
        public IChatRoom ChatRoom { get; set; }
        public Participant(string name)
        {
            Name = name;
        }
        public void Send(string to, string message)
        {
            ChatRoom.Send(Name, to, message);
        }
        public void Receive(string from, string message)
        {
            Console.WriteLine($"{from} to {Name}: '{message}'");
        }
    }
    // Testing the Mediator Design Pattern
    // Client Code
    public class Client
    {
        public static void Main()
        {
            var chatroom = new ChatRoom();
            var john = new Participant("John");
            var jane = new Participant("Jane");
            chatroom.Register(john);
            chatroom.Register(jane);
            john.Send("Jane", "Hey there!");
            jane.Send("John", "Hi John!");
            Console.ReadKey();
        }
    }
}
