using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leap
{
    public static class MotionEnum
    {
        // ex) (long) MotionEnum.GRAB.Grab => 1
        // ex) MotionEnum.GRAB.Grab => Grab
        public enum GRAB : long { Grab = 1L, UnGrab = 0 }
        public enum PINCH : long { Pinch = 1L, UnPinch = 0 }
        public enum MOUSE : int
        {
            MouseLeftDown = 0x02,
            MouseLeftUp = 0x04,
            MouseRightDown = 0x08,
            MouseRightUp = 0x10,
            MouseWheel = 0x00000800
        }
    }
}