using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class FormLogin : Form
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tbUser = new System.Windows.Forms.TextBox();
      this.tbSecurityCode = new System.Windows.Forms.TextBox();
      this.tbSecurityCodeRepeat = new System.Windows.Forms.TextBox();
      this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.btnSet = new System.Windows.Forms.Button();
      this.txtInfo = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(63, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "User Name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Security Code";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 69);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(111, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Repeat Security Code";
      // 
      // tbUser
      // 
      this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbUser.Location = new System.Drawing.Point(132, 10);
      this.tbUser.Name = "tbUser";
      this.tbUser.Size = new System.Drawing.Size(181, 20);
      this.tbUser.TabIndex = 1;
      this.tbUser.Validated += new System.EventHandler(this.tbUser_Validated);
      // 
      // tbSecurityCode
      // 
      this.tbSecurityCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSecurityCode.Location = new System.Drawing.Point(132, 38);
      this.tbSecurityCode.Name = "tbSecurityCode";
      this.tbSecurityCode.Size = new System.Drawing.Size(181, 20);
      this.tbSecurityCode.TabIndex = 3;
      this.tbSecurityCode.UseSystemPasswordChar = true;
      this.tbSecurityCode.Validated += new System.EventHandler(this.tbSecurityCode_Validated);
      // 
      // tbSecurityCodeRepeat
      // 
      this.tbSecurityCodeRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSecurityCodeRepeat.Location = new System.Drawing.Point(132, 65);
      this.tbSecurityCodeRepeat.Name = "tbSecurityCodeRepeat";
      this.tbSecurityCodeRepeat.Size = new System.Drawing.Size(181, 20);
      this.tbSecurityCodeRepeat.TabIndex = 5;
      this.tbSecurityCodeRepeat.UseSystemPasswordChar = true;
      this.tbSecurityCodeRepeat.Validated += new System.EventHandler(this.tbSecurityCodeRepeat_Validated);
      // 
      // errProvider
      // 
      this.errProvider.ContainerControl = this;
      // 
      // btnSet
      // 
      this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSet.Location = new System.Drawing.Point(228, 125);
      this.btnSet.Name = "btnSet";
      this.btnSet.Size = new System.Drawing.Size(85, 23);
      this.btnSet.TabIndex = 6;
      this.btnSet.Text = "Set";
      this.btnSet.UseVisualStyleBackColor = true;
      this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
      // 
      // txtInfo
      // 
      this.txtInfo.Location = new System.Drawing.Point(16, 92);
      this.txtInfo.Name = "txtInfo";
      this.txtInfo.ReadOnly = true;
      this.txtInfo.Size = new System.Drawing.Size(297, 20);
      this.txtInfo.TabIndex = 7;
      // 
      // FormLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(338, 160);
      this.Controls.Add(this.txtInfo);
      this.Controls.Add(this.btnSet);
      this.Controls.Add(this.tbSecurityCodeRepeat);
      this.Controls.Add(this.tbSecurityCode);
      this.Controls.Add(this.tbUser);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "FormLogin";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "FormLogin";
      this.Load += new System.EventHandler(this.FormLogin_Load);
      ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbUser;
    private System.Windows.Forms.TextBox tbSecurityCode;
    private System.Windows.Forms.TextBox tbSecurityCodeRepeat;
    private System.Windows.Forms.ErrorProvider errProvider;
    private TextBox txtInfo;
    private System.Windows.Forms.Button btnSet;

    #region unneeded
    //private System.Windows.Forms.TextBox tbTeam;
    //private System.Windows.Forms.TextBox tbCountry;
    //private System.Windows.Forms.TextBox tbDiv; 
    #endregion
    //private Common.UserSettings cus = new Common.UserSettings();

    public FormLogin()
    {
      InitializeComponent();
    }

    private void validator (string regex, Control c, string err)
    {
      Regex r = new Regex(regex);
      bool ok = r.IsMatch(c.Text);
      errProvider.SetError(c, ok ? "" : err);
      if (!ok)
        txtInfo.Text = err;
      btnSet.Enabled = ok;      
    }

    #region unneeded
    //private void tbTeam_Validated(object sender, EventArgs e)
    //{
    //  validator(@"\d+", tbTeam, "Team id should be a number");

    //}

    //private void tbCountry_Validated(object sender, EventArgs e)
    //{
    //  validator(@"[1-9]|[1-9][0-9]", tbCountry, "Country should be a number");
    //}

    //private void tbDiv_Validated(object sender, EventArgs e)
    //{
    //  validator(@"\d+", tbDiv, "Division id should be a number");
    //} 
    #endregion

    private void tbSecurityCode_Validated(object sender, EventArgs e)
    {
      validator(@"\w+", tbSecurityCode, "Security code has improper characters");
    }

    private void tbSecurityCodeRepeat_Validated(object sender, EventArgs e)
    {
      //validator(@"\w+", tbSecurityCodeRepeat, "Repeated security code has improper characters");
      if (tbSecurityCodeRepeat.Text != tbSecurityCode.Text)
      { 
        errProvider.SetError(tbSecurityCodeRepeat, "Codes do not match");
        btnSet.Enabled = false;
      }
    }

    private void tbUser_Validated(object sender, EventArgs e)
    {
      validator(@"\w+", tbUser, "User code has improper charcters");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSet_Click(object sender, EventArgs e)
    {
      //cus.DivisionId = ushort.Parse(tbDiv.Text);
      //cus.TeamId = ushort.Parse(tbTeam.Text);
      //cus.CountryId = byte.Parse(tbCountry.Text);

      using (Web.Downloader crawler = new Web.Downloader())
      {
        Web.DownloadItem di = new Web.MyInfoXml(tbUser.Text, tbSecurityCode.Text);
        crawler.Add(di);
        crawler.ForceGet(true);
        
        using (System.IO. FileStream fs = new System.IO.FileStream
          (di.m_fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
          Xsd2.charazay obj = (Xsd2.charazay)(new System.Xml.Serialization.XmlSerializer
            (typeof(Xsd2.charazay)).Deserialize(fs));
          if (obj.user == null)
          {
            txtInfo.Text = "Charazay user name or associated security code are wrong";
            btnSet.Enabled = false;
          }
          else
          {
            Properties.Settings cus = Properties.Settings.Default;
            cus.SecurityCode = tbSecurityCode.Text;
            cus.UserName = tbUser.Text;
            cus.Save();
            txtInfo.Text = "Provided information is correct and was saved";            
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
      //Binding bndTeam = new Binding("Text", Properties.Settings.Default, "TeamId", true, DataSourceUpdateMode.OnPropertyChanged);
      //tbTeam.DataBindings.Add(bndTeam);
      Binding bnd2 = new Binding("Text", Properties.Settings.Default, "UserName", true, DataSourceUpdateMode.OnPropertyChanged);
      tbUser.DataBindings.Add(bnd2);
      Binding bnd1 = new Binding("Text", Properties.Settings.Default, "SecurityCode", true, DataSourceUpdateMode.OnPropertyChanged);
      tbSecurityCode.DataBindings.Add(bnd1);

      txtInfo.Text = "Enter required info";
      btnSet.Enabled = false;
    }

    

    
  }
}
