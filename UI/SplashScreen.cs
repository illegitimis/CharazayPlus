
namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Windows.Forms;
  using System.Diagnostics;
  using AndreiPopescu.CharazayPlus.Splash;
  using AndreiPopescu.CharazayPlus.Extensions;
  
  public partial class SplashScreen : Form
  {
    #region fields

    Func<SplashScreen, ValidationResult> _setup;
    ValidationResult _validationResult;

    private System.Windows.Forms.Label ProgressLabel;
    private System.Windows.Forms.Label label1;

    #endregion

    #region splash functionality
    
    public SplashScreen (Func<SplashScreen, ValidationResult> setup)
    {
      Trace.WriteLine("SplashScreen constructor");
      //
      InitializeComponent();
      //
      var asmInfo = new AndreiPopescu.CharazayPlus.Utils.AssemblyInfo();
      label1.Text = asmInfo.Product + ", " + asmInfo.Version;
      //
      _setup = setup;
      //
      Shown += delegate(object sender, EventArgs e)
      {
        Trace.WriteLine("Splash Shown");
        Application.DoEvents();
        try
        {
          _validationResult = _setup.Invoke(this);
        }
        catch (Exception ex)
        {
          ex.DumpException();
        }
        finally
        {
          this.Close();
        }
      };
    }

    public void UpdateProgress (string message)
    {
      ProgressLabel.Text = message;
      Application.DoEvents();
    }
    
    public static ValidationResult ShowSplashScreen (Func<SplashScreen, ValidationResult> setup)
    {
      Trace.WriteLine("ShowSplashScreen");

      var screen = new SplashScreen(setup);
      
      Application.Run(screen);
      
      return screen._validationResult;
    }
        
    #endregion

    #region Windows Form Designer generated code

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }



    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
      this.ProgressLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // ProgressLabel
      // 
      this.ProgressLabel.BackColor = System.Drawing.Color.Transparent;
      this.ProgressLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ProgressLabel.Location = new System.Drawing.Point(104, 9);
      this.ProgressLabel.MinimumSize = new System.Drawing.Size(100, 13);
      this.ProgressLabel.Name = "ProgressLabel";
      this.ProgressLabel.Size = new System.Drawing.Size(315, 26);
      this.ProgressLabel.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label1.Location = new System.Drawing.Point(161, 105);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(258, 23);
      this.label1.TabIndex = 1;
      // 
      // SplashScreen
      // 
      this.BackgroundImage = global::AndreiPopescu.CharazayPlus.Properties.Resources.Charazay_;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(431, 137);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ProgressLabel);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "SplashScreen";
      this.ResumeLayout(false);

    }

    #endregion
    
  }
}
