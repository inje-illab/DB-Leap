using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leap
{
    class GunAction
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        internal static extern void ReleaseDC(IntPtr dc);

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
            IntPtr hdcSrc = GetDC(IntPtr.Zero);
            //int hdcSrc = GetWindowDC(GetDesktopWindow());
            Graphics g = Graphics.FromHdc(hdcSrc);
            //int newcolor = ColorTranslator.ToWin32(clr);
            //int myPen = CreatePen(0, 1, newcolor);
            //int myBrush = CreateSolidBrush(newcolor);
            //SelectObject(hdcSrc, myPen);
            //SelectObject(hdcSrc, myBrush);

            g.FillEllipse(new SolidBrush(Color.Red), x, x + 1, y, y + 1);
            //DeleteDC(hdcSrc);
            //DeleteObject(myBrush);
            //g.Clear(Color.Empty);

            g.Dispose();
            ReleaseDC(hdcSrc);
            //Console.WriteLine("clabGun 실행");

        }
    }
}
