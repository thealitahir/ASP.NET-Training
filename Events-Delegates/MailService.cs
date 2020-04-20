using System;

namespace Events_Delegates
{
    public class MailService
    {
        public void onVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
        }
    }
}
