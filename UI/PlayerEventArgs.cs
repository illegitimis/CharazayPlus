/* Custom EventArgs class
 * v1.1.1.0
 * added PlayerSelectionEventArgs
 * 
 */

using System;

namespace AndreiPopescu.CharazayPlus.UI
{
  public class PlayerEventArgs : EventArgs
  {
    public string FullName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
  }

  public class PlayerSelectionEventArgs : PlayerEventArgs
  {
    //public string FullName { get; set; }
    //public string Name { get; set; }
    //public string Surname { get; set; }

    public int SelectedIndices { get; set; }

    public int ItemCount { get; set; }
  }
}
