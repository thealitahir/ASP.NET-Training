using System;

namespace Events_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var viedo = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //Publisher
            var mailService = new MailService(); //Subscriber
            var messageService = new MessageService(); //Subscriber

            videoEncoder.VideoEncoded += mailService.onVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(viedo);
        }
    }
}
