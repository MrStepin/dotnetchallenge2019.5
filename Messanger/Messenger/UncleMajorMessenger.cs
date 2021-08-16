using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    class UncleMajorMessenger : IMessenger
    {
        private readonly IMessenger _majorMessenger;

        public UncleMajorMessenger (IMessenger majorMessenger)
        {
            _majorMessenger = majorMessenger;
        }

        string[] stopWords = new string[3] { "bomb", "kill", "drugs"};

        public string Name { get; set ;  }

        private IMessenger _to { get; set; }

        public void Connect(IMessenger to)
        {
            _to = to;
        }

        public void Send(string message)
        {
            _majorMessenger.OnMessage(this, message);
        }

        public void OnMessage(IMessenger sender, string message)
        {
            Name = _majorMessenger.Name;
            string[] cachedMessage = message.Split(' ');
            foreach (string wordFromMessage in cachedMessage)
            {
                foreach (string word in stopWords)
                {
                    if (word == wordFromMessage)
                    {
                        Console.WriteLine(sender.Name + ". Black volga is coming to you soon.");
                        return;
                    }
                }
            }
            Console.WriteLine(Name + " received message from " + sender.Name + ": " + message);
        }
    }
}
