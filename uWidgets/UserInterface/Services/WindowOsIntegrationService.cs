using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace uWidgets.UserInterface.Services;

public static class WindowOsIntegrationService
{
    public static void DisableWindowSnapping(Window window)
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

    public static void RemoveWindowFromAltTab(Window window)
    {
        const int WS_EX_TOOLWINDOW = 0x00000080;
        const int GWL_EXSTYLE = -20;
        
        IntPtr handle = new WindowInteropHelper(window).Handle;

        int exStyle = (int)GetWindowLong(handle, GWL_EXSTYLE);

        exStyle |= WS_EX_TOOLWINDOW;
        SetWindowLong(handle, GWL_EXSTYLE, (IntPtr)exStyle);
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

    private static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
    {
        var error = 0;
        var result = IntPtr.Zero;
        
        SetLastError(0);

        if (IntPtr.Size == 4)
        {
            var tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
            error = Marshal.GetLastWin32Error();
            result = new IntPtr(tempResult);
        }
        else
        {
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

    private static int IntPtrToInt32(IntPtr intPtr) => unchecked((int)intPtr.ToInt64());

    [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
    private static extern void SetLastError(int dwErrorCode);
}