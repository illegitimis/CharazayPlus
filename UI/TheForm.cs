
namespace AndreiPopescu.CharazayPlus
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Windows.Forms;
  using System.Xml.Serialization;
  using System.IO;
  using BrightIdeasSoftware;
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
        , TL = 13
          ,
      Decoration = 14

    }

    #region //-- Behavior fields
    List<PG> pgs = new List<PG>();
    List<SG> sgs = new List<SG>();
    List<SF> sfs = new List<SF>();
    List<PF> pfs = new List<PF>();
    List<C> cs = new List<C>();

    List<Player> _optimumPlayers = new List<Player>(); 
    List<Coach> _coaches = new List<Coach>();

    // info tab
    Xsd2.charazayArena _arena;
    Xsd2.charazayTeam _team;
    Xsd2.charazayUser _user;
    Xsd2.charazayCountry _country;

    // my Schedule tab
    Xsd2.charazayDivision _myDivisionStandings;
    //Xsd2.charazayMatch[] _mySchedule;
    Xsd2.match[] _mySchedule;

    // my Division tab
    Xsd2.charazayRound[] _myDivisionFullSchedule;
    Xsd2.match _selectedMatch;

    // money
    Xsd2.charazayEconomy _economy;
    Xsd2.charazayTransfer[] _myTransfers;

    //plyr
    //Xsd2.charazayPlayer _player;

    /// <summary>
    /// 
    /// </summary>
    private readonly Web.WebServiceUser _wsu;
      //new Web.WebServiceUser("stergein", "security_code", 1013, 5, 21191);

    #endregion

    #region //-- designer fields
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    // status column customized designer 
    //private HeaderStateStyle hssSkillsDisplay;
    //private HeaderStateStyle hssSkillsActive;
    //private HeaderFormatStyle hfsSkillsTab;
    private BrightIdeasSoftware.ObjectListView olvStatus;
    private BrightIdeasSoftware.OLVColumn olvcFullName;
    private BrightIdeasSoftware.OLVColumn olvAge;
    private BrightIdeasSoftware.OLVColumn olvcHeight;
    private BrightIdeasSoftware.OLVColumn olvcWeight;
    private BrightIdeasSoftware.OLVColumn olvcSI;
    private BrightIdeasSoftware.OLVColumn olvcSalary;
    private System.Windows.Forms.ImageList imageListCountries;
    private BrightIdeasSoftware.OLVColumn olvBmi;
    private BrightIdeasSoftware.OLVColumn olvcForm;
    private BrightIdeasSoftware.OLVColumn olvcFame;
    private BrightIdeasSoftware.OLVColumn olvcFatigue;
    private BrightIdeasSoftware.OLVColumn olvcInjured;
    private BrightIdeasSoftware.OLVColumn olvcInjuryDays;
    private BrightIdeasSoftware.OLVColumn olvcNt;
    private BrightIdeasSoftware.OLVColumn olvcNtU21;
    private BrightIdeasSoftware.OLVColumn olvcNtU18;
    // positions (attributes)
    private BrightIdeasSoftware.ObjectListView olvPg;
    private UI.SideTabControl sideTabControl;
    private System.Windows.Forms.TabPage tabPageStatus;
    private System.Windows.Forms.TabPage tabPageSkills;
    private System.Windows.Forms.TabPage tabPagePG;
    private System.Windows.Forms.TabPage tabPageSG;
    private System.Windows.Forms.TabPage tabPageSF;
    private System.Windows.Forms.TabPage tabPagePF;
    private System.Windows.Forms.TabPage tabPageC;
    private BrightIdeasSoftware.ObjectListView olvSg;
    private BrightIdeasSoftware.ObjectListView olvSf;
    private BrightIdeasSoftware.ObjectListView olvPf;
    private BrightIdeasSoftware.ObjectListView olvC;
    private System.Windows.Forms.TabPage tabPageTraining;
    private BrightIdeasSoftware.ObjectListView olvCoaches;
    private BrightIdeasSoftware.ObjectListView olvSkillIncrease;
    private BrightIdeasSoftware.OLVColumn olvcSkIncName;
    private BrightIdeasSoftware.OLVColumn olvcSkIncDef;
    private BrightIdeasSoftware.OLVColumn olvcSkIncFreethrows;
    private BrightIdeasSoftware.OLVColumn olvcSkInc2p;
    private BrightIdeasSoftware.OLVColumn olvcSkInc3p;
    private BrightIdeasSoftware.OLVColumn olvcSkIncDribbling;
    private BrightIdeasSoftware.OLVColumn olvcSkIncPassing;
    private BrightIdeasSoftware.OLVColumn olvcSkIncSpeed;
    private BrightIdeasSoftware.OLVColumn olvcSkIncFootwork;
    private BrightIdeasSoftware.OLVColumn olvcSkIncRebounds;
    private System.Windows.Forms.SplitContainer splitLR;
    private BrightIdeasSoftware.ObjectListView olvTraining;
    private BrightIdeasSoftware.OLVColumn olvcTrainingName;
    private BrightIdeasSoftware.OLVColumn olvcTrainingDef;
    private BrightIdeasSoftware.OLVColumn olvcTrainingInsideSh;
    private BrightIdeasSoftware.OLVColumn olvcTrainingOutsideSh;
    private BrightIdeasSoftware.OLVColumn olvcTrainingDribbling;
    private BrightIdeasSoftware.OLVColumn olvcTrainingPassing;
    private BrightIdeasSoftware.OLVColumn olvcTrainingSpeed;
    private BrightIdeasSoftware.OLVColumn olvcTrainingFootwork;
    private BrightIdeasSoftware.OLVColumn olvcTrainingRebounds;
    private System.Windows.Forms.SplitContainer splitTBIncrease;
    private System.Windows.Forms.SplitContainer splitTBCoachesSkillsIncrease;
    //private VerticalLabel labelCoachesList;
    private Label lblCoachesList;
    private Label lblSkillIncrease;
    private Label lblScoreIncrease;
    private TabPage tabPageInfo;
    private PropertyGrid propGridInfo;
    private DataGridView dgDivisionList;
    private TabPage tabPageMyTeamSchedule;
    private DataGridView dgMySchedule;
    private TabPage tabPageMyDivisionStandings;
    private TabPage tabPageMyEconomy;
    private DataGridView dgTeamTransfers;
    private SplitContainer splitEconomy;
    private TabPage tabPageTL;
    private Button btnTLAdd;
    private Button btnTLGet;
    private TextBox tbxPrice;
    private Label label51;
    private Label label50;
    private TextBox tbxPlayerId;
    private ObjectListView olvTL;
    private GroupBox gbxPosition;
    private RadioButton rdC;
    private RadioButton rdPf;
    private RadioButton rdSf;
    private RadioButton rdSg;
    private RadioButton rdPg;
    private OLVColumn olvcTLPosition;
    private OLVColumn olvcTLName;
    private OLVColumn olvcTLValueIndex;
    private OLVColumn olvcTLProfitability;
    private OLVColumn olvcTLTotalScore;
    private OLVColumn olvcTLDefensiveScore;
    private OLVColumn olvcTLOffenseScore;
    private OLVColumn olvcTLOffensiveAbilityScore;
    private OLVColumn olvcTLShoot;
    private OLVColumn olvcTLRebounds;
    private OLVColumn olvcTLRebO;
    private OLVColumn olvcTLRebD;
    private OLVColumn olvcTLPrice;
    private OLVColumn olvcTLDeadline;
    private DateTimePicker dtpDeadline;
    private Label label52;
    private ContextMenuStrip cmsOlvTL;
    private ToolStripMenuItem cmsOlvTLRemove;
    private Label label53;
    private Label label54;
    private SplitContainer splitContainer2;
    private EconomyUserControl ucEconomyWeek;
    private EconomyUserControl ucEconomySeason;
    private TabPage tabPageMyDivisionSchedule;
    private ObjectListView olvMd;
    private OLVColumn olvcMd;
    private UI.RatingBballUserControl ucrAway;
    private UI.RatingBballUserControl ucrHome;
    private UI.LineupHomeAwayUserControl ucLineup;
    private TableLayoutPanel tlpMyDiv;
    private UI.MatchDetailsUserControl ucMatchDetails;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private DataGridView dgStandings;
    private SplitContainer splitContainer3;
    private GroupBox gbxTeamSchedulePlayed;
    private RadioButton rdPlayedNo;
    private RadioButton rdPlayedYes;
    private RadioButton rdPlayedAll;
    private GroupBox gbxWL;
    private RadioButton rdWLLost;
    private RadioButton rdWLAll;
    private RadioButton rdWLWin;
    private ComboBox cbxMatchTypes;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tlpTL;
    private Panel panel1;
    private Panel panel2;
    private UI.EvaluatePlayerUserControl evaluatePlayerUC;
    //private DataGridViewTextBoxColumn dgColDivId;
    //private DataGridViewTextBoxColumn dgColDivName;
    //private DataGridViewTextBoxColumn dgColDivLh;
    //private DataGridViewTextBoxColumn dgColDivLevel;
    private System.Windows.Forms.PropertyGrid propGrid;    
    #endregion

    #region //-- Download
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
      if (pgs != null && pgs.Count != 0) 
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

    #region //-- Populate object list views
    /// <summary>
    /// derive group names from markers
    /// </summary>
    /// <typeparam name="T">value array type</typeparam>
    /// <param name="values">array of special group markers</param>
    private string[] BuildCustomGroupies<T> (T[] values)
    {
      List<string> groupKeys = new List<string> (values.Length+1);
      groupKeys.Add(string.Format("< {0}", values[0]));
      
      for (int i = 0; i < values.Length - 1; i++)
      {
        groupKeys.Add(string.Format("[{0} - {1})", values[i], values[i+1]));
      }

      groupKeys.Add(string.Format("> {0}", values[values.Length - 1]));

      return groupKeys.ToArray();
    }

    /// <summary>
    /// Position based list customizer
    /// </summary>
    /// <typeparam name="T">player type</typeparam>
    /// <param name="olv">object list view</param>
    /// <param name="players">player derived collection</param>
    private void initOLV <T>(ObjectListView olv, List<T> players)
      where T : Player
    {
      Generator.GenerateColumns(olv, players);
      olv.HeaderUsesThemes = false;

      double[] scoreMarkers = new double[] { 6, 8, 10, 12, 14, 16 };
      string[] descriptions = BuildCustomGroupies<double>(scoreMarkers);

      foreach (OLVColumn col in olv.Columns)
      {
        col.IsHeaderVertical = true;
        //col.MaximumWidth = 80;
        //col.MinimumWidth = 40;
        //col.Width = 65;

        string tag = col.Tag as string;
        if (!tag.Contains(/*Custom.TagPosition*/ "Position"))
          col.IsVisible = false;

        switch (col.DisplayIndex)
        {
          case 0:
          {
            //col.MaximumWidth = 200;
            //col.MinimumWidth = 100;
            //col.Width = 130;
            
            
            col.GroupKeyGetter = delegate(object row) { return ((T)row).HeightForPosition; };
            col.GroupKeyToTitleConverter = delegate(object groupKey)
            {
              PositionHeight adequacy = (PositionHeight)groupKey;
              if (adequacy == PositionHeight.Adequate)
              {
                return string.Format("{0} [{1} - {2}]", adequacy, players[0].MinimumHeight, players[0].MaximumHeight);
              }
              else
                return adequacy.ToString();              
            };  
                     
          } break;

          default: 
          { 
            //col.AspectToStringFormat = "{0:F02}";
            col.MakeGroupies(scoreMarkers, descriptions);
          } break;          
        }
      }
      olv.RebuildColumns();

      // either call works
      //this.olvSG.Objects = sgs;       
      olv.SetObjects(players);      
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void initStatus()
    {
      //XmlServiceDownload();

      //List<PG> players = pgs;
      
      TypedObjectListView<Player> tlist = new TypedObjectListView<Player>(this.olvStatus);
      tlist.GenerateAspectGetters();
      
      // Name
      this.olvcFullName.ImageGetter = delegate(object row) { return (int)(((Player)row).CountryId - 1); };
      this.olvcFullName.GroupKeyGetter = delegate(object row) { return (int)(((Player)row).CountryId); };
      this.olvcFullName.GroupKeyToTitleConverter = delegate(object groupKey)
      {
        Country country = Defines.Countries[(int)groupKey];
        return string.Format("{0} (id={1})", country.Name, country.Id);
      };

      // Age
      this.olvAge.MakeGroupies(
        new byte[] { 17, 19, 22, 24, 26, 28, 30, 32, 35 }
      , new string[] { "< 17", "17-18", "19-21", "22-23", "24-25", "26-27", "28-29", "30-31", "32-34", "> 34"}
      );

      //height
      this.olvcHeight.MakeGroupies (
        new byte[] { 180, 185, 190, 195, 200, 205, 210, 215, 220 }
      , new string [] {"160-180", "180-185", "185-190", "190-195", "195-200", "200-205", "205-210", "210-215", "215-220", "220-230"}
      );

      // weight
      double[] weightMarkers = new double[] { 80d, 90d, 100d, 110d, 120d };
      this.olvcWeight.MakeGroupies( weightMarkers, BuildCustomGroupies<double> (weightMarkers));

      //bmi
      this.olvBmi.AspectToStringConverter = delegate(object val)
      {
        double bmi = (double)val;
        return string.Format("{0:F02}", bmi);
      };
      double[] bmiMarkers = new double[] { 21, 23, 25, 27};
      this.olvBmi.MakeGroupies(bmiMarkers, BuildCustomGroupies<double>(bmiMarkers));
            
      //si
      ulong k = (ulong)Math.Pow( 10, 3);
      ulong k10 = (ulong)Math.Pow( 10, 4);
      ulong k100 = (ulong)Math.Pow( 10, 5);

      ulong[] siMarkers = new ulong[] { k10, 2*k10, 35*k, 5*k10, 7*k10, 9*k10, 11*k10, 13*k10
        , 15*k10 , 175*k, 2*k100, 225*k, 25*k10, 275*k, 3*k100, 325*k, 35*k10, 4*k100, 5*k100, 6*k100
      };
      this.olvcSI.MakeGroupies(siMarkers, BuildCustomGroupies<ulong>(siMarkers));

      //salary
      ulong[] salaryMarkers = new ulong[] { k10, 2*k10, 3*k10, 4*k10, 6*k10, k100
        , 125*k, 15*k10 , 175*k, 2*k100, 225*k, 25*k10, 275*k, 3*k100, 35*k10, 4*k100
      };
      this.olvcSalary.MakeGroupies(salaryMarkers, BuildCustomGroupies<ulong>(salaryMarkers));
      
      // form     
      this.olvcForm.GroupKeyGetter = delegate(object row) { return (byte)(((Player)row).Form); };
      this.olvcForm.GroupKeyToTitleConverter = delegate(object groupKey)
      {
        return string.Format("{0} ({1})", (AndreiPopescu.CharazayPlus.Utils.Form)groupKey, (byte)groupKey);        
      };
      this.olvcForm.Renderer = new MultiImageRenderer(Properties.Resources.star13, 8, 1, 8);

      // fame   
      this.olvcFame.GroupKeyGetter = delegate(object row) { return (byte)(((Player)row).Fame); };
      this.olvcFame.GroupKeyToTitleConverter = delegate(object groupKey)
      {
        return string.Format("{0} ({1})", (Fame)groupKey, (byte)groupKey);
      };
      this.olvcFame.Renderer = new MultiImageRenderer(Properties.Resources.star12, 10, 0, 11);

      //fatigue
      byte[] fatigueMarkers = new byte[] { 2, 5, 10, 15, 20, 30 };
      this.olvcFatigue.MakeGroupies(fatigueMarkers, BuildCustomGroupies<byte>(fatigueMarkers));
      this.olvcFatigue.Renderer = new BarTextRenderer(0, 100, new Pen(Color.Bisque), Color.GreenYellow, Color.Red);
      this.olvcFatigue.AspectGetter = (row) => { return ((Player)row).Fatigue; };
      this.olvcFatigue.AspectName = "Fatigue";
      //this.olvcFatigue.AspectToStringConverter = (row) => { return ((Player)row).Fatigue.ToString()+"%"; };
      this.olvcFatigue.AspectToStringFormat = "{0}%";

      // fill
      //this.olvStatus.SetObjects(players);
      this.olvStatus.SetObjects(_optimumPlayers);
    }

    #region skills tab
    /// <summary>
    /// 
    /// </summary>
    private void initSkills ( )
    {
      //
      Generator.GenerateColumns(olvSkills, typeof(Player));
      //
      double[] doubleSkillMarkers = new double[] { 3, 5, 8, 11, 14, 17, 20 };
      byte[] byteSkillMarkers = new byte[] { 3, 5, 8, 11, 14, 17, 20 };
      string[] descriptions = BuildCustomGroupies<double>(doubleSkillMarkers);

      foreach (OLVColumn col in olvSkills.Columns)
      {
        string tag = col.Tag as string;
        if (!tag.Contains("Skills"))
        {
          col.IsVisible = false;
        }
        else
        { // skill column
          col.IsEditable = false;

          if (col.DisplayIndex == 0)
          { // name
            col.Groupable = false;
            col.IsHeaderVertical = false;
          }
          else
          { // values
            col.IsHeaderVertical = true;
            if (col.DisplayIndex > 9 && col.DisplayIndex < 19)
            { // active
              col.MakeGroupies<double>(doubleSkillMarkers, descriptions);
              col.HeaderForeColor = Color.Gold;
              col.Width = 50;
              col.MinimumWidth = 40;
              col.MaximumWidth = 60;
            }
            else
            { // display
              col.MakeGroupies<byte>(byteSkillMarkers, descriptions);
              col.HeaderForeColor = Color.LightSkyBlue;
              col.Width = 45;
              col.MinimumWidth = 40;
              col.MaximumWidth = 55;
            }
          }
        }

      }
      olvSkills.RebuildColumns();
      //
      olvSkills.SetObjects(_optimumPlayers);
      //      
    }

    #endregion

    #region Info Tab
    private void initInfoTab()
    {
      initInfoPropertyGrid();
      initInfoDataGridView();      
    }

    private void initInfoPropertyGrid()
    {
      InfoPropertyGridObject ipg = new InfoPropertyGridObject(
        _arena
        , _user
        , _team
        , _country
        , imageListCountries);
      propGridInfo.CommandsVisibleIfAvailable = true;
      propGridInfo.SelectedObject = ipg;
    }

    private void initInfoDataGridView()
    {
      SortableBindingList<Xsd2.charazayCountryDivision> sbl = 
        new SortableBindingList<Xsd2.charazayCountryDivision>(_country.division);
      dgDivisionList.DataSource = sbl;

      dgDivisionList.Columns["countryid"].Visible = false;
      dgDivisionList.AllowUserToOrderColumns = true;
    }
    #endregion

    /// <summary>
    /// Fills the object list view with the division full schedule
    /// on the 'My Division' tab
    /// </summary>
    [Obsolete]
    private void initDivisionFullSchedule()
    {
      //Generator.GenerateColumns(olvDivisionFullSchedule, _myDivisionFullSchedule);
      //olvDivisionFullSchedule.AllColumns[2].AspectGetter =
      //  delegate(object o)
      //  {
      //    Xsd2.charazayRound round = (Xsd2.charazayRound)o;
      //    return round.match.id;
      //  };

      //olvDivisionFullSchedule.SetObjects(_myDivisionFullSchedule);
    }

    private void initMd()
    {
      //olvcMd.AspectGetter = delegate(object row) { return (uint)(((Xsd2.charazayRound)row).match.id); };
      olvcMd.AspectGetter = delegate(object row) { return (Xsd2.charazayRoundMatch)(((Xsd2.charazayRound)row).match); };
      olvcMd.GroupKeyGetter = delegate(object o)
      {
        Xsd2.charazayRound round = (Xsd2.charazayRound)o;
        return string.Format("Round: {0:D02} {1:yyyy-MMMM-dd}", round.number, Compute.EstimatedDateTime(round.date));         
      };
      //this.olvcFullName.GroupKeyToTitleConverter = delegate(object groupKey)
      //{
      //  Country country = Defines.Countries[(int)groupKey];
      //  return string.Format("{0} (id={1})", country.Name, country.Id);
      //};
      olvMd.SetObjects(_myDivisionFullSchedule);

      //olvMd.SelectObject (
    }
    #endregion

    #region DataGridView initialization helpers
    private void initGridPrologue(DataGridView dgv)
    {
      dgv.Columns.Clear();
      dgv.AutoGenerateColumns = false;
    }

    private void initGridEpilogue<T>(DataGridView dgv, T[] xsd2Array)
    {
      dgv.DataSource = new SortableBindingList<T>(xsd2Array);
      //dgv.AutoSize = true;
      dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    //private void initGridEpilogue<T>(DataGridView dgv, T[] xsd2Array, bool find)
    //{
    //  FilteredBindingList <T> ssbl =
    //    new FilteredBindingList<T>();

    //  foreach (T m in xsd2Array)
    //    ssbl.Add(m);
      
    //  //BindingSource bs = new BindingSource ();
    //  //bs.DataSource = ssbl;
    //  //bs.Filter = "round=0";
    //  //bs.Sort = "MatchType DESC";
    //  //dgv.DataSource = bs;

    //  //ssbl.Filter = "round=0";
    //  ssbl.Filter = "played='yes'";

    //  dgv.DataSource = ssbl;

    //  //dgv.AutoSize = true;
    //  dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

    //  //int i = ssbl.Find("played", "yes");
      

    //}

    private void GenerateTextBoxColumn(DataGridView dg, string name, string property)
    {
      DataGridViewColumn column = new DataGridViewTextBoxColumn();
      column.DataPropertyName = property;
      column.Name = name;
      dg.Columns.Add(column);
    }

    private void GenerateLinkColumn(DataGridView dgv, string name, string property)
    {
      GenerateLinkColumn(dgv, name, property, null);
    }

    //private void GenerateLinkColumn(DataGridView dgv, string name, string property, Delegate _CellContentClick)
    private void GenerateLinkColumn(DataGridView dgv, string name, string property, DataGridViewCellEventHandler _CellContentClick)
    {
      DataGridViewLinkColumn column2 = new DataGridViewLinkColumn();
      column2.DataPropertyName = property;
      column2.Name = name;
      column2.ActiveLinkColor = Color.White;
      column2.LinkBehavior = LinkBehavior.SystemDefault;
      column2.LinkColor = Color.Blue;
      column2.TrackVisitedState = true;
      
      if (_CellContentClick != null)
        dgv.CellContentClick += new DataGridViewCellEventHandler(_CellContentClick);

      dgv.Columns.Add(column2);
    }
    #endregion

    #region Populate DataGridViews 
    private void initDgStandings()
    {
      initGridPrologue(dgStandings);

      // position column (#).
      GenerateTextBoxColumn(dgStandings, "#", "position");
      // team (id+name).\
      //column2.DataPropertyName = "TeamLink";
      //column2.HeaderText = "Team";
      GenerateLinkColumn(dgStandings, "Team", "Name", dg_CellContentClick);
      
      GenerateTextBoxColumn(dgStandings, "Pld", "played");
      GenerateTextBoxColumn(dgStandings, "W", "wins");
      GenerateTextBoxColumn(dgStandings, "L", "loss");
      GenerateTextBoxColumn(dgStandings, "+", "points_made");
      GenerateTextBoxColumn(dgStandings, "-", "points_against");
      GenerateTextBoxColumn(dgStandings, "Pts", "points");
      GenerateTextBoxColumn(dgStandings, "Owner", "owner");

      initGridEpilogue<Xsd2.charazayDivisionStanding>(dgStandings, _myDivisionStandings.standings);      
    }

    private void initDgMySchedule()
    {
      // purge
      //dgMySchedule.CaptionText = "My Team Schedule";
      initGridPrologue (dgMySchedule);

      // home team (id+name).
      GenerateLinkColumn (dgMySchedule, "Home",  "HomeTeamName");
      GenerateTextBoxColumn (dgMySchedule, string.Empty, "homescore");
      GenerateTextBoxColumn (dgMySchedule, string.Empty, "awayscore");
      // away team (id+name).
      GenerateLinkColumn (dgMySchedule, "Away", "AwayTeamName");

      GenerateTextBoxColumn(dgMySchedule, "Type", "MatchType"); 
      // date (match link)
      GenerateTextBoxColumn(dgMySchedule, "Date", "Date_");
      GenerateTextBoxColumn(dgMySchedule, "Rnd", "round"); 
      GenerateTextBoxColumn(dgMySchedule, "Season", "season"); 
      GenerateTextBoxColumn(dgMySchedule, "Spectators", "spectators"); 
      GenerateTextBoxColumn(dgMySchedule, "Vips", "vips"); 
      
      //todo: abstractize
      DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
      column.DataPropertyName = "played";
      column.Name = "Played?";
      column.ValueType = typeof(string);
      column.TrueValue = "yes";
      column.FalseValue = "no";
      column.ThreeState = false;
      dgMySchedule.Columns.Add(column);
      //
      // bind
      //
      //initGridEpilogue<Xsd2.match>(dgMySchedule, _mySchedule);  
      FilteredBindingList < Xsd2.match > fbl = new FilteredBindingList<Xsd2.match>();
      foreach (Xsd2.match m in _mySchedule)
      {
        m.MyTeamId = _team.id;
        fbl.Add(m); 
      }
      dgMySchedule.DataSource = fbl;
      dgMySchedule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    /// <summary>
    /// my team transfer history
    /// tab: My Economy
    /// </summary>
    private void initDgMyTransfers()
    {
      initGridPrologue (dgTeamTransfers);
            
      GenerateTextBoxColumn (dgTeamTransfers, "Seller", "Seller");
      GenerateTextBoxColumn (dgTeamTransfers, "Buyer", "Buyer");
      GenerateTextBoxColumn(dgTeamTransfers, "Date", "Date");
      GenerateTextBoxColumn(dgTeamTransfers, "Player", "Player");
      GenerateTextBoxColumn(dgTeamTransfers, "Skill Index", "si");
      GenerateTextBoxColumn(dgTeamTransfers, "Price", "price");

      initGridEpilogue<Xsd2.charazayTransfer> (dgTeamTransfers, _myTransfers);      
    }

    private void initEconomyUserControls()
    {
      //ucEconomyWeek.Income = _economy.economy_week.income;
      //ucEconomyWeek.Expences = _economy.economy_week.expences;
      //ucEconomyWeek.IsWeek = true;

      //ucEconomySeason.Income = _economy.economy_season.income;
      //ucEconomySeason.Expences = _economy.economy_season.expences;
      //ucEconomySeason.IsWeek = false;

      ucEconomyWeek.LabelsInit(_economy.economy_week.income, _economy.economy_week.expences, true);
      ucEconomySeason.LabelsInit(_economy.economy_season.income, _economy.economy_season.expences, false);
    }

    #endregion

    #region dgv events
    private void dgMySchedule_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      //throw new NotImplementedException();
    }
    #endregion

    #region Object List View events
    private void objectListView1_IsHyperlink(object sender, IsHyperlinkEventArgs e)
    {
      //ObjectListView olv = (ObjectListView)sender;
      //if (olv.GetItemCount() == 0)
      //  return;
      
      //Player p = (Player)olv.SelectedObject;
      //if (p == null)
      //  return;

      //Web.CharazayDownoadItem playerLink = new Web.CharazayDownoadItem("player", 1, p.Id);
      //e.Url = playerLink.m_uri.AbsoluteUri;
    }

    private void objectListView1_HyperlinkClicked(object sender, HyperlinkClickedEventArgs e)
    {
      //ObjectListViewItem olvi = (ObjectListViewItem)sender;
      //olvi
      //int ri = e.RowIndex;
      //e.Url
      
      Player p = (Player)e.Item.RowObject;
      if (p == null)
        return;

      Web.CharazayDownoadItem playerLink = new Web.CharazayDownoadItem("player", 1, p.Id);
      e.Url = playerLink.m_uri.AbsoluteUri;
    }

    private void olvCoaches_FormatCell(object sender, FormatCellEventArgs e)
    {
      //e.RowIndex == _coaches.Count - 1 &&
      if (e.Item.Text == "Active Coach")
        e.SubItem.Font = new Font(e.SubItem.Font, FontStyle.Bold);
    }

    private void olvCoaches_FormatRow(object sender, FormatRowEventArgs e)
    {

    }

    #endregion

    #region //-- IDisposable
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
      this.cmsOlvTL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmsOlvTLRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sideTabControl = new AndreiPopescu.CharazayPlus.UI.SideTabControl();
      this.tabPageInfo = new System.Windows.Forms.TabPage();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.propGridInfo = new System.Windows.Forms.PropertyGrid();
      this.dgDivisionList = new System.Windows.Forms.DataGridView();
      this.label53 = new System.Windows.Forms.Label();
      this.tabPageStatus = new System.Windows.Forms.TabPage();
      this.olvStatus = new BrightIdeasSoftware.ObjectListView();
      this.olvcFullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvBmi = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSI = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSalary = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcForm = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFame = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcFatigue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcInjured = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcInjuryDays = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcNt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcNtU21 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcNtU18 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.tabPageSkills = new System.Windows.Forms.TabPage();
      this.lblSkillsActive = new System.Windows.Forms.Label();
      this.lblSkillsDisplay = new System.Windows.Forms.Label();
      this.olvSkills = new BrightIdeasSoftware.ObjectListView();
      this.olvcskName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.tabPagePG = new System.Windows.Forms.TabPage();
      this.olvPg = new BrightIdeasSoftware.ObjectListView();
      this.tabPageSG = new System.Windows.Forms.TabPage();
      this.olvSg = new BrightIdeasSoftware.ObjectListView();
      this.tabPageSF = new System.Windows.Forms.TabPage();
      this.olvSf = new BrightIdeasSoftware.ObjectListView();
      this.tabPagePF = new System.Windows.Forms.TabPage();
      this.olvPf = new BrightIdeasSoftware.ObjectListView();
      this.tabPageC = new System.Windows.Forms.TabPage();
      this.olvC = new BrightIdeasSoftware.ObjectListView();
      this.tabPageTraining = new System.Windows.Forms.TabPage();
      this.splitLR = new System.Windows.Forms.SplitContainer();
      this.splitTBCoachesSkillsIncrease = new System.Windows.Forms.SplitContainer();
      this.lblCoachesList = new System.Windows.Forms.Label();
      this.olvCoaches = new BrightIdeasSoftware.ObjectListView();
      this.splitTBIncrease = new System.Windows.Forms.SplitContainer();
      this.lblSkillIncrease = new System.Windows.Forms.Label();
      this.olvSkillIncrease = new BrightIdeasSoftware.ObjectListView();
      this.olvcSkIncName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncDef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncFreethrows = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkInc2p = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkInc3p = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncDribbling = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncPassing = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncSpeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncFootwork = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcSkIncRebounds = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.lblScoreIncrease = new System.Windows.Forms.Label();
      this.olvTraining = new BrightIdeasSoftware.ObjectListView();
      this.olvcTrainingName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingDef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingDribbling = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingPassing = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingSpeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingFootwork = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingRebounds = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingInsideSh = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTrainingOutsideSh = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.splitTrnRight = new System.Windows.Forms.SplitContainer();
      this.chkTEu18 = new System.Windows.Forms.CheckBox();
      this.olvTrainingEfficiency = new BrightIdeasSoftware.ObjectListView();
      this.propGrid = new System.Windows.Forms.PropertyGrid();
      this.tabPageMyTeamSchedule = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.dgMySchedule = new System.Windows.Forms.DataGridView();
      this.gbxWL = new System.Windows.Forms.GroupBox();
      this.rdWLLost = new System.Windows.Forms.RadioButton();
      this.rdWLAll = new System.Windows.Forms.RadioButton();
      this.rdWLWin = new System.Windows.Forms.RadioButton();
      this.gbxTeamSchedulePlayed = new System.Windows.Forms.GroupBox();
      this.rdPlayedNo = new System.Windows.Forms.RadioButton();
      this.rdPlayedYes = new System.Windows.Forms.RadioButton();
      this.rdPlayedAll = new System.Windows.Forms.RadioButton();
      this.cbxMatchTypes = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPageMyDivisionStandings = new System.Windows.Forms.TabPage();
      this.dgStandings = new System.Windows.Forms.DataGridView();
      this.tabPageMyDivisionSchedule = new System.Windows.Forms.TabPage();
      this.tlpMyDiv = new System.Windows.Forms.TableLayoutPanel();
      this.ucrHome = new AndreiPopescu.CharazayPlus.UI.RatingBballUserControl();
      this.ucLineup = new AndreiPopescu.CharazayPlus.UI.LineupHomeAwayUserControl();
      this.olvMd = new BrightIdeasSoftware.ObjectListView();
      this.olvcMd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.ucrAway = new AndreiPopescu.CharazayPlus.UI.RatingBballUserControl();
      this.ucMatchDetails = new AndreiPopescu.CharazayPlus.UI.MatchDetailsUserControl();
      this.tabPageMyEconomy = new System.Windows.Forms.TabPage();
      this.splitEconomy = new System.Windows.Forms.SplitContainer();
      this.label54 = new System.Windows.Forms.Label();
      this.dgTeamTransfers = new System.Windows.Forms.DataGridView();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.ucEconomyWeek = new AndreiPopescu.CharazayPlus.EconomyUserControl();
      this.ucEconomySeason = new AndreiPopescu.CharazayPlus.EconomyUserControl();
      this.tabPageTL = new System.Windows.Forms.TabPage();
      this.tlpTL = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnTLAdd = new System.Windows.Forms.Button();
      this.gbxPosition = new System.Windows.Forms.GroupBox();
      this.rdC = new System.Windows.Forms.RadioButton();
      this.rdPf = new System.Windows.Forms.RadioButton();
      this.rdPg = new System.Windows.Forms.RadioButton();
      this.rdSg = new System.Windows.Forms.RadioButton();
      this.rdSf = new System.Windows.Forms.RadioButton();
      this.panel2 = new System.Windows.Forms.Panel();
      this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
      this.label50 = new System.Windows.Forms.Label();
      this.tbxPlayerId = new System.Windows.Forms.TextBox();
      this.label52 = new System.Windows.Forms.Label();
      this.btnTLGet = new System.Windows.Forms.Button();
      this.tbxPrice = new System.Windows.Forms.TextBox();
      this.label51 = new System.Windows.Forms.Label();
      this.olvTL = new BrightIdeasSoftware.ObjectListView();
      this.olvcTLPosition = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLValueIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLProfitability = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLDeadline = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLTotalScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLDefensiveScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLOffenseScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLOffensiveAbilityScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLShoot = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLRebounds = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLRebO = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvcTLRebD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.evaluatePlayerUC = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.userControl11 = new AndreiPopescu.CharazayPlus.UI.PlayerSkillsUserControl();
      this.cmsOlvTL.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.sideTabControl.SuspendLayout();
      this.tabPageInfo.SuspendLayout();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgDivisionList)).BeginInit();
      this.tabPageStatus.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvStatus)).BeginInit();
      this.tabPageSkills.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvSkills)).BeginInit();
      this.tabPagePG.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvPg)).BeginInit();
      this.tabPageSG.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvSg)).BeginInit();
      this.tabPageSF.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvSf)).BeginInit();
      this.tabPagePF.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvPf)).BeginInit();
      this.tabPageC.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvC)).BeginInit();
      this.tabPageTraining.SuspendLayout();
      this.splitLR.Panel1.SuspendLayout();
      this.splitLR.Panel2.SuspendLayout();
      this.splitLR.SuspendLayout();
      this.splitTBCoachesSkillsIncrease.Panel1.SuspendLayout();
      this.splitTBCoachesSkillsIncrease.Panel2.SuspendLayout();
      this.splitTBCoachesSkillsIncrease.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvCoaches)).BeginInit();
      this.splitTBIncrease.Panel1.SuspendLayout();
      this.splitTBIncrease.Panel2.SuspendLayout();
      this.splitTBIncrease.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvSkillIncrease)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.olvTraining)).BeginInit();
      this.splitTrnRight.Panel1.SuspendLayout();
      this.splitTrnRight.Panel2.SuspendLayout();
      this.splitTrnRight.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTrainingEfficiency)).BeginInit();
      this.tabPageMyTeamSchedule.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgMySchedule)).BeginInit();
      this.gbxWL.SuspendLayout();
      this.gbxTeamSchedulePlayed.SuspendLayout();
      this.tabPageMyDivisionStandings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgStandings)).BeginInit();
      this.tabPageMyDivisionSchedule.SuspendLayout();
      this.tlpMyDiv.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvMd)).BeginInit();
      this.tabPageMyEconomy.SuspendLayout();
      this.splitEconomy.Panel1.SuspendLayout();
      this.splitEconomy.Panel2.SuspendLayout();
      this.splitEconomy.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamTransfers)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.tabPageTL.SuspendLayout();
      this.tlpTL.SuspendLayout();
      this.panel1.SuspendLayout();
      this.gbxPosition.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).BeginInit();
      this.tabPage1.SuspendLayout();
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
      // cmsOlvTL
      // 
      this.cmsOlvTL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsOlvTLRemove});
      this.cmsOlvTL.Name = "cmsOlvTL";
      this.cmsOlvTL.Size = new System.Drawing.Size(118, 26);
      // 
      // cmsOlvTLRemove
      // 
      this.cmsOlvTLRemove.Name = "cmsOlvTLRemove";
      this.cmsOlvTLRemove.Size = new System.Drawing.Size(117, 22);
      this.cmsOlvTLRemove.Text = "Remove";
      this.cmsOlvTLRemove.Click += new System.EventHandler(this.cmsOlvTLRemove_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(872, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.optionsToolStripMenuItem.Text = "&Options";
      this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
      this.sideTabControl.Controls.Add(this.tabPage1);
      this.sideTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
      this.sideTabControl.ItemSize = new System.Drawing.Size(26, 104);
      this.sideTabControl.Location = new System.Drawing.Point(0, 27);
      this.sideTabControl.MinimumSize = new System.Drawing.Size(104, 104);
      this.sideTabControl.Multiline = true;
      this.sideTabControl.Name = "sideTabControl";
      this.sideTabControl.SelectedIndex = 0;
      this.sideTabControl.Size = new System.Drawing.Size(866, 612);
      this.sideTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.sideTabControl.TabIndex = 1;
      this.sideTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.sideTabControl_Selected);
      // 
      // tabPageInfo
      // 
      this.tabPageInfo.Controls.Add(this.splitContainer3);
      this.tabPageInfo.Location = new System.Drawing.Point(4, 4);
      this.tabPageInfo.Name = "tabPageInfo";
      this.tabPageInfo.Size = new System.Drawing.Size(754, 604);
      this.tabPageInfo.TabIndex = 8;
      this.tabPageInfo.Text = "Info";
      this.tabPageInfo.UseVisualStyleBackColor = true;
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.propGridInfo);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.dgDivisionList);
      this.splitContainer3.Panel2.Controls.Add(this.label53);
      this.splitContainer3.Size = new System.Drawing.Size(754, 604);
      this.splitContainer3.SplitterDistance = 348;
      this.splitContainer3.TabIndex = 3;
      // 
      // propGridInfo
      // 
      this.propGridInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propGridInfo.Location = new System.Drawing.Point(0, 0);
      this.propGridInfo.Name = "propGridInfo";
      this.propGridInfo.Size = new System.Drawing.Size(348, 604);
      this.propGridInfo.TabIndex = 0;
      // 
      // dgDivisionList
      // 
      this.dgDivisionList.AllowUserToAddRows = false;
      this.dgDivisionList.AllowUserToDeleteRows = false;
      this.dgDivisionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgDivisionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgDivisionList.Location = new System.Drawing.Point(6, 16);
      this.dgDivisionList.Name = "dgDivisionList";
      this.dgDivisionList.ReadOnly = true;
      this.dgDivisionList.Size = new System.Drawing.Size(393, 585);
      this.dgDivisionList.TabIndex = 1;
      // 
      // label53
      // 
      this.label53.AutoSize = true;
      this.label53.Location = new System.Drawing.Point(3, 0);
      this.label53.Name = "label53";
      this.label53.Size = new System.Drawing.Size(102, 13);
      this.label53.TabIndex = 2;
      this.label53.Text = "Country Division List";
      // 
      // tabPageStatus
      // 
      this.tabPageStatus.Controls.Add(this.olvStatus);
      this.tabPageStatus.Location = new System.Drawing.Point(4, 4);
      this.tabPageStatus.Name = "tabPageStatus";
      this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageStatus.Size = new System.Drawing.Size(754, 604);
      this.tabPageStatus.TabIndex = 0;
      this.tabPageStatus.Text = "Status";
      this.tabPageStatus.UseVisualStyleBackColor = true;
      // 
      // olvStatus
      // 
      this.olvStatus.AllColumns.Add(this.olvcFullName);
      this.olvStatus.AllColumns.Add(this.olvAge);
      this.olvStatus.AllColumns.Add(this.olvcHeight);
      this.olvStatus.AllColumns.Add(this.olvcWeight);
      this.olvStatus.AllColumns.Add(this.olvBmi);
      this.olvStatus.AllColumns.Add(this.olvcSI);
      this.olvStatus.AllColumns.Add(this.olvcSalary);
      this.olvStatus.AllColumns.Add(this.olvcForm);
      this.olvStatus.AllColumns.Add(this.olvcFame);
      this.olvStatus.AllColumns.Add(this.olvcFatigue);
      this.olvStatus.AllColumns.Add(this.olvcInjured);
      this.olvStatus.AllColumns.Add(this.olvcInjuryDays);
      this.olvStatus.AllColumns.Add(this.olvcNt);
      this.olvStatus.AllColumns.Add(this.olvcNtU21);
      this.olvStatus.AllColumns.Add(this.olvcNtU18);
      this.olvStatus.AllowColumnReorder = true;
      this.olvStatus.AlternateRowBackColor = System.Drawing.Color.DimGray;
      this.olvStatus.BackColor = System.Drawing.Color.Gray;
      this.olvStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcFullName,
            this.olvAge,
            this.olvcHeight,
            this.olvcWeight,
            this.olvBmi,
            this.olvcSI,
            this.olvcSalary,
            this.olvcForm,
            this.olvcFame,
            this.olvcFatigue,
            this.olvcInjured,
            this.olvcInjuryDays,
            this.olvcNt,
            this.olvcNtU21,
            this.olvcNtU18});
      this.olvStatus.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvStatus.ForeColor = System.Drawing.Color.White;
      this.olvStatus.FullRowSelect = true;
      this.olvStatus.HeaderUsesThemes = false;
      this.olvStatus.HideSelection = false;
      this.olvStatus.LargeImageList = this.imageListCountries;
      this.olvStatus.Location = new System.Drawing.Point(3, 3);
      this.olvStatus.Name = "olvStatus";
      this.olvStatus.OwnerDraw = true;
      this.olvStatus.ShowItemToolTips = true;
      this.olvStatus.Size = new System.Drawing.Size(0, 236);
      this.olvStatus.SmallImageList = this.imageListCountries;
      this.olvStatus.TabIndex = 0;
      this.olvStatus.UseAlternatingBackColors = true;
      this.olvStatus.UseCompatibleStateImageBehavior = false;
      this.olvStatus.UseHotItem = true;
      this.olvStatus.UseHyperlinks = true;
      this.olvStatus.UseTranslucentHotItem = true;
      this.olvStatus.View = System.Windows.Forms.View.Details;
      this.olvStatus.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.objectListView1_HyperlinkClicked);
      this.olvStatus.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.objectListView1_IsHyperlink);
      // 
      // olvcFullName
      // 
      this.olvcFullName.AspectName = "FullName";
      this.olvcFullName.CellPadding = null;
      this.olvcFullName.Hyperlink = true;
      this.olvcFullName.MaximumWidth = 200;
      this.olvcFullName.MinimumWidth = 100;
      this.olvcFullName.Text = "Name";
      this.olvcFullName.ToolTipText = "Player full name";
      this.olvcFullName.UseInitialLetterForGroup = true;
      this.olvcFullName.Width = 160;
      this.olvcFullName.WordWrap = true;
      // 
      // olvAge
      // 
      this.olvAge.AspectName = "Age";
      this.olvAge.CellPadding = null;
      this.olvAge.MaximumWidth = 60;
      this.olvAge.MinimumWidth = 25;
      this.olvAge.Text = "Age";
      this.olvAge.Width = 40;
      // 
      // olvcHeight
      // 
      this.olvcHeight.AspectName = "Height";
      this.olvcHeight.CellPadding = null;
      this.olvcHeight.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcHeight.MaximumWidth = 70;
      this.olvcHeight.MinimumWidth = 30;
      this.olvcHeight.Text = "Height";
      this.olvcHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.olvcHeight.Width = 50;
      // 
      // olvcWeight
      // 
      this.olvcWeight.AspectName = "Weight";
      this.olvcWeight.CellPadding = null;
      this.olvcWeight.MaximumWidth = 70;
      this.olvcWeight.MinimumWidth = 40;
      this.olvcWeight.Text = "Weight";
      this.olvcWeight.Width = 50;
      // 
      // olvBmi
      // 
      this.olvBmi.AspectName = "BMI";
      this.olvBmi.CellPadding = null;
      this.olvBmi.MaximumWidth = 60;
      this.olvBmi.MinimumWidth = 40;
      this.olvBmi.Text = "BMI";
      this.olvBmi.ToolTipText = "Body mass index";
      this.olvBmi.Width = 50;
      // 
      // olvcSI
      // 
      this.olvcSI.AspectName = "SkillsIndex";
      this.olvcSI.CellPadding = null;
      this.olvcSI.MaximumWidth = 80;
      this.olvcSI.MinimumWidth = 50;
      this.olvcSI.Text = "SI";
      this.olvcSI.ToolTipText = "Skills index";
      // 
      // olvcSalary
      // 
      this.olvcSalary.AspectName = "Salary";
      this.olvcSalary.CellPadding = null;
      this.olvcSalary.MaximumWidth = 65;
      this.olvcSalary.MinimumWidth = 45;
      this.olvcSalary.Text = "Salary";
      this.olvcSalary.Width = 55;
      // 
      // olvcForm
      // 
      this.olvcForm.AspectName = "Form";
      this.olvcForm.CellPadding = null;
      this.olvcForm.IsEditable = false;
      this.olvcForm.MaximumWidth = 150;
      this.olvcForm.MinimumWidth = 80;
      this.olvcForm.Text = "Form";
      this.olvcForm.ToolTipText = "Player form";
      this.olvcForm.Width = 110;
      // 
      // olvcFame
      // 
      this.olvcFame.AspectName = "Fame";
      this.olvcFame.CellPadding = null;
      this.olvcFame.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcFame.MaximumWidth = 130;
      this.olvcFame.MinimumWidth = 50;
      this.olvcFame.Text = "Fame";
      this.olvcFame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcFame.Width = 120;
      // 
      // olvcFatigue
      // 
      this.olvcFatigue.AspectName = "Fatigue";
      this.olvcFatigue.CellPadding = null;
      this.olvcFatigue.IsEditable = false;
      this.olvcFatigue.MaximumWidth = 100;
      this.olvcFatigue.MinimumWidth = 50;
      this.olvcFatigue.Text = "Fatigue";
      this.olvcFatigue.Width = 70;
      // 
      // olvcInjured
      // 
      this.olvcInjured.AspectName = "Injury";
      this.olvcInjured.CellPadding = null;
      this.olvcInjured.CheckBoxes = true;
      this.olvcInjured.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcInjured.IsHeaderVertical = true;
      this.olvcInjured.Text = "Injured?";
      this.olvcInjured.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcInjured.Width = 40;
      // 
      // olvcInjuryDays
      // 
      this.olvcInjuryDays.AspectName = "InjuryDays";
      this.olvcInjuryDays.CellPadding = null;
      this.olvcInjuryDays.IsEditable = false;
      this.olvcInjuryDays.MaximumWidth = 50;
      this.olvcInjuryDays.MinimumWidth = 30;
      this.olvcInjuryDays.Text = "Injury Days";
      this.olvcInjuryDays.Width = 45;
      // 
      // olvcNt
      // 
      this.olvcNt.AspectName = "NT";
      this.olvcNt.CellPadding = null;
      this.olvcNt.CheckBoxes = true;
      this.olvcNt.IsEditable = false;
      this.olvcNt.IsHeaderVertical = true;
      this.olvcNt.Text = "NT?";
      this.olvcNt.Width = 40;
      // 
      // olvcNtU21
      // 
      this.olvcNtU21.AspectName = "U21NT";
      this.olvcNtU21.CellPadding = null;
      this.olvcNtU21.CheckBoxes = true;
      this.olvcNtU21.IsEditable = false;
      this.olvcNtU21.IsHeaderVertical = true;
      this.olvcNtU21.Text = "U21 NT?";
      this.olvcNtU21.ToolTipText = "under 21 national team member";
      this.olvcNtU21.Width = 40;
      // 
      // olvcNtU18
      // 
      this.olvcNtU18.AspectName = "U18NT";
      this.olvcNtU18.CellPadding = null;
      this.olvcNtU18.CheckBoxes = true;
      this.olvcNtU18.IsEditable = false;
      this.olvcNtU18.IsHeaderVertical = true;
      this.olvcNtU18.Text = "U18 NT?";
      this.olvcNtU18.ToolTipText = "under 18 national team member";
      this.olvcNtU18.Width = 40;
      // 
      // tabPageSkills
      // 
      this.tabPageSkills.Controls.Add(this.lblSkillsActive);
      this.tabPageSkills.Controls.Add(this.lblSkillsDisplay);
      this.tabPageSkills.Controls.Add(this.olvSkills);
      this.tabPageSkills.Location = new System.Drawing.Point(4, 4);
      this.tabPageSkills.Name = "tabPageSkills";
      this.tabPageSkills.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSkills.Size = new System.Drawing.Size(754, 604);
      this.tabPageSkills.TabIndex = 1;
      this.tabPageSkills.Text = "Skills";
      this.tabPageSkills.UseVisualStyleBackColor = true;
      // 
      // lblSkillsActive
      // 
      this.lblSkillsActive.AutoSize = true;
      this.lblSkillsActive.BackColor = System.Drawing.Color.Gold;
      this.lblSkillsActive.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblSkillsActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.lblSkillsActive.Location = new System.Drawing.Point(3, 575);
      this.lblSkillsActive.MaximumSize = new System.Drawing.Size(1000, 26);
      this.lblSkillsActive.MinimumSize = new System.Drawing.Size(300, 13);
      this.lblSkillsActive.Name = "lblSkillsActive";
      this.lblSkillsActive.Size = new System.Drawing.Size(300, 13);
      this.lblSkillsActive.TabIndex = 1;
      this.lblSkillsActive.Text = "Active skills";
      // 
      // lblSkillsDisplay
      // 
      this.lblSkillsDisplay.AutoSize = true;
      this.lblSkillsDisplay.BackColor = System.Drawing.Color.LightSkyBlue;
      this.lblSkillsDisplay.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblSkillsDisplay.Location = new System.Drawing.Point(3, 588);
      this.lblSkillsDisplay.MaximumSize = new System.Drawing.Size(1000, 26);
      this.lblSkillsDisplay.MinimumSize = new System.Drawing.Size(300, 13);
      this.lblSkillsDisplay.Name = "lblSkillsDisplay";
      this.lblSkillsDisplay.Size = new System.Drawing.Size(300, 13);
      this.lblSkillsDisplay.TabIndex = 0;
      this.lblSkillsDisplay.Text = "Charazay display skill values";
      // 
      // olvSkills
      // 
      this.olvSkills.AllColumns.Add(this.olvcskName);
      this.olvSkills.AllowColumnReorder = true;
      this.olvSkills.AllowDrop = true;
      this.olvSkills.AlternateRowBackColor = System.Drawing.Color.Silver;
      this.olvSkills.BackColor = System.Drawing.Color.DarkGray;
      this.olvSkills.CheckBoxes = true;
      this.olvSkills.CheckedAspectName = "IsActive";
      this.olvSkills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcskName});
      this.olvSkills.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvSkills.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvSkills.EmptyListMsg = "This list is empty. Press \"Add\" to create some items";
      this.olvSkills.FullRowSelect = true;
      this.olvSkills.GroupWithItemCountFormat = "{0} ({1} people)";
      this.olvSkills.GroupWithItemCountSingularFormat = "{0} ({1} person)";
      this.olvSkills.HeaderUsesThemes = false;
      this.olvSkills.HideSelection = false;
      this.olvSkills.Location = new System.Drawing.Point(3, 3);
      this.olvSkills.MinimumSize = new System.Drawing.Size(400, 250);
      this.olvSkills.Name = "olvSkills";
      this.olvSkills.OverlayImage.Alignment = System.Drawing.ContentAlignment.BottomLeft;
      this.olvSkills.OverlayText.Alignment = System.Drawing.ContentAlignment.TopRight;
      this.olvSkills.OverlayText.BorderColor = System.Drawing.Color.DarkRed;
      this.olvSkills.OverlayText.BorderWidth = 4F;
      this.olvSkills.OverlayText.InsetX = 10;
      this.olvSkills.OverlayText.InsetY = 35;
      this.olvSkills.OverlayText.Rotation = 20;
      this.olvSkills.OverlayText.Text = "";
      this.olvSkills.OverlayText.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.olvSkills.OwnerDraw = true;
      this.olvSkills.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
      this.olvSkills.ShowCommandMenuOnRightClick = true;
      this.olvSkills.ShowGroups = false;
      this.olvSkills.ShowImagesOnSubItems = true;
      this.olvSkills.ShowItemCountOnGroups = true;
      this.olvSkills.ShowItemToolTips = true;
      this.olvSkills.Size = new System.Drawing.Size(748, 598);
      this.olvSkills.SpaceBetweenGroups = 20;
      this.olvSkills.TabIndex = 0;
      this.olvSkills.UseAlternatingBackColors = true;
      this.olvSkills.UseCompatibleStateImageBehavior = false;
      this.olvSkills.UseFiltering = true;
      this.olvSkills.UseHotItem = true;
      this.olvSkills.UseHyperlinks = true;
      this.olvSkills.UseSubItemCheckBoxes = true;
      this.olvSkills.View = System.Windows.Forms.View.Details;
      // 
      // olvcskName
      // 
      this.olvcskName.AspectName = "FullName";
      this.olvcskName.CellPadding = null;
      this.olvcskName.Text = "Name";
      // 
      // tabPagePG
      // 
      this.tabPagePG.Controls.Add(this.olvPg);
      this.tabPagePG.Location = new System.Drawing.Point(4, 4);
      this.tabPagePG.Name = "tabPagePG";
      this.tabPagePG.Size = new System.Drawing.Size(754, 604);
      this.tabPagePG.TabIndex = 2;
      this.tabPagePG.Text = "PG";
      this.tabPagePG.UseVisualStyleBackColor = true;
      // 
      // olvPg
      // 
      this.olvPg.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvPg.Location = new System.Drawing.Point(0, 0);
      this.olvPg.Name = "olvPg";
      this.olvPg.Size = new System.Drawing.Size(0, 242);
      this.olvPg.TabIndex = 0;
      this.olvPg.UseCompatibleStateImageBehavior = false;
      this.olvPg.View = System.Windows.Forms.View.Details;
      // 
      // tabPageSG
      // 
      this.tabPageSG.Controls.Add(this.olvSg);
      this.tabPageSG.Location = new System.Drawing.Point(4, 4);
      this.tabPageSG.Name = "tabPageSG";
      this.tabPageSG.Size = new System.Drawing.Size(754, 604);
      this.tabPageSG.TabIndex = 3;
      this.tabPageSG.Text = "SG";
      this.tabPageSG.UseVisualStyleBackColor = true;
      // 
      // olvSg
      // 
      this.olvSg.BackColor = System.Drawing.Color.MistyRose;
      this.olvSg.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvSg.Location = new System.Drawing.Point(0, 0);
      this.olvSg.Name = "olvSg";
      this.olvSg.Size = new System.Drawing.Size(0, 242);
      this.olvSg.TabIndex = 0;
      this.olvSg.UseCompatibleStateImageBehavior = false;
      this.olvSg.View = System.Windows.Forms.View.Details;
      // 
      // tabPageSF
      // 
      this.tabPageSF.Controls.Add(this.olvSf);
      this.tabPageSF.Location = new System.Drawing.Point(4, 4);
      this.tabPageSF.Name = "tabPageSF";
      this.tabPageSF.Size = new System.Drawing.Size(754, 604);
      this.tabPageSF.TabIndex = 4;
      this.tabPageSF.Text = "SF";
      this.tabPageSF.UseVisualStyleBackColor = true;
      // 
      // olvSf
      // 
      this.olvSf.BackColor = System.Drawing.Color.LightYellow;
      this.olvSf.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvSf.Location = new System.Drawing.Point(0, 0);
      this.olvSf.Name = "olvSf";
      this.olvSf.Size = new System.Drawing.Size(0, 242);
      this.olvSf.TabIndex = 0;
      this.olvSf.UseCompatibleStateImageBehavior = false;
      this.olvSf.View = System.Windows.Forms.View.Details;
      // 
      // tabPagePF
      // 
      this.tabPagePF.Controls.Add(this.olvPf);
      this.tabPagePF.Location = new System.Drawing.Point(4, 4);
      this.tabPagePF.Name = "tabPagePF";
      this.tabPagePF.Size = new System.Drawing.Size(754, 604);
      this.tabPagePF.TabIndex = 5;
      this.tabPagePF.Text = "PF";
      this.tabPagePF.UseVisualStyleBackColor = true;
      // 
      // olvPf
      // 
      this.olvPf.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.olvPf.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvPf.Location = new System.Drawing.Point(0, 0);
      this.olvPf.Name = "olvPf";
      this.olvPf.Size = new System.Drawing.Size(0, 242);
      this.olvPf.TabIndex = 0;
      this.olvPf.UseCompatibleStateImageBehavior = false;
      this.olvPf.View = System.Windows.Forms.View.Details;
      // 
      // tabPageC
      // 
      this.tabPageC.Controls.Add(this.olvC);
      this.tabPageC.Location = new System.Drawing.Point(4, 4);
      this.tabPageC.Name = "tabPageC";
      this.tabPageC.Size = new System.Drawing.Size(754, 604);
      this.tabPageC.TabIndex = 6;
      this.tabPageC.Text = "C";
      this.tabPageC.UseVisualStyleBackColor = true;
      // 
      // olvC
      // 
      this.olvC.BackColor = System.Drawing.SystemColors.ControlLight;
      this.olvC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvC.Location = new System.Drawing.Point(0, 0);
      this.olvC.Name = "olvC";
      this.olvC.Size = new System.Drawing.Size(0, 242);
      this.olvC.TabIndex = 0;
      this.olvC.UseCompatibleStateImageBehavior = false;
      this.olvC.View = System.Windows.Forms.View.Details;
      // 
      // tabPageTraining
      // 
      this.tabPageTraining.Controls.Add(this.splitLR);
      this.tabPageTraining.Location = new System.Drawing.Point(4, 4);
      this.tabPageTraining.Name = "tabPageTraining";
      this.tabPageTraining.Size = new System.Drawing.Size(754, 604);
      this.tabPageTraining.TabIndex = 7;
      this.tabPageTraining.Text = "Training";
      this.tabPageTraining.UseVisualStyleBackColor = true;
      // 
      // splitLR
      // 
      this.splitLR.BackColor = System.Drawing.Color.Black;
      this.splitLR.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitLR.Location = new System.Drawing.Point(0, 0);
      this.splitLR.Name = "splitLR";
      // 
      // splitLR.Panel1
      // 
      this.splitLR.Panel1.Controls.Add(this.splitTBCoachesSkillsIncrease);
      this.splitLR.Panel1MinSize = 225;
      // 
      // splitLR.Panel2
      // 
      this.splitLR.Panel2.Controls.Add(this.splitTrnRight);
      this.splitLR.Size = new System.Drawing.Size(252, 242);
      this.splitLR.SplitterDistance = 225;
      this.splitLR.SplitterWidth = 2;
      this.splitLR.TabIndex = 1;
      // 
      // splitTBCoachesSkillsIncrease
      // 
      this.splitTBCoachesSkillsIncrease.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitTBCoachesSkillsIncrease.Location = new System.Drawing.Point(0, 0);
      this.splitTBCoachesSkillsIncrease.Name = "splitTBCoachesSkillsIncrease";
      this.splitTBCoachesSkillsIncrease.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitTBCoachesSkillsIncrease.Panel1
      // 
      this.splitTBCoachesSkillsIncrease.Panel1.Controls.Add(this.lblCoachesList);
      this.splitTBCoachesSkillsIncrease.Panel1.Controls.Add(this.olvCoaches);
      // 
      // splitTBCoachesSkillsIncrease.Panel2
      // 
      this.splitTBCoachesSkillsIncrease.Panel2.Controls.Add(this.splitTBIncrease);
      this.splitTBCoachesSkillsIncrease.Size = new System.Drawing.Size(225, 242);
      this.splitTBCoachesSkillsIncrease.SplitterDistance = 29;
      this.splitTBCoachesSkillsIncrease.SplitterWidth = 2;
      this.splitTBCoachesSkillsIncrease.TabIndex = 2;
      // 
      // lblCoachesList
      // 
      this.lblCoachesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCoachesList.AutoSize = true;
      this.lblCoachesList.BackColor = System.Drawing.Color.Black;
      this.lblCoachesList.ForeColor = System.Drawing.Color.White;
      this.lblCoachesList.Location = new System.Drawing.Point(154, 16);
      this.lblCoachesList.Name = "lblCoachesList";
      this.lblCoachesList.Size = new System.Drawing.Size(68, 13);
      this.lblCoachesList.TabIndex = 1;
      this.lblCoachesList.Text = "Coaches List";
      // 
      // olvCoaches
      // 
      this.olvCoaches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvCoaches.BackColor = System.Drawing.Color.Cornsilk;
      this.olvCoaches.FullRowSelect = true;
      this.olvCoaches.HeaderUsesThemes = false;
      this.olvCoaches.Location = new System.Drawing.Point(0, 0);
      this.olvCoaches.Name = "olvCoaches";
      this.olvCoaches.ShowGroups = false;
      this.olvCoaches.Size = new System.Drawing.Size(222, 29);
      this.olvCoaches.TabIndex = 0;
      this.olvCoaches.UseAlternatingBackColors = true;
      this.olvCoaches.UseCellFormatEvents = true;
      this.olvCoaches.UseCompatibleStateImageBehavior = false;
      this.olvCoaches.View = System.Windows.Forms.View.Details;
      this.olvCoaches.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olvCoaches_FormatCell);
      this.olvCoaches.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvCoaches_FormatRow);
      // 
      // splitTBIncrease
      // 
      this.splitTBIncrease.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitTBIncrease.Location = new System.Drawing.Point(0, 0);
      this.splitTBIncrease.Name = "splitTBIncrease";
      this.splitTBIncrease.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitTBIncrease.Panel1
      // 
      this.splitTBIncrease.Panel1.Controls.Add(this.lblSkillIncrease);
      this.splitTBIncrease.Panel1.Controls.Add(this.olvSkillIncrease);
      // 
      // splitTBIncrease.Panel2
      // 
      this.splitTBIncrease.Panel2.Controls.Add(this.lblScoreIncrease);
      this.splitTBIncrease.Panel2.Controls.Add(this.olvTraining);
      this.splitTBIncrease.Size = new System.Drawing.Size(225, 211);
      this.splitTBIncrease.SplitterDistance = 87;
      this.splitTBIncrease.SplitterWidth = 2;
      this.splitTBIncrease.TabIndex = 3;
      // 
      // lblSkillIncrease
      // 
      this.lblSkillIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSkillIncrease.AutoSize = true;
      this.lblSkillIncrease.ForeColor = System.Drawing.Color.White;
      this.lblSkillIncrease.Location = new System.Drawing.Point(116, 74);
      this.lblSkillIncrease.Name = "lblSkillIncrease";
      this.lblSkillIncrease.Size = new System.Drawing.Size(106, 13);
      this.lblSkillIncrease.TabIndex = 2;
      this.lblSkillIncrease.Text = "Weekly skill increase";
      // 
      // olvSkillIncrease
      // 
      this.olvSkillIncrease.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncName);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncDef);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncFreethrows);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkInc2p);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkInc3p);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncDribbling);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncPassing);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncSpeed);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncFootwork);
      this.olvSkillIncrease.AllColumns.Add(this.olvcSkIncRebounds);
      this.olvSkillIncrease.AlternateRowBackColor = System.Drawing.Color.Moccasin;
      this.olvSkillIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvSkillIncrease.BackColor = System.Drawing.Color.Cornsilk;
      this.olvSkillIncrease.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcSkIncName,
            this.olvcSkIncDef,
            this.olvcSkIncFreethrows,
            this.olvcSkInc2p,
            this.olvcSkInc3p,
            this.olvcSkIncDribbling,
            this.olvcSkIncPassing,
            this.olvcSkIncSpeed,
            this.olvcSkIncFootwork,
            this.olvcSkIncRebounds});
      this.olvSkillIncrease.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvSkillIncrease.FullRowSelect = true;
      this.olvSkillIncrease.HeaderUsesThemes = false;
      this.olvSkillIncrease.HeaderWordWrap = true;
      this.olvSkillIncrease.HighlightBackgroundColor = System.Drawing.Color.IndianRed;
      this.olvSkillIncrease.HighlightForegroundColor = System.Drawing.Color.Teal;
      this.olvSkillIncrease.HotTracking = true;
      this.olvSkillIncrease.HoverSelection = true;
      this.olvSkillIncrease.Location = new System.Drawing.Point(0, 0);
      this.olvSkillIncrease.Name = "olvSkillIncrease";
      this.olvSkillIncrease.ShowGroups = false;
      this.olvSkillIncrease.ShowItemToolTips = true;
      this.olvSkillIncrease.Size = new System.Drawing.Size(225, 87);
      this.olvSkillIncrease.TabIndex = 1;
      this.olvSkillIncrease.UseCompatibleStateImageBehavior = false;
      this.olvSkillIncrease.UseHotItem = true;
      this.olvSkillIncrease.UseTranslucentHotItem = true;
      this.olvSkillIncrease.View = System.Windows.Forms.View.Details;
      // 
      // olvcSkIncName
      // 
      this.olvcSkIncName.AspectName = "FullName";
      this.olvcSkIncName.CellPadding = null;
      this.olvcSkIncName.MaximumWidth = 200;
      this.olvcSkIncName.MinimumWidth = 100;
      this.olvcSkIncName.Text = "Player";
      this.olvcSkIncName.Width = 130;
      this.olvcSkIncName.WordWrap = true;
      // 
      // olvcSkIncDef
      // 
      this.olvcSkIncDef.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncDef.CellPadding = null;
      this.olvcSkIncDef.IsHeaderVertical = true;
      this.olvcSkIncDef.MaximumWidth = 70;
      this.olvcSkIncDef.MinimumWidth = 50;
      this.olvcSkIncDef.Text = "Defense";
      this.olvcSkIncDef.WordWrap = true;
      // 
      // olvcSkIncFreethrows
      // 
      this.olvcSkIncFreethrows.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncFreethrows.CellPadding = null;
      this.olvcSkIncFreethrows.IsHeaderVertical = true;
      this.olvcSkIncFreethrows.MaximumWidth = 70;
      this.olvcSkIncFreethrows.MinimumWidth = 50;
      this.olvcSkIncFreethrows.Text = "Freethrows";
      this.olvcSkIncFreethrows.WordWrap = true;
      // 
      // olvcSkInc2p
      // 
      this.olvcSkInc2p.AspectToStringFormat = "{0:F04}";
      this.olvcSkInc2p.CellPadding = null;
      this.olvcSkInc2p.IsHeaderVertical = true;
      this.olvcSkInc2p.MaximumWidth = 70;
      this.olvcSkInc2p.MinimumWidth = 50;
      this.olvcSkInc2p.Text = "2p";
      this.olvcSkInc2p.WordWrap = true;
      // 
      // olvcSkInc3p
      // 
      this.olvcSkInc3p.AspectToStringFormat = "{0:F04}";
      this.olvcSkInc3p.CellPadding = null;
      this.olvcSkInc3p.IsHeaderVertical = true;
      this.olvcSkInc3p.MaximumWidth = 70;
      this.olvcSkInc3p.MinimumWidth = 50;
      this.olvcSkInc3p.Text = "3p";
      this.olvcSkInc3p.WordWrap = true;
      // 
      // olvcSkIncDribbling
      // 
      this.olvcSkIncDribbling.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncDribbling.CellPadding = null;
      this.olvcSkIncDribbling.IsHeaderVertical = true;
      this.olvcSkIncDribbling.MaximumWidth = 70;
      this.olvcSkIncDribbling.MinimumWidth = 50;
      this.olvcSkIncDribbling.Text = "Dribbling";
      this.olvcSkIncDribbling.WordWrap = true;
      // 
      // olvcSkIncPassing
      // 
      this.olvcSkIncPassing.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncPassing.CellPadding = null;
      this.olvcSkIncPassing.IsHeaderVertical = true;
      this.olvcSkIncPassing.MaximumWidth = 70;
      this.olvcSkIncPassing.MinimumWidth = 50;
      this.olvcSkIncPassing.Text = "Passing";
      this.olvcSkIncPassing.WordWrap = true;
      // 
      // olvcSkIncSpeed
      // 
      this.olvcSkIncSpeed.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncSpeed.CellPadding = null;
      this.olvcSkIncSpeed.IsHeaderVertical = true;
      this.olvcSkIncSpeed.MaximumWidth = 70;
      this.olvcSkIncSpeed.MinimumWidth = 50;
      this.olvcSkIncSpeed.Text = "Speed";
      this.olvcSkIncSpeed.WordWrap = true;
      // 
      // olvcSkIncFootwork
      // 
      this.olvcSkIncFootwork.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncFootwork.CellPadding = null;
      this.olvcSkIncFootwork.IsHeaderVertical = true;
      this.olvcSkIncFootwork.MaximumWidth = 70;
      this.olvcSkIncFootwork.MinimumWidth = 50;
      this.olvcSkIncFootwork.Text = "Footwork";
      this.olvcSkIncFootwork.WordWrap = true;
      // 
      // olvcSkIncRebounds
      // 
      this.olvcSkIncRebounds.AspectToStringFormat = "{0:F04}";
      this.olvcSkIncRebounds.CellPadding = null;
      this.olvcSkIncRebounds.IsHeaderVertical = true;
      this.olvcSkIncRebounds.MaximumWidth = 70;
      this.olvcSkIncRebounds.MinimumWidth = 50;
      this.olvcSkIncRebounds.Text = "Rebounds";
      this.olvcSkIncRebounds.WordWrap = true;
      // 
      // lblScoreIncrease
      // 
      this.lblScoreIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblScoreIncrease.AutoSize = true;
      this.lblScoreIncrease.ForeColor = System.Drawing.Color.White;
      this.lblScoreIncrease.Location = new System.Drawing.Point(143, 104);
      this.lblScoreIncrease.Name = "lblScoreIncrease";
      this.lblScoreIncrease.Size = new System.Drawing.Size(79, 13);
      this.lblScoreIncrease.TabIndex = 3;
      this.lblScoreIncrease.Text = "Score Increase";
      // 
      // olvTraining
      // 
      this.olvTraining.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.olvTraining.AllColumns.Add(this.olvcTrainingName);
      this.olvTraining.AllColumns.Add(this.olvcTrainingDef);
      this.olvTraining.AllColumns.Add(this.olvcTrainingDribbling);
      this.olvTraining.AllColumns.Add(this.olvcTrainingPassing);
      this.olvTraining.AllColumns.Add(this.olvcTrainingSpeed);
      this.olvTraining.AllColumns.Add(this.olvcTrainingFootwork);
      this.olvTraining.AllColumns.Add(this.olvcTrainingRebounds);
      this.olvTraining.AllColumns.Add(this.olvcTrainingInsideSh);
      this.olvTraining.AllColumns.Add(this.olvcTrainingOutsideSh);
      this.olvTraining.AlternateRowBackColor = System.Drawing.Color.Moccasin;
      this.olvTraining.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.olvTraining.BackColor = System.Drawing.Color.Cornsilk;
      this.olvTraining.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcTrainingName,
            this.olvcTrainingDef,
            this.olvcTrainingInsideSh,
            this.olvcTrainingOutsideSh,
            this.olvcTrainingDribbling,
            this.olvcTrainingPassing,
            this.olvcTrainingSpeed,
            this.olvcTrainingFootwork,
            this.olvcTrainingRebounds});
      this.olvTraining.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvTraining.FullRowSelect = true;
      this.olvTraining.HeaderUsesThemes = false;
      this.olvTraining.HeaderWordWrap = true;
      this.olvTraining.HighlightBackgroundColor = System.Drawing.Color.IndianRed;
      this.olvTraining.HighlightForegroundColor = System.Drawing.Color.Teal;
      this.olvTraining.HotTracking = true;
      this.olvTraining.HoverSelection = true;
      this.olvTraining.Location = new System.Drawing.Point(0, 0);
      this.olvTraining.Name = "olvTraining";
      this.olvTraining.ShowGroups = false;
      this.olvTraining.ShowItemToolTips = true;
      this.olvTraining.Size = new System.Drawing.Size(221, 122);
      this.olvTraining.TabIndex = 2;
      this.olvTraining.UseCompatibleStateImageBehavior = false;
      this.olvTraining.UseHotItem = true;
      this.olvTraining.UseTranslucentHotItem = true;
      this.olvTraining.View = System.Windows.Forms.View.Details;
      // 
      // olvcTrainingName
      // 
      this.olvcTrainingName.AspectName = "FullName";
      this.olvcTrainingName.CellPadding = null;
      this.olvcTrainingName.MaximumWidth = 200;
      this.olvcTrainingName.MinimumWidth = 100;
      this.olvcTrainingName.Text = "Player";
      this.olvcTrainingName.Width = 130;
      this.olvcTrainingName.WordWrap = true;
      // 
      // olvcTrainingDef
      // 
      this.olvcTrainingDef.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingDef.CellPadding = null;
      this.olvcTrainingDef.IsHeaderVertical = true;
      this.olvcTrainingDef.MaximumWidth = 70;
      this.olvcTrainingDef.MinimumWidth = 50;
      this.olvcTrainingDef.Text = "Defense";
      this.olvcTrainingDef.WordWrap = true;
      // 
      // olvcTrainingDribbling
      // 
      this.olvcTrainingDribbling.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingDribbling.CellPadding = null;
      this.olvcTrainingDribbling.IsHeaderVertical = true;
      this.olvcTrainingDribbling.MaximumWidth = 70;
      this.olvcTrainingDribbling.MinimumWidth = 50;
      this.olvcTrainingDribbling.Text = "Dribbling";
      this.olvcTrainingDribbling.WordWrap = true;
      // 
      // olvcTrainingPassing
      // 
      this.olvcTrainingPassing.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingPassing.CellPadding = null;
      this.olvcTrainingPassing.IsHeaderVertical = true;
      this.olvcTrainingPassing.MaximumWidth = 70;
      this.olvcTrainingPassing.MinimumWidth = 50;
      this.olvcTrainingPassing.Text = "Passing";
      this.olvcTrainingPassing.WordWrap = true;
      // 
      // olvcTrainingSpeed
      // 
      this.olvcTrainingSpeed.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingSpeed.CellPadding = null;
      this.olvcTrainingSpeed.IsHeaderVertical = true;
      this.olvcTrainingSpeed.MaximumWidth = 70;
      this.olvcTrainingSpeed.MinimumWidth = 50;
      this.olvcTrainingSpeed.Text = "Speed";
      this.olvcTrainingSpeed.WordWrap = true;
      // 
      // olvcTrainingFootwork
      // 
      this.olvcTrainingFootwork.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingFootwork.CellPadding = null;
      this.olvcTrainingFootwork.IsHeaderVertical = true;
      this.olvcTrainingFootwork.MaximumWidth = 70;
      this.olvcTrainingFootwork.MinimumWidth = 50;
      this.olvcTrainingFootwork.Text = "Footwork";
      this.olvcTrainingFootwork.WordWrap = true;
      // 
      // olvcTrainingRebounds
      // 
      this.olvcTrainingRebounds.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingRebounds.CellPadding = null;
      this.olvcTrainingRebounds.IsHeaderVertical = true;
      this.olvcTrainingRebounds.MaximumWidth = 70;
      this.olvcTrainingRebounds.MinimumWidth = 50;
      this.olvcTrainingRebounds.Text = "Rebounds";
      this.olvcTrainingRebounds.WordWrap = true;
      // 
      // olvcTrainingInsideSh
      // 
      this.olvcTrainingInsideSh.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingInsideSh.CellPadding = null;
      this.olvcTrainingInsideSh.IsHeaderVertical = true;
      this.olvcTrainingInsideSh.MaximumWidth = 70;
      this.olvcTrainingInsideSh.MinimumWidth = 50;
      this.olvcTrainingInsideSh.Text = "InsideSh";
      this.olvcTrainingInsideSh.WordWrap = true;
      // 
      // olvcTrainingOutsideSh
      // 
      this.olvcTrainingOutsideSh.AspectToStringFormat = "{0:F03}";
      this.olvcTrainingOutsideSh.CellPadding = null;
      this.olvcTrainingOutsideSh.IsHeaderVertical = true;
      this.olvcTrainingOutsideSh.MaximumWidth = 70;
      this.olvcTrainingOutsideSh.MinimumWidth = 50;
      this.olvcTrainingOutsideSh.Text = "OutsideSh";
      this.olvcTrainingOutsideSh.WordWrap = true;
      // 
      // splitTrnRight
      // 
      this.splitTrnRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitTrnRight.Location = new System.Drawing.Point(0, 0);
      this.splitTrnRight.Name = "splitTrnRight";
      this.splitTrnRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitTrnRight.Panel1
      // 
      this.splitTrnRight.Panel1.BackColor = System.Drawing.Color.DimGray;
      this.splitTrnRight.Panel1.Controls.Add(this.chkTEu18);
      this.splitTrnRight.Panel1.Controls.Add(this.olvTrainingEfficiency);
      // 
      // splitTrnRight.Panel2
      // 
      this.splitTrnRight.Panel2.Controls.Add(this.propGrid);
      this.splitTrnRight.Size = new System.Drawing.Size(27, 242);
      this.splitTrnRight.SplitterDistance = 100;
      this.splitTrnRight.TabIndex = 1;
      // 
      // chkTEu18
      // 
      this.chkTEu18.AutoSize = true;
      this.chkTEu18.Dock = System.Windows.Forms.DockStyle.Top;
      this.chkTEu18.ForeColor = System.Drawing.Color.White;
      this.chkTEu18.Location = new System.Drawing.Point(0, 0);
      this.chkTEu18.Name = "chkTEu18";
      this.chkTEu18.Size = new System.Drawing.Size(27, 17);
      this.chkTEu18.TabIndex = 3;
      this.chkTEu18.Text = "Keep top 8";
      this.chkTEu18.UseVisualStyleBackColor = true;
      this.chkTEu18.CheckedChanged += new System.EventHandler(this.chkTEu18_CheckedChanged);
      // 
      // olvTrainingEfficiency
      // 
      this.olvTrainingEfficiency.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.olvTrainingEfficiency.AlternateRowBackColor = System.Drawing.Color.Gray;
      this.olvTrainingEfficiency.BackColor = System.Drawing.Color.DimGray;
      this.olvTrainingEfficiency.Cursor = System.Windows.Forms.Cursors.Default;
      this.olvTrainingEfficiency.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvTrainingEfficiency.ForeColor = System.Drawing.SystemColors.Info;
      this.olvTrainingEfficiency.FullRowSelect = true;
      this.olvTrainingEfficiency.HeaderUsesThemes = false;
      this.olvTrainingEfficiency.HeaderWordWrap = true;
      this.olvTrainingEfficiency.HighlightBackgroundColor = System.Drawing.Color.DarkGray;
      this.olvTrainingEfficiency.HighlightForegroundColor = System.Drawing.Color.Gray;
      this.olvTrainingEfficiency.HotTracking = true;
      this.olvTrainingEfficiency.HoverSelection = true;
      this.olvTrainingEfficiency.Location = new System.Drawing.Point(0, 0);
      this.olvTrainingEfficiency.Name = "olvTrainingEfficiency";
      this.olvTrainingEfficiency.ShowGroups = false;
      this.olvTrainingEfficiency.ShowItemToolTips = true;
      this.olvTrainingEfficiency.Size = new System.Drawing.Size(27, 100);
      this.olvTrainingEfficiency.TabIndex = 2;
      this.olvTrainingEfficiency.UseAlternatingBackColors = true;
      this.olvTrainingEfficiency.UseCompatibleStateImageBehavior = false;
      this.olvTrainingEfficiency.UseHotItem = true;
      this.olvTrainingEfficiency.UseTranslucentHotItem = true;
      this.olvTrainingEfficiency.UseTranslucentSelection = true;
      this.olvTrainingEfficiency.View = System.Windows.Forms.View.Details;
      // 
      // propGrid
      // 
      this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propGrid.Location = new System.Drawing.Point(0, 0);
      this.propGrid.Name = "propGrid";
      this.propGrid.Size = new System.Drawing.Size(27, 138);
      this.propGrid.TabIndex = 0;
      // 
      // tabPageMyTeamSchedule
      // 
      this.tabPageMyTeamSchedule.Controls.Add(this.tableLayoutPanel1);
      this.tabPageMyTeamSchedule.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyTeamSchedule.Name = "tabPageMyTeamSchedule";
      this.tabPageMyTeamSchedule.Size = new System.Drawing.Size(754, 604);
      this.tabPageMyTeamSchedule.TabIndex = 9;
      this.tabPageMyTeamSchedule.Text = "My Team Schedule";
      this.tabPageMyTeamSchedule.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tableLayoutPanel1.Controls.Add(this.dgMySchedule, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.gbxWL, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.gbxTeamSchedulePlayed, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.cbxMatchTypes, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 242);
      this.tableLayoutPanel1.TabIndex = 5;
      // 
      // dgMySchedule
      // 
      this.dgMySchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgMySchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgMySchedule.CausesValidation = false;
      this.tableLayoutPanel1.SetColumnSpan(this.dgMySchedule, 4);
      this.dgMySchedule.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgMySchedule.Location = new System.Drawing.Point(3, 53);
      this.dgMySchedule.Name = "dgMySchedule";
      this.dgMySchedule.ReadOnly = true;
      this.dgMySchedule.Size = new System.Drawing.Size(1, 186);
      this.dgMySchedule.TabIndex = 4;
      this.dgMySchedule.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgMySchedule_DataError);
      // 
      // gbxWL
      // 
      this.gbxWL.Controls.Add(this.rdWLLost);
      this.gbxWL.Controls.Add(this.rdWLAll);
      this.gbxWL.Controls.Add(this.rdWLWin);
      this.gbxWL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxWL.Location = new System.Drawing.Point(3, 3);
      this.gbxWL.Name = "gbxWL";
      this.gbxWL.Size = new System.Drawing.Size(1, 44);
      this.gbxWL.TabIndex = 3;
      this.gbxWL.TabStop = false;
      this.gbxWL.Text = "Won/Lost";
      // 
      // rdWLLost
      // 
      this.rdWLLost.AutoSize = true;
      this.rdWLLost.Location = new System.Drawing.Point(104, 20);
      this.rdWLLost.Name = "rdWLLost";
      this.rdWLLost.Size = new System.Drawing.Size(45, 17);
      this.rdWLLost.TabIndex = 2;
      this.rdWLLost.Text = "Lost";
      this.rdWLLost.UseVisualStyleBackColor = true;
      this.rdWLLost.CheckedChanged += new System.EventHandler(this.rdWLAll_CheckedChanged);
      // 
      // rdWLAll
      // 
      this.rdWLAll.AutoSize = true;
      this.rdWLAll.Checked = true;
      this.rdWLAll.Location = new System.Drawing.Point(7, 20);
      this.rdWLAll.Name = "rdWLAll";
      this.rdWLAll.Size = new System.Drawing.Size(36, 17);
      this.rdWLAll.TabIndex = 1;
      this.rdWLAll.TabStop = true;
      this.rdWLAll.Text = "All";
      this.rdWLAll.UseVisualStyleBackColor = true;
      this.rdWLAll.CheckedChanged += new System.EventHandler(this.rdWLAll_CheckedChanged);
      // 
      // rdWLWin
      // 
      this.rdWLWin.AutoSize = true;
      this.rdWLWin.Location = new System.Drawing.Point(49, 20);
      this.rdWLWin.Name = "rdWLWin";
      this.rdWLWin.Size = new System.Drawing.Size(48, 17);
      this.rdWLWin.TabIndex = 0;
      this.rdWLWin.Text = "Won";
      this.rdWLWin.UseVisualStyleBackColor = true;
      this.rdWLWin.CheckedChanged += new System.EventHandler(this.rdWLAll_CheckedChanged);
      // 
      // gbxTeamSchedulePlayed
      // 
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedNo);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedYes);
      this.gbxTeamSchedulePlayed.Controls.Add(this.rdPlayedAll);
      this.gbxTeamSchedulePlayed.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gbxTeamSchedulePlayed.Location = new System.Drawing.Point(3, 3);
      this.gbxTeamSchedulePlayed.Name = "gbxTeamSchedulePlayed";
      this.gbxTeamSchedulePlayed.Size = new System.Drawing.Size(1, 44);
      this.gbxTeamSchedulePlayed.TabIndex = 0;
      this.gbxTeamSchedulePlayed.TabStop = false;
      this.gbxTeamSchedulePlayed.Text = "Played";
      // 
      // rdPlayedNo
      // 
      this.rdPlayedNo.AutoSize = true;
      this.rdPlayedNo.Location = new System.Drawing.Point(98, 20);
      this.rdPlayedNo.Name = "rdPlayedNo";
      this.rdPlayedNo.Size = new System.Drawing.Size(39, 17);
      this.rdPlayedNo.TabIndex = 2;
      this.rdPlayedNo.Text = "No";
      this.rdPlayedNo.UseVisualStyleBackColor = true;
      this.rdPlayedNo.CheckedChanged += new System.EventHandler(this.rdPlayedAll_CheckedChanged);
      // 
      // rdPlayedYes
      // 
      this.rdPlayedYes.AutoSize = true;
      this.rdPlayedYes.Location = new System.Drawing.Point(49, 20);
      this.rdPlayedYes.Name = "rdPlayedYes";
      this.rdPlayedYes.Size = new System.Drawing.Size(43, 17);
      this.rdPlayedYes.TabIndex = 1;
      this.rdPlayedYes.Text = "Yes";
      this.rdPlayedYes.UseVisualStyleBackColor = true;
      this.rdPlayedYes.CheckedChanged += new System.EventHandler(this.rdPlayedAll_CheckedChanged);
      // 
      // rdPlayedAll
      // 
      this.rdPlayedAll.AutoSize = true;
      this.rdPlayedAll.Checked = true;
      this.rdPlayedAll.Location = new System.Drawing.Point(7, 20);
      this.rdPlayedAll.Name = "rdPlayedAll";
      this.rdPlayedAll.Size = new System.Drawing.Size(36, 17);
      this.rdPlayedAll.TabIndex = 0;
      this.rdPlayedAll.TabStop = true;
      this.rdPlayedAll.Text = "All";
      this.rdPlayedAll.UseVisualStyleBackColor = true;
      this.rdPlayedAll.CheckedChanged += new System.EventHandler(this.rdPlayedAll_CheckedChanged);
      // 
      // cbxMatchTypes
      // 
      this.cbxMatchTypes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbxMatchTypes.FormattingEnabled = true;
      this.cbxMatchTypes.Location = new System.Drawing.Point(3, 3);
      this.cbxMatchTypes.Name = "cbxMatchTypes";
      this.cbxMatchTypes.Size = new System.Drawing.Size(1, 21);
      this.cbxMatchTypes.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(1, 50);
      this.label1.TabIndex = 1;
      this.label1.Text = "Match type:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tabPageMyDivisionStandings
      // 
      this.tabPageMyDivisionStandings.Controls.Add(this.dgStandings);
      this.tabPageMyDivisionStandings.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyDivisionStandings.Name = "tabPageMyDivisionStandings";
      this.tabPageMyDivisionStandings.Size = new System.Drawing.Size(754, 604);
      this.tabPageMyDivisionStandings.TabIndex = 10;
      this.tabPageMyDivisionStandings.Text = "My Division Standings";
      this.tabPageMyDivisionStandings.UseVisualStyleBackColor = true;
      // 
      // dgStandings
      // 
      this.dgStandings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgStandings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgStandings.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.dgStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgStandings.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgStandings.Location = new System.Drawing.Point(0, 0);
      this.dgStandings.Name = "dgStandings";
      this.dgStandings.Size = new System.Drawing.Size(0, 242);
      this.dgStandings.TabIndex = 2;
      // 
      // tabPageMyDivisionSchedule
      // 
      this.tabPageMyDivisionSchedule.Controls.Add(this.tlpMyDiv);
      this.tabPageMyDivisionSchedule.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyDivisionSchedule.Name = "tabPageMyDivisionSchedule";
      this.tabPageMyDivisionSchedule.Size = new System.Drawing.Size(754, 604);
      this.tabPageMyDivisionSchedule.TabIndex = 13;
      this.tabPageMyDivisionSchedule.Text = "My division schedule";
      // 
      // tlpMyDiv
      // 
      this.tlpMyDiv.ColumnCount = 2;
      this.tlpMyDiv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tlpMyDiv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
      this.tlpMyDiv.Controls.Add(this.ucrHome, 1, 1);
      this.tlpMyDiv.Controls.Add(this.ucLineup, 1, 3);
      this.tlpMyDiv.Controls.Add(this.olvMd, 0, 0);
      this.tlpMyDiv.Controls.Add(this.ucrAway, 1, 2);
      this.tlpMyDiv.Controls.Add(this.ucMatchDetails, 1, 0);
      this.tlpMyDiv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpMyDiv.Location = new System.Drawing.Point(0, 0);
      this.tlpMyDiv.Name = "tlpMyDiv";
      this.tlpMyDiv.RowCount = 4;
      this.tlpMyDiv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
      this.tlpMyDiv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
      this.tlpMyDiv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
      this.tlpMyDiv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.tlpMyDiv.Size = new System.Drawing.Size(0, 242);
      this.tlpMyDiv.TabIndex = 5;
      // 
      // ucrHome
      // 
      this.ucrHome.AutoSize = true;
      this.ucrHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucrHome.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucrHome.Location = new System.Drawing.Point(3, 42);
      this.ucrHome.Name = "ucrHome";
      this.ucrHome.RatingType = AndreiPopescu.CharazayPlus.UI.RatingType.Home;
      this.ucrHome.Size = new System.Drawing.Size(1, 65);
      this.ucrHome.TabIndex = 2;
      // 
      // ucLineup
      // 
      this.ucLineup.AutoSize = true;
      this.ucLineup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucLineup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucLineup.Location = new System.Drawing.Point(3, 184);
      this.ucLineup.Name = "ucLineup";
      this.ucLineup.Size = new System.Drawing.Size(1, 55);
      this.ucLineup.TabIndex = 4;
      // 
      // olvMd
      // 
      this.olvMd.AllColumns.Add(this.olvcMd);
      this.olvMd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcMd});
      this.olvMd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvMd.Location = new System.Drawing.Point(3, 3);
      this.olvMd.Name = "olvMd";
      this.tlpMyDiv.SetRowSpan(this.olvMd, 4);
      this.olvMd.Size = new System.Drawing.Size(1, 236);
      this.olvMd.TabIndex = 0;
      this.olvMd.UseCompatibleStateImageBehavior = false;
      this.olvMd.View = System.Windows.Forms.View.Details;
      this.olvMd.SelectionChanged += new System.EventHandler(this.olvMd_SelectionChanged);
      // 
      // olvcMd
      // 
      this.olvcMd.CellPadding = null;
      this.olvcMd.FillsFreeSpace = true;
      this.olvcMd.Text = "Match Id";
      this.olvcMd.Width = 208;
      // 
      // ucrAway
      // 
      this.ucrAway.AutoSize = true;
      this.ucrAway.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucrAway.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucrAway.Location = new System.Drawing.Point(3, 113);
      this.ucrAway.Name = "ucrAway";
      this.ucrAway.RatingType = AndreiPopescu.CharazayPlus.UI.RatingType.Away;
      this.ucrAway.Size = new System.Drawing.Size(1, 65);
      this.ucrAway.TabIndex = 3;
      // 
      // ucMatchDetails
      // 
      this.ucMatchDetails.AutoSize = true;
      this.ucMatchDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucMatchDetails.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
      this.ucMatchDetails.CausesValidation = false;
      this.ucMatchDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMatchDetails.Location = new System.Drawing.Point(3, 3);
      this.ucMatchDetails.Name = "ucMatchDetails";
      this.ucMatchDetails.Size = new System.Drawing.Size(1, 33);
      this.ucMatchDetails.TabIndex = 5;
      // 
      // tabPageMyEconomy
      // 
      this.tabPageMyEconomy.Controls.Add(this.splitEconomy);
      this.tabPageMyEconomy.Location = new System.Drawing.Point(4, 4);
      this.tabPageMyEconomy.Name = "tabPageMyEconomy";
      this.tabPageMyEconomy.Size = new System.Drawing.Size(754, 604);
      this.tabPageMyEconomy.TabIndex = 11;
      this.tabPageMyEconomy.Text = "My Economy";
      this.tabPageMyEconomy.UseVisualStyleBackColor = true;
      // 
      // splitEconomy
      // 
      this.splitEconomy.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitEconomy.Location = new System.Drawing.Point(0, 0);
      this.splitEconomy.Name = "splitEconomy";
      // 
      // splitEconomy.Panel1
      // 
      this.splitEconomy.Panel1.Controls.Add(this.label54);
      this.splitEconomy.Panel1.Controls.Add(this.dgTeamTransfers);
      // 
      // splitEconomy.Panel2
      // 
      this.splitEconomy.Panel2.Controls.Add(this.splitContainer2);
      this.splitEconomy.Size = new System.Drawing.Size(54, 242);
      this.splitEconomy.SplitterDistance = 25;
      this.splitEconomy.TabIndex = 1;
      // 
      // label54
      // 
      this.label54.AutoSize = true;
      this.label54.Location = new System.Drawing.Point(4, 9);
      this.label54.Name = "label54";
      this.label54.Size = new System.Drawing.Size(98, 13);
      this.label54.TabIndex = 1;
      this.label54.Text = "My Team Transfers";
      // 
      // dgTeamTransfers
      // 
      this.dgTeamTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgTeamTransfers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dgTeamTransfers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
      this.dgTeamTransfers.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.dgTeamTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTeamTransfers.Location = new System.Drawing.Point(7, 25);
      this.dgTeamTransfers.Name = "dgTeamTransfers";
      this.dgTeamTransfers.Size = new System.Drawing.Size(456, 571);
      this.dgTeamTransfers.TabIndex = 0;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.ucEconomyWeek);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.ucEconomySeason);
      this.splitContainer2.Size = new System.Drawing.Size(25, 242);
      this.splitContainer2.SplitterDistance = 109;
      this.splitContainer2.TabIndex = 0;
      // 
      // ucEconomyWeek
      // 
      this.ucEconomyWeek.AutoSize = true;
      this.ucEconomyWeek.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomyWeek.Location = new System.Drawing.Point(0, 0);
      this.ucEconomyWeek.Name = "ucEconomyWeek";
      this.ucEconomyWeek.Size = new System.Drawing.Size(300, 130);
      this.ucEconomyWeek.TabIndex = 0;
      // 
      // ucEconomySeason
      // 
      this.ucEconomySeason.AutoSize = true;
      this.ucEconomySeason.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEconomySeason.Location = new System.Drawing.Point(0, 0);
      this.ucEconomySeason.Name = "ucEconomySeason";
      this.ucEconomySeason.Size = new System.Drawing.Size(300, 130);
      this.ucEconomySeason.TabIndex = 0;
      // 
      // tabPageTL
      // 
      this.tabPageTL.Controls.Add(this.tlpTL);
      this.tabPageTL.Location = new System.Drawing.Point(4, 4);
      this.tabPageTL.Name = "tabPageTL";
      this.tabPageTL.Size = new System.Drawing.Size(754, 604);
      this.tabPageTL.TabIndex = 12;
      this.tabPageTL.Text = "Transfer List";
      this.tabPageTL.UseVisualStyleBackColor = true;
      // 
      // tlpTL
      // 
      this.tlpTL.ColumnCount = 3;
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74F));
      this.tlpTL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
      this.tlpTL.Controls.Add(this.panel1, 2, 0);
      this.tlpTL.Controls.Add(this.panel2, 0, 0);
      this.tlpTL.Controls.Add(this.olvTL, 0, 1);
      this.tlpTL.Controls.Add(this.evaluatePlayerUC, 1, 0);
      this.tlpTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tlpTL.Location = new System.Drawing.Point(0, 0);
      this.tlpTL.Name = "tlpTL";
      this.tlpTL.RowCount = 2;
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 194F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpTL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpTL.Size = new System.Drawing.Size(754, 604);
      this.tlpTL.TabIndex = 11;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnTLAdd);
      this.panel1.Controls.Add(this.gbxPosition);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(658, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(93, 188);
      this.panel1.TabIndex = 0;
      // 
      // btnTLAdd
      // 
      this.btnTLAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btnTLAdd.Location = new System.Drawing.Point(0, 133);
      this.btnTLAdd.Name = "btnTLAdd";
      this.btnTLAdd.Size = new System.Drawing.Size(93, 55);
      this.btnTLAdd.TabIndex = 9;
      this.btnTLAdd.Text = "Add to List";
      this.btnTLAdd.UseVisualStyleBackColor = true;
      this.btnTLAdd.Click += new System.EventHandler(this.btnTLAdd_Click);
      // 
      // gbxPosition
      // 
      this.gbxPosition.Controls.Add(this.rdC);
      this.gbxPosition.Controls.Add(this.rdPf);
      this.gbxPosition.Controls.Add(this.rdPg);
      this.gbxPosition.Controls.Add(this.rdSg);
      this.gbxPosition.Controls.Add(this.rdSf);
      this.gbxPosition.Dock = System.Windows.Forms.DockStyle.Top;
      this.gbxPosition.Location = new System.Drawing.Point(0, 0);
      this.gbxPosition.Name = "gbxPosition";
      this.gbxPosition.Size = new System.Drawing.Size(93, 135);
      this.gbxPosition.TabIndex = 4;
      this.gbxPosition.TabStop = false;
      this.gbxPosition.Text = "Position";
      // 
      // rdC
      // 
      this.rdC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdC.AutoSize = true;
      this.rdC.Location = new System.Drawing.Point(6, 108);
      this.rdC.Name = "rdC";
      this.rdC.Size = new System.Drawing.Size(32, 17);
      this.rdC.TabIndex = 4;
      this.rdC.TabStop = true;
      this.rdC.Text = "C";
      this.rdC.UseVisualStyleBackColor = true;
      // 
      // rdPf
      // 
      this.rdPf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdPf.AutoSize = true;
      this.rdPf.Location = new System.Drawing.Point(6, 85);
      this.rdPf.Name = "rdPf";
      this.rdPf.Size = new System.Drawing.Size(38, 17);
      this.rdPf.TabIndex = 3;
      this.rdPf.TabStop = true;
      this.rdPf.Text = "PF";
      this.rdPf.UseVisualStyleBackColor = true;
      // 
      // rdPg
      // 
      this.rdPg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdPg.AutoSize = true;
      this.rdPg.Location = new System.Drawing.Point(6, 16);
      this.rdPg.Name = "rdPg";
      this.rdPg.Size = new System.Drawing.Size(40, 17);
      this.rdPg.TabIndex = 0;
      this.rdPg.TabStop = true;
      this.rdPg.Text = "PG";
      this.rdPg.UseVisualStyleBackColor = true;
      // 
      // rdSg
      // 
      this.rdSg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdSg.AutoSize = true;
      this.rdSg.Location = new System.Drawing.Point(6, 39);
      this.rdSg.Name = "rdSg";
      this.rdSg.Size = new System.Drawing.Size(40, 17);
      this.rdSg.TabIndex = 1;
      this.rdSg.TabStop = true;
      this.rdSg.Text = "SG";
      this.rdSg.UseVisualStyleBackColor = true;
      // 
      // rdSf
      // 
      this.rdSf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rdSf.AutoSize = true;
      this.rdSf.Location = new System.Drawing.Point(6, 62);
      this.rdSf.Name = "rdSf";
      this.rdSf.Size = new System.Drawing.Size(38, 17);
      this.rdSf.TabIndex = 2;
      this.rdSf.TabStop = true;
      this.rdSf.Text = "SF";
      this.rdSf.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.dtpDeadline);
      this.panel2.Controls.Add(this.label50);
      this.panel2.Controls.Add(this.tbxPlayerId);
      this.panel2.Controls.Add(this.label52);
      this.panel2.Controls.Add(this.btnTLGet);
      this.panel2.Controls.Add(this.tbxPrice);
      this.panel2.Controls.Add(this.label51);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(3, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(92, 188);
      this.panel2.TabIndex = 1;
      // 
      // dtpDeadline
      // 
      this.dtpDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dtpDeadline.CustomFormat = "yyyy-MM-dd HH:mm";
      this.dtpDeadline.Enabled = false;
      this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDeadline.Location = new System.Drawing.Point(6, 155);
      this.dtpDeadline.Name = "dtpDeadline";
      this.dtpDeadline.ShowUpDown = true;
      this.dtpDeadline.Size = new System.Drawing.Size(91, 20);
      this.dtpDeadline.TabIndex = 8;
      this.dtpDeadline.Visible = false;
      // 
      // label50
      // 
      this.label50.AutoSize = true;
      this.label50.Location = new System.Drawing.Point(0, 0);
      this.label50.Name = "label50";
      this.label50.Size = new System.Drawing.Size(47, 13);
      this.label50.TabIndex = 0;
      this.label50.Text = "Player id";
      this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tbxPlayerId
      // 
      this.tbxPlayerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPlayerId.Location = new System.Drawing.Point(6, 16);
      this.tbxPlayerId.Name = "tbxPlayerId";
      this.tbxPlayerId.Size = new System.Drawing.Size(91, 20);
      this.tbxPlayerId.TabIndex = 1;
      // 
      // label52
      // 
      this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label52.AutoSize = true;
      this.label52.Enabled = false;
      this.label52.Location = new System.Drawing.Point(3, 139);
      this.label52.Name = "label52";
      this.label52.Size = new System.Drawing.Size(49, 13);
      this.label52.TabIndex = 7;
      this.label52.Text = "Deadline";
      this.label52.Visible = false;
      // 
      // btnTLGet
      // 
      this.btnTLGet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTLGet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.btnTLGet.Location = new System.Drawing.Point(5, 42);
      this.btnTLGet.Name = "btnTLGet";
      this.btnTLGet.Size = new System.Drawing.Size(91, 37);
      this.btnTLGet.TabIndex = 2;
      this.btnTLGet.Text = "Get";
      this.btnTLGet.UseVisualStyleBackColor = true;
      this.btnTLGet.Click += new System.EventHandler(this.btnTLGet_Click);
      // 
      // tbxPrice
      // 
      this.tbxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPrice.Enabled = false;
      this.tbxPrice.Location = new System.Drawing.Point(6, 108);
      this.tbxPrice.Name = "tbxPrice";
      this.tbxPrice.Size = new System.Drawing.Size(91, 20);
      this.tbxPrice.TabIndex = 6;
      this.tbxPrice.Visible = false;
      // 
      // label51
      // 
      this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label51.AutoSize = true;
      this.label51.Enabled = false;
      this.label51.Location = new System.Drawing.Point(16, 87);
      this.label51.Name = "label51";
      this.label51.Size = new System.Drawing.Size(31, 13);
      this.label51.TabIndex = 5;
      this.label51.Text = "Price";
      this.label51.Visible = false;
      // 
      // olvTL
      // 
      this.olvTL.AllColumns.Add(this.olvcTLPosition);
      this.olvTL.AllColumns.Add(this.olvcTLName);
      this.olvTL.AllColumns.Add(this.olvcTLPrice);
      this.olvTL.AllColumns.Add(this.olvcTLValueIndex);
      this.olvTL.AllColumns.Add(this.olvcTLProfitability);
      this.olvTL.AllColumns.Add(this.olvcTLDeadline);
      this.olvTL.AllColumns.Add(this.olvcTLTotalScore);
      this.olvTL.AllColumns.Add(this.olvcTLDefensiveScore);
      this.olvTL.AllColumns.Add(this.olvcTLOffenseScore);
      this.olvTL.AllColumns.Add(this.olvcTLOffensiveAbilityScore);
      this.olvTL.AllColumns.Add(this.olvcTLShoot);
      this.olvTL.AllColumns.Add(this.olvcTLRebounds);
      this.olvTL.AllColumns.Add(this.olvcTLRebO);
      this.olvTL.AllColumns.Add(this.olvcTLRebD);
      this.olvTL.BackColor = System.Drawing.Color.Beige;
      this.olvTL.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
      this.olvTL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcTLPosition,
            this.olvcTLName,
            this.olvcTLPrice,
            this.olvcTLValueIndex,
            this.olvcTLProfitability,
            this.olvcTLDeadline,
            this.olvcTLTotalScore,
            this.olvcTLDefensiveScore,
            this.olvcTLOffenseScore,
            this.olvcTLOffensiveAbilityScore,
            this.olvcTLShoot,
            this.olvcTLRebounds,
            this.olvcTLRebO,
            this.olvcTLRebD});
      this.tlpTL.SetColumnSpan(this.olvTL, 3);
      this.olvTL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.olvTL.FullRowSelect = true;
      this.olvTL.HeaderUsesThemes = false;
      this.olvTL.HeaderWordWrap = true;
      this.olvTL.Location = new System.Drawing.Point(3, 197);
      this.olvTL.MinimumSize = new System.Drawing.Size(100, 100);
      this.olvTL.Name = "olvTL";
      this.olvTL.Size = new System.Drawing.Size(748, 404);
      this.olvTL.TabIndex = 10;
      this.olvTL.UseCompatibleStateImageBehavior = false;
      this.olvTL.View = System.Windows.Forms.View.Details;
      this.olvTL.BeforeSorting += new System.EventHandler<BrightIdeasSoftware.BeforeSortingEventArgs>(this.olvTL_BeforeSorting);
      this.olvTL.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditFinishing);
      this.olvTL.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvTL_CellEditStarting);
      this.olvTL.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvTL_CellRightClick);
      this.olvTL.SelectionChanged += new System.EventHandler(this.olvTL_SelectionChanged);
      this.olvTL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olvTL_KeyDown);
      // 
      // olvcTLPosition
      // 
      this.olvcTLPosition.AspectName = "Pos";
      this.olvcTLPosition.CellPadding = null;
      this.olvcTLPosition.IsEditable = false;
      this.olvcTLPosition.IsHeaderVertical = true;
      this.olvcTLPosition.Text = "Position";
      this.olvcTLPosition.Width = 50;
      this.olvcTLPosition.WordWrap = true;
      // 
      // olvcTLName
      // 
      this.olvcTLName.AspectName = "Name";
      this.olvcTLName.CellPadding = null;
      this.olvcTLName.Groupable = false;
      this.olvcTLName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcTLName.IsEditable = false;
      this.olvcTLName.Text = "Name";
      this.olvcTLName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvcTLName.Width = 110;
      this.olvcTLName.WordWrap = true;
      // 
      // olvcTLPrice
      // 
      this.olvcTLPrice.AspectName = "Price";
      this.olvcTLPrice.CellPadding = null;
      this.olvcTLPrice.Text = "Price";
      // 
      // olvcTLValueIndex
      // 
      this.olvcTLValueIndex.AspectName = "ValueIndex";
      this.olvcTLValueIndex.AspectToStringFormat = "{0:F02}";
      this.olvcTLValueIndex.CellPadding = null;
      this.olvcTLValueIndex.IsEditable = false;
      this.olvcTLValueIndex.IsHeaderVertical = true;
      this.olvcTLValueIndex.Text = "ValueIndex";
      this.olvcTLValueIndex.Width = 35;
      this.olvcTLValueIndex.WordWrap = true;
      // 
      // olvcTLProfitability
      // 
      this.olvcTLProfitability.AspectName = "Profitability";
      this.olvcTLProfitability.AspectToStringFormat = "{0:F02}";
      this.olvcTLProfitability.CellPadding = null;
      this.olvcTLProfitability.IsEditable = false;
      this.olvcTLProfitability.IsHeaderVertical = true;
      this.olvcTLProfitability.Text = "Profitability";
      this.olvcTLProfitability.Width = 35;
      this.olvcTLProfitability.WordWrap = true;
      // 
      // olvcTLDeadline
      // 
      this.olvcTLDeadline.AspectName = "Deadline";
      this.olvcTLDeadline.CellPadding = null;
      this.olvcTLDeadline.Text = "Deadline";
      this.olvcTLDeadline.Width = 100;
      // 
      // olvcTLTotalScore
      // 
      this.olvcTLTotalScore.AspectName = "Total";
      this.olvcTLTotalScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLTotalScore.CellPadding = null;
      this.olvcTLTotalScore.IsEditable = false;
      this.olvcTLTotalScore.IsHeaderVertical = true;
      this.olvcTLTotalScore.Text = "Total";
      this.olvcTLTotalScore.Width = 41;
      this.olvcTLTotalScore.WordWrap = true;
      // 
      // olvcTLDefensiveScore
      // 
      this.olvcTLDefensiveScore.AspectName = "Def";
      this.olvcTLDefensiveScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLDefensiveScore.CellPadding = null;
      this.olvcTLDefensiveScore.IsEditable = false;
      this.olvcTLDefensiveScore.IsHeaderVertical = true;
      this.olvcTLDefensiveScore.Text = "Defensive Score";
      this.olvcTLDefensiveScore.Width = 39;
      this.olvcTLDefensiveScore.WordWrap = true;
      // 
      // olvcTLOffenseScore
      // 
      this.olvcTLOffenseScore.AspectName = "Off";
      this.olvcTLOffenseScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLOffenseScore.CellPadding = null;
      this.olvcTLOffenseScore.IsEditable = false;
      this.olvcTLOffenseScore.IsHeaderVertical = true;
      this.olvcTLOffenseScore.Text = "Offense Score";
      this.olvcTLOffenseScore.Width = 39;
      this.olvcTLOffenseScore.WordWrap = true;
      // 
      // olvcTLOffensiveAbilityScore
      // 
      this.olvcTLOffensiveAbilityScore.AspectName = "OfAb";
      this.olvcTLOffensiveAbilityScore.AspectToStringFormat = "{0:F02}";
      this.olvcTLOffensiveAbilityScore.CellPadding = null;
      this.olvcTLOffensiveAbilityScore.IsEditable = false;
      this.olvcTLOffensiveAbilityScore.IsHeaderVertical = true;
      this.olvcTLOffensiveAbilityScore.Text = "Offensive Ability Score";
      this.olvcTLOffensiveAbilityScore.Width = 39;
      // 
      // olvcTLShoot
      // 
      this.olvcTLShoot.AspectName = "Shoot";
      this.olvcTLShoot.AspectToStringFormat = "{0:F02}";
      this.olvcTLShoot.CellPadding = null;
      this.olvcTLShoot.IsEditable = false;
      this.olvcTLShoot.IsHeaderVertical = true;
      this.olvcTLShoot.Text = "Shooting Score";
      this.olvcTLShoot.Width = 39;
      this.olvcTLShoot.WordWrap = true;
      // 
      // olvcTLRebounds
      // 
      this.olvcTLRebounds.AspectName = "Reb";
      this.olvcTLRebounds.AspectToStringFormat = "{0:F02}";
      this.olvcTLRebounds.CellPadding = null;
      this.olvcTLRebounds.IsEditable = false;
      this.olvcTLRebounds.IsHeaderVertical = true;
      this.olvcTLRebounds.Text = "Rebounds Score";
      this.olvcTLRebounds.Width = 39;
      this.olvcTLRebounds.WordWrap = true;
      // 
      // olvcTLRebO
      // 
      this.olvcTLRebO.AspectName = "RebO";
      this.olvcTLRebO.AspectToStringFormat = "{0:F02}";
      this.olvcTLRebO.CellPadding = null;
      this.olvcTLRebO.IsEditable = false;
      this.olvcTLRebO.IsHeaderVertical = true;
      this.olvcTLRebO.Text = "Offensive Rebounds Score";
      this.olvcTLRebO.Width = 39;
      // 
      // olvcTLRebD
      // 
      this.olvcTLRebD.AspectName = "RebD";
      this.olvcTLRebD.AspectToStringFormat = "{0:F02}";
      this.olvcTLRebD.CellPadding = null;
      this.olvcTLRebD.IsEditable = false;
      this.olvcTLRebD.IsHeaderVertical = true;
      this.olvcTLRebD.Text = "Defensive Rebounds Score";
      this.olvcTLRebD.Width = 39;
      this.olvcTLRebD.WordWrap = true;
      // 
      // evaluatePlayerUC
      // 
      this.evaluatePlayerUC.AutoSize = true;
      this.evaluatePlayerUC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.evaluatePlayerUC.BackColor = System.Drawing.Color.DimGray;
      this.evaluatePlayerUC.CausesValidation = false;
      this.evaluatePlayerUC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.evaluatePlayerUC.ForeColor = System.Drawing.Color.White;
      this.evaluatePlayerUC.Location = new System.Drawing.Point(101, 3);
      this.evaluatePlayerUC.Name = "evaluatePlayerUC";
      this.evaluatePlayerUC.SelectedObject = null;
      this.evaluatePlayerUC.Size = new System.Drawing.Size(551, 188);
      this.evaluatePlayerUC.TabIndex = 11;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.userControl11);
      this.tabPage1.Location = new System.Drawing.Point(4, 4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(754, 604);
      this.tabPage1.TabIndex = 14;
      this.tabPage1.Text = "Decoration";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // userControl11
      // 
      this.userControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.userControl11.AutoSize = true;
      this.userControl11.Location = new System.Drawing.Point(0, 0);
      this.userControl11.Name = "userControl11";
      this.userControl11.Players = null;
      this.userControl11.Size = new System.Drawing.Size(751, 604);
      this.userControl11.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(872, 639);
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
      this.cmsOlvTL.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.sideTabControl.ResumeLayout(false);
      this.tabPageInfo.ResumeLayout(false);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      this.splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgDivisionList)).EndInit();
      this.tabPageStatus.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvStatus)).EndInit();
      this.tabPageSkills.ResumeLayout(false);
      this.tabPageSkills.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvSkills)).EndInit();
      this.tabPagePG.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvPg)).EndInit();
      this.tabPageSG.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvSg)).EndInit();
      this.tabPageSF.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvSf)).EndInit();
      this.tabPagePF.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvPf)).EndInit();
      this.tabPageC.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvC)).EndInit();
      this.tabPageTraining.ResumeLayout(false);
      this.splitLR.Panel1.ResumeLayout(false);
      this.splitLR.Panel2.ResumeLayout(false);
      this.splitLR.ResumeLayout(false);
      this.splitTBCoachesSkillsIncrease.Panel1.ResumeLayout(false);
      this.splitTBCoachesSkillsIncrease.Panel1.PerformLayout();
      this.splitTBCoachesSkillsIncrease.Panel2.ResumeLayout(false);
      this.splitTBCoachesSkillsIncrease.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvCoaches)).EndInit();
      this.splitTBIncrease.Panel1.ResumeLayout(false);
      this.splitTBIncrease.Panel1.PerformLayout();
      this.splitTBIncrease.Panel2.ResumeLayout(false);
      this.splitTBIncrease.Panel2.PerformLayout();
      this.splitTBIncrease.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvSkillIncrease)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.olvTraining)).EndInit();
      this.splitTrnRight.Panel1.ResumeLayout(false);
      this.splitTrnRight.Panel1.PerformLayout();
      this.splitTrnRight.Panel2.ResumeLayout(false);
      this.splitTrnRight.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.olvTrainingEfficiency)).EndInit();
      this.tabPageMyTeamSchedule.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgMySchedule)).EndInit();
      this.gbxWL.ResumeLayout(false);
      this.gbxWL.PerformLayout();
      this.gbxTeamSchedulePlayed.ResumeLayout(false);
      this.gbxTeamSchedulePlayed.PerformLayout();
      this.tabPageMyDivisionStandings.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgStandings)).EndInit();
      this.tabPageMyDivisionSchedule.ResumeLayout(false);
      this.tlpMyDiv.ResumeLayout(false);
      this.tlpMyDiv.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvMd)).EndInit();
      this.tabPageMyEconomy.ResumeLayout(false);
      this.splitEconomy.Panel1.ResumeLayout(false);
      this.splitEconomy.Panel1.PerformLayout();
      this.splitEconomy.Panel2.ResumeLayout(false);
      this.splitEconomy.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamTransfers)).EndInit();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      this.splitContainer2.ResumeLayout(false);
      this.tabPageTL.ResumeLayout(false);
      this.tlpTL.ResumeLayout(false);
      this.tlpTL.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.gbxPosition.ResumeLayout(false);
      this.gbxPosition.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.olvTL)).EndInit();
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    #region Cache related
    private void addMyPlayersToCache()
    {
      foreach (var op in _optimumPlayers)
      {
        CacheManager.Instance.AddPlayer(op.Id, op.FullName);
      }
    }

    private void addMyTeamScheduleToCache()
    {
      //throw new NotImplementedException();
      foreach (Xsd2.match m in _mySchedule)
      {
        CacheManager.Instance.AddTeam(m.HomeTeamId, m.HomeTeamName);
        CacheManager.Instance.AddTeam(m.AwayTeamId, m.AwayTeamName);
        CacheManager.Instance.AddMatch(m);
      }
    }

    private void addDivisionScheduleToCache()
    {
      foreach (var rnd in _myDivisionFullSchedule)
      {
        //rnd.match
      }
    }
    #endregion

    #region //-- main form
    private void MainForm_Load(object sender, EventArgs e)
    {
      sideTabControl.SelectedTab = tabPageInfo;
      tabPageInfo.Focus();
      initInfoTab();
    }

    /// <summary>
    /// selected side tab change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void sideTabControl_Selected(object sender, TabControlEventArgs e)
    {
      switch ((SideTabPage)e.TabPageIndex)
      {
        case SideTabPage.Status: 
        { 
          initStatus(); 
          addMyPlayersToCache(); 
        } break;
        case SideTabPage.Skills:
          initSkills();          
          //InitializeComplexExample();
          break;

        case SideTabPage.PG: 
          initOLV<PG>(olvPg, pgs); 
          break;
        case SideTabPage.SG: 
          initOLV<SG>(olvSg, sgs); 
          break;  
        case SideTabPage.PF: initOLV<PF>(olvPf, pfs); break;
        case SideTabPage.SF: 
          initOLV<SF>(olvSf, sfs); 
          break;
        case SideTabPage.C: initOLV<C>(olvC, cs); break;
        
        case SideTabPage.Training: 
        {
        initCoachesList();
        initTrainingSkillIncrease();
        initTrainingScoreIncrease();
        initTrainingPropertyGrid();
        initTrainingEfficiency();
        } break;

        case SideTabPage.Info: initInfoTab(); break;
        case SideTabPage.MyTeamSchedule: 
        {
          initTeamScheduleFilter();
          initDgMySchedule();
          addMyTeamScheduleToCache();          
        } break;
      
        case SideTabPage.MyDivisionStandings:
          initDgStandings();
          //initDivisionFullSchedule(); 
          break;
        
        case SideTabPage.MyDivisionSchedule: 
          initMd(); 
          break;
        
        case SideTabPage.MyEconomy:
          {
            initDgMyTransfers();
            initEconomyUserControls();
          } break;

        case SideTabPage.TL: initTransferShortList(); break;

        case SideTabPage.Decoration: 
          userControl11.Players = _optimumPlayers; 
          break;

        default: break;
      }
    }

    private void initTeamScheduleFilter()
    {
      this.cbxMatchTypes.SelectedValueChanged -= new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
      cbxMatchTypes.DataSource = Enum.GetValues(typeof(MatchType));
      this.cbxMatchTypes.SelectedValueChanged += new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
    }

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
        formLogin.ShowDialog(this);
      }

       _wsu = new Web.WebServiceUser(Properties.Settings.Default.UserName, Properties.Settings.Default.SecurityCode);
       //
       // down + deserialize xmls
       //
       DownloadMandatoryXmlFiles();
       DownloadXmlAdditional();             
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="di"></param>    
    private void DeserializeXml(Web.XmlDownloadItem di)
    {
      using (FileStream fs = new FileStream(di.m_fileName, FileMode.Open, FileAccess.Read))
      {
        //Xsd.charazay charazayObject = null;
        Xsd2.charazay obj = null;
        try
        {
          obj = (Xsd2.charazay)(new XmlSerializer(typeof(Xsd2.charazay)).Deserialize(fs));
          switch (di.DeserializationType)
          { //
            // MyPlayers
            //
            case Web.XmlSerializationType.MyPlayers: initMyPlayers(obj.players); break;
            //
            // di.DeserializationObject = obj.arena; 
            //
            case Web.XmlSerializationType.Arena: _arena = obj.arena; break;
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
            case Web.XmlSerializationType.Coaches: initCoachesData(obj.coaches); break;
            //
            case Web.XmlSerializationType.MySchedule: _mySchedule = obj.matches; break;
            //
            case Web.XmlSerializationType.DivisionStandings: _myDivisionStandings = obj.division; break;
            //
            case Web.XmlSerializationType.DivisionSchedule: _myDivisionFullSchedule = obj.schedule; break;
            //
            case Web.XmlSerializationType.Match: _selectedMatch = obj.match; break;
            //
            case Web.XmlSerializationType.MyTransfers: _myTransfers = obj.team_transfers; break;
            // 
            case Web.XmlSerializationType.Economy: _economy = obj.economy; break;
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

    #endregion

    #region Trial and error
    //private void Serialize()
    //{
    //  Player p = new PG(1UL, "primu", "jucator", 13, 15, 191, 89
    //    , 13130, 1300, 4, 23, Fame.UnknownPlayer,
    //    5, 2, 3, 4, 5, 6, 7, 2, 3, 1);

    //  Player p2 = new PG(2UL, "aldoilea", "jucator", 13, 15, 191, 89
    //    , 13130, 1300, 4, 23, Fame.UnknownPlayer,
    //    5, 2, 3, 4, 5, 6, 7, 2, 3, 1);

    //  Players<PG> players = new Players<PG>();
    //  players.Items.Add(p);
    //  players.Items.Add(p2);

    //  XmlSerializer srlz = new XmlSerializer(typeof(Players<PG>));
    //  using (FileStream fs = new FileStream("try.xml", FileMode.OpenOrCreate, FileAccess.Write))
    //  {
    //    srlz.Serialize(fs, players);
    //  }
    //}

    //private void Deserialize()
    //{
    //  //XmlSerializer srlz = new XmlSerializer(typeof(Players<PG>));
    //  //XmlSerializer srlz = new XmlSerializer(typeof(Xsd.CharazayPlayers));
    //  //XmlSerializer srlz = new XmlSerializer(typeof(Xsd.CharazayPlayersDataset));

    //  XmlSerializer srlz = new XmlSerializer(typeof(Xsd.charazay));

    //  Xsd.charazay charazayObject = null;

    //  //foreach (string f in Directory.GetFiles(Test.XmlTestFilesDirectory))
    //  AssemblyInfo asi = new AssemblyInfo();

    //  foreach (string f in Directory.GetFiles(asi.ApplicationFolder, "*.xml", SearchOption.AllDirectories))
    //  {
    //    using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read))
    //    {
    //      //Players<PG> players = (Players<PG>)srlz.Deserialize(fs);        
    //      //Xsd.CharazayPlayersDataset players = (Xsd.CharazayPlayersDataset)srlz.Deserialize(fs);
    //      //Xsd.CharazayPlayers players = (Xsd.CharazayPlayers)srlz.Deserialize(fs);

    //      charazayObject = (Xsd.charazay)srlz.Deserialize(fs);
    //    }
    //  }
    //}
    //private Xsd.CharazayPlayers GetObjectFromXML()
    //{
    //  var settings = new XmlReaderSettings();
    //  var obj = new Xsd.CharazayPlayers();
    //  var reader = XmlReader.Create(Test.playersDeserialize, settings);
    //  var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Xsd.CharazayPlayers));
    //  obj = (Xsd.CharazayPlayers)serializer.Deserialize(reader);

    //  reader.Close();
    //  return obj;
    //}
    private void BindDataGridView()
    { // populate 
      //System.Data.DataSet ds = Test.LoadDatasetFromXml(Test.refXml, @"..\..\charazay.xsd");

      //Xsd.CharazayPlayersDataset charazayDs = new Xsd.CharazayPlayersDataset();
      //charazayDs.ReadXml(Test.refXml);

      //this.dataGridView1.DataSource = charazayDs.player;
      //this.dataGridView1.DataMember = "player";
    }
    
    #endregion    

    //private void olvMd_Click(object sender, EventArgs e)
    //{
    //  ObjectListView olv = sender as ObjectListView;
    //  uint mid = ((Xsd2.charazayRound)olv.SelectedObject).match.id;
    //}

    //private void olvMd_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    //{
    //  if (e.IsSelected)
    //  {
    //    ListViewItem li = e.Item;
    //    int i = e.ItemIndex;
    //  }
    //}

    private void olvMd_SelectionChanged(object sender, EventArgs e)
    {
      if (olvMd.SelectedObjects == null || olvMd.SelectedObjects.Count == 0)
        return;
      var v = olvMd.SelectedObjects[0] as Xsd2.charazayRound;
      if (v == null)
        return;

      MatchRating(v.match.id);      
    }

    private void MatchRating(uint matchId)
    {
      using (Web.Downloader crawler = new Web.Downloader())
      {
        crawler.Add(new Web.MatchXml(_wsu, (ulong)matchId));
        crawler.Get(true);

        try
        {
          //foreach (Web.XmlDownloadItem di in m_xmlDownloadItems)
          foreach (Web.XmlDownloadItem di in crawler.Items)
            DeserializeXml(di);
          //

          ucMatchDetails.SetData(_selectedMatch);
          ucrHome.RatingType = UI.RatingType.Home;
          ucrHome.SetData(_selectedMatch.stats.home, _selectedMatch.bballs.home);
          ucrAway.RatingType = UI.RatingType.Away;
          ucrAway.SetData(_selectedMatch.stats.away, _selectedMatch.bballs.away);
          ucLineup.SetData(_selectedMatch.lineup);
          //
          CacheManager.Instance.AddMatch (_selectedMatch);

        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.Write(ex.Message);
        }
      }
    }

    private void initMyPlayers(Xsd2.charazayPlayer[] players)
    {
      {
        //di.DeserializationObject = obj.players;
        // positions 
        //Xsd.players xsdPlayers = (Xsd.players)m_xmlDownloadItems[0].DeserializationObject;
        //foreach (Xsd.player plyr in xsdPlayers.player)
        foreach (Xsd2.charazayPlayer plyr in players)
        {
          PG pg = new PG(plyr);
          pgs.Add(pg);
          SG sg = new SG(plyr);
          sgs.Add(sg);
          PF pf = new PF(plyr);
          pfs.Add(pf);
          SF sf = new SF(plyr);
          sfs.Add(sf);
          C c = new C(plyr);
          cs.Add(c);

          _optimumPlayers.Add(Player.Decide(pg, sg, sf, pf, c));
        }
      }
    }

    private void initCoachesData(Xsd2.charazayCoach[] xsdCoaches)
    {
      // coaches file
      //Xsd.coaches xsdCoaches = (Xsd.coaches)m_xmlDownloadItems[1].DeserializationObject;
      //
      // alloc max coach (inner struct)
      //
      Xsd2.charazayCoach maxCoach = new Xsd2.charazayCoach();
      maxCoach.skills = new Xsd2.charazayCoachSkills();
      maxCoach.basic = new Xsd2.charazayCoachBasic();
      //
      // get maximum skills from al coaches
      //
      foreach (Xsd2.charazayCoach xsdCoach in xsdCoaches)
      {
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

    private void cbxMatchTypes_SelectedValueChanged(object sender, EventArgs e)
    {
      MatchType mt = (MatchType)cbxMatchTypes.SelectedValue;
      FilteredBindingList <Xsd2.match> fbl = (FilteredBindingList<Xsd2.match>) dgMySchedule.DataSource;
      fbl.Filter = "MatchType=" + Enum.GetName(typeof(MatchType), mt);
      dgMySchedule.DataSource = fbl;
    }

    private void rdPlayedAll_CheckedChanged(object sender, EventArgs e)
    {
      FilteredBindingList <Xsd2.match> fbl =
        (FilteredBindingList<Xsd2.match>) dgMySchedule.DataSource;

      if (rdPlayedYes.Checked)
        fbl.Filter = string.Format("played='{0}'", "yes");
      else if (rdPlayedNo.Checked)
        fbl.Filter = string.Format("played='{0}'", "no");
      else
        fbl.RemoveFilter();
      
      dgMySchedule.DataSource = fbl;
    }

    private void rdWLAll_CheckedChanged(object sender, EventArgs e)
    {
      FilteredBindingList<Xsd2.match> fbl =
        (FilteredBindingList<Xsd2.match>)dgMySchedule.DataSource;

      if (rdWLWin.Checked)
        fbl.Filter = string.Format("Won='{0}'", "true");
      else if (rdWLLost.Checked)
        fbl.Filter = string.Format("Won='{0}'", "false");
      else
        fbl.RemoveFilter();

      dgMySchedule.DataSource = fbl;
    }

    private void olvSkills_CellEditFinishing (object sender, CellEditEventArgs e)
    {

    }

    private void olvSkills_CellEditStarting (object sender, CellEditEventArgs e)
    {

    }

    private void olvSkills_CellEditValidating (object sender, CellEditEventArgs e)
    {

    }

    private void olvSkills_CellRightClick (object sender, CellRightClickEventArgs e)
    {

    }

    private void olvSkills_CellToolTip (object sender, ToolTipShowingEventArgs e)
    {

    }

    private void olvSkills_FormatCell (object sender, FormatCellEventArgs e)
    {

    }

    private void olvSkills_FormatRow (object sender, FormatRowEventArgs e)
    {

    }

    private void olvSkills_HeaderToolTipShowing (object sender, ToolTipShowingEventArgs e)
    {

    }

    private void olvSkills_GroupTaskClicked (object sender, GroupTaskClickedEventArgs e)
    {

    }
    
   }
}
