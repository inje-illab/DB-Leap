using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leap
{
    class MotionFuntion     // 모션 인식함수
    {
        public MotionFuntion()
        { }
        // 
        public void grab(Frame frame)
        {
            Hand hand = frame.Hands[0];
            int handpalmX = (int)hand.PalmNormal.x;
            Console.WriteLine(handpalmX);

            //int grab_integer = (int)frame.Hands[0].GrabStrength;
            //bool grab_ready = false;
            //if (grab_integer == 1 && !grab_ready)
            //    grab_ready = true;
            //else if (grab_integer == 0 && grab_ready)
            //{
            //    grab_ready = false;
            //    MessageBox.Show("Grab 동작");
            //}
        }
    }
}
