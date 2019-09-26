using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace leap
{
    class LeapControllerListener  
    {
        // Controller Frame Listener
        MotionFuntion mf = new MotionFuntion();
        public void OnFrame(object sender, FrameEventArgs args) // 모션 인식 후, 동작 (마우스 이동같이)
        {
            Frame frame = args.frame;
            foreach(Hand hand in frame.Hands)
            {
                mf.grab(frame);

            }
            
        }

        // Device connection check listener
        public void OnConnect(object sender, DeviceEventArgs args)
        {

            Console.WriteLine(args.Device.IsStreaming.ToString());
        }

        //public void OnDisConnect(object sender, DeviceEventArgs args)
        //{
        //    Console.WriteLine(args.Device.IsStreaming.ToString());
        //}
    }
}

