using System;
using System.Runtime.InteropServices;

namespace Ryujinx.Common.System
{
    public class DisplaySleep
    {
        [Flags]
        enum Options : uint
        {
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Options SetThreadExecutionState(Options esFlags);

        static public void Prevent()
        {
            if (OperatingSystem.IsWindows())
            {
                SetThreadExecutionState(Options.ES_CONTINUOUS | Options.ES_SYSTEM_REQUIRED | Options.ES_DISPLAY_REQUIRED);
            }
        }
        
        static public void Restore()
        {
            if (OperatingSystem.IsWindows())
            {
                SetThreadExecutionState(Options.ES_CONTINUOUS);  
            }
        }
    }
}
