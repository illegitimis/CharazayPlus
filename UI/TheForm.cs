
namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using System.Xml.Serialization;
  using System.IO;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.UI;
    
  public partial class MainForm : System.Windows.Forms.Form
  {
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
    }

    #region Behavior fields
    List<PG> _pgs = new List<PG>();
    List<SG> _sgs = new List<SG>();
    List<SF> _sfs = new List<SF>();
    List<PF> _pfs = new List<PF>();
    List<C> _cs = new List<C>();

    List<Player> _optimumPlayers = new List<Player>(); 
    List<Coach> _coaches = new List<Coach>();

    // info tab

    Xsd2.charazayArena _arena;
    Xsd2.charazayTeam _team;
    Xsd2.charazayUser _user;
    Xsd2.charazayCountry _country;


    // my Schedule tab (comes from Schedule)
    Xsd2.charazayDivision _myDivisionStandings;
    Xsd2.match[] _mySchedule;


    // my Division tab (comes from DivisionSchedule)

    Xsd2.charazayRound[] _myDivisionFullSchedule;    
    Xsd2.match _selectedMatch;
  

    // money

    Xsd2.charazayEconomy _economy;
    Xsd2.charazayTransfer[] _myTransfers;


    /// <summary>
    /// 
    /// </summary>
    private /*readonly*/ Web.WebServiceUser _wsu;
      //new Web.WebServiceUser("stergein", "security_code", 1013, 5, 21191);

    #endregion

    #region designer fields

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    // status column customized designer 
    //private HeaderStateStyle hssSkillsDisplay;
    //private HeaderStateStyle hssSkillsActive;
    //private HeaderFormatStyle hfsSkillsTab;
    private System.Windows.Forms.ImageList imageListCountries;
    // positions (attributes)
    private UI.SideTabControl sideTabControl;
    private System.Windows.Forms.TabPage tabPageStatus;
    private System.Windows.Forms.TabPage tabPagePG;
    private System.Windows.Forms.TabPage tabPageSG;
    private System.Windows.Forms.TabPage tabPageSF;
    private System.Windows.Forms.TabPage tabPagePF;
    private System.Windows.Forms.TabPage tabPageC;
    private System.Windows.Forms.TabPage tabPageTraining;
    //private VerticalLabel labelCoachesList;
    private TabPage tabPageInfo;
    private TabPage tabPageMyTeamSchedule;
    private TabPage tabPageMyDivisionStandings;
    private TabPage tabPageMyEconomy;
    private TabPage tabPageTL;
    private TabPage tabPageMyDivisionSchedule;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem tsmiTools;
    private ToolStripMenuItem tsmiOptions;
    private ToolStripMenuItem tsmiHelp;
    private TrainingTabUserControl ucTraining;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private TabPage tabPageSkills;
    private UI.PlayerSkillsUserControl ucPlayerSkills;
    //private UI.MyTeamScheduleUserControl ucMyTeamSchedule;
    UI.TeamScheduleUserControl ucMyTeamSchedule;
    private UI.InfoTabUserControl ucInfoTab;
    private StatusUserControl ucStatus;
    private PlayerPositionUserControl ucPG;
    private PlayerPositionUserControl ucC;
    private PlayerPositionUserControl ucSF;
    private PlayerPositionUserControl ucPF;
    private PlayerPositionUserControl ucSG;
    private MyEconomyUserControl ucMyEconomy;
    private DivisionScheduleUserControl ucDivisionSchedule;
    private DivisionStandingsUserControl ucStandings;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem tschkShowGroups;
    private ToolStripMenuItem tschkOwnerDrawn;
    private ToolStripMenuItem tsmiFilter;
    private ToolStripTextBox tstxtFilterText;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel tsslbl;
    private ToolStripStatusLabel tsslblr;
    private UI.TransferListUserControl ucTransferList;
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

    private void DownloadXmlFiles(Web.DownloadItem[] xmls)
    {
      using (Web.Downloader crawler = new Web.Downloader())
      {
        foreach (Web.DownloadItem xml in xmls)
          crawler.Add(xml);   
        // download items
        crawler.Get(true);

        try
        {
          //foreach (Web.XmlDownloadItem di in m_xmlDownloadItems)
          foreach (Web.XmlDownloadItem di in crawler.Items)
            DeserializeXml(di);
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.Write(ex.Message);
        }
      }
    }

    private void DownloadMandatoryXmlFiles () 
    {   //
        // mandatory first
        //
        Web.DownloadItem[] xmls = new Web.DownloadItem[] {
            new Web.MyInfoXml(_wsu)
          , new Web.MyTeamInfoXml(_wsu) 
        };

        DownloadXmlFiles(xmls);      
    }

    /// <summary>
    /// 
    /// </summary>
    private void DownloadXmlAdditional()
    {
      if (_pgs != null && _pgs.Count != 0) 
        return;

      //coachesXml.DeserializationReturnType
      //myPlayersXml.m_offline = coachesXml.m_offline = true;
      //crawler.AddRange(m_xmlDownloadItems);

      Web.DownloadItem[] xmls = new Web.DownloadItem[] {
      new Web.MyPlayersXml(_wsu)
      ,new Web.CoachesXml(_wsu)               
      ,new Web.ArenaXml(_wsu)
      ,new Web.CountryDivisionListXml(_wsu)
      ,new Web.MyScheduleXml(_wsu)
      ,new Web.DivisionStandingsXml(_wsu)
      ,new Web.DivisionScheduleXml(_wsu)
      ,new Web.EconomyXml(_wsu)
      ,new Web.MyTransfersXml(_wsu)
      };

     DownloadXmlFiles(xmls);
      
    }
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
      this.imageListCountries = new System.Windows.Forms.ImageList(this.components);
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tschkShowGroups = new System.Windows.Forms.ToolStripMenuItem();
      this.tschkOwnerDrawn = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiFilter = new System.Windows.Forms.ToolStripMenuItem();
      this.tstxtFilterText = new System.Windows.Forms.ToolStripTextBox();
      this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.tsslbl = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslblr = new System.Windows.Forms.ToolStripStatusLabel();
      this.sideTabControl = new AndreiPopescu.CharazayPlus.UI.SideTabControl();
      this.tabPageInfo = new System.Windows.Forms.TabPage();
      this.ucInfoTab = new AndreiPopescu.CharazayPlus.UI.InfoTabUserControl();
      this.tabPageStatus = new System.Windows.Forms.TabPage();
      this.ucStatus = new AndreiPopescu.CharazayPlus.UI.StatusUserControl();
      this.tabPageSkills = new System.Windows.Forms.TabPage();
      this.ucPlayerSkills = new AndreiPopescu.CharazayPlus.UI.PlayerSkillsUserControl();
      this.tabPagePG = new System.Windows.Forms.TabPage();
      this.ucPG = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageSG = new System.Windows.Forms.TabPage();
      this.ucSG = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageSF = new System.Windows.Forms.TabPage();
      this.ucSF = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPagePF = new System.Windows.Forms.TabPage();
      this.ucPF = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageC = new System.Windows.Forms.TabPage();
      this.ucC = new AndreiPopescu.CharazayPlus.UI.PlayerPositionUserControl();
      this.tabPageTraining = new System.Windows.Forms.TabPage();
      this.ucTraining = new AndreiPopescu.CharazayPlus.UI.TrainingTabUserControl();
      this.tabPageMyTeamSchedule = new System.Windows.Forms.TabPage();
      //this.ucMyTeamSchedule = new AndreiPopescu.CharazayPlus.UI.MyTeamScheduleUserControl();
      this.ucMyTeamSchedule = new AndreiPopescu.CharazayPlus.UI.TeamScheduleUserControl();
      this.tabPageMyDivisionStandings = new System.Windows.Forms.TabPage();
      this.ucStandings = new AndreiPopescu.CharazayPlus.UI.DivisionStandingsUserControl();
      this.tabPageMyDivisionSchedule = new System.Windows.Forms.TabPage();
      this.ucDivisionSchedule = new AndreiPopescu.CharazayPlus.UI.DivisionScheduleUserControl();
      this.tabPageMyEconomy = new System.Windows.Forms.TabPage();
      this.ucMyEconomy = new AndreiPopescu.CharazayPlus.UI.MyEconomyUserControl();
      this.tabPageTL = new System.Windows.Forms.TabPage();
      this.ucTransferList = new AndreiPopescu.CharazayPlus.UI.TransferListUserControl();
      this.menuStrip1.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.sideTabControl.SuspendLayout();
      this.tabPageInfo.SuspendLayout();
      this.tabPageStatus.SuspendLayout();
      this.tabPageSkills.SuspendLayout();
      this.tabPagePG.SuspendLayout();
      this.tabPageSG.SuspendLayout();
      this.tabPageSF.SuspendLayout();
      this.tabPagePF.SuspendLayout();
      this.tabPageC.SuspendLayout();
      this.tabPageTraining.SuspendLayout();
      this.tabPageMyTeamSchedule.SuspendLayout();
      this.tabPageMyDivisionStandings.SuspendLayout();
      this.tabPageMyDivisionSchedule.SuspendLayout();
      this.tabPageMyEconomy.SuspendLayout();
      this.tabPageTL.SuspendLayout();
      this.SuspendLayout();
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
      this.imageListCountries.Images.SetKeyName(25, "ar.png");
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
      this.ucInfoTab.Size = new System.Drawing.Size(754, 558);
      this.ucInfoTab.TabIndex = 0;
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
      this.ucStatus.Size = new System.Drawing.Size(7, 236);
      this.ucStatus.TabIndex = 0;
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
      this.ucPlayerSkills.Players = null;
      this.ucPlayerSkills.Size = new System.Drawing.Size(13, 242);
      this.ucPlayerSkills.TabIndex = 0;
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
      this.ucTraining.Coaches = null;
      this.ucTraining.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTraining.Location = new System.Drawing.Point(0, 0);
      this.ucTraining.Name = "ucTraining";
      this.ucTraining.OptimumPlayers = null;
      this.ucTraining.Size = new System.Drawing.Size(13, 242);
      this.ucTraining.TabIndex = 0;
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
      //this.ucMyTeamSchedule.MySchedule = null;
      this.ucMyTeamSchedule.Name = "ucMyTeamSchedule";
      this.ucMyTeamSchedule.Size = new System.Drawing.Size(0, 242);
      this.ucMyTeamSchedule.TabIndex = 0;
      //this.ucMyTeamSchedule.Team = null;
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
      this.ucStandings.Size = new System.Drawing.Size(0, 242);
      this.ucStandings.TabIndex = 1;
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
      this.ucDivisionSchedule.Size = new System.Drawing.Size(0, 242);
      this.ucDivisionSchedule.TabIndex = 0;
      this.ucDivisionSchedule.User = null;
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
      this.ucMyEconomy.Size = new System.Drawing.Size(0, 242);
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
      this.ucTransferList.Size = new System.Drawing.Size(0, 242);
      this.ucTransferList.TabIndex = 0;
      this.ucTransferList.User = null;
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
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.sideTabControl.ResumeLayout(false);
      this.tabPageInfo.ResumeLayout(false);
      this.tabPageStatus.ResumeLayout(false);
      this.tabPageSkills.ResumeLayout(false);
      this.tabPagePG.ResumeLayout(false);
      this.tabPageSG.ResumeLayout(false);
      this.tabPageSF.ResumeLayout(false);
      this.tabPagePF.ResumeLayout(false);
      this.tabPageC.ResumeLayout(false);
      this.tabPageTraining.ResumeLayout(false);
      this.tabPageMyTeamSchedule.ResumeLayout(false);
      this.tabPageMyTeamSchedule.PerformLayout();
      this.tabPageMyDivisionStandings.ResumeLayout(false);
      this.tabPageMyDivisionSchedule.ResumeLayout(false);
      this.tabPageMyEconomy.ResumeLayout(false);
      this.tabPageTL.ResumeLayout(false);
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
      foreach (var op in _optimumPlayers)
      {
        CacheManager.Instance.AddPlayer(op.Id, op.FullName);
      }
    }

    private void AddMyTeamScheduleToCache()
    {

      foreach (var m in _mySchedule)
      {
        CacheManager.Instance.AddTeam(m.HomeTeamId, m.HomeTeamName);
        CacheManager.Instance.AddTeam(m.AwayTeamId, m.AwayTeamName);
        CacheManager.Instance.AddMatch(m);
      }  
    }

    #endregion

    #region main form
    private void MainForm_Load(object sender, EventArgs e)
    {
      sideTabControl.SelectedTab = tabPageInfo;
      tabPageInfo.Focus();
      InitInfoTab();
    }

    /// <summary>
    /// selected side tab change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void sideTabControl_Selected(object sender, TabControlEventArgs e)
    {
      SideTabPage currentTab = (SideTabPage)e.TabPageIndex;
      if (currentTab != SideTabPage.TL && _lastTab == SideTabPage.TL)
        this.ucTransferList.SerializePlayersTL();
      //
      switch (currentTab)
      {
        case SideTabPage.Status:
          {
            this.ucStatus.initStatus(this._optimumPlayers, this.imageListCountries);
            AddMyPlayersToCache();
          } break;

        case SideTabPage.PG: ucPG.Init(_pgs); break;
        case SideTabPage.SG: ucSG.Init(_sgs); break;
        case SideTabPage.PF: ucPF.Init(_pfs); break;
        case SideTabPage.SF: ucSF.Init(_sfs); break;
        case SideTabPage.C: ucC.Init(_cs); break;

        case SideTabPage.Training:
        {
          ucTraining.Coaches = _coaches;
          ucTraining.OptimumPlayers = _optimumPlayers;
          ucTraining.initCoachesList();
          ucTraining.initTrainingSkillIncrease();
          ucTraining.initTrainingScoreIncrease();
          ucTraining.initTrainingPropertyGrid();
          ucTraining.initTrainingEfficiency();
        } break;

        case SideTabPage.Info: InitInfoTab(); break;
        case SideTabPage.MyTeamSchedule:
          {

            //this.ucMyTeamSchedule.MySchedule = this._mySchedule;
            //this.ucMyTeamSchedule.Team = this._team;
            //this.ucMyTeamSchedule.initTeamScheduleFilter();
            //this.ucMyTeamSchedule.initDgMySchedule();

            this.ucMyTeamSchedule.Init(this._mySchedule, this._team.id);

            AddMyTeamScheduleToCache();
          } break;

        case SideTabPage.MyDivisionStandings:
          { 

            ucStandings.Init(_myDivisionStandings.standings);
            ucStandings.DivisionName = _myDivisionStandings.name;
            ucStandings.Hardiness = _myDivisionStandings.lh;
            ucStandings.DivisionId = _myDivisionStandings.id;
            ucStandings.Level = _myDivisionStandings.level;
            //ucStandings.Country = _myDivisionStandings.countryid;

          } break;

        case SideTabPage.MyDivisionSchedule:
          this.ucDivisionSchedule.User = this._wsu;
          this.ucDivisionSchedule.InitOLV(_myDivisionFullSchedule);
          break;

        case SideTabPage.MyEconomy:
          {
            //ucMyEconomy.InitDgMyTransfers(_myTransfers);
            this.ucMyEconomy.MyTeamId = this._team.id;
            ucMyEconomy.InitOLV(_myTransfers);
            ucMyEconomy.InitEconomyUserControls(_economy);
          } break;

        case SideTabPage.TL:
          {
            ucTransferList.User = _wsu;
            ucTransferList.InitTransferShortList();
            ucTransferList.PlayerDataUnavailable += (sndr, ev) => { tsslbl.Text = "Player Data Unavailable"; };
            ucTransferList.BadPlayerId += (sndr, ev) => { tsslbl.Text = "Bad Player Id"; };
            ucTransferList.DownloadPlayerData += (sndr, ev) =>
              { tsslbl.Text = "Downloaded Player Data for: " + ev.Name + " " + ev.Surname; };
          } break;

        case SideTabPage.Skills:
          { 
            ucPlayerSkills.Players = _optimumPlayers; 
            this.ucPlayerSkills.SelectionChanged += (sndr,ev) => {
              this.tsslbl.Text = String.Format("Selected {0} of {1} items", ev.SelectedIndices, ev.ItemCount);
              this.tsslblr.Text = String.Format("Selected player: {0}", ev.FullName);
            };
              
          }
          break;

        default: break;
      }
      // update last selected
      _lastTab = currentTab;
    }
    SideTabPage _lastTab = SideTabPage.Info;

    
    public MainForm()
    {
      InitializeComponent();

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
        UI.FormLogin formLogin = new UI.FormLogin();
        formLogin.CorrectUserInformation += new EventHandler(formLogin_CorrectUserInformation);
        formLogin.ShowDialog(this);
      }
      else
      {
       _wsu = new Web.WebServiceUser(Properties.Settings.Default.UserName, Properties.Settings.Default.SecurityCode);
        //
        // down + deserialize xmls
        //
        DownloadMandatoryXmlFiles();
        DownloadXmlAdditional();
      }
            
    }

    void formLogin_CorrectUserInformation (object sender, EventArgs e)
    {
      UI.FormLogin formLogin = (UI.FormLogin)sender;
      _wsu = new Web.WebServiceUser(Properties.Settings.Default.UserName, Properties.Settings.Default.SecurityCode);
      //
      // down + deserialize xmls
      //
      formLogin.Info("downloading team info");
      DownloadMandatoryXmlFiles();
      formLogin.Info("downloading additional data");
      DownloadXmlAdditional();
      formLogin.Info("ready...");
      //     
      formLogin.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="di"></param>    
    private void DeserializeXml(Web.XmlDownloadItem di)
    {
      using (FileStream fs = new FileStream(di.m_fileName, FileMode.Open, FileAccess.Read))
      {
          Xsd2.charazay obj = null;

        try
        {
          obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
          switch (di.DeserializationType)
          { //
            // MyPlayers
            //
            case Web.XmlSerializationType.MyPlayers: 
              InitMyPlayers(obj.players); 
              break;
            //
            // di.DeserializationObject = obj.arena; 
            //
            case Web.XmlSerializationType.Arena:

                  _arena = obj.arena;            
              
              break;
            //
            // di.DeserializationObject = obj.team;
            // division id is a mandatory session variable
            //
            case Web.XmlSerializationType.MyTeamInfo:
              {

                _team = obj.team;           


                _wsu.divisionId = _team.team_info.divisionid;
              } break;
            // 
            // di.DeserializationObject = obj.user; 
            // country and team id are mandatory session variables
            // arenaid == teamid
            //
            case Web.XmlSerializationType.MyInfo:
              {

                _user = obj.user;
                if (obj.user == null)       


                throw new Exception("XmlSerializationType.MyInfo");
                _wsu.countryId = _user.countryid;
                _wsu.arenaId = _user.teamid;
              } break;

            case Web.XmlSerializationType.CountryDivisionList:

                _country = obj.country;

                break;
            //
            // Coaches
            // di.DeserializationObject = obj.coaches; 
            //
            case Web.XmlSerializationType.Coaches: 
          
                initCoachesData(obj.coaches);      


                break;
            //
            case Web.XmlSerializationType.MySchedule: 

                _mySchedule = obj.matches;            


                break;
            //
            case Web.XmlSerializationType.DivisionStandings: 

                _myDivisionStandings = obj.division;           


                break;
            //
            case Web.XmlSerializationType.DivisionSchedule: 

                _myDivisionFullSchedule = obj.schedule;     

              
              break;
            //
            case Web.XmlSerializationType.Match: 

              _selectedMatch = obj.match;         


              break;
            //
            case Web.XmlSerializationType.MyTransfers: 

    _myTransfers = obj.team_transfers; 
               
                break;
            // 
            case Web.XmlSerializationType.Economy: 
             
                _economy = obj.economy; 

              
              break;
            //
            //case Web.XmlSerializationType.Player:
            //  _player = obj.player;
            //  break;
            //
            case Web.XmlSerializationType.Unknown:
            default:
              throw new Exception("Deserialization return type error!");
          }

          //charazayObject = (Xsd.charazay)(new XmlSerializer(typeof(Xsd.charazay)).Deserialize(fs));
          //di.DeserializationObject = charazayObject.Item;
        }
        catch (Exception ex)
        {
          throw ex;
        }

        //if (charazayObject.Item.GetType() != di.DeserializationReturnType)
        //throw new Exception("Deserialization conversion error");
      }
    }

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

    private void InitInfoTab ( )
    {
      InfoPropertyGridObject ipg = new InfoPropertyGridObject(_arena, _user, _team, _country, imageListCountries);
      this.ucInfoTab.SelectedGridObject = ipg;
      var sbl = new SortableBindingList<Xsd2.charazayCountryDivision>(_country.division);
      this.ucInfoTab.DataContext(sbl);
    }

    private void InitMyPlayers(Xsd2.charazayPlayer[] players)  
    {
      foreach (var plyr in players)
      {
            PG pg = new PG(plyr); _pgs.Add(pg);
            SG sg = new SG(plyr); _sgs.Add(sg);
            PF pf = new PF(plyr); _pfs.Add(pf);
            SF sf = new SF(plyr); _sfs.Add(sf);
            C c = new C(plyr);    _cs.Add(c);
            Player p = Player.DecideOnValueIndex(pg, sg, sf, pf, c);
            _optimumPlayers.Add(p);
        }
    }

    // coaches file
    private void initCoachesData(Xsd2.charazayCoach[] xsdCoaches)  
    { //
      // alloc max coach (inner struct)
      //      
        var maxCoach = new Xsd2.charazayCoach() { skills = new Xsd2.charazayCoachSkills(), basic = new Xsd2.charazayCoachBasic() };
        foreach (Xsd2.charazayCoach xsdCoach in xsdCoaches)
     
        { //
          // get maximum skills from al coaches
          //
        maxCoach.skills.defence = Math.Max(xsdCoach.skills.defence, maxCoach.skills.defence);
        maxCoach.skills.twopoint = Math.Max(xsdCoach.skills.twopoint, maxCoach.skills.twopoint);
        maxCoach.skills.threepoint = Math.Max(xsdCoach.skills.threepoint, maxCoach.skills.threepoint);
        maxCoach.skills.freethrow = Math.Max(xsdCoach.skills.freethrow, maxCoach.skills.freethrow);
        maxCoach.skills.dribling = Math.Max(xsdCoach.skills.dribling, maxCoach.skills.dribling);
        maxCoach.skills.passing = Math.Max(xsdCoach.skills.passing, maxCoach.skills.passing);
        maxCoach.skills.speed = Math.Max(xsdCoach.skills.speed, maxCoach.skills.speed);
        maxCoach.skills.footwork = Math.Max(xsdCoach.skills.footwork, maxCoach.skills.footwork);
        maxCoach.skills.rebounds = Math.Max(xsdCoach.skills.rebounds, maxCoach.skills.rebounds);
        maxCoach.skills.experience = Math.Max(xsdCoach.skills.experience, maxCoach.skills.experience);
        //
        maxCoach.price += xsdCoach.price;
        maxCoach.salary += xsdCoach.salary;
        //
        // add current coach to pool
        //
        _coaches.Add(new Coach(xsdCoach));
      }
      //
      // common props for active coach
      //
      maxCoach.basic.name = "Active";
      maxCoach.basic.surname = "Coach";
      maxCoach.id = 0;
      _coaches.Add(new Coach(maxCoach));
    }
      
    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UI.FormLogin loginForm = new UI.FormLogin();
      loginForm.Show(this);
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UI.AboutForm aboutForm = new UI.AboutForm();
      aboutForm.Show(this);
    }

    private void MainForm_FormClosing (object sender, FormClosingEventArgs e)
    {
      this.ucTransferList.SerializePlayersTL();
      GC.WaitForPendingFinalizers();
    }

    #region view menu
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
    #endregion

    
    
   }
}
