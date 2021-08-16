namespace Messenger
{
    class TelecomStation
    {
        public static void Connect(IMessenger from, IMessenger to)
        {
            IMessenger KGB = new UncleMajorMessenger(to);
            from.Connect(KGB);
        }
    }
}