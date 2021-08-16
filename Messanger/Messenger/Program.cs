using System;
using System.Text;

namespace Messenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var vova = new Messenger("vova");
            var dima = new Messenger("dima");

            TelecomStation.Connect(vova, dima);
            TelecomStation.Connect(dima, vova);

            vova.Send("Димон чемпион!");
            dima.Send("drugs");

            Console.ReadKey();
        }
    }
}
