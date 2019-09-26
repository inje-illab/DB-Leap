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
        bool grab_ready = false;
        public MotionFuntion()
        { }
        // 
        public void grab(Frame frame)
        {
            Hand hand = frame.Hands[0];
            Console.WriteLine(hand.GrabStrength);
            if (hand.GrabStrength == 1 && !grab_ready)
                grab_ready = true;
            else if (hand.GrabStrength == 0 && grab_ready)
            {
                grab_ready = false;
                MessageBox.Show("Grab 동작");
            }
        }
    }
}
