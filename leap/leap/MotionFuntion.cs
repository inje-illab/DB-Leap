using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace leap
{
    class MotionFuntion     // 모션 인식함수
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        bool grab_ready = false;
        private int screenWidth, screenHeight;

        public MotionFuntion(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void grab(Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.GrabStrength == 1 && !grab_ready)
                grab_ready = true;
            else if (hand.GrabStrength == 0 && grab_ready)
            {
                grab_ready = false;
                MessageBox.Show("Grab 동작");
            }
        }

        public void setMouseCursor(Frame frame)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", Cursor.Position.X, Cursor.Position.Y, frame.Hands[0].PalmPosition.x, frame.Hands[0].PalmPosition.y);
            double mousePointX = (frame.Hands[0].PalmPosition.x + 300) / 600 * screenWidth;
            double mousePointY = (1 - (frame.Hands[0].PalmPosition.y - 200) / 300) * screenHeight;
            SetCursorPos((int)mousePointX, (int)mousePointY);
        }
    }
}
