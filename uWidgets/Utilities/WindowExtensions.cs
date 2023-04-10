using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace uWidgets.Utilities;

public static class WindowExtensions
{
    public static Screen GetCurrentScreen(this Window window)
    {
        return Screen.FromHandle(new WindowInteropHelper(window).Handle);
    }

    public static void DisableSnapping(this Window window)
    {
        const int WM_SYSCOMMAND = 0x112;
        const int SC_MOVE = 0xF010;
        const int WM_MOUSELEAVE = 0x2A2;
        
        var source = PresentationSource.FromVisual(window) as HwndSource;
        source?.AddHook(DisableSnappingHook);
        
        IntPtr DisableSnappingHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SYSCOMMAND)
            {
                if ((wParam.ToInt32() & ~0x0F) == SC_MOVE)
                    window.ResizeMode = ResizeMode.NoResize;
            }
            else if (msg == WM_MOUSELEAVE)
            {
                window.ResizeMode = ResizeMode.CanResize;
            }

            return IntPtr.Zero;
        }
    }

    public static void RemoveFromAltTab(this Window window)
    {
        IntPtr handle = new WindowInteropHelper(window).Handle;

        int exStyle = (int)GetWindowLong(handle, (int)GetWindowLongFields.GWL_EXSTYLE);

        exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
        SetWindowLong(handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
    }
    
    [Flags]
    private enum ExtendedWindowStyles
    {
        // ...
        WS_EX_TOOLWINDOW = 0x00000080,
        // ...
    }

    private enum GetWindowLongFields
    {
        // ...
        GWL_EXSTYLE = (-20),
        // ...
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

    public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
    {
        int error = 0;
        IntPtr result = IntPtr.Zero;
        // Win32 SetWindowLong doesn't clear error on success
        SetLastError(0);

        if (IntPtr.Size == 4)
        {
            // use SetWindowLong
            Int32 tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
            error = Marshal.GetLastWin32Error();
            result = new IntPtr(tempResult);
        }
        else
        {
            // use SetWindowLongPtr
            result = IntSetWindowLongPtr(hWnd, nIndex, dwNewLong);
            error = Marshal.GetLastWin32Error();
        }

        if ((result == IntPtr.Zero) && (error != 0))
        {
            throw new System.ComponentModel.Win32Exception(error);
        }

        return result;
    }

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
    private static extern IntPtr IntSetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
    private static extern Int32 IntSetWindowLong(IntPtr hWnd, int nIndex, Int32 dwNewLong);

    private static int IntPtrToInt32(IntPtr intPtr)
    {
        return unchecked((int)intPtr.ToInt64());
    }

    [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
    private static extern void SetLastError(int dwErrorCode);
}