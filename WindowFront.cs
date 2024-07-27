using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class WindowFront : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint uFlags);

    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOZORDER = 0x0010;
    private const uint SWP_SHOWWINDOW = 0x0040;
    private const int HWND_TOPMOST = -1;
    private const int HWND_NOTOPMOST = -2;

    /// <summary>
    /// ウィンドウを最前面にするか切り替える
    /// </summary>
    /// <param name="isOnTop">最前面にするか</param>
    public void SetWindowOnTop(bool isOnTop)
    {
        IntPtr hWnd = GetActiveWindow();
        if (isOnTop)
        {
            SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOZORDER | SWP_SHOWWINDOW);
        }
        else
        {
            SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_SHOWWINDOW);
        }

        //アクティブウィンドウに戻す
        SetForegroundWindow(hWnd);
    }
}
