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
        MotionFuntion motionFunction;

        public LeapControllerListener(int width, int height)
        {
            motionFunction = new MotionFuntion(width, height);
        }
        public void OnFrame(object sender, FrameEventArgs args) // 모션 인식 후, 동작 (마우스 이동같이)
        {
            Frame frame = args.frame;
            //Console.WriteLine(frame.Hands.Count);
            if (frame.Hands.Count > 0)
            {
                motionFunction.setMouseCursor(frame);
                motionFunction.grab(frame);
                motionFunction.pinch(frame);
                motionFunction.grabPull(frame);
                motionFunction.wheel(frame);
            }
        }

        // Device connection check listener
        public void OnConnect(object sender, DeviceEventArgs args)
        {
            //Console.WriteLine(args.Device.IsStreaming.ToString());
        }

        //public void OnDisConnect(object sender, DeviceEventArgs args)
        //{
        //    Console.WriteLine(args.Device.IsStreaming.ToString());
        //}
    }
}

