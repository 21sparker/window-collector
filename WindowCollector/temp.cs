//using System;
//using System.Text;
//using System.Runtime.InteropServices;
//using System.Collections.Generic;
//using System.Diagnostics;

//class ActiveWindow
//{
//    public string WindowText { get; set; }
//    public string TimeCollected { get; set; }
//}

//class ActiveWindowCollector
//{

//    static List<ActiveWindow> activeWindows = new List<ActiveWindow>();
//    static Dictionary<string, int> totalTime = new Dictionary<string, int>();

//    static void Main()
//    {

//        ActiveWindowCollector ge = new ActiveWindowCollector();


//        Int32 hWnd = 0;
//        string windowText;
//        string currentTime;
//        // ActiveWindow aw = new ActiveWindow();

//        for (int i = 0; i < 10; i++)
//        {
//            // windowText = ge.getAciveWindow();
//            hWnd = ge.getActiveWindow();
//            windowText = ge.GetAppName(hWnd);
//            currentTime = DateTime.Now.ToString("h:mm:ss");

//            activeWindows.Add(new ActiveWindow { WindowText = windowText, TimeCollected = currentTime });

//            if (!totalTime.ContainsKey(windowText))
//            {
//                totalTime.Add(windowText, 1);
//            }
//            else
//            {
//                totalTime[windowText] += 1;
//            }
//        }

//        Console.WriteLine(activeWindows.Count.ToString());
//        ge.printWindowHistory();
//    }

//    [DllImport("user32.dll")]
//    static extern IntPtr GetForegroundWindow();

//    [DllImport("user32.dll")]
//    static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

//    [DllImport("user32.dll")]
//    static extern UInt32 GetWindowThreadProcessId(Int32 hWnd, out Int32 lpdwProcessId);

//    private Int32 getActiveWindow()
//    {
//        System.Threading.Thread.Sleep(1000);
//        const int nChars = 256;
//        IntPtr handle;
//        StringBuilder Buff = new StringBuilder(nChars);
//        handle = GetForegroundWindow  ();
//        // if (GetWindowText(handle, Buff, nChars) > 0)
//        // {
//        //     return Buff.ToString();
//        // }
//        // return "None Found";
//        return (Int32)handle;
//    }

//    private string GetAppName(Int32 hWnd)
//    {
//        Int32 pid = GetWindowThreadProcessId(hWnd);
//        Process p = Process.GetProcessById(pid);
//        string appName = p.MainWindowTitle;
//        return appName;
//    }

//    private static Int32 GetWindowThreadProcessId(Int32 hWnd)
//    {
//        Int32 pid = 1;
//        GetWindowThreadProcessId(hWnd, out pid);
//        return pid;
//    }

//    private void printWindowHistory()
//    {
//        foreach (ActiveWindow win in activeWindows)
//        {
//            Console.WriteLine(win.TimeCollected + ": " + win.WindowText);
//        }

//        Console.WriteLine("----------------");

//        foreach (string key in totalTime.Keys)
//        {
//            Console.WriteLine(key + ": " + totalTime[key].ToString());
//        }
//    }
//}