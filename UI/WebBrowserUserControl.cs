using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AndreiPopescu.CharazayPlus.UI
{
  public partial class WebBrowserUserControl : UserControl
  {
    public WebBrowserUserControl ( )
    {
      InitializeComponent();
    }

    private void browser_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      var doc = ((WebBrowser)sender).Document;
      
      doc.Window.Error +=
        // new HtmlElementErrorEventHandler(Window_Error);
              (o, /*HtmlElementErrorEventArgs */heee) => heee.Handled = true;

      Debug.WriteLine("Completed: {0}", e.Url);
      
      
      }

    private void browser_Navigated (object sender, WebBrowserNavigatedEventArgs e)
    {
      Debug.WriteLine("Navigated to: {0}", e.Url);
    }

    private void browser_Navigating (object sender, WebBrowserNavigatingEventArgs e)
    {
      var uris = new string[] {
        "https://www.facebook.com" ,
        "http://www.facebook.com",
      "http://googleads.g.doubleclick.net",
       "http://M.betrad.com",
       "http://static.ak.facebook.com",
       "https://tlPlayer-static.ak.facebook.com"
        };
      if (uris.Any(u => e.Url.AbsoluteUri.StartsWith(u)))
        e.Cancel=true;
      else
        Debug.WriteLine("Navigating to: {0} from frame: {1}", e.Url, e.TargetFrameName);
    }

    private void browser_NewWindow (object sender, CancelEventArgs e)
    {
      
    }

    void RecursiveRemoval(HtmlElement elem)
    {
      
      
        switch (elem.TagName)
        {
          case "DIV":
            if (elem.GetAttribute("class") == "rc-t")
              elem.OuterHtml = string.Empty;
            break;

          case "INS":
            if (elem.GetAttribute("id") == "aswift_0_expand")
              elem.OuterHtml = string.Empty;
            break;

          case "SCRIPT":
            elem.OuterHtml = string.Empty;
            break;

          default:
            if (elem.CanHaveChildren && elem.Children != null && elem.Children.Count > 0)
            { 
            foreach (HtmlElement child in elem.Children)
              RecursiveRemoval(child);
            }
            break;
        }
      
    }


    private void browser_ProgressChanged (object sender, WebBrowserProgressChangedEventArgs e)
    {
      Debug.WriteLine("Progress: {0} of: {1}", e.CurrentProgress, e.MaximumProgress);

      if (this.browser.Document != null)
      {
        //1
        if (this.browser.DocumentTitle.StartsWith("Charazay Basketball Manager - "))
        {
          RecursiveRemoval(this.browser.Document.Body);
        }
      }
    }

    private void browser_TabIndexChanged (object sender, EventArgs e)
    {

    }

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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.browser = new System.Windows.Forms.WebBrowser();
      this.SuspendLayout();
      // 
      // browser
      // 
      this.browser.CausesValidation = false;
      this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.browser.IsWebBrowserContextMenuEnabled = false;
      this.browser.Location = new System.Drawing.Point(0, 0);
      this.browser.MinimumSize = new System.Drawing.Size(20, 20);
      this.browser.Name = "browser";
      this.browser.ScriptErrorsSuppressed = true;
      this.browser.Size = new System.Drawing.Size(582, 396);
      this.browser.TabIndex = 1;
      this.browser.Url = new System.Uri("", System.UriKind.Relative);
      this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
      this.browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.browser_Navigated);
      this.browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browser_Navigating);
      this.browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.browser_NewWindow);
      this.browser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.browser_ProgressChanged);
      this.browser.TabIndexChanged += new System.EventHandler(this.browser_TabIndexChanged);
      // 
      // WebBrowserUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gray;
      this.Controls.Add(this.browser);
      this.Name = "WebBrowserUserControl";
      this.Size = new System.Drawing.Size(582, 396);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser browser;

    internal void Navigate (string p)
    {
      this.browser.Navigate(p);
    }
  }
}
