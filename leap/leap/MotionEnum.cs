using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leap
{
    public static class MotionEnum      // 사용자 입력한 동작이 의미할 모션 
    {
        // ex) (long) MotionEnum.GRAB.Grab => 1
        // ex) MotionEnum.GRAB.Grab => Grab
        public enum GRAB : int { UnGrab, Grab }
        public enum PINCH : int { UnPinch, Pinch }
        public enum MOUSE : uint
        {
            MouseLeftDown = 0x0002,
            MouseLeftUp = 0x0004,
            MouseRightDown = 0x0008,
            MouseRightUp = 0x0010,
            MouseWheel = 0x0800
        }
    }
}