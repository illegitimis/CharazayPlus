using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using AndreiPopescu.CharazayPlus.Splash;
using AndreiPopescu.CharazayPlus.Extensions;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class LoginForm : Form
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this._lblTitle = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbUser = new System.Windows.Forms.TextBox();
      this.tbSecurityCode = new System.Windows.Forms.TextBox();
      this._errProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.btnSet = new System.Windows.Forms.Button();
      this.txtInfo = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this._errProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // _lblTitle
      // 
      this._lblTitle.AutoSize = true;
      this._lblTitle.Location = new System.Drawing.Point(138, 7);
      this._lblTitle.Name = "_lblTitle";
      this._lblTitle.Size = new System.Drawing.Size(63, 13);
      this._lblTitle.TabIndex = 0;
      this._lblTitle.Text = "User Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(128, 30);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Security Code";
      // 
      // tbUser
      // 
      this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbUser.Location = new System.Drawing.Point(207, 4);
      this.tbUser.Name = "tbUser";
      this.tbUser.Size = new System.Drawing.Size(141, 20);
      this.tbUser.TabIndex = 1;
      this.tbUser.Validated += new System.EventHandler(this.tbUser_Validated);
      // 
      // tbSecurityCode
      // 
      this.tbSecurityCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSecurityCode.Location = new System.Drawing.Point(207, 27);
      this.tbSecurityCode.Name = "tbSecurityCode";
      this.tbSecurityCode.Size = new System.Drawing.Size(141, 20);
      this.tbSecurityCode.TabIndex = 3;
      this.tbSecurityCode.UseSystemPasswordChar = true;
      this.tbSecurityCode.Validated += new System.EventHandler(this.tbSecurityCode_Validated);
      // 
      // _errProvider
      // 
      this._errProvider.ContainerControl = this;
      // 
      // btnSet
      // 
      this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnSet.Location = new System.Drawing.Point(100, 111);
      this.btnSet.Name = "btnSet";
      this.btnSet.Size = new System.Drawing.Size(58, 23);
      this.btnSet.TabIndex = 6;
      this.btnSet.Text = "Set";
      this.btnSet.UseVisualStyleBackColor = true;
      this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
      // 
      // txtInfo
      // 
      this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtInfo.Location = new System.Drawing.Point(162, 113);
      this.txtInfo.Name = "txtInfo";
      this.txtInfo.ReadOnly = true;
      this.txtInfo.Size = new System.Drawing.Size(264, 20);
      this.txtInfo.TabIndex = 7;
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackgroundImage = global::AndreiPopescu.CharazayPlus.Properties.Resources.Charazay_;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(428, 135);
      this.Controls.Add(this.txtInfo);
      this.Controls.Add(this.btnSet);
      this.Controls.Add(this.tbSecurityCode);
      this.Controls.Add(this.tbUser);
      this.Controls.Add(this.label2);
      this.Controls.Add(this._lblTitle);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "LoginForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "FormLogin";
      this.Load += new System.EventHandler(this.FormLogin_Load);
      ((System.ComponentModel.ISupportInitialize)(this._errProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label _lblTitle;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbUser;
    private System.Windows.Forms.TextBox tbSecurityCode;
    private System.Windows.Forms.ErrorProvider _errProvider;
    private TextBox txtInfo;
    private System.Windows.Forms.Button btnSet;

    #region unneeded
    //private System.Windows.Forms.TextBox tbTeam;
    //private System.Windows.Forms.TextBox tbCountry;
    //private System.Windows.Forms.TextBox tbDiv; 
    //private Common.UserSettings cus = new Common.UserSettings();
    #endregion


    public LoginForm (/*Func<LoginForm, ValidationResult> setup = null*/)
    {
      Trace.WriteLine("LoginForm constructor");
      //
      InitializeComponent();
      //
      /*  
      if (setup != null && setup != DefaultSetup)
        SplashScreenConstructor(setup);
       */
    }

    private void RegexValidator (string regex, Control c, string err)
    {
      Regex r = new Regex(regex);
      bool ok = r.IsMatch(c.Text);
      _errProvider.SetError(c, ok ? String.Empty : err);
      if (!ok)
        txtInfo.Text = err;
      btnSet.Enabled = ok;      
    }

    #region unneeded
    //private void tbTeam_Validated(object sender, EventArgs e)
    //{
    //  RegexValidator(@"\d+", tbTeam, "Team id should be m number");

    //}

    //private void tbCountry_Validated(object sender, EventArgs e)
    //{
    //  RegexValidator(@"[1-9]|[1-9][0-9]", tbCountry, "Country should be m number");
    //}

    //private void tbDiv_Validated(object sender, EventArgs e)
    //{
    //  RegexValidator(@"\d+", tbDiv, "Division id should be m number");
    //} 
    #endregion

    private void tbSecurityCode_Validated(object sender, EventArgs e)
    {
      RegexValidator(@"\w+", tbSecurityCode, "Security code has improper characters");
    }

      private void tbUser_Validated(object sender, EventArgs e)
    {
      RegexValidator(@"\w+", tbUser, "User code has improper charcters");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSet_Click(object sender, EventArgs e)
    {
      //cus.DivisionId = ushort.Parse(tbDiv.Text);
      //cus.LastBidByTeamId = ushort.Parse(tbTeam.Text);
      //cus.CountryId = byte.Parse(tbCountry.Text);

      Info("Modifying login info for Charazay web services ...");

      using (Web.Downloader crawler = new Web.Downloader())
      {
        Web.DownloadItem di = null;
        try
        {
          di = new Web.MyInfoXml(tbUser.Text, tbSecurityCode.Text);
          crawler.Add(di);
          crawler.ForceGet(true);
          Info("Charazay user information was downloaded");
        }
        catch 
        { 
          Info("Could not download user information from Charazay. Most probably user name or associated security code are wrong"); 
        }
        
        
        using (System.IO. FileStream fs = new System.IO.FileStream
          (di.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
          Xsd2.charazay obj = (Xsd2.charazay)(new System.Xml.Serialization.XmlSerializer
            (typeof(Xsd2.charazay)).Deserialize(fs));
          if (obj.user == null)
          {
           Info("Charazay user name is invalid");
            btnSet.Enabled = false;
          }
          
          else
          {
            Properties.Settings cus = Properties.Settings.Default;
            cus.SecurityCode = tbSecurityCode.Text;
            cus.UserName = tbUser.Text;
            cus.Save();
            Info("Provided information is correct and was saved");       
            OnCorrectUserInformation();
          }
           
        }
      }
    }


    private void FormLogin_Load(object sender, EventArgs e)
    {
      //Data bind settings properties with straightforward associations.
      //Binding bndCountry = new Binding("Text", Properties.Settings.Default, "CountryId", true, DataSourceUpdateMode.OnPropertyChanged);
      //tbCountry.DataBindings.Add(bndCountry);
      //Binding bndDiv = new Binding("Text", Properties.Settings.Default, "DivisionId", true, DataSourceUpdateMode.OnPropertyChanged);
      //tbDiv.DataBindings.Add(bndDiv);
      //Binding bndTeam = new Binding("Text", Properties.Settings.Default, "LastBidByTeamId", true, DataSourceUpdateMode.OnPropertyChanged);
      //tbTeam.DataBindings.Add(bndTeam);

      tbUser.DataBindings.Add(new Binding("Text", Properties.Settings.Default, "UserName", true, DataSourceUpdateMode.OnPropertyChanged));

      tbSecurityCode.DataBindings.Add(new Binding("Text", Properties.Settings.Default, "SecurityCode", true, DataSourceUpdateMode.OnPropertyChanged));
            
      btnSet.Enabled = false;
    }

     public event EventHandler CorrectUserInformation;
     
    protected virtual void OnCorrectUserInformation()
       {
           if (CorrectUserInformation != null)
           {
               CorrectUserInformation(this, new EventArgs());
           }
       }
    
     internal void Info (string p)
     {
       txtInfo.Text = p;
       //
       //Application.DoEvents();
     }

   

    #region splash functionality

    /* 
     
    Func<LoginForm, ValidationResult> DefaultSetup = delegate(LoginForm lf) { return ValidationResult.Inconclusive; };

    Func<LoginForm, ValidationResult> _setup;
    ValidationResult _validationResult;

    public void SplashScreenConstructor (Func<LoginForm, ValidationResult> setup)
    {
      Trace.WriteLine("SplashScreenConstructor");
      //
      InitializeComponent();
      //
      //var asmInfo = new AndreiPopescu.CharazayPlus.Utils.AssemblyInfo();
      //this.Text = asmInfo.Product + ", " + asmInfo.Title;
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
      //
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    }

    
    
    public static ValidationResult ShowSplashScreen (Func<LoginForm, ValidationResult> setup)
    {
      Trace.WriteLine("ShowSplashScreen");

      var screen = new LoginForm(setup);
      
      Application.Run(screen);
      
      return screen._validationResult;
    }
        
     */
    #endregion



  }
}
