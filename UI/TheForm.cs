
namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using System.Xml.Serialization;
  using System.IO;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.UI;
  using AndreiPopescu.CharazayPlus.Data;
  using AndreiPopescu.CharazayPlus.Web;
  
#if DOTNET30
  using System.Linq;
  using System.Diagnostics;
#endif
  
  /// <summary>
  /// Application main form
  /// </summary>
  public partial class MainForm : System.Windows.Forms.Form
  {
    /// <summary>
    /// side tab categories
    /// </summary>
    enum SideTabPage : int
    {
      Info = 0
        ,
      Status = 1
        ,
      Skills = 2
        ,
      PG = 3
        ,
      SG = 4
        ,
      SF = 5
        ,
      PF = 6
        ,
      C = 7
        ,
      Training = 8
        ,
      MyTeamSchedule = 9
        ,
      MyDivisionStandings = 10
        ,
      MyDivisionSchedule = 11
        ,
      MyEconomy = 12
        ,
      TL = 13
        ,
      WebBrowser = 14
      ,
      GraphTransferMarket = 15
      ,
      AssessPlayer = 16
    }

    public MainForm ( )
    {
      Trace.WriteLine("MainForm constructor");
      //
      InitializeComponent();
      //
      Shown += MainWindow_Shown;
      Load += new EventHandler(MainWindow_Load);
      //
      //Size sz = new Size ((int) (olvSkills.Size.Width / 2 - 1), lblSkillsDisplay.Height);
      //lblSkillsDisplay.Size = lblSkillsActive.Size = sz;
      string user = null;
      string code = null;
      try
      {
        user = Properties.Settings.Default.UserName;
        code = Properties.Settings.Default.SecurityCode;
      }
      catch (System.Configuration.ConfigurationException)
      {

      }
      catch (Exception)
      {

      }
      if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(code))
      {
        UI.LoginForm formLogin = new UI.LoginForm();
        formLogin.CorrectUserInformation += new EventHandler(formLogin_CorrectUserInformation);
        formLogin.ShowDialog(this);
      }
      else
      {
        //AssignWebServiceManager();
        //
        // down + deserialize xmls
        //
        //DownloadMandatoryXmlFiles();
        //DownloadXmlAdditional();
      }

    }

    public void SplashScreenLoad (/*SplashScreen*/ System.Windows.Forms.Form splashScreen)
    {
      Trace.WriteLine("SplashScreenLoad()");
      //
      if (splashScreen is LoginForm) 
        (splashScreen as LoginForm).Info("Loading...");
      if (splashScreen is SplashScreen)
        (splashScreen as SplashScreen).UpdateProgress("Loading ...");      
    }

    void MainWindow_Shown (object sender, EventArgs e)
    {
      Application.DoEvents();
      //if (Explorer != null && Explorer.SelectedNode != null)
      //  ExplorerClick(Explorer.SelectedNode as SPTreeNode);
    }

    public void MainWindow_Load (object sender, EventArgs e)
    {
      //SetLanguage(SPMLocalization.C_CULTURE_EN);

      //this.MainMenuStrip = IoCContainer.Resolve<MainMenuStrip>();
      //this.Controls.Add(this.MainMenuStrip);

      //var statusStrip = IoCContainer.Resolve<MainWindowStatusStrip>();
      //this.Controls.Add(statusStrip);

      //string language = SPMRegistry.GetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID) as string;
      //if (language == null)
      //{
      //    SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_EN);
      //}
      //else
      //{
      /* NEW LANGUAGE INSTRUCTIONS
       * - Add a new constant in Library-SPMLocalization.cs  (public const string C_CULTURE_XX = "XX";)
       * - Add a new sub-menu ("Xxxxx") in the MainForm.cs under "Languages", and his Click Event
       * - Add two rows code to the Event of the sub-menu:
       *             SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, SPMLocalization.C_CULTURE_XX);
       *             this.MainWindow_Load(null, null);
       * - Add a new case in the switch statement in the Load event of MainForm.cs (from row 57)
       *                     case SPMLocalization.C_CULTURE_XX:
       *                         xxxxxToolStripMenuItem.Checked = true;
       *                         break;
       * - Add a row in the function InitializeInterfaceStrings (MainForm.cs):
       *                  xxxxxToolStripMenuItem.Text = SPMLocalization.GetString("Interface_xxxxxLanguage");
       * - Add a row in each SPManagerLanguage.xx.resx file:
       *                  Interface_xxxxxLanguage	    NameOfLanguageIn-resx-File	    MainForm
       * - Add a new resources file to the project ("SPManagerLanguage.xx.resx")
       * - Copy all from SPManagerLanguage.resx to the new SPManagerLanguage.xx.resx file
       * - Change the "Value" of each string in the new file
       */

      //Uncheck everything in the Language Menu

      ////}

    }

    #region designer fields

    private ToolStripMenuItem tsmiTools;
    private ToolStripMenuItem tsmiOptions;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem tschkShowGroups;
    private ToolStripMenuItem tschkOwnerDrawn;
    private ToolStripMenuItem tsmiFilter;
    private ToolStripTextBox tstxtFilterText;
    private ToolStripMenuItem tsmiHelp;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private TabPage tabPageMyDivisionStandings;
    private DivisionStandingsUserControl ucStandings;
    private TabPage tabPageMyTeamSchedule;
    private TeamScheduleUserControl ucMyTeamSchedule;
    private TabPage tabPageTraining;
    private TrainingTabUserControl ucTraining;
    private TabPage tabPageC;
    private PlayerPositionUserControl ucC;
    private TabPage tabPagePF;
    private PlayerPositionUserControl ucPF;
    private TabPage tabPageSF;
    private PlayerPositionUserControl ucSF;
    private TabPage tabPageSG;
    private PlayerPositionUserControl ucSG;
    private TabPage tabPagePG;
    private PlayerPositionUserControl ucPG;
    private TabPage tabPageSkills;
    private PlayerSkillsTabUserControl ucPlayerSkills;
    private TabPage tabPageStatus;
    private StatusUserControl ucStatus;
    private TabPage tabPageInfo;
    private InfoTabUserControl ucInfoTab;
    private SideTabControl sideTabControl;
    private TabPage tabPageMyDivisionSchedule;
    private DivisionScheduleUserControl ucDivisionSchedule;
    private TabPage tabPageMyEconomy;
    private MyEconomyUserControl ucMyEconomy;
    private TabPage tabPageTL;
    private TransferListUserControl ucTransferList;
    private TabPage tabPageBrowser;
    private SearchTMUserControl ucSearchTM;
    private TabPage tabPageChartTM;
    private ChartUserControl _chartTransferHistory;
    private TabPage tabPageAssessPlayer;
    private ImageList imageListCountries;
    private ToolStripStatusLabel tsslbl;
    private ToolStripStatusLabel tsslblr;
    private StatusStrip statusStrip;
    private AssessPlayerUserControl assessPlayerUserControl1;
   
  

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
   
    // status column customized designer 
    //private HeaderStateStyle hssSkillsDisplay;
    //private HeaderStateStyle hssSkillsActive;
    //private HeaderFormatStyle hfsSkillsTab;
    // positions (attributes)
    //private VerticalLabel labelCoachesList;
    //private UI.MyTeamScheduleUserControl ucMyTeamSchedule;
    //private WebBrowserUserControl ucWebBrowser;
    #endregion

    #region Download
    private void DownloadFlags()
    {
      using (Web.Downloader crawler = new Web.Downloader())
      {
        foreach (Country country in Defines.Countries)
      {
        if (country.Id != 0)
        {
          Web.DownloadItem di = new Web.PngDownloadItem(country.Id);
          crawler.Add(di);
        }
      }
      
        crawler.Get();
      }
    }

    //private void DownloadXmlAdditional ( )
    //{
    //  //if (MyXmlTeam.CountryInfo == null || MyXmlTeam.Arena == null)
    //  //  throw new NotImplementedException();
    //  //if (MyXmlTeam.Schedule == null || MyXmlTeam.DivisionSchedule == null)
    //  //  throw new NotImplementedException();
    //  //if (MyXmlTeam.Standings == null)
    //  //  throw new NotImplementedException();
    //  //if (MyXmlTeam.Economy == null || MyXmlTeam.Transfers == null)
    //  //  throw new NotImplementedException();
    //  if (PlayersEnvironment.OptimumPlayers == null || PlayersEnvironment.Coaches == null)
    //    throw new NotImplementedException();
    //  if (TransferList.Bookmarks == null)
    //    throw new NotImplementedException();
    //  //
    //  new System.Threading.Thread(( ) => Web.Scraper.Instance.Login()).Start();
    //  //

    //}

    //private void DownloadMandatoryXmlFiles ( )
    //{
    //  if (MyXmlTeam.UserInfo == null || MyXmlTeam.TeamInfo == null)
    //    throw new ApplicationException();
    //}
    #endregion

    #region IDisposable
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

    /// <summary>
    /// called main window closing
    /// on tab change no more
    /// </summary>
    private void MainForm_FormClosing (object sender, FormClosingEventArgs e)
    {
      // sync this.olvTL.Objects & Data.TransferList.bookmarks
      //Deserializer.SerializePlayersTL(olvTL.Objects);
      Deserializer.SerializePlayersTL(Data.TransferList.Bookmarks);
      GC.WaitForPendingFinalizers();
    }

    #endregion

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tschkShowGroups = new System.Windows.Forms.ToolStripMenuItem();
      this.tschkOwnerDrawn = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiFilter = new System.Windows.Forms.ToolStripMenuItem();
      this.tstxtFilterText = new System.Windows.Forms.ToolStripTextBox();
      this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabPageMyDivisionStandings = new System.Windows.Forms.TabPage();
      this.ucStandings = new AndreiPopescu.CharazayPlus.UI.DivisionStandingsUserControl();
      this.tabPageMyTeamSchedule = new System.Windows.Forms.TabPage();
      this.ucMyTeamSchedule = new AndreiPopescu.CharazayPlus.UI.TeamScheduleUserControl();
      this.tabPageTraining = new System.Windows.Forms.TabPage();
      this.ucTraining = new AndreiPopescu.CharazayPlus.UI.TrainingTabUserControl();
      this.tabPageC = new System.Windows.Forms.TabPage();
      this.ucC = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPagePF = new System.Windows.Forms.TabPage();
      this.ucPF = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageSF = new System.Windows.Forms.TabPage();
      this.ucSF = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageSG = new System.Windows.Forms.TabPage();
      this.ucSG = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPagePG = new System.Windows.Forms.TabPage();
      this.ucPG = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageSkills = new System.Windows.Forms.TabPage();
      this.ucPlayerSkills = new AndreiPopescu.CharazayPlus.UI.PlayerSkillsTabUserControl();
      this.tabPageStatus = new System.Windows.Forms.TabPage();
      this.ucStatus = new AndreiPopescu.CharazayPlus.UI.StatusUserControl();
      this.tabPageInfo = new System.Windows.Forms.TabPage();
      this.ucInfoTab = new AndreiPopescu.CharazayPlus.UI.InfoTabUserControl();
      this.sideTabControl = new AndreiPopescu.CharazayPlus.UI.SideTabControl();
      this.tabPageMyDivisionSchedule = new System.Windows.Forms.TabPage();
      this.ucDivisionSchedule = new AndreiPopescu.CharazayPlus.UI.DivisionScheduleUserControl();
      this.tabPageMyEconomy = new System.Windows.Forms.TabPage();
      this.ucMyEconomy = new AndreiPopescu.CharazayPlus.UI.MyEconomyUserControl();
      this.tabPageTL = new System.Windows.Forms.TabPage();
      this.ucTransferList = new AndreiPopescu.CharazayPlus.UI.TransferListUserControl();
      this.tabPageBrowser = new System.Windows.Forms.TabPage();
      this.ucSearchTM = new AndreiPopescu.CharazayPlus.UI.SearchTMUserControl();
      this.tabPageChartTM = new System.Windows.Forms.TabPage();
      this._chartTransferHistory = new AndreiPopescu.CharazayPlus.UI.ChartUserControl();
      this.tabPageAssessPlayer = new System.Windows.Forms.TabPage();
      this.imageListCountries = new System.Windows.Forms.ImageList(this.components);
      this.tsslbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslblr = new System.Windows.Forms.ToolStripStatusLabel();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.assessPlayerUserControl1 = new AndreiPopescu.CharazayPlus.UI.AssessPlayerUserControl();
      this.menuStrip1.SuspendLayout();
      this.tabPageMyDivisionStandings.SuspendLayout();
      this.tabPageMyTeamSchedule.SuspendLayout();
      this.tabPageTraining.SuspendLayout();
      this.tabPageC.SuspendLayout();
      this.tabPagePF.SuspendLayout();
      this.tabPageSF.SuspendLayout();
      this.tabPageSG.SuspendLayout();
      this.tabPagePG.SuspendLayout();
      this.tabPageSkills.SuspendLayout();
      this.tabPageStatus.SuspendLayout();
      this.tabPageInfo.SuspendLayout();
      this.sideTabControl.SuspendLayout();
      this.tabPageMyDivisionSchedule.SuspendLayout();
      this.tabPageMyEconomy.SuspendLayout();
      this.tabPageTL.SuspendLayout();
      this.tabPageBrowser.SuspendLayout();
      this.tabPageChartTM.SuspendLayout();
      this.tabPageAssessPlayer.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // tsmiTools
      // 
      this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOptions});
      this.tsmiTools.Name = "tsmiTools";
      this.tsmiTools.Size = new System.Drawing.Size(48, 20);
      this.tsmiTools.Text = "&Tools";
      // 
      // tsmiOptions
      // 
      this.tsmiOptions.Name = "tsmiOptions";
      this.tsmiOptions.Size = new System.Drawing.Size(116, 22);
      this.tsmiOptions.Text = "&Options";
      this.tsmiOptions.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.tsmiTools,
            this.tsmiHelp});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(872, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tschkShowGroups,
            this.tschkOwnerDrawn,
            this.tsmiFilter});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // tschkShowGroups
      // 
      this.tschkShowGroups.Checked = true;
      this.tschkShowGroups.CheckOnClick = true;
      this.tschkShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tschkShowGroups.Name = "tschkShowGroups";
      this.tschkShowGroups.Size = new System.Drawing.Size(145, 22);
      this.tschkShowGroups.Text = "Show &Groups";
      this.tschkShowGroups.CheckedChanged += new System.EventHandler(this.tschkShowGroups_CheckedChanged);
      this.tschkShowGroups.CheckStateChanged += new System.EventHandler(this.tschkShowGroups_CheckStateChanged);
      this.tschkShowGroups.Click += new System.EventHandler(this.tschkShowGroups_Click);
      // 
      // tschkOwnerDrawn
      // 
      this.tschkOwnerDrawn.Checked = true;
      this.tschkOwnerDrawn.CheckOnClick = true;
      this.tschkOwnerDrawn.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tschkOwnerDrawn.Name = "tschkOwnerDrawn";
      this.tschkOwnerDrawn.Size = new System.Drawing.Size(145, 22);
      this.tschkOwnerDrawn.Text = "&Owner drawn";
      // 
      // tsmiFilter
      // 
      this.tsmiFilter.CheckOnClick = true;
      this.tsmiFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstxtFilterText});
      this.tsmiFilter.Name = "tsmiFilter";
      this.tsmiFilter.Size = new System.Drawing.Size(145, 22);
      this.tsmiFilter.Text = "&Filter";
      this.tsmiFilter.CheckedChanged += new System.EventHandler(this.tsmiFilter_CheckedChanged);
      // 
      // tstxtFilterText
      // 
      this.tstxtFilterText.Enabled = false;
      this.tstxtFilterText.Name = "tstxtFilterText";
      this.tstxtFilterText.Size = new System.Drawing.Size(152, 23);
      this.tstxtFilterText.Text = "text";
      this.tstxtFilterText.TextChanged += new System.EventHandler(this.tstxtFilterText_TextChanged);
      // 
      // tsmiHelp
      // 
      this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.tsmiHelp.Name = "tsmiHelp";
      this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
      this.tsmiHelp.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // tabPageMyDivisionStandings
      // 
      this.tabPageMyDivisionStandings.Controls.Add(this.ucStandings);
      this.tabPageMyDivisionStandings.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyDivisionStandings.Name = "tabPageMyDivisionStandings";
      this.tabPageMyDivisionStandings.Size = new System.Drawing.Size(754, 579);
      this.tabPageMyDivisionStandings.TabIndex = 10;
      this.tabPageMyDivisionStandings.Text = "My Division Standings";
      this.tabPageMyDivisionStandings.UseVisualStyleBackColor = true;
      // 
      // ucStandings
      // 
      this.ucStandings.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucStandings.Location = new System.Drawing.Point(0, 0);
      this.ucStandings.Name = "ucStandings";
      this.ucStandings.Size = new System.Drawing.Size(754, 579);
      this.ucStandings.TabIndex = 1;
      // 
      // tabPageMyTeamSchedule
      // 
      this.tabPageMyTeamSchedule.Controls.Add(this.ucMyTeamSchedule);
      this.tabPageMyTeamSchedule.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyTeamSchedule.Name = "tabPageMyTeamSchedule";
      this.tabPageMyTeamSchedule.Size = new System.Drawing.Size(754, 579);
      this.tabPageMyTeamSchedule.TabIndex = 9;
      this.tabPageMyTeamSchedule.Text = "My Team Schedule";
      this.tabPageMyTeamSchedule.UseVisualStyleBackColor = true;
      // 
      // ucMyTeamSchedule
      // 
      this.ucMyTeamSchedule.AutoSize = true;
      this.ucMyTeamSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMyTeamSchedule.Location = new System.Drawing.Point(0, 0);
      this.ucMyTeamSchedule.Name = "ucMyTeamSchedule";
      this.ucMyTeamSchedule.Size = new System.Drawing.Size(754, 579);
      this.ucMyTeamSchedule.TabIndex = 0;
      // 
      // tabPageTraining
      // 
      this.tabPageTraining.Controls.Add(this.ucTraining);
      this.tabPageTraining.Location = new System.Drawing.Point(4, 4);
      this.tabPageTraining.Name = "tabPageTraining";
      this.tabPageTraining.Size = new System.Drawing.Size(754, 579);
      this.tabPageTraining.TabIndex = 7;
      this.tabPageTraining.Text = "Training";
      this.tabPageTraining.UseVisualStyleBackColor = true;
      // 
      // ucTraining
      // 
      this.ucTraining.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTraining.Location = new System.Drawing.Point(0, 0);
      this.ucTraining.Name = "ucTraining";
      this.ucTraining.Size = new System.Drawing.Size(754, 579);
      this.ucTraining.TabIndex = 0;
      // 
      // tabPageC
      // 
      this.tabPageC.Controls.Add(this.ucC);
      this.tabPageC.Location = new System.Drawing.Point(4, 4);
      this.tabPageC.Name = "tabPageC";
      this.tabPageC.Size = new System.Drawing.Size(754, 579);
      this.tabPageC.TabIndex = 6;
      this.tabPageC.Text = "C";
      this.tabPageC.UseVisualStyleBackColor = true;
      // 
      // ucC
      // 
      this.ucC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucC.Location = new System.Drawing.Point(0, 0);
      this.ucC.MinimumSize = new System.Drawing.Size(751, 576);
      this.ucC.Name = "ucC";
      this.ucC.Size = new System.Drawing.Size(751, 576);
      this.ucC.TabIndex = 0;
      // 
      // tabPagePF
      // 
      this.tabPagePF.Controls.Add(this.ucPF);
      this.tabPagePF.Location = new System.Drawing.Point(4, 4);
      this.tabPagePF.Name = "tabPagePF";
      this.tabPagePF.Size = new System.Drawing.Size(754, 579);
      this.tabPagePF.TabIndex = 5;
      this.tabPagePF.Text = "PF";
      this.tabPagePF.UseVisualStyleBackColor = true;
      // 
      // ucPF
      // 
      this.ucPF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucPF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucPF.Location = new System.Drawing.Point(0, 0);
      this.ucPF.MinimumSize = new System.Drawing.Size(751, 576);
      this.ucPF.Name = "ucPF";
      this.ucPF.Size = new System.Drawing.Size(751, 576);
      this.ucPF.TabIndex = 0;
      // 
      // tabPageSF
      // 
      this.tabPageSF.Controls.Add(this.ucSF);
      this.tabPageSF.Location = new System.Drawing.Point(4, 4);
      this.tabPageSF.Name = "tabPageSF";
      this.tabPageSF.Size = new System.Drawing.Size(754, 579);
      this.tabPageSF.TabIndex = 4;
      this.tabPageSF.Text = "SF";
      this.tabPageSF.UseVisualStyleBackColor = true;
      // 
      // ucSF
      // 
      this.ucSF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucSF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucSF.Location = new System.Drawing.Point(0, 0);
      this.ucSF.MinimumSize = new System.Drawing.Size(751, 576);
      this.ucSF.Name = "ucSF";
      this.ucSF.Size = new System.Drawing.Size(751, 576);
      this.ucSF.TabIndex = 0;
      // 
      // tabPageSG
      // 
      this.tabPageSG.Controls.Add(this.ucSG);
      this.tabPageSG.Location = new System.Drawing.Point(4, 4);
      this.tabPageSG.Name = "tabPageSG";
      this.tabPageSG.Size = new System.Drawing.Size(754, 579);
      this.tabPageSG.TabIndex = 3;
      this.tabPageSG.Text = "SG";
      this.tabPageSG.UseVisualStyleBackColor = true;
      // 
      // ucSG
      // 
      this.ucSG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucSG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucSG.Location = new System.Drawing.Point(0, 0);
      this.ucSG.MinimumSize = new System.Drawing.Size(751, 576);
      this.ucSG.Name = "ucSG";
      this.ucSG.Size = new System.Drawing.Size(751, 576);
      this.ucSG.TabIndex = 0;
      // 
      // tabPagePG
      // 
      this.tabPagePG.Controls.Add(this.ucPG);
      this.tabPagePG.Location = new System.Drawing.Point(4, 4);
      this.tabPagePG.Name = "tabPagePG";
      this.tabPagePG.Size = new System.Drawing.Size(754, 579);
      this.tabPagePG.TabIndex = 2;
      this.tabPagePG.Text = "PG";
      this.tabPagePG.UseVisualStyleBackColor = true;
      // 
      // ucPG
      // 
      this.ucPG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucPG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucPG.Location = new System.Drawing.Point(0, 0);
      this.ucPG.MinimumSize = new System.Drawing.Size(751, 576);
      this.ucPG.Name = "ucPG";
      this.ucPG.Size = new System.Drawing.Size(751, 576);
      this.ucPG.TabIndex = 0;
      // 
      // tabPageSkills
      // 
      this.tabPageSkills.Controls.Add(this.ucPlayerSkills);
      this.tabPageSkills.Location = new System.Drawing.Point(4, 4);
      this.tabPageSkills.Name = "tabPageSkills";
      this.tabPageSkills.Size = new System.Drawing.Size(754, 579);
      this.tabPageSkills.TabIndex = 14;
      this.tabPageSkills.Text = "Skills";
      this.tabPageSkills.UseVisualStyleBackColor = true;
      // 
      // ucPlayerSkills
      // 
      this.ucPlayerSkills.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucPlayerSkills.Location = new System.Drawing.Point(0, 0);
      this.ucPlayerSkills.Name = "ucPlayerSkills";
      this.ucPlayerSkills.Size = new System.Drawing.Size(754, 579);
      this.ucPlayerSkills.TabIndex = 0;
      // 
      // tabPageStatus
      // 
      this.tabPageStatus.Controls.Add(this.ucStatus);
      this.tabPageStatus.Location = new System.Drawing.Point(4, 4);
      this.tabPageStatus.Name = "tabPageStatus";
      this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageStatus.Size = new System.Drawing.Size(754, 579);
      this.tabPageStatus.TabIndex = 0;
      this.tabPageStatus.Text = "Status";
      this.tabPageStatus.UseVisualStyleBackColor = true;
      // 
      // ucStatus
      // 
      this.ucStatus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucStatus.Location = new System.Drawing.Point(3, 3);
      this.ucStatus.Name = "ucStatus";
      this.ucStatus.Size = new System.Drawing.Size(748, 573);
      this.ucStatus.TabIndex = 0;
      // 
      // tabPageInfo
      // 
      this.tabPageInfo.Controls.Add(this.ucInfoTab);
      this.tabPageInfo.Location = new System.Drawing.Point(4, 4);
      this.tabPageInfo.Name = "tabPageInfo";
      this.tabPageInfo.Size = new System.Drawing.Size(754, 579);
      this.tabPageInfo.TabIndex = 8;
      this.tabPageInfo.Text = "Info";
      this.tabPageInfo.UseVisualStyleBackColor = true;
      // 
      // ucInfoTab
      // 
      this.ucInfoTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucInfoTab.Location = new System.Drawing.Point(0, 0);
      this.ucInfoTab.Name = "ucInfoTab";
      this.ucInfoTab.Size = new System.Drawing.Size(754, 576);
      this.ucInfoTab.TabIndex = 0;
      // 
      // sideTabControl
      // 
      this.sideTabControl.Alignment = System.Windows.Forms.TabAlignment.Right;
      this.sideTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.sideTabControl.Controls.Add(this.tabPageInfo);
      this.sideTabControl.Controls.Add(this.tabPageStatus);
      this.sideTabControl.Controls.Add(this.tabPageSkills);
      this.sideTabControl.Controls.Add(this.tabPagePG);
      this.sideTabControl.Controls.Add(this.tabPageSG);
      this.sideTabControl.Controls.Add(this.tabPageSF);
      this.sideTabControl.Controls.Add(this.tabPagePF);
      this.sideTabControl.Controls.Add(this.tabPageC);
      this.sideTabControl.Controls.Add(this.tabPageTraining);
      this.sideTabControl.Controls.Add(this.tabPageMyTeamSchedule);
      this.sideTabControl.Controls.Add(this.tabPageMyDivisionStandings);
      this.sideTabControl.Controls.Add(this.tabPageMyDivisionSchedule);
      this.sideTabControl.Controls.Add(this.tabPageMyEconomy);
      this.sideTabControl.Controls.Add(this.tabPageTL);
      this.sideTabControl.Controls.Add(this.tabPageBrowser);
      this.sideTabControl.Controls.Add(this.tabPageChartTM);
      this.sideTabControl.Controls.Add(this.tabPageAssessPlayer);
      this.sideTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
      this.sideTabControl.ItemSize = new System.Drawing.Size(26, 104);
      this.sideTabControl.Location = new System.Drawing.Point(0, 27);
      this.sideTabControl.MinimumSize = new System.Drawing.Size(104, 104);
      this.sideTabControl.Multiline = true;
      this.sideTabControl.Name = "sideTabControl";
      this.sideTabControl.SelectedIndex = 0;
      this.sideTabControl.Size = new System.Drawing.Size(866, 587);
      this.sideTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.sideTabControl.TabIndex = 1;
      this.sideTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.sideTabControl_Selected);
      // 
      // tabPageMyDivisionSchedule
      // 
      this.tabPageMyDivisionSchedule.Controls.Add(this.ucDivisionSchedule);
      this.tabPageMyDivisionSchedule.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyDivisionSchedule.Name = "tabPageMyDivisionSchedule";
      this.tabPageMyDivisionSchedule.Size = new System.Drawing.Size(754, 579);
      this.tabPageMyDivisionSchedule.TabIndex = 13;
      this.tabPageMyDivisionSchedule.Text = "My division schedule";
      // 
      // ucDivisionSchedule
      // 
      this.ucDivisionSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucDivisionSchedule.Location = new System.Drawing.Point(0, 0);
      this.ucDivisionSchedule.Name = "ucDivisionSchedule";
      this.ucDivisionSchedule.Size = new System.Drawing.Size(754, 579);
      this.ucDivisionSchedule.TabIndex = 0;
      // 
      // tabPageMyEconomy
      // 
      this.tabPageMyEconomy.Controls.Add(this.ucMyEconomy);
      this.tabPageMyEconomy.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyEconomy.Name = "tabPageMyEconomy";
      this.tabPageMyEconomy.Size = new System.Drawing.Size(754, 579);
      this.tabPageMyEconomy.TabIndex = 11;
      this.tabPageMyEconomy.Text = "My Economy";
      this.tabPageMyEconomy.UseVisualStyleBackColor = true;
      // 
      // ucMyEconomy
      // 
      this.ucMyEconomy.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMyEconomy.Location = new System.Drawing.Point(0, 0);
      this.ucMyEconomy.MyTeamId = ((uint)(0u));
      this.ucMyEconomy.Name = "ucMyEconomy";
      this.ucMyEconomy.Size = new System.Drawing.Size(754, 579);
      this.ucMyEconomy.TabIndex = 0;
      // 
      // tabPageTL
      // 
      this.tabPageTL.Controls.Add(this.ucTransferList);
      this.tabPageTL.Location = new System.Drawing.Point(4, 4);
      this.tabPageTL.Name = "tabPageTL";
      this.tabPageTL.Size = new System.Drawing.Size(754, 579);
      this.tabPageTL.TabIndex = 12;
      this.tabPageTL.Text = "Transfer List";
      this.tabPageTL.UseVisualStyleBackColor = true;
      // 
      // ucTransferList
      // 
      this.ucTransferList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTransferList.Location = new System.Drawing.Point(0, 0);
      this.ucTransferList.Name = "ucTransferList";
      this.ucTransferList.Size = new System.Drawing.Size(754, 579);
      this.ucTransferList.TabIndex = 0;
      // 
      // tabPageBrowser
      // 
      this.tabPageBrowser.Controls.Add(this.ucSearchTM);
      this.tabPageBrowser.Location = new System.Drawing.Point(4, 4);
      this.tabPageBrowser.Name = "tabPageBrowser";
      this.tabPageBrowser.Size = new System.Drawing.Size(754, 579);
      this.tabPageBrowser.TabIndex = 15;
      this.tabPageBrowser.Text = "Browser";
      this.tabPageBrowser.UseVisualStyleBackColor = true;
      // 
      // ucSearchTM
      // 
      this.ucSearchTM.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucSearchTM.ImageListCountries = null;
      this.ucSearchTM.Location = new System.Drawing.Point(0, 0);
      this.ucSearchTM.Name = "ucSearchTM";
      this.ucSearchTM.Size = new System.Drawing.Size(754, 579);
      this.ucSearchTM.TabIndex = 0;
      // 
      // tabPageChartTM
      // 
      this.tabPageChartTM.Controls.Add(this._chartTransferHistory);
      this.tabPageChartTM.Location = new System.Drawing.Point(4, 4);
      this.tabPageChartTM.Name = "tabPageChartTM";
      this.tabPageChartTM.Size = new System.Drawing.Size(754, 579);
      this.tabPageChartTM.TabIndex = 16;
      this.tabPageChartTM.Text = "Transfer Chart";
      this.tabPageChartTM.UseVisualStyleBackColor = true;
      // 
      // _chartTransferHistory
      // 
      this._chartTransferHistory.Dock = System.Windows.Forms.DockStyle.Fill;
      this._chartTransferHistory.Location = new System.Drawing.Point(0, 0);
      this._chartTransferHistory.Name = "_chartTransferHistory";
      this._chartTransferHistory.Size = new System.Drawing.Size(754, 579);
      this._chartTransferHistory.TabIndex = 0;
      // 
      // tabPageAssessPlayer
      // 
      this.tabPageAssessPlayer.BackColor = System.Drawing.Color.DimGray;
      this.tabPageAssessPlayer.Controls.Add(this.assessPlayerUserControl1);
      this.tabPageAssessPlayer.ForeColor = System.Drawing.Color.White;
      this.tabPageAssessPlayer.Location = new System.Drawing.Point(4, 4);
      this.tabPageAssessPlayer.Name = "tabPageAssessPlayer";
      this.tabPageAssessPlayer.Size = new System.Drawing.Size(754, 579);
      this.tabPageAssessPlayer.TabIndex = 17;
      this.tabPageAssessPlayer.Text = "Assess Player";
      // 
      // imageListCountries
      // 
      this.imageListCountries.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCountries.ImageStream")));
      this.imageListCountries.TransparentColor = System.Drawing.Color.Transparent;
      this.imageListCountries.Images.SetKeyName(0, "no.png");
      this.imageListCountries.Images.SetKeyName(1, "dk.png");
      this.imageListCountries.Images.SetKeyName(2, "se.png");
      this.imageListCountries.Images.SetKeyName(3, "us.png");
      this.imageListCountries.Images.SetKeyName(4, "ro.png");
      this.imageListCountries.Images.SetKeyName(5, "pl.png");
      this.imageListCountries.Images.SetKeyName(6, "nl.png");
      this.imageListCountries.Images.SetKeyName(7, "lt.png");
      this.imageListCountries.Images.SetKeyName(8, "it.png");
      this.imageListCountries.Images.SetKeyName(9, "il.png");
      this.imageListCountries.Images.SetKeyName(10, "gr.png");
      this.imageListCountries.Images.SetKeyName(11, "es.png");
      this.imageListCountries.Images.SetKeyName(12, "en.png");
      this.imageListCountries.Images.SetKeyName(13, "ee.png");
      this.imageListCountries.Images.SetKeyName(14, "ca.png");
      this.imageListCountries.Images.SetKeyName(15, "br.png");
      this.imageListCountries.Images.SetKeyName(16, "be.png");
      this.imageListCountries.Images.SetKeyName(17, "fr.png");
      this.imageListCountries.Images.SetKeyName(18, "de.png");
      this.imageListCountries.Images.SetKeyName(19, "si.png");
      this.imageListCountries.Images.SetKeyName(20, "uy.png");
      this.imageListCountries.Images.SetKeyName(21, "lv.png");
      this.imageListCountries.Images.SetKeyName(22, "cl.png");
      this.imageListCountries.Images.SetKeyName(23, "pt.png");
      this.imageListCountries.Images.SetKeyName(24, "fi.png");
      this.imageListCountries.Images.SetKeyName(25, "enumerable.png");
      this.imageListCountries.Images.SetKeyName(26, "au.png");
      this.imageListCountries.Images.SetKeyName(27, "rs.png");
      this.imageListCountries.Images.SetKeyName(28, "hr.png");
      this.imageListCountries.Images.SetKeyName(29, "at.png");
      this.imageListCountries.Images.SetKeyName(30, "al.png");
      this.imageListCountries.Images.SetKeyName(31, "by.png");
      this.imageListCountries.Images.SetKeyName(32, "bo.png");
      this.imageListCountries.Images.SetKeyName(33, "ba.png");
      this.imageListCountries.Images.SetKeyName(34, "bg.png");
      this.imageListCountries.Images.SetKeyName(35, "cm.png");
      this.imageListCountries.Images.SetKeyName(36, "cz.png");
      this.imageListCountries.Images.SetKeyName(37, "cy.png");
      this.imageListCountries.Images.SetKeyName(38, "co.png");
      this.imageListCountries.Images.SetKeyName(39, "eg.png");
      this.imageListCountries.Images.SetKeyName(40, "gg.png");
      this.imageListCountries.Images.SetKeyName(41, "mk.png");
      this.imageListCountries.Images.SetKeyName(42, "id.png");
      this.imageListCountries.Images.SetKeyName(43, "jm.png");
      this.imageListCountries.Images.SetKeyName(44, "mx.png");
      this.imageListCountries.Images.SetKeyName(45, "ng.png");
      this.imageListCountries.Images.SetKeyName(46, "sa.png");
      this.imageListCountries.Images.SetKeyName(47, "sk.png");
      this.imageListCountries.Images.SetKeyName(48, "kr.png");
      this.imageListCountries.Images.SetKeyName(49, "ua.png");
      this.imageListCountries.Images.SetKeyName(50, "hu.png");
      this.imageListCountries.Images.SetKeyName(51, "cn.png");
      this.imageListCountries.Images.SetKeyName(52, "ru.png");
      this.imageListCountries.Images.SetKeyName(53, "tr.png");
      this.imageListCountries.Images.SetKeyName(54, "pi.png");
      this.imageListCountries.Images.SetKeyName(55, "jp.png");
      this.imageListCountries.Images.SetKeyName(56, "th.png");
      this.imageListCountries.Images.SetKeyName(57, "sg.png");
      this.imageListCountries.Images.SetKeyName(58, "nz.png");
      this.imageListCountries.Images.SetKeyName(59, "am.png");
      this.imageListCountries.Images.SetKeyName(60, "az.png");
      this.imageListCountries.Images.SetKeyName(61, "gh.png");
      this.imageListCountries.Images.SetKeyName(62, "is.png");
      this.imageListCountries.Images.SetKeyName(63, "ir.png");
      this.imageListCountries.Images.SetKeyName(64, "ci.png");
      this.imageListCountries.Images.SetKeyName(65, "py.png");
      this.imageListCountries.Images.SetKeyName(66, "pe.png");
      this.imageListCountries.Images.SetKeyName(67, "sn.png");
      this.imageListCountries.Images.SetKeyName(68, "za.png");
      this.imageListCountries.Images.SetKeyName(69, "ch.png");
      this.imageListCountries.Images.SetKeyName(70, "tn.png");
      this.imageListCountries.Images.SetKeyName(71, "ve.png");
      this.imageListCountries.Images.SetKeyName(72, "tw.png");
      this.imageListCountries.Images.SetKeyName(73, "pr.png");
      // 
      // tsslbl
      // 
      this.tsslbl.Name = "tsslbl";
      this.tsslbl.Size = new System.Drawing.Size(130, 17);
      this.tsslbl.Text = "                                         ";
      // 
      // tsslblr
      // 
      this.tsslblr.AutoSize = false;
      this.tsslblr.Name = "tsslblr";
      this.tsslblr.Size = new System.Drawing.Size(700, 17);
      this.tsslblr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbl,
            this.tsslblr});
      this.statusStrip.Location = new System.Drawing.Point(0, 617);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(872, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // assessPlayerUserControl1
      // 
      this.assessPlayerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.assessPlayerUserControl1.Location = new System.Drawing.Point(0, 0);
      this.assessPlayerUserControl1.Name = "assessPlayerUserControl1";
      this.assessPlayerUserControl1.Size = new System.Drawing.Size(754, 579);
      this.assessPlayerUserControl1.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(872, 639);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.sideTabControl);
      this.DoubleBuffered = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(800, 600);
      this.Name = "MainForm";
      this.Text = "Charazay Plus";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabPageMyDivisionStandings.ResumeLayout(false);
      this.tabPageMyTeamSchedule.ResumeLayout(false);
      this.tabPageMyTeamSchedule.PerformLayout();
      this.tabPageTraining.ResumeLayout(false);
      this.tabPageC.ResumeLayout(false);
      this.tabPagePF.ResumeLayout(false);
      this.tabPageSF.ResumeLayout(false);
      this.tabPageSG.ResumeLayout(false);
      this.tabPagePG.ResumeLayout(false);
      this.tabPageSkills.ResumeLayout(false);
      this.tabPageStatus.ResumeLayout(false);
      this.tabPageInfo.ResumeLayout(false);
      this.sideTabControl.ResumeLayout(false);
      this.tabPageMyDivisionSchedule.ResumeLayout(false);
      this.tabPageMyEconomy.ResumeLayout(false);
      this.tabPageTL.ResumeLayout(false);
      this.tabPageBrowser.ResumeLayout(false);
      this.tabPageChartTM.ResumeLayout(false);
      this.tabPageAssessPlayer.ResumeLayout(false);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    #region Cache related
    /// <summary>
    /// used on tab change to status
    /// </summary>
    private void AddMyPlayersToCache()
    {
      foreach (var op in PlayersEnvironment.OptimumPlayers)
      {
        CacheManager.Instance.AddPlayer(op.Id, op.FullName);
      }
    }

    private void AddMyTeamScheduleToCache()
    {

      foreach (var m in MyXmlTeam.Schedule)
      {
        CacheManager.Instance.AddTeam(m.HomeTeamId, m.HomeTeamName);
        CacheManager.Instance.AddTeam(m.AwayTeamId, m.AwayTeamName);
        CacheManager.Instance.AddMatch(m);
      }  
    }

    #endregion

    #region main form event handlers
    private void MainForm_Load(object sender, EventArgs e)
    {
      sideTabControl.SelectedTab = tabPageInfo;
      tabPageInfo.Focus();
      InitInfoTab();
    }

    SideTabPage _lastTab = SideTabPage.Info;
    
    /// <summary>
    /// selected side tab change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void sideTabControl_Selected(object sender, TabControlEventArgs e)
    {
      SideTabPage currentTab = (SideTabPage)e.TabPageIndex;
      //if (currentTab != SideTabPage.TL && _lastTab == SideTabPage.TL)
        //this.ucTransferList.SerializePlayersTL();
      //
      switch (currentTab)
      {
        case SideTabPage.Status:
          {
            this.ucStatus.initStatus(PlayersEnvironment.OptimumPlayers, this.imageListCountries);
            AddMyPlayersToCache();
          } break;

        case SideTabPage.PG: ucPG.Init(PlayersEnvironment.PointGuards); break;
        case SideTabPage.SG: ucSG.Init(PlayersEnvironment.ShootingGuards); break;
        case SideTabPage.PF: ucPF.Init(PlayersEnvironment.PowerForwards); break;
        case SideTabPage.SF: ucSF.Init(PlayersEnvironment.SmallForwards); break;
        case SideTabPage.C: ucC.Init(PlayersEnvironment.Centers); break;

        case SideTabPage.Training:
          {
            ucTraining.initCoachesList();
            ucTraining.initTrainingSkillIncrease();
            ucTraining.initTrainingScoreIncrease();
            ucTraining.initTrainingEfficiency();
          } break;

        case SideTabPage.Info: InitInfoTab(); break;

        case SideTabPage.MyTeamSchedule: InitMyTeamSchedule(); break;

        case SideTabPage.MyDivisionStandings: InitMyDivisionStandings(); break;

        case SideTabPage.MyDivisionSchedule: this.ucDivisionSchedule.InitOLV(MyXmlTeam.DivisionSchedule); break;

        case SideTabPage.MyEconomy: InitMyEconomy(); break;

        case SideTabPage.TL: InitTL(); break;

        case SideTabPage.Skills: InitSkillsTab(); break;

        case SideTabPage.WebBrowser: 
          this.ucSearchTM.ImageListCountries = this.imageListCountries;
          this.ucSearchTM.PlayerError += (sndr, ev) => { tsslbl.Text = String.Format("Player error: {0}", ev.ErrorMessage); };
          break;

        case SideTabPage.AssessPlayer:
        case SideTabPage.GraphTransferMarket:

        default: break;
      }
      // update last selected
      _lastTab = currentTab;
    }

    void formLogin_CorrectUserInformation (object sender, EventArgs e)
    {
      UI.LoginForm formLogin = (UI.LoginForm)sender;
      //
      //AssignWebServiceManager();
      //
      // down + deserialize xmls
      //
      formLogin.Info("downloading team info");
      //DownloadMandatoryXmlFiles();
        if (MyXmlTeam.UserInfo == null || MyXmlTeam.TeamInfo == null)
          throw new ApplicationException();

      formLogin.Info("downloading additional data");
      //DownloadXmlAdditional();
      formLogin.Info("ready...");
      //     
      formLogin.Close();
    }
        
    /// <summary>
    /// override for sole application instance
    /// </summary>
    /// <param name="m">windows message</param>
    protected override void WndProc (ref Message m)
    {
      if (m.Msg == NativeMethods.WM_SHOWME)
      {
        if (this.WindowState == FormWindowState.Minimized)
        {
          this.WindowState = FormWindowState.Normal;
        }
        //
        this.Activate();
        //
        bool bRestoreTopMost = this.TopMost;
        this.TopMost = true;
        this.TopMost = bRestoreTopMost;    
        //
        // activate any visible owned modal dialog (Form or not), if any
        ModalWindowUtil.ActivateWindow(ModalWindowUtil.GetModalWindow(Handle));
      }
      base.WndProc(ref m);
    }

    #endregion

    #region utility

    private void InitInfoTab ( )
    {
      var ipg = new Objects.InfoPropertyGridObject(MyXmlTeam.Arena, MyXmlTeam.UserInfo, MyXmlTeam.TeamInfo, MyXmlTeam.CountryInfo, imageListCountries);
      this.ucInfoTab.SelectedGridObject = ipg;
      var sbl = new SortableBindingList<Xsd2.charazayCountryDivision>(MyXmlTeam.CountryInfo.division);
      this.ucInfoTab.DataContext(sbl);
    }

    private void InitSkillsTab ( )
    {
      ucPlayerSkills.Initialize();
      this.ucPlayerSkills.SelectionChanged += (sndr, ev) =>
      {
        this.tsslbl.Text = String.Format("Selected {0} of {1} items", ev.SelectedIndices, ev.ItemCount);
        this.tsslblr.Text = String.Format("Selected player: {0}", ev.FullName);
      };
    }

    private void InitTL ( )
    {
      ucTransferList.InitTransferShortList();
      ucTransferList.PlayerDataUnavailable += (sndr, ev) => { 
        tsslbl.Text = "Player Data Unavailable";
        if (string.IsNullOrEmpty(ev.ErrorMessage))
          tsslbl.Text += ": " + ev.ErrorMessage;
        };
      ucTransferList.BadPlayerId += (sndr, ev) => { tsslbl.Text = "Bad Player Id"; };
      ucTransferList.DownloadPlayerData += (sndr, ev) => { tsslbl.Text = "Downloaded Player Data for: " + ev.Name + " " + ev.Surname; };
    }

    private void InitMyEconomy ( )
    {
      //ucMyEconomy.InitDgMyTransfers(_myTransfers);
      this.ucMyEconomy.MyTeamId = MyXmlTeam.TeamInfo.id;
      ucMyEconomy.InitOLV(MyXmlTeam.Transfers);
      ucMyEconomy.InitEconomyUserControls(MyXmlTeam.Economy);
    }

    private void InitMyDivisionStandings ( )
    {
      ucStandings.Init(MyXmlTeam.Standings.standings);
      ucStandings.DivisionName = MyXmlTeam.Standings.name;
      ucStandings.Hardiness = MyXmlTeam.Standings.lh;
      ucStandings.DivisionId = MyXmlTeam.Standings.id;
      ucStandings.Level = MyXmlTeam.Standings.level;
      //ucStandings.Country = MyXmlTeam.Standings.countryid;
    }

    private void InitMyTeamSchedule ( )
    {
      //this.ucMyTeamSchedule.MySchedule = this.MyXmlTeam.Schedule;
      //this.ucMyTeamSchedule.Team = this.MyXmlTeam.TeamInfo;
      //this.ucMyTeamSchedule.initTeamScheduleFilter();
      //this.ucMyTeamSchedule.initDgMySchedule();

      this.ucMyTeamSchedule.Init(MyXmlTeam.Schedule, MyXmlTeam.TeamInfo.id);
      AddMyTeamScheduleToCache();
    }
        
    #endregion

    #region application/view menu
    private void tschkShowGroups_CheckedChanged (object sender, EventArgs e)
    {

    }

    private void tschkShowGroups_CheckStateChanged (object sender, EventArgs e)
    {

    }

    private void tschkShowGroups_Click (object sender, EventArgs e)
    {

    }

    private void tstxtFilterText_TextChanged (object sender, EventArgs e)
    {
      
      if (sideTabControl.SelectedIndex == 2)
        ucPlayerSkills.ApplyFilter(tstxtFilterText.Text);
    }   

    private void tsmiFilter_CheckedChanged (object sender, EventArgs e)
    {
      tstxtFilterText.Enabled = tsmiFilter.Checked;
    }

    private void optionsToolStripMenuItem_Click (object sender, EventArgs e)
    {
      UI.LoginForm loginForm = new UI.LoginForm();
      loginForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      loginForm.Show(this);
    }

    private void aboutToolStripMenuItem_Click (object sender, EventArgs e)
    {
      UI.AboutForm aboutForm = new UI.AboutForm();
      aboutForm.Show(this);
    }
    #endregion

       
   }


 
}
