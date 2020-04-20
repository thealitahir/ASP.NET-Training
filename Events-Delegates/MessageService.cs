using System;

namespace Events_Delegates
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MessageService : Sending message..."+ args.Video.Title);
        }
    }
}
