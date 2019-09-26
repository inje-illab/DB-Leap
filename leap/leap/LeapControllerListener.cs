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
        int mainHandID = 0;
        public void OnFrame(object sender, FrameEventArgs args) // 모션 인식 후, 동작 (마우스 이동같이)
        {
            //foreach (Hand hand in args.frame.Hands)
            //{
            //    if (mainHandID < hand.Id)
            //        mainHandID = hand.Id;

            //}


            try
            {
                Frame frame = args.frame;
                if (frame.Hands.Count > 0)
                {
                    mf.grab(frame);
                    if (frame.Hands.Count == 2)
                    {

                    }
                }
            }
            catch { }
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

