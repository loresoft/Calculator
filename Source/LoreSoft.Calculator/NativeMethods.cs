using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LoreSoft.Calculator
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DebuggerNonUserCode]
        public static bool IsNumLockOn
        {
            get
            {
                byte[] keyState = new byte[255];
                bool result = GetKeyboardState(keyState);
                return (result && keyState[(int)Keys.NumLock] == 1);
            }
        }

        [DebuggerNonUserCode]
        public static bool IsCapsLockOn
        {
            get
            {
                byte[] keyState = new byte[255];
                bool result = GetKeyboardState(keyState);
                return (result && keyState[(int)Keys.CapsLock] == 1);
            }
        }

        [DebuggerNonUserCode]
        public static bool IsScrollLockOn
        {
            get
            {
                byte[] keyState = new byte[255];
                bool result = GetKeyboardState(keyState);
                return (result && keyState[(int)Keys.Scroll] == 1);
            }
        }
    }
}
