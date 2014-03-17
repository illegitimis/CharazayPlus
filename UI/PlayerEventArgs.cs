using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndreiPopescu.CharazayPlus.UI
{
  public class PlayerEventArgs : EventArgs
  {
    public string FullName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
  }
}
