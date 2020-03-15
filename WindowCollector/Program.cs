using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace WindowCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] allProcesses = Process.GetProcesses();
            //while (!Console.KeyAvailable)
            //{


            //}


            IntPtr hWnd;
            bool wpIsVisible;
            List<string> processesToIgnore = new List<string>();
            processesToIgnore.Add("explorer");
            processesToIgnore.Add("ApplicationFrameHost");

            foreach (Process proc in allProcesses)
            {
                hWnd = proc.MainWindowHandle;
                wpIsVisible = WindowCollector.WindowPlacementIsVisible(hWnd);
                if (hWnd != IntPtr.Zero && !processesToIgnore.Contains(proc.ProcessName) && !String.IsNullOrWhiteSpace(proc.MainWindowTitle) && proc.Responding && wpIsVisible)
                {
                    
                    Console.WriteLine(proc.ProcessName + proc.Id + proc.Responding +  ": " + proc.MainWindowTitle + " (" + proc.MainWindowHandle.ToString() + ")");
                }
            }
        }
    }
}
