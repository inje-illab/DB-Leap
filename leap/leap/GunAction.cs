using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace leap
{
    class GunAction
    {
        [DllImport("GDI32.dll")]
        private static extern bool DeleteDC(int hdc);
        [DllImport("GDI32.dll")]
        private static extern bool DeleteObject(int hObject);
        [DllImport("GDI32.dll")]
        private static extern int SelectObject(int hdc, int hgdiobj);
        [DllImport("User32.dll")]
        private static extern int GetDesktopWindow();
        [DllImport("User32.dll")]
        private static extern int GetWindowDC(int hWnd);
        [DllImport("GDI32.dll")]
        private static extern int LineTo(int hdc, int x, int y);
        [DllImport("GDI32.dll")]
        private static extern int MoveToEx(int hdc, int x, int y, ref Point lppoint);
        [DllImport("GDI32.dll")]
        private static extern int CreatePen(int penstyle, int width, int color);
        [DllImport("GDI32.dll")]
        private static extern int CreateSolidBrush(int color);
        [DllImport("GDI32.dll")]
        private static extern int Ellipse(int hdc, int left, int top, int right, int bottom);

        public static void drawAim(int x, int y, Color clr)
        {
            int hdcSrc = GetWindowDC(GetDesktopWindow());
            int newcolor = ColorTranslator.ToWin32(clr);
            int myBrush = CreateSolidBrush(newcolor);
            SelectObject(hdcSrc, myBrush);
            Ellipse(hdcSrc, x, y, x+10, y+10);
            DeleteDC(hdcSrc);
            DeleteObject(myBrush);
            Console.WriteLine("clabGun 실행");
            
        }
    }
}
