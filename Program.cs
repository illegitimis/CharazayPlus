

namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Windows.Forms;
  using System.Threading;
  using System.Runtime.InteropServices;
  using System.Diagnostics;
  using AndreiPopescu.CharazayPlus.UI;
  using AndreiPopescu.CharazayPlus.Splash;

  static class Program
  {
    /// <summary>
    /// named s_mutex => stack synchronization across multiple threads and processes
    /// </summary>
    static Mutex s_mutex = new Mutex(true, "{5EDF70B6-F80D-4C2F-A313-E4084D681195}");

    /// <summary>
    /// 
    /// </summary>
    public static MainForm Window = null;

    /// <summary>
    /// The main entry point for the application.
    /// Mutex for single application instance
    /// </summary>
    [STAThread]
    static void Main()
    {
      // if able to enter return true, set the exitContext to true 
      // so we can exit the synchronization context before we try to aquire m lock on it
      if (s_mutex.WaitOne(TimeSpan.Zero, true))
      {

        Trace.WriteLine("Application started");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //
        Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        //
        try
        {
#if DEBUG
          NativeMethods.AllocConsole();
#endif
          var result = SplashScreen.ShowSplashScreen(Setup);
          //var result = LoginForm.ShowSplashScreen(Setup);

          if (result == ValidationResult.Success)
          {
            Application.Run(Window);
          }
          Trace.WriteLine("Application ended");
        }
        catch (Exception ex)
        {
          Trace.WriteLine(ex.Message);
        }
        finally
        {
#if DEBUG
          NativeMethods.FreeConsole();
#endif
        }
        //
        s_mutex.ReleaseMutex();
      }
      // notify my running instance that someone forgot that it was already running
      else
      { // send our Win32 message to make the currently running instance jump on top of all the other windows
        NativeMethods.PostMessage(
                (IntPtr)NativeMethods.HWND_BROADCAST,
                NativeMethods.WM_SHOWME,
                IntPtr.Zero,
                IntPtr.Zero);
      }
    }

    static ValidationResult Setup (SplashScreen splashScreen)
    {
      //var RegexValidator = new SPFInstalledValidator();

      //if (RegexValidator.RunValidator() == ValidationResult.Error)
      //{
      //  MessageBox.Show(RegexValidator.ErrorString + Environment.NewLine + Environment.NewLine + RegexValidator.QuestionString, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //  return ValidationResult.Error;
      //}

      var engine = new PreflightController(splashScreen);
      if (! engine.Validate())
      {
        return ValidationResult.Error;
      }
      //
      Window = new MainForm();
      //
      Window.SplashScreenLoad(splashScreen);

      return ValidationResult.Success;
    }

    static ValidationResult Setup (LoginForm splashScreen)
    {
      var engine = new PreflightController(splashScreen);
      if (!engine.Validate())
      {
        return ValidationResult.Error;
      }
      //
      Window = new MainForm();
      //
      Window.SplashScreenLoad(splashScreen);

      return ValidationResult.Success;
    }
    
    static void Application_ThreadException (object sender, System.Threading.ThreadExceptionEventArgs e)
    {
      Cursor.Current = Cursors.Default;
      MessageBox.Show(e.Exception.Message + " : " + e.Exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

  }

  internal class NativeMethods
  {
    public const int HWND_BROADCAST = 0xffff;
    public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
    [DllImport("user32")]
    public static extern bool PostMessage (IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    [DllImport("user32")]
    public static extern int RegisterWindowMessage (string message);

    
    [DllImport("kernel32.dll")]
    public static extern Boolean AllocConsole ( );
    [DllImport("kernel32.dll")]
    public static extern Boolean FreeConsole ( );
    
  }

  internal class ModalWindowUtil
  {
    [DllImport("user32.dll")]
    private static extern IntPtr GetWindow (IntPtr hWnd, int uCmd);

    [DllImport("user32.dll")]
    private static extern IntPtr SetActiveWindow (IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible (IntPtr hWnd);

    [DllImport("kernel32.dll")]
    private static extern int GetCurrentThreadId ( );

    [DllImport("user32.dll")]
    private static extern bool EnumThreadWindows (int dwThreadId, EnumChildrenCallback lpEnumFunc, IntPtr lParam);
    private delegate bool EnumChildrenCallback (IntPtr hwnd, IntPtr lParam);

    private const int GW_OWNER = 4;
    private int _maxOwnershipLevel;
    private IntPtr _maxOwnershipHandle;

    private bool EnumChildren (IntPtr hwnd, IntPtr lParam)
    {
      int level = 1;
      if (IsWindowVisible(hwnd) && IsOwned(lParam, hwnd, ref level))
      {
        if (level > _maxOwnershipLevel)
        {
          _maxOwnershipHandle = hwnd;
          _maxOwnershipLevel = level;
        }
      }
      return true;
    }

    private static bool IsOwned (IntPtr owner, IntPtr hwnd, ref int level)
    {
      IntPtr o = GetWindow(hwnd, GW_OWNER);
      if (o == IntPtr.Zero)
        return false;

      if (o == owner)
        return true;

      level++;
      return IsOwned(owner, o, ref level);
    }

    public static void ActivateWindow (IntPtr hwnd)
    {
      if (hwnd != IntPtr.Zero)
      {
        SetActiveWindow(hwnd);
      }
    }

    public static IntPtr GetModalWindow (IntPtr owner)
    {
      ModalWindowUtil util = new ModalWindowUtil();
      EnumThreadWindows(GetCurrentThreadId(), util.EnumChildren, owner);
      return util._maxOwnershipHandle; // may be IntPtr.Zero
    }
  }
}


