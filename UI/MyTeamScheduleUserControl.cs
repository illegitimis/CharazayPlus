

namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Windows.Forms;
  using MatchType = AndreiPopescu.CharazayPlus.Utils.MatchType;
  using MatchFilteredBindingList = AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<Xsd2.match>;


  public partial class MyTeamScheduleUserControl : UserControl
  {
    public MyTeamScheduleUserControl ( )
    {
      InitializeComponent();
    }

#if XSD2
      public Xsd2.charazayTeam Team { get; set; }
      public Xsd2.match[] MySchedule { get; set; }
#elif XSDMERGE
    public XsdMerge.team Team { get; set; }
    public XsdMerge.match[] MySchedule { get; set; }
#else
#endif


    public void initDgMySchedule ( )
    {
#if DOTNET30
      // purge
      //dgMySchedule.CaptionText = "My Team Schedule";
      dgMySchedule.initGridPrologue();

      // home team (id+name).
      dgMySchedule.GenerateLinkColumn( "Home", "HomeTeamName");
      dgMySchedule.GenerateTextBoxColumn( string.Empty, "homescore");
      dgMySchedule.GenerateTextBoxColumn( string.Empty, "awayscore");
      // away team (id+name).
      dgMySchedule.GenerateLinkColumn( "Away", "AwayTeamName");
      dgMySchedule.GenerateTextBoxColumn( "Type", "MatchType");
      // date (match link)
      dgMySchedule.GenerateTextBoxColumn( "Date", "Date_");
      dgMySchedule.GenerateTextBoxColumn( "Rnd", "round");
      dgMySchedule.GenerateTextBoxColumn( "Season", "season");
      dgMySchedule.GenerateTextBoxColumn( "Spectators", "spectators");
      dgMySchedule.GenerateTextBoxColumn( "Vips", "vips");
#else
      DataGridExtensions.initGridPrologue(dgMySchedule);
      DataGridExtensions.GenerateLinkColumn   (dgMySchedule,"Home", "HomeTeamName");                                   
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,string.Empty, "homescore");                                
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,string.Empty, "awayscore");                                
      DataGridExtensions.GenerateLinkColumn   (dgMySchedule,"Away", "AwayTeamName");                                   
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Type", "MatchType");                                      
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Date", "Date_");                                          
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Rnd", "round");                                           
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Season", "season");                                       
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Spectators", "spectators");                               
      DataGridExtensions.GenerateTextBoxColumn(dgMySchedule,"Vips", "vips");                                           
#endif


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
#if XSD2
        var fbl = new AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<Xsd2.match>();
#elif XSDMERGE
      var fbl = new AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<XsdMerge.match>();
#else
#endif
      foreach (var m in MySchedule)
      {
        m.MyTeamId = Team.id;
        fbl.Add(m);
      }
      dgMySchedule.DataSource = fbl;
      dgMySchedule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    }

    public void initTeamScheduleFilter ( )
    {
      this.cbxMatchTypes.SelectedValueChanged -= new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
      cbxMatchTypes.DataSource = Enum.GetValues(typeof(AndreiPopescu.CharazayPlus.Utils.MatchType));
      this.cbxMatchTypes.SelectedValueChanged += new System.EventHandler(this.cbxMatchTypes_SelectedValueChanged);
    }

    #region event handlers
    private void cbxMatchTypes_SelectedValueChanged (object sender, EventArgs e)
    {
      MatchType mt = (MatchType)cbxMatchTypes.SelectedValue;
      var fbl = (AndreiPopescu.CharazayPlus.Utils.FilteredBindingList<Xsd2.match>)dgMySchedule.DataSource;
      fbl.Filter = "MatchType=" + Enum.GetName(typeof(MatchType), mt);
      dgMySchedule.DataSource = fbl;
    }

    private void rdPlayedAll_CheckedChanged (object sender, EventArgs e)
    {
      var fbl = (MatchFilteredBindingList)dgMySchedule.DataSource;

      if (rdPlayedYes.Checked)
        fbl.Filter = string.Format("played='{0}'", "yes");
      else if (rdPlayedNo.Checked)
        fbl.Filter = string.Format("played='{0}'", "no");
      else
        fbl.RemoveFilter();

      dgMySchedule.DataSource = fbl;
    }

    private void rdWLAll_CheckedChanged (object sender, EventArgs e)
    {
      var fbl = (MatchFilteredBindingList)dgMySchedule.DataSource;

      if (rdWLWin.Checked)
        fbl.Filter = string.Format("Won='{0}'", "true");
      else if (rdWLLost.Checked)
        fbl.Filter = string.Format("Won='{0}'", "false");
      else
        fbl.RemoveFilter();

      dgMySchedule.DataSource = fbl;
    }

    private void dg_DataError (object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    
    #endregion
  }
}
