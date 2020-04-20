using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

//when using static classes how the compiler instanciate the class and the singelton method
//can static classes do inheritance
//static classes dependency injection
//why dependecy injection

namespace Events_Delegates
{
    public class VideoEventArgs: EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
        /*public delegate void VideoEncodedEventHandler(Object source, VideoEventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;*/

        public EventHandler<VideoEventArgs> VideoEncoded;//same functionality as line 19-20 

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video");
            Thread.Sleep(3000);
            onVideoEncoded(video);
        }

        protected virtual void onVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}
