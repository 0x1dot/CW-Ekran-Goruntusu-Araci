using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CW_Ekran_Görüntüsü_Aracı
{
    public sealed class SCapture
    {
        public static Bitmap FullScreen(bool includeCursor)
        {
            return SCapture.ScreenRectangle(SystemInformation.VirtualScreen, includeCursor);
        }
        public static Bitmap DisplayMonitor(Screen monitor, bool includeCursor)
        {
            if (monitor != null)
            {
                return SCapture.ScreenRectangle(monitor.Bounds, includeCursor);
            }
            throw new SCaptureException("The monitor cannot be Null (Nothing in VB).");
        }
        public static Bitmap ActiveWindow(bool includeCursor)
        {
            IntPtr foregroundWindow = SCapture.UnsafeNativeMethods.GetForegroundWindow();
            if (foregroundWindow != IntPtr.Zero)
            {
                return SCapture.Control(foregroundWindow, includeCursor);
            }
            throw new SCaptureException("Could not find any active window.");
        }
        public static Bitmap Window(Point screenPoint, bool includeCursor)
        {
            IntPtr intPtr = SCapture.UnsafeNativeMethods.WindowFromPoint(screenPoint);
            if (!(intPtr != IntPtr.Zero))
            {
                throw new SCaptureException("Could not find any window at the specified point.");
            }
            IntPtr ancestor = SCapture.UnsafeNativeMethods.GetAncestor(intPtr, 3u);
            if (ancestor != IntPtr.Zero)
            {
                return SCapture.Control(ancestor, includeCursor);
            }
            return SCapture.Control(intPtr, includeCursor);
        }
        public static Bitmap Window(IntPtr handle, bool includeCursor)
        {
            if (handle != IntPtr.Zero)
            {
                return SCapture.Control(handle, includeCursor);
            }
            throw new SCaptureException("Invalid window handle.");
        }
        public static Bitmap Control(Point screenPoint, bool includeCursor)
        {
            IntPtr intPtr = SCapture.UnsafeNativeMethods.WindowFromPoint(screenPoint);
            if (intPtr != IntPtr.Zero)
            {
                return SCapture.Control(intPtr, includeCursor);
            }
            throw new SCaptureException("Could not find any control at the specified point.");
        }
        public static Bitmap Control(Control ctrl)
        {
            Bitmap bitmap = new Bitmap(ctrl.Width, ctrl.Height);
            Bitmap bitmap2 = bitmap;
            Rectangle targetBounds = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
            ctrl.DrawToBitmap(bitmap2, targetBounds);
            return bitmap;
        }
        static SCapture.Rect rect;
        public static Bitmap Control(IntPtr handle, bool includeCursor)
        {
            if (!(handle != IntPtr.Zero))
            {
                throw new SCaptureException("Invalid control handle.");
            }
            
            if (!SCapture.UnsafeNativeMethods.GetWindowRect(handle, ref rect))
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new SCaptureException(new Win32Exception(lastWin32Error).Message);
            }
            return SCapture.ScreenRectangle(rect.ToRectangle(), includeCursor);
        }
        public static Bitmap ScreenRectangle(Rectangle rect, bool includeCursor)
        {
            if (!rect.IsEmpty && rect.Width != 0 && rect.Height != 0)
            {
                Bitmap image = SCapture.GetImage(rect);
                if (includeCursor)
                {
                    SCapture.DrawCursor(rect, image);
                }
                return image;
            }
            throw new SCaptureException("Empty rectangle.");
        }
        private static Bitmap GetImage(Rectangle rect)
        {
            IntPtr dc = SCapture.GetDC();
            return SCapture.GetImage(dc, rect);
        }
        public static Bitmap GetImage(IntPtr hdc, Rectangle rect)
        {
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            IntPtr hdc2 = graphics.GetHdc();
            if (!SCapture.UnsafeNativeMethods.BitBlt(hdc2, 0, 0, rect.Width, rect.Height, hdc, rect.X, rect.Y, 1087111200u))
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                graphics.ReleaseHdc(hdc2);
                graphics.Dispose();
                throw new SCaptureException(new Win32Exception(lastWin32Error).Message);
            }
            graphics.ReleaseHdc(hdc2);
            SCapture.UnsafeNativeMethods.ReleaseDC(IntPtr.Zero, hdc);
            graphics.Dispose();
            return bitmap;
        }
        private static IntPtr GetDC()
        {
            IntPtr dc = SCapture.UnsafeNativeMethods.GetDC(IntPtr.Zero);
            if (dc == IntPtr.Zero)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new SCaptureException(new Win32Exception(lastWin32Error).Message);
            }
            return dc;
        }
        private static void DrawCursor(Rectangle rect, Bitmap bmp)
        {
            SCapture.CursorInfo cursorInfo = SCapture.GetCursorInfo();
            checked
            {
                if (cursorInfo.flags == 1u && rect.Contains(cursorInfo.ptScreenPos))
                {
                    IntPtr cursorIcon = SCapture.GetCursorIcon(cursorInfo.hCursor);
                    SCapture.IconInfo iconInfo = SCapture.GetIconInfo(cursorIcon);
                    Graphics graphics = Graphics.FromImage(bmp);
                    graphics.DrawIcon(Icon.FromHandle(cursorIcon), (int)(unchecked((long)(checked(cursorInfo.ptScreenPos.X - rect.X))) - (long)(unchecked((ulong)iconInfo.xHotspot))), (int)(unchecked((long)(checked(cursorInfo.ptScreenPos.Y - rect.Y))) - (long)(unchecked((ulong)iconInfo.yHotspot))));
                    graphics.Dispose();
                }
            }
        }
        private static IntPtr GetCursorIcon(IntPtr hCursor)
        {
            IntPtr intPtr = SCapture.UnsafeNativeMethods.CopyIcon(hCursor);
            if (intPtr == IntPtr.Zero)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new SCaptureException(new Win32Exception(lastWin32Error).Message);
            }
            return intPtr;
        }
        private static SCapture.CursorInfo GetCursorInfo()
        {
            SCapture.CursorInfo cursorInfo = default(SCapture.CursorInfo);
            cursorInfo.cbSize = checked((uint)Marshal.SizeOf(cursorInfo));
            if (!SCapture.UnsafeNativeMethods.GetCursorInfo(ref cursorInfo))
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new SCaptureException(new Win32Exception(lastWin32Error).Message);
            }
            return cursorInfo;
        }
        private static SCapture.IconInfo GetIconInfo(IntPtr hicon)
        {
            SCapture.IconInfo result = default(SCapture.IconInfo);
            if (!SCapture.UnsafeNativeMethods.GetIconInfo(hicon, ref result))
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new SCaptureException(new Win32Exception(lastWin32Error).Message);
            }
            return result;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct Rect
        {
            public Rectangle ToRectangle()
            {
                Rectangle result = checked(new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top));
                return result;
            }
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct CursorInfo
        {
            public uint cbSize;
            public uint flags;
            public IntPtr hCursor;
            public Point ptScreenPos;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct IconInfo
        {
            public bool fIcon;
            public uint xHotspot;
            public uint yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        internal sealed class UnsafeNativeMethods
        {
            private UnsafeNativeMethods()
            {
            }
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, ref SCapture.Rect lpRect);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr WindowFromPoint(Point pt);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hwnd);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr CopyIcon(IntPtr hIcon);
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetCursorInfo(ref SCapture.CursorInfo pci);
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetIconInfo(IntPtr hIcon, ref SCapture.IconInfo piconinfo);
            [DllImport("gdi32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
            public const uint CAPTUREBLT = 1073741824u;
            public const uint BLACKNESS = 66u;
            public const uint DSTINVERT = 5570569u;
            public const uint MERGECOPY = 12583114u;
            public const uint MERGEPAINT = 12255782u;
            public const uint NOTSRCCOPY = 3342344u;
            public const uint NOTSRCERASE = 1114278u;
            public const uint PATCOPY = 15728673u;
            public const uint PATINVERT = 5898313u;
            public const uint PATPAINT = 16452105u;
            public const uint SRCAND = 8913094u;
            public const uint SRCCOPY = 13369376u;
            public const uint SRCERASE = 4457256u;
            public const uint SRCINVERT = 6684742u;
            public const uint SRCPAINT = 15597702u;
            public const uint WHITENESS = 16711778u;
            public const uint GA_PARENT = 1u;
            public const uint GA_ROOT = 2u;
            public const uint GA_ROOTOWNER = 3u;
            public const uint CURSOR_SHOWING = 1u;
        }
    }
}
