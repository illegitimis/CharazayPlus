using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndreiPopescu.CharazayPlus.Extensions
{
  static class FormsExtensions
  {
    public static void SetWaitCursor (Action seqAct)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        seqAct();
      }
      catch { }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }
  }
}
