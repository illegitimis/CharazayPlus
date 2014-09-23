using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndreiPopescu.CharazayPlus.UI
{
  public class HiLoButton : System.Windows.Forms.Button
  {
    public HiLoButton ( ) : base()
    {
      //this.AutoSize = true;
      HiLoState = HiLoButton.HighLowState.None;
    }

    private void OnLoad (object sender, System.EventArgs e)
    {
      // use double buffering
      SetStyle(ControlStyles.DoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.UserPaint, true);

      this.Text = "<>";
      HiLoState = HiLoButton.HighLowState.None;
    }

    public override string Text
    {
      get
      {
        switch (HiLoState)
        {
          case HighLowState.None: return "<>";
            
          case HighLowState.Lower: return "<";
          default:
          case HighLowState.Greater: return ">";
        }
      }
    }

    protected override void OnClick (EventArgs e)
    {
      HighLowState current = HiLoState;
      this.SuspendLayout();
      switch(HiLoState)
      {
        case HighLowState.None: HiLoState = HiLoButton.HighLowState.Lower; break;
        case HighLowState.Lower: HiLoState = HiLoButton.HighLowState.Greater; break;
        case HighLowState.Greater: HiLoState = HiLoButton.HighLowState.Lower; break;
      }
      this.PerformLayout();
      if (HiLoStateChanged != null)
        HiLoStateChanged(this, new HiLoStateChangedEventArgs(current, HiLoState));
    }

    internal enum HighLowState {None,Lower,Greater}

    HighLowState HiLoState { get; set; }

    internal event EventHandler<HiLoStateChangedEventArgs> HiLoStateChanged;

  }

  internal class HiLoStateChangedEventArgs : EventArgs
  {
    public HiLoButton.HighLowState from { get; private set; }
    public HiLoButton.HighLowState to { get; private set; }

    public HiLoStateChangedEventArgs (HiLoButton.HighLowState from, HiLoButton.HighLowState to)
    {
      // TODO: Complete member initialization
      this.from = from;
      this.to = to;
    }
  }

  internal class SkillComboBox : ComboBox
  {
    public SkillComboBox () : base () 
    {
      //
      DoubleBuffered = true;
    }

    private void OnLoad (object sender, System.EventArgs e)
    {
      // use double buffering
      SetStyle(ControlStyles.DoubleBuffer, true);
      
      //
      this.SelectedItem = Utils.TransferListSkill.noSkill;
    }

    protected override void InitLayout ( )
    {
      base.InitLayout();
      DataSource = (Utils.TransferListSkill[])Enum.GetValues(typeof(Utils.TransferListSkill));
    }


  }
}
