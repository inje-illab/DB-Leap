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
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dwExtraInfo);

        double pointX = 0.0, pointY = 0.0;
        bool sensitiveMoving = false;
        bool pinch_ready = false;
        private int screenWidth, screenHeight;
        private int frameCount = 0;


        public MotionFuntion(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void grab(Frame frame)
        {
            if (frame.Hands.Count == 2)
            {
                Hand hand = frame.Hands[1];
                if (hand.GrabStrength == (int)MotionEnum.GRAB.Grab && !sensitiveMoving)
                {
                    sensitiveMoving = true;
                    pointX = Cursor.Position.X;
                    pointY = Cursor.Position.Y;
                    //Console.WriteLine("세부동작 감지 : " + pointX + ", " + pointY);
                }
                else if (hand.GrabStrength == (int)MotionEnum.GRAB.UnGrab && sensitiveMoving)
                {
                    sensitiveMoving = false;
                }
            }
            else
            {
                sensitiveMoving = false;
            }
        }

        public void pinch(Frame frame)
        {
            Hand hand = frame.Hands[0];
            if (hand.PinchStrength == 1 && !pinch_ready)
                pinch_ready = true;
            else if (hand.PinchStrength == 1 && pinch_ready)
            {
                frameCount++;
                //if (frameCount == 180)
                //{
                //    mouse_event((uint)MotionEnum.MOUSE.MouseRightDown, 0, 0, 0, 0);
                //    mouse_event((uint)MotionEnum.MOUSE.MouseRightUp, 0, 0, 0, 0);
                //    Console.WriteLine("R클릭~");
                //    pinch_ready = false;
                //    frameCount = 0;
                //}

            }
            else if (hand.PinchStrength == 0 && pinch_ready)
            {
                if (frameCount < 180)
                {
                    mouse_event((uint)MotionEnum.MOUSE.MouseLeftDown, 0, 0, 0, 0);
                    mouse_event((uint)MotionEnum.MOUSE.MouseLeftUp, 0, 0, 0, 0);
                    Console.WriteLine("삔취~");
                    pinch_ready = false;
                    frameCount = 0;
                }
                else
                {
                    mouse_event((uint)MotionEnum.MOUSE.MouseRightDown, 0, 0, 0, 0);
                    mouse_event((uint)MotionEnum.MOUSE.MouseRightUp, 0, 0, 0, 0);
                    Console.WriteLine("R클릭~");
                    pinch_ready = false;
                    frameCount = 0;
                }
            }
        }

        public void setMouseCursor(Frame frame)
        {
            if (!sensitiveMoving)
            {
                //Console.WriteLine("{0}, {1}, {2}, {3}", Cursor.Position.X, Cursor.Position.Y, frame.Hands[0].PalmPosition.x, frame.Hands[0].PalmPosition.y);
                double mousePointX = (frame.Hands[0].PalmPosition.x + 300) / 600 * screenWidth;
                double mousePointY = (1 - (frame.Hands[0].PalmPosition.y - 200) / 300) * screenHeight;
                SetCursorPos((int)mousePointX, (int)mousePointY);
                //Console.WriteLine("일반동작 감지 : " + (int)mousePointX + ", " + (int)mousePointY + " = " + frame.Hands.Count);
            }
            else
            {
                double mousePointX = (frame.Hands[0].PalmPosition.x + 300) / 600 * screenWidth;
                double mousePointY = (1 - (frame.Hands[0].PalmPosition.y - 200) / 300) * screenHeight;
                double scaledX = (mousePointX - pointX) / 300;
                double scaledY = (mousePointY - pointY) / 300;
                //if (Math.Abs(scaledX) > 1)
                    pointX += scaledX;
                //if (Math.Abs(scaledY) > 1)
                    pointY += scaledY;

                SetCursorPos((int)pointX, (int)pointY);
                //Console.WriteLine("세부동작 감지 : " + pointX + ", " + pointY + " = " + frame.Hands.Count);
            }
        }

        public void leapMouseWheelEvent(Leap.Frame frame)
        {
            if (frame.Hands[0].PalmNormal.z < -0.65)
            {
                // 150 = 스크롤 업
                mouse_event((uint)MotionEnum.MOUSE.MouseWheel, 0, 0, 150, 0);
            }
            else if (frame.Hands[0].PalmNormal.z > 0.35)
            {
                // -150 = 스크롤 다운
                mouse_event((uint)MotionEnum.MOUSE.MouseWheel, 0, 0, -150, 0);
            }
        }

        //public void pinch(Frame frame)    // 모션추가 베이직
        //{
        //    Hand hand = frame.Hands[0];
        //}
    }
}
