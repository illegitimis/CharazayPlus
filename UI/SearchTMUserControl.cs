using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BrightIdeasSoftware;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.UI
{
  /// <summary>
  /// The transfer market search user control uses browser automation
  /// to post and get data from the Charazay site
  /// </summary>
  public partial class SearchTMUserControl : UserControl
  {
    public event EventHandler<PlayerEventArgs> PlayerError;
    public event EventHandler<PlayerEventArgs> DownloadPlayerData;

    #region init
    public SearchTMUserControl ( )
    {
      InitializeComponent();
    }

    private void SearchTMUserControl_Load (object sender, EventArgs e)
    { // 
      // rangeBarAge
      // 
      this.rangeBarAge.SetRangeLimit(15d, 40d);
      this.rangeBarAge.SelectRange(15, 40);
      this.rangeBarAge.DivisionNum = 24;
      this.rangeBarAge.TotalMinimum = 15;
      this.rangeBarAge.TotalMaximum = 40;
      this.rangeBarAge.RangeMinimum = 15;
      this.rangeBarAge.RangeMaximum = 40;
      // h
      this.rangeBarHeight.DivisionNum = 35;
      this.rangeBarHeight.TotalMaximum = 230;
      this.rangeBarHeight.TotalMinimum = 160;
      this.rangeBarHeight.RangeMaximum = 230;
      this.rangeBarHeight.RangeMinimum = 160;
      // skills
      foreach (RangeBar rb in new RangeBar[] { rangeBarDef, rangeBarDrib, rangeBarExp, rangeBarFT, rangeBarFtw, rangeBarPas, rangeBarReb, rangeBarSpe, rangeBar2p, rangeBar3p })
      {
        rb.SetRangeLimit(0, 30);
        rb.SelectRange(0, 30);
        rb.TotalMinimum = 0;
        rb.TotalMaximum = 30;
        rb.RangeMinimum = 0;
        rb.RangeMaximum = 30;
        rb.DivisionNum = 30;
      }
      //
      foreach (RangeBar rb in new RangeBar[] { this.rangeBarSum1, this.rangeBarSum2 })
      {
        rb.SetRangeLimit(0, 90);
        rb.SelectRange(0, 90);
        rb.TotalMinimum = 0;
        rb.TotalMaximum = 90;
        rb.RangeMinimum = 0;
        rb.RangeMaximum = 90;
        rb.DivisionNum = 45;
      }
      //
      InitSkillCombos();
      //
      Generator.GenerateColumns(this.folvTM, typeof(Objects.TransferListedPlayer));
      //
      this.ucEvaluatePlayer.EvaluationType = Evaluation.season30;
      this.ucEvaluatePlayer.IsHeightWeightImpact = true;
    }

    void InitSkillCombos ( )
    {
      this.scb24 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      this.scb23 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      this.scb22 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      this.scb21 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      // 
      // scb24
      // 
      this.scb24.FormattingEnabled = true;
      this.scb24.Location = new System.Drawing.Point(158, 47);
      this.scb24.Name = "scb24";
      this.scb24.Size = new System.Drawing.Size(139, 21);
      this.scb24.TabIndex = 34;
      // 
      // scb23
      // 
      this.scb23.FormattingEnabled = true;
      this.scb23.Location = new System.Drawing.Point(7, 47);
      this.scb23.Name = "scb23";
      this.scb23.Size = new System.Drawing.Size(139, 21);
      this.scb23.TabIndex = 33;
      // 
      // scb22
      // 
      this.scb22.FormattingEnabled = true;
      this.scb22.Location = new System.Drawing.Point(158, 20);
      this.scb22.Name = "scb22";
      this.scb22.Size = new System.Drawing.Size(139, 21);
      this.scb22.TabIndex = 32;
      // 
      // scb21
      // 
      this.scb21.FormattingEnabled = true;
      this.scb21.Location = new System.Drawing.Point(7, 20);
      this.scb21.Name = "scb21";
      this.scb21.Size = new System.Drawing.Size(139, 21);
      this.scb21.TabIndex = 31;
      //
      this.gbx2.Controls.Add(this.scb24);
      this.gbx2.Controls.Add(this.scb23);
      this.gbx2.Controls.Add(this.scb22);
      this.gbx2.Controls.Add(this.scb21);
      //
      this.scb14 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      this.scb13 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      this.scb12 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      this.scb11 = new AndreiPopescu.CharazayPlus.UI.SkillComboBox();
      //
      this.gbx1.Controls.Add(this.scb14);
      this.gbx1.Controls.Add(this.scb13);
      this.gbx1.Controls.Add(this.scb12);
      this.gbx1.Controls.Add(this.scb11);
      //
      // 
      // scb14
      // 
      this.scb14.FormattingEnabled = true;
      this.scb14.Location = new System.Drawing.Point(158, 47);
      this.scb14.Name = "scb14";
      this.scb14.Size = new System.Drawing.Size(139, 21);
      this.scb14.TabIndex = 34;
      // 
      // scb13
      // 
      this.scb13.FormattingEnabled = true;
      this.scb13.Location = new System.Drawing.Point(7, 47);
      this.scb13.Name = "scb13";
      this.scb13.Size = new System.Drawing.Size(139, 21);
      this.scb13.TabIndex = 33;
      // 
      // scb12
      //
      this.scb12.FormattingEnabled = true;
      this.scb12.Location = new System.Drawing.Point(158, 20);
      this.scb12.Name = "scb12";
      this.scb12.Size = new System.Drawing.Size(139, 21);
      this.scb12.TabIndex = 32;
      // 
      // scb11
      // 
      this.scb11.FormattingEnabled = true;
      this.scb11.Location = new System.Drawing.Point(7, 20);
      this.scb11.Name = "scb11";
      this.scb11.Size = new System.Drawing.Size(139, 21);
      this.scb11.TabIndex = 31;
    }

    public ImageList ImageListCountries { get; set; } 
    #endregion

    #region utility
    T? GetTextBoxValue<T> (TextBox tb) where T : struct
    {
      try
      {
        if (string.IsNullOrWhiteSpace(tb.Text))
          return null;
        else
          return (T)Convert.ChangeType(tb.Text, typeof(T));
      }
      catch
      {
        return null;
      }

    }

    byte? GetRangeMin (RangeBar rb, int defaultValueMin)
    {
      if (rb.RangeMinimum != defaultValueMin)
        return (byte)rb.RangeMinimum;
      else return null;
    }

    byte? GetRangeMax (RangeBar rb, int defaultValueMax)
    {
      if (rb.RangeMaximum != defaultValueMax)
        return (byte)rb.RangeMaximum;
      else return null;

    }

    /// <summary>
    /// 
    /// </summary>
    private void GetXmlApiPlayer ( )
    {
      Objects.TransferListedPlayer tlp = (Objects.TransferListedPlayer)this.folvTM.SelectedObject;
      if (tlp == null) return;
      //
      Xsd2.error err = null;
      var xsdp = Utils.Deserializer.GoGetPlayerXml(tlp.PlayerId, out err);
      if (PlayerError != null && err != null)
        PlayerError(this, new PlayerEventArgs() { ErrorMessage = err.message });
      else if (DownloadPlayerData != null)
        DownloadPlayerData(null, new PlayerEventArgs() { Surname = xsdp.basic.surname, Name = xsdp.basic.name });
      //
      this.ucEvaluatePlayer.SelectedObject = xsdp;

      if (xsdp.skills == null)
      {
        //throw new Exception("player has no skills");
        this.ucBasicPlayer.Init();
        this.btnShortlist.Enabled = false;
      }
      else
      {
        this.ucBasicPlayer.CurrentPrice = tlp.CurrentPrice;
        //
        var evaluatedPlayers = this.ucEvaluatePlayer.GetPlayers().ToArray();
        var top2facets = TrainingEfficiencyCalculator.TopN(evaluatedPlayers, 2).ToArray();
        _playerFacets = FacetsDeduction(top2facets[0], top2facets[1]).ToArray();
        //        
        this.ucBasicPlayer.Init(
          //Player.DecideOnTotalScore(evaluatedPlayers)
          _playerFacets[0]
          , this.ImageListCountries);
        //
        this.btnShortlist.Enabled = true;
      }
    } 

    /// <summary>
    /// Best position for a player, called on shortlist
    /// taller player may qualify for smaller position
    /// </summary>
    private IEnumerable<Player> DecideCourtPosition ()
    { //
      var futurePositions = _playerFacets[0].FuturePositionsHeightBased.Distinct().ToArray();
      //
      if (_playerFacets.Length == 1)
      { //
        // strong indicator for that pos, as skillset is concerned
        // a single court position for the current player
        //
        if (futurePositions.Contains(_playerFacets[0].PositionEnum))
          yield return _playerFacets[0];
        else
        { //
          // current player facet is not a future viable position
          // for instance facet is C and future positions are PG, SG, SF
          // or facet is PF and future positions are PG, SG
          // or facet is PG and future position is SF
          //
          foreach (var p in FrontBackCourtDeduction(futurePositions))
            yield return p;
        }
      }
      else
      { //
        // multiple positions returned
        //
        bool is1 = futurePositions.Contains(_playerFacets[0].PositionEnum);
        bool is2 = futurePositions.Contains(_playerFacets[1].PositionEnum);
        if (is1 || is2)
        { // 
          // pinpoint positions from score & value index as most relevant
          //
          if (is1) yield return _playerFacets[0];
          if (is2) yield return _playerFacets[1];
        }
        else
        { //
          // no facets inside the contiguous future positions zone, e.g.
          // future position PG, facets SF, PF
          // future positions PF, C facet PG, SF
          // future positions SG,SF,PF facets PG, C
          //
          foreach (var p in FrontBackCourtDeduction(futurePositions))
            yield return p;          
        }

      }
    }

    private IEnumerable<Player> FrontBackCourtDeduction (IEnumerable <PlayerPosition> futureCourtPositions)
    {
      var allPositions = _playerFacets.Select(facet => facet.PositionEnum).Union(futureCourtPositions).ToList();
      var min = allPositions.Min();
      var max = allPositions.Max();
      foreach (var pos in (PlayerPosition[])Enum.GetValues(typeof(PlayerPosition)))
      {
        if (pos >= min && pos <= max)
        {
          yield return Deserializer.GetPlayerFromIdAndPosition(_playerFacets[0].Id, pos, Evaluation.season30);
        }
      }
      
      //if (_playerFacets[idx].PositionEnum < ppmin)
      //  //score for backcourt, height for frontcourt
      //  return _playerFacets[0];                      
      //else if (_playerFacets[0].PositionEnum > ppmax)
      //  // score for frontcourt, height for backcourt
      //  return Deserializer.GetPlayerFromIdAndPosition(_playerFacets[0].Id, ppmax, Evaluation.season30);
      //else
      //  throw new Exception("FrontBackCourtDeduction");
    }
     

    /// <summary>
    /// infers possible facets for a player, maximum 2 court positions
    /// </summary>
    /// <param name="p1">best player facet by score</param>
    /// <param name="p2">2nd best player facet by score</param>
    /// <returns>all player facets</returns>
    IEnumerable <Player> FacetsDeduction (Player p1, Player p2)
    {
      if (p1.Id != p2.Id)
        throw new ArgumentException("Facets of the same player");

      double div = p1.ValueIndex / p2.ValueIndex;
      if (div < 0.94)
      {
        yield return p2;
      }
      else if (div > 1.05)
      {
        yield return p1;
      }
      else
      {
        yield return p1;
        yield return p2;
      }

    }

    
    #endregion

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
      this.split1 = new System.Windows.Forms.SplitContainer();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnSearch = new System.Windows.Forms.Button();
      this.gbx2 = new System.Windows.Forms.GroupBox();
      this.rangeBarSum2 = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.label16 = new System.Windows.Forms.Label();
      this.tbSiH = new System.Windows.Forms.TextBox();
      this.tbSiL = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbPriceH = new System.Windows.Forms.TextBox();
      this.tbPriceL = new System.Windows.Forms.TextBox();
      this.rangeBarReb = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarExp = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarPas = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarSpe = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarFtw = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBar2p = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBar3p = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarDrib = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarHeight = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarDef = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarFT = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.rangeBarAge = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.gbx1 = new System.Windows.Forms.GroupBox();
      this.rangeBarSum1 = new AndreiPopescu.CharazayPlus.UI.RangeBar();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btnShortlist = new System.Windows.Forms.Button();
      this.ucBasicPlayer = new AndreiPopescu.CharazayPlus.UI.BasicPlayerUserControl();
      this.ucEvaluatePlayer = new AndreiPopescu.CharazayPlus.UI.EvaluatePlayerUserControl();
      this.folvTM = new BrightIdeasSoftware.FastObjectListView();
      ((System.ComponentModel.ISupportInitialize)(this.split1)).BeginInit();
      this.split1.Panel1.SuspendLayout();
      this.split1.Panel2.SuspendLayout();
      this.split1.SuspendLayout();
      this.gbx2.SuspendLayout();
      this.gbx1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.folvTM)).BeginInit();
      this.SuspendLayout();
      // 
      // split1
      // 
      this.split1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.split1.IsSplitterFixed = true;
      this.split1.Location = new System.Drawing.Point(0, 0);
      this.split1.Name = "split1";
      // 
      // split1.Panel1
      // 
      this.split1.Panel1.Controls.Add(this.btnReset);
      this.split1.Panel1.Controls.Add(this.btnSearch);
      this.split1.Panel1.Controls.Add(this.gbx2);
      this.split1.Panel1.Controls.Add(this.label16);
      this.split1.Panel1.Controls.Add(this.tbSiH);
      this.split1.Panel1.Controls.Add(this.tbSiL);
      this.split1.Panel1.Controls.Add(this.label2);
      this.split1.Panel1.Controls.Add(this.tbPriceH);
      this.split1.Panel1.Controls.Add(this.tbPriceL);
      this.split1.Panel1.Controls.Add(this.rangeBarReb);
      this.split1.Panel1.Controls.Add(this.rangeBarExp);
      this.split1.Panel1.Controls.Add(this.rangeBarPas);
      this.split1.Panel1.Controls.Add(this.rangeBarSpe);
      this.split1.Panel1.Controls.Add(this.rangeBarFtw);
      this.split1.Panel1.Controls.Add(this.rangeBar2p);
      this.split1.Panel1.Controls.Add(this.rangeBar3p);
      this.split1.Panel1.Controls.Add(this.rangeBarDrib);
      this.split1.Panel1.Controls.Add(this.rangeBarHeight);
      this.split1.Panel1.Controls.Add(this.rangeBarDef);
      this.split1.Panel1.Controls.Add(this.rangeBarFT);
      this.split1.Panel1.Controls.Add(this.rangeBarAge);
      this.split1.Panel1.Controls.Add(this.gbx1);
      this.split1.Panel1.Controls.Add(this.label11);
      this.split1.Panel1.Controls.Add(this.label12);
      this.split1.Panel1.Controls.Add(this.label13);
      this.split1.Panel1.Controls.Add(this.label14);
      this.split1.Panel1.Controls.Add(this.label15);
      this.split1.Panel1.Controls.Add(this.label6);
      this.split1.Panel1.Controls.Add(this.label7);
      this.split1.Panel1.Controls.Add(this.label8);
      this.split1.Panel1.Controls.Add(this.label9);
      this.split1.Panel1.Controls.Add(this.label10);
      this.split1.Panel1.Controls.Add(this.label5);
      this.split1.Panel1.Controls.Add(this.label4);
      this.split1.Panel1.Controls.Add(this.label3);
      this.split1.Panel1.Controls.Add(this.label1);
      this.split1.Panel1.DoubleClick += new System.EventHandler(this.split1_Panel1_DoubleClick);
      // 
      // split1.Panel2
      // 
      this.split1.Panel2.Controls.Add(this.btnShortlist);
      this.split1.Panel2.Controls.Add(this.ucBasicPlayer);
      this.split1.Panel2.Controls.Add(this.ucEvaluatePlayer);
      this.split1.Panel2.Controls.Add(this.folvTM);
      this.split1.Panel2.DoubleClick += new System.EventHandler(this.split1_Panel2_DoubleClick);
      this.split1.Size = new System.Drawing.Size(993, 903);
      this.split1.SplitterDistance = 301;
      this.split1.TabIndex = 0;
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(10, 808);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(288, 23);
      this.btnReset.TabIndex = 40;
      this.btnReset.Text = "Reset search parameters";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnSearch.Location = new System.Drawing.Point(11, 840);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(287, 59);
      this.btnSearch.TabIndex = 38;
      this.btnSearch.Text = "Search now!";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // gbx2
      // 
      this.gbx2.Controls.Add(this.rangeBarSum2);
      this.gbx2.Location = new System.Drawing.Point(4, 680);
      this.gbx2.Name = "gbx2";
      this.gbx2.Size = new System.Drawing.Size(303, 121);
      this.gbx2.TabIndex = 37;
      this.gbx2.TabStop = false;
      this.gbx2.Text = "Second sum";
      // 
      // rangeBarSum2
      // 
      this.rangeBarSum2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarSum2.BackColor = System.Drawing.Color.Lavender;
      this.rangeBarSum2.DivisionNum = 25;
      this.rangeBarSum2.HeightOfBar = 13;
      this.rangeBarSum2.HeightOfMark = 16;
      this.rangeBarSum2.HeightOfTick = 1;
      this.rangeBarSum2.InnerColor = System.Drawing.Color.OrangeRed;
      this.rangeBarSum2.Location = new System.Drawing.Point(7, 74);
      this.rangeBarSum2.Name = "rangeBarSum2";
      this.rangeBarSum2.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarSum2.RangeMaximum = 10;
      this.rangeBarSum2.RangeMinimum = 0;
      this.rangeBarSum2.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarSum2.Size = new System.Drawing.Size(290, 40);
      this.rangeBarSum2.TabIndex = 30;
      this.rangeBarSum2.TotalMaximum = 90;
      this.rangeBarSum2.TotalMinimum = 0;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(183, 47);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(10, 13);
      this.label16.TabIndex = 36;
      this.label16.Text = "-";
      // 
      // tbSiH
      // 
      this.tbSiH.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tbSiH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbSiH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbSiH.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tbSiH.Location = new System.Drawing.Point(199, 41);
      this.tbSiH.Name = "tbSiH";
      this.tbSiH.Size = new System.Drawing.Size(107, 20);
      this.tbSiH.TabIndex = 35;
      // 
      // tbSiL
      // 
      this.tbSiL.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tbSiL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbSiL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbSiL.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tbSiL.Location = new System.Drawing.Point(68, 41);
      this.tbSiL.Name = "tbSiL";
      this.tbSiL.Size = new System.Drawing.Size(109, 20);
      this.tbSiL.TabIndex = 34;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(183, 21);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(10, 13);
      this.label2.TabIndex = 33;
      this.label2.Text = "-";
      // 
      // tbPriceH
      // 
      this.tbPriceH.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tbPriceH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbPriceH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbPriceH.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tbPriceH.Location = new System.Drawing.Point(199, 15);
      this.tbPriceH.Name = "tbPriceH";
      this.tbPriceH.Size = new System.Drawing.Size(107, 20);
      this.tbPriceH.TabIndex = 32;
      // 
      // tbPriceL
      // 
      this.tbPriceL.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tbPriceL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbPriceL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.tbPriceL.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tbPriceL.Location = new System.Drawing.Point(68, 15);
      this.tbPriceL.Name = "tbPriceL";
      this.tbPriceL.Size = new System.Drawing.Size(109, 20);
      this.tbPriceL.TabIndex = 31;
      // 
      // rangeBarReb
      // 
      this.rangeBarReb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarReb.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarReb.DivisionNum = 10;
      this.rangeBarReb.HeightOfBar = 13;
      this.rangeBarReb.HeightOfMark = 16;
      this.rangeBarReb.HeightOfTick = 1;
      this.rangeBarReb.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarReb.Location = new System.Drawing.Point(68, 467);
      this.rangeBarReb.Name = "rangeBarReb";
      this.rangeBarReb.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarReb.RangeMaximum = 5;
      this.rangeBarReb.RangeMinimum = 3;
      this.rangeBarReb.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarReb.Size = new System.Drawing.Size(238, 40);
      this.rangeBarReb.TabIndex = 30;
      this.rangeBarReb.TotalMaximum = 10;
      this.rangeBarReb.TotalMinimum = 0;
      // 
      // rangeBarExp
      // 
      this.rangeBarExp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarExp.BackColor = System.Drawing.Color.Gainsboro;
      this.rangeBarExp.DivisionNum = 10;
      this.rangeBarExp.HeightOfBar = 13;
      this.rangeBarExp.HeightOfMark = 16;
      this.rangeBarExp.HeightOfTick = 1;
      this.rangeBarExp.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarExp.Location = new System.Drawing.Point(68, 507);
      this.rangeBarExp.Name = "rangeBarExp";
      this.rangeBarExp.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarExp.RangeMaximum = 5;
      this.rangeBarExp.RangeMinimum = 3;
      this.rangeBarExp.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarExp.Size = new System.Drawing.Size(238, 40);
      this.rangeBarExp.TabIndex = 29;
      this.rangeBarExp.TotalMaximum = 10;
      this.rangeBarExp.TotalMinimum = 0;
      // 
      // rangeBarPas
      // 
      this.rangeBarPas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarPas.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarPas.DivisionNum = 10;
      this.rangeBarPas.HeightOfBar = 13;
      this.rangeBarPas.HeightOfMark = 16;
      this.rangeBarPas.HeightOfTick = 1;
      this.rangeBarPas.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarPas.Location = new System.Drawing.Point(68, 347);
      this.rangeBarPas.Name = "rangeBarPas";
      this.rangeBarPas.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarPas.RangeMaximum = 5;
      this.rangeBarPas.RangeMinimum = 3;
      this.rangeBarPas.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarPas.Size = new System.Drawing.Size(238, 40);
      this.rangeBarPas.TabIndex = 28;
      this.rangeBarPas.TotalMaximum = 10;
      this.rangeBarPas.TotalMinimum = 0;
      // 
      // rangeBarSpe
      // 
      this.rangeBarSpe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarSpe.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarSpe.DivisionNum = 10;
      this.rangeBarSpe.HeightOfBar = 13;
      this.rangeBarSpe.HeightOfMark = 16;
      this.rangeBarSpe.HeightOfTick = 1;
      this.rangeBarSpe.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarSpe.Location = new System.Drawing.Point(68, 387);
      this.rangeBarSpe.Name = "rangeBarSpe";
      this.rangeBarSpe.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarSpe.RangeMaximum = 5;
      this.rangeBarSpe.RangeMinimum = 3;
      this.rangeBarSpe.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarSpe.Size = new System.Drawing.Size(238, 40);
      this.rangeBarSpe.TabIndex = 27;
      this.rangeBarSpe.TotalMaximum = 10;
      this.rangeBarSpe.TotalMinimum = 0;
      // 
      // rangeBarFtw
      // 
      this.rangeBarFtw.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarFtw.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarFtw.DivisionNum = 10;
      this.rangeBarFtw.HeightOfBar = 13;
      this.rangeBarFtw.HeightOfMark = 16;
      this.rangeBarFtw.HeightOfTick = 1;
      this.rangeBarFtw.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarFtw.Location = new System.Drawing.Point(68, 427);
      this.rangeBarFtw.Name = "rangeBarFtw";
      this.rangeBarFtw.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarFtw.RangeMaximum = 5;
      this.rangeBarFtw.RangeMinimum = 3;
      this.rangeBarFtw.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarFtw.Size = new System.Drawing.Size(238, 40);
      this.rangeBarFtw.TabIndex = 26;
      this.rangeBarFtw.TotalMaximum = 10;
      this.rangeBarFtw.TotalMinimum = 0;
      // 
      // rangeBar2p
      // 
      this.rangeBar2p.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBar2p.BackColor = System.Drawing.SystemColors.Control;
      this.rangeBar2p.DivisionNum = 10;
      this.rangeBar2p.HeightOfBar = 13;
      this.rangeBar2p.HeightOfMark = 16;
      this.rangeBar2p.HeightOfTick = 1;
      this.rangeBar2p.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBar2p.Location = new System.Drawing.Point(68, 227);
      this.rangeBar2p.Name = "rangeBar2p";
      this.rangeBar2p.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBar2p.RangeMaximum = 5;
      this.rangeBar2p.RangeMinimum = 3;
      this.rangeBar2p.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBar2p.Size = new System.Drawing.Size(238, 40);
      this.rangeBar2p.TabIndex = 25;
      this.rangeBar2p.TotalMaximum = 10;
      this.rangeBar2p.TotalMinimum = 0;
      // 
      // rangeBar3p
      // 
      this.rangeBar3p.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBar3p.BackColor = System.Drawing.SystemColors.Control;
      this.rangeBar3p.DivisionNum = 10;
      this.rangeBar3p.HeightOfBar = 13;
      this.rangeBar3p.HeightOfMark = 16;
      this.rangeBar3p.HeightOfTick = 1;
      this.rangeBar3p.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBar3p.Location = new System.Drawing.Point(68, 267);
      this.rangeBar3p.Name = "rangeBar3p";
      this.rangeBar3p.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBar3p.RangeMaximum = 5;
      this.rangeBar3p.RangeMinimum = 3;
      this.rangeBar3p.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBar3p.Size = new System.Drawing.Size(238, 40);
      this.rangeBar3p.TabIndex = 24;
      this.rangeBar3p.TotalMaximum = 10;
      this.rangeBar3p.TotalMinimum = 0;
      // 
      // rangeBarDrib
      // 
      this.rangeBarDrib.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarDrib.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarDrib.DivisionNum = 10;
      this.rangeBarDrib.HeightOfBar = 13;
      this.rangeBarDrib.HeightOfMark = 16;
      this.rangeBarDrib.HeightOfTick = 1;
      this.rangeBarDrib.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarDrib.Location = new System.Drawing.Point(68, 307);
      this.rangeBarDrib.Name = "rangeBarDrib";
      this.rangeBarDrib.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarDrib.RangeMaximum = 5;
      this.rangeBarDrib.RangeMinimum = 3;
      this.rangeBarDrib.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarDrib.Size = new System.Drawing.Size(238, 40);
      this.rangeBarDrib.TabIndex = 23;
      this.rangeBarDrib.TotalMaximum = 10;
      this.rangeBarDrib.TotalMinimum = 0;
      // 
      // rangeBarHeight
      // 
      this.rangeBarHeight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarHeight.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarHeight.DivisionNum = 10;
      this.rangeBarHeight.HeightOfBar = 13;
      this.rangeBarHeight.HeightOfMark = 16;
      this.rangeBarHeight.HeightOfTick = 1;
      this.rangeBarHeight.InnerColor = System.Drawing.Color.Red;
      this.rangeBarHeight.Location = new System.Drawing.Point(68, 107);
      this.rangeBarHeight.Name = "rangeBarHeight";
      this.rangeBarHeight.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarHeight.RangeMaximum = 5;
      this.rangeBarHeight.RangeMinimum = 3;
      this.rangeBarHeight.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarHeight.Size = new System.Drawing.Size(238, 40);
      this.rangeBarHeight.TabIndex = 22;
      this.rangeBarHeight.TotalMaximum = 10;
      this.rangeBarHeight.TotalMinimum = 0;
      // 
      // rangeBarDef
      // 
      this.rangeBarDef.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarDef.BackColor = System.Drawing.Color.Gainsboro;
      this.rangeBarDef.DivisionNum = 10;
      this.rangeBarDef.HeightOfBar = 13;
      this.rangeBarDef.HeightOfMark = 16;
      this.rangeBarDef.HeightOfTick = 1;
      this.rangeBarDef.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarDef.Location = new System.Drawing.Point(68, 147);
      this.rangeBarDef.Name = "rangeBarDef";
      this.rangeBarDef.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarDef.RangeMaximum = 5;
      this.rangeBarDef.RangeMinimum = 3;
      this.rangeBarDef.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarDef.Size = new System.Drawing.Size(238, 40);
      this.rangeBarDef.TabIndex = 21;
      this.rangeBarDef.TotalMaximum = 10;
      this.rangeBarDef.TotalMinimum = 0;
      // 
      // rangeBarFT
      // 
      this.rangeBarFT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarFT.BackColor = System.Drawing.SystemColors.Control;
      this.rangeBarFT.DivisionNum = 10;
      this.rangeBarFT.HeightOfBar = 13;
      this.rangeBarFT.HeightOfMark = 16;
      this.rangeBarFT.HeightOfTick = 1;
      this.rangeBarFT.InnerColor = System.Drawing.Color.Tomato;
      this.rangeBarFT.Location = new System.Drawing.Point(68, 187);
      this.rangeBarFT.Name = "rangeBarFT";
      this.rangeBarFT.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarFT.RangeMaximum = 5;
      this.rangeBarFT.RangeMinimum = 3;
      this.rangeBarFT.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarFT.Size = new System.Drawing.Size(238, 40);
      this.rangeBarFT.TabIndex = 20;
      this.rangeBarFT.TotalMaximum = 10;
      this.rangeBarFT.TotalMinimum = 0;
      // 
      // rangeBarAge
      // 
      this.rangeBarAge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarAge.BackColor = System.Drawing.Color.WhiteSmoke;
      this.rangeBarAge.DivisionNum = 10;
      this.rangeBarAge.HeightOfBar = 13;
      this.rangeBarAge.HeightOfMark = 16;
      this.rangeBarAge.HeightOfTick = 1;
      this.rangeBarAge.InnerColor = System.Drawing.Color.Red;
      this.rangeBarAge.Location = new System.Drawing.Point(68, 67);
      this.rangeBarAge.Name = "rangeBarAge";
      this.rangeBarAge.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarAge.RangeMaximum = 5;
      this.rangeBarAge.RangeMinimum = 3;
      this.rangeBarAge.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarAge.Size = new System.Drawing.Size(238, 40);
      this.rangeBarAge.TabIndex = 17;
      this.rangeBarAge.TotalMaximum = 10;
      this.rangeBarAge.TotalMinimum = 0;
      // 
      // gbx1
      // 
      this.gbx1.Controls.Add(this.rangeBarSum1);
      this.gbx1.Location = new System.Drawing.Point(3, 553);
      this.gbx1.Name = "gbx1";
      this.gbx1.Size = new System.Drawing.Size(303, 121);
      this.gbx1.TabIndex = 15;
      this.gbx1.TabStop = false;
      this.gbx1.Text = "First sum";
      // 
      // rangeBarSum1
      // 
      this.rangeBarSum1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.rangeBarSum1.BackColor = System.Drawing.Color.Lavender;
      this.rangeBarSum1.DivisionNum = 25;
      this.rangeBarSum1.HeightOfBar = 13;
      this.rangeBarSum1.HeightOfMark = 16;
      this.rangeBarSum1.HeightOfTick = 1;
      this.rangeBarSum1.InnerColor = System.Drawing.Color.OrangeRed;
      this.rangeBarSum1.Location = new System.Drawing.Point(7, 74);
      this.rangeBarSum1.Name = "rangeBarSum1";
      this.rangeBarSum1.Orientation = AndreiPopescu.CharazayPlus.UI.RangeBar.RangeBarOrientation.horizontal;
      this.rangeBarSum1.RangeMaximum = 10;
      this.rangeBarSum1.RangeMinimum = 0;
      this.rangeBarSum1.ScaleOrientation = AndreiPopescu.CharazayPlus.UI.RangeBar.TopBottomOrientation.bottom;
      this.rangeBarSum1.Size = new System.Drawing.Size(290, 40);
      this.rangeBarSum1.TabIndex = 30;
      this.rangeBarSum1.TotalMaximum = 90;
      this.rangeBarSum1.TotalMinimum = 0;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(23, 400);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(38, 13);
      this.label11.TabIndex = 14;
      this.label11.Text = "Speed";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(12, 439);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(51, 13);
      this.label12.TabIndex = 13;
      this.label12.Text = "Footwork";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(5, 478);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(56, 13);
      this.label13.TabIndex = 12;
      this.label13.Text = "Rebounds";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(3, 519);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(60, 13);
      this.label14.TabIndex = 11;
      this.label14.Text = "Experience";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(17, 360);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(44, 13);
      this.label15.TabIndex = 10;
      this.label15.Text = "Passing";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(4, 199);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(57, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "Free throw";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(20, 239);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(36, 13);
      this.label7.TabIndex = 8;
      this.label7.Text = "2point";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(25, 280);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(36, 13);
      this.label8.TabIndex = 7;
      this.label8.Text = "3point";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(8, 319);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(48, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "Dribbling";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(15, 158);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(48, 13);
      this.label10.TabIndex = 5;
      this.label10.Text = "Defence";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(4, 44);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(59, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Skills index";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(35, 79);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(26, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Age";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(23, 120);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Height";
      // 
      // _lblTitle
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 15);
      this.label1.Name = "_lblTitle";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Price";
      // 
      // btnShortlist
      // 
      this.btnShortlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnShortlist.BackColor = System.Drawing.SystemColors.ControlLight;
      this.btnShortlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnShortlist.ForeColor = System.Drawing.Color.DimGray;
      this.btnShortlist.Location = new System.Drawing.Point(474, 621);
      this.btnShortlist.Name = "btnShortlist";
      this.btnShortlist.Size = new System.Drawing.Size(210, 40);
      this.btnShortlist.TabIndex = 45;
      this.btnShortlist.Text = "Shortlist !";
      this.btnShortlist.UseVisualStyleBackColor = false;
      this.btnShortlist.Click += new System.EventHandler(this.btnShortlist_Click);
      // 
      // ucBasicPlayer
      // 
      this.ucBasicPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ucBasicPlayer.Location = new System.Drawing.Point(474, 7);
      this.ucBasicPlayer.Name = "ucBasicPlayer";
      this.ucBasicPlayer.Size = new System.Drawing.Size(210, 608);
      this.ucBasicPlayer.TabIndex = 2;
      // 
      // ucEvaluatePlayer
      // 
      this.ucEvaluatePlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ucEvaluatePlayer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ucEvaluatePlayer.BackColor = System.Drawing.Color.DimGray;
      this.ucEvaluatePlayer.CausesValidation = false;
      this.ucEvaluatePlayer.ForeColor = System.Drawing.Color.White;
      this.ucEvaluatePlayer.IsFatigue = false;
      this.ucEvaluatePlayer.IsForm = false;
      this.ucEvaluatePlayer.IsHeightWeightImpact = false;
      this.ucEvaluatePlayer.Location = new System.Drawing.Point(3, 764);
      this.ucEvaluatePlayer.Name = "ucEvaluatePlayer";
      this.ucEvaluatePlayer.SelectedObject = null;
      this.ucEvaluatePlayer.Size = new System.Drawing.Size(681, 135);
      this.ucEvaluatePlayer.TabIndex = 1;
      // 
      // folvTM
      // 
      this.folvTM.AlternateRowBackColor = System.Drawing.Color.Gainsboro;
      this.folvTM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.folvTM.BackColor = System.Drawing.Color.LightGray;
      this.folvTM.FullRowSelect = true;
      this.folvTM.HighlightBackgroundColor = System.Drawing.Color.Black;
      this.folvTM.HighlightForegroundColor = System.Drawing.Color.White;
      this.folvTM.Location = new System.Drawing.Point(3, 5);
      this.folvTM.MultiSelect = false;
      this.folvTM.Name = "folvTM";
      this.folvTM.ShowGroups = false;
      this.folvTM.Size = new System.Drawing.Size(465, 753);
      this.folvTM.TabIndex = 0;
      this.folvTM.UseAlternatingBackColors = true;
      this.folvTM.UseCompatibleStateImageBehavior = false;
      this.folvTM.UseHotItem = true;
      this.folvTM.UseHyperlinks = true;
      this.folvTM.UseTranslucentHotItem = true;
      this.folvTM.UseTranslucentSelection = true;
      this.folvTM.View = System.Windows.Forms.View.Details;
      this.folvTM.VirtualMode = true;
      this.folvTM.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.folvTM_HyperlinkClicked);
      this.folvTM.SelectionChanged += new System.EventHandler(this.folvTM_SelectionChanged);
      // 
      // SearchTMUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.split1);
      this.Name = "SearchTMUserControl";
      this.Size = new System.Drawing.Size(993, 903);
      this.Load += new System.EventHandler(this.SearchTMUserControl_Load);
      this.split1.Panel1.ResumeLayout(false);
      this.split1.Panel1.PerformLayout();
      this.split1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.split1)).EndInit();
      this.split1.ResumeLayout(false);
      this.gbx2.ResumeLayout(false);
      this.gbx1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.folvTM)).EndInit();
      this.ResumeLayout(false);

    }

    private Button btnShortlist;
    private Button btnReset;

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

    #endregion

    #region contained controls
    private Button btnSearch;
    private BasicPlayerUserControl ucBasicPlayer;
    private EvaluatePlayerUserControl ucEvaluatePlayer;
    private System.Windows.Forms.SplitContainer split1;
    private BrightIdeasSoftware.FastObjectListView folvTM;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.GroupBox gbx1;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private RangeBar rangeBarAge;
    private RangeBar rangeBarReb;
    private RangeBar rangeBarExp;
    private RangeBar rangeBarPas;
    private RangeBar rangeBarSpe;
    private RangeBar rangeBarFtw;
    private RangeBar rangeBar2p;
    private RangeBar rangeBar3p;
    private RangeBar rangeBarDrib;
    private RangeBar rangeBarHeight;
    private RangeBar rangeBarDef;
    private RangeBar rangeBarFT;
    private RangeBar rangeBarSum1;
    private Label label16;
    private TextBox tbSiH;
    private TextBox tbSiL;
    private Label label2;
    private TextBox tbPriceH;
    private TextBox tbPriceL;
    private GroupBox gbx2;
    private SkillComboBox scb24;
    private SkillComboBox scb23;
    private SkillComboBox scb22;
    private SkillComboBox scb21;
    private RangeBar rangeBarSum2;
    private SkillComboBox scb14;
    private SkillComboBox scb13;
    private SkillComboBox scb12;
    private SkillComboBox scb11; 
    #endregion

    #region local event handlers
    private void btnSearch_Click (object sender, EventArgs e)
    {
      Extensions.FormsExtensions.SetWaitCursor( ( ) => {
          var uri = Web.CharazayDownloadItem.ConstructUri(true,                     //isTransferMarket
            null,                                                                   //byte? countryId
            GetTextBoxValue<uint>(this.tbPriceL),                                   //, uint? price_l
            GetTextBoxValue<uint>(this.tbPriceH),                                   //uint? price_h
            GetTextBoxValue<uint>(this.tbSiL),                                      //uint? value_l
            GetTextBoxValue<uint>(this.tbSiH),                                      //uint? value_h
            GetRangeMin(this.rangeBarAge, 15),                                      //byte? age_l, 
            GetRangeMax(this.rangeBarAge, 40),                                      //byte? age_h
            GetRangeMin(this.rangeBarHeight, 160),                                  //byte? height_l
            GetRangeMax(this.rangeBarHeight, 230),                                  //, byte? height_h
            GetRangeMin(this.rangeBarDef, 0), GetRangeMax(this.rangeBarDef, 30),    //byte? defence_l, byte? defence_h
            GetRangeMin(this.rangeBarFT, 0), GetRangeMax(this.rangeBarFT, 30),      //byte? ft_l, byte? ft_h
            GetRangeMin(this.rangeBar2p, 0), GetRangeMax(this.rangeBar2p, 30),      //byte? tpt_l, byte? tpt_h
            GetRangeMin(this.rangeBar3p, 0), GetRangeMax(this.rangeBar3p, 30),      //byte? thpt_l, byte? thpt_h
            GetRangeMin(this.rangeBarDrib, 0), GetRangeMax(this.rangeBarDrib, 30),  //byte? dribbling_l, byte? dribbling_h
            GetRangeMin(this.rangeBarPas, 0), GetRangeMax(this.rangeBarPas, 30),    //byte? passing_l, byte? passing_h
            GetRangeMin(this.rangeBarSpe, 0), GetRangeMax(this.rangeBarSpe, 30),    //byte? speed_l, byte? speed_h
            GetRangeMin(this.rangeBarFtw, 0), GetRangeMax(this.rangeBarFtw, 30),    //byte? footwork_l, byte? footwork_h
            GetRangeMin(this.rangeBarReb, 0), GetRangeMax(this.rangeBarReb, 30),    //byte? rebound_l, byte? rebound_h
            GetRangeMin(this.rangeBarExp, 0), GetRangeMax(this.rangeBarExp, 30),    //byte? experience_l, byte? experience_h
            (byte)(TransferListSkill)this.scb11.SelectedValue,                      //byte skill1a
            (byte)(TransferListSkill)this.scb12.SelectedValue,                      //byte skill1b
            (byte)(TransferListSkill)this.scb13.SelectedValue,                      //byte skill1c
            (byte)(TransferListSkill)this.scb14.SelectedValue,                      //byte skill1d           
            GetRangeMin(this.rangeBarSum1, 0), GetRangeMax(this.rangeBarSum1, 30),  //byte? skill1_l, byte? skill1_h
            (byte)(TransferListSkill)this.scb21.SelectedValue,                      //, byte skill2a,  
            (byte)(TransferListSkill)this.scb22.SelectedValue,                      //byte skill2b, ,
            (byte)(TransferListSkill)this.scb23.SelectedValue,                      //byte skill2c, 
            (byte)(TransferListSkill)this.scb24.SelectedValue,                      //byte skill2d
            GetRangeMin(this.rangeBarSum2, 0), GetRangeMax(this.rangeBarSum2, 30),  //byte? skill2_l, byte? skill2_h
            true                                                                    //bool isClassicView
          );

          var tlps = Web.Scraper.Instance.ClassicTransferMarket(uri).ToList();
          this.folvTM.SetObjects(tlps);
        } );

    }

    void folvTM_HyperlinkClicked (object sender, HyperlinkClickedEventArgs e)
    {

      Objects.TransferListedPlayer tlPlayer = (Objects.TransferListedPlayer)e.Item.RowObject;
      if (tlPlayer == null)
        return;
      //
      Web.CharazayDownloadItem cdi = null;
      switch (e.ColumnIndex)
      {
        case 1: // player id
          cdi = new Web.CharazayDownloadItem("player", 1, tlPlayer.PlayerId);
          break;

        case 2: // owner
          cdi = new Web.CharazayDownloadItem("team", 0, tlPlayer.OwnerTeamId);
          break;

        case 7: // bidder
          cdi = new Web.CharazayDownloadItem("team", 0, tlPlayer.BidHolderTeamId);
          break;

        default: break;
      }
      
      if (cdi != null)
        e.Url = cdi.Uri.AbsoluteUri;

    }

    void folvTM_SelectionChanged (object sender, EventArgs e)
    {
      GetXmlApiPlayer();
    }

    private void split1_Panel1_DoubleClick (object sender, EventArgs e)
    {
      this.split1.Panel1Collapsed = true;
    }

    private void split1_Panel2_DoubleClick (object sender, EventArgs e)
    {
      this.split1.Panel1Collapsed = false;
    }

/// <summary>
    /// Shortlist button clicked event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnShortlist_Click (object sender, EventArgs e)
    {
      Objects.TransferListedPlayer searchTlp = (Objects.TransferListedPlayer)this.folvTM.SelectedObject;
      if (searchTlp == null) return;
      //
      string ddl = searchTlp.Deadline.ToString("yyyy/MM/dd HH:mm");
      uint prc = Math.Max (searchTlp.CurrentPrice,10000u);
      //
      // search for bookmarks with same id and court position
      //
      //foreach (var p in DecideCourtPosition (this.ucBasicPlayer.PlayerByValueIndex, this.ucBasicPlayer.PlayerByScore).ToList())
      foreach (var p in DecideCourtPosition().Distinct().ToList())
      {
        var found = Data.TransferList.Bookmarks.FirstOrDefault(x => x.PlayerId == p.Id && x.Pos == p.PositionEnum);
        if (found == null)
        { //
          // not found => add
          //
          Data.TransferList.Bookmarks.Add(new Objects.TLPlayer()
          {
            Deadline = ddl,
            AgeValueIndex = p.ValueIndex,
            Price = prc,
            Profitability = Math.Pow(10d, 6d) * p.TransferMarketValue / (double)prc,
            Position = p.PositionEnum.ToString(),
            Name = p.FullName,
            PlayerId = p.Id
          });
        }
        else
        { //
          // found => update
          //
          found.Deadline = ddl;
          found.AgeValueIndex = p.ValueIndex;
          found.Price = prc;
          found.Profitability = Math.Pow(10d, 6d) * p.TransferMarketValue / (double)prc;
        }
      }
      
     
      
    }

    private void btnReset_Click (object sender, EventArgs e)
    {
      this.SuspendLayout();
      //
      foreach (var x in this.split1.Panel1.Controls)
      {
        if (x is RangeBar)
        {
          RangeBar rb = (x as RangeBar);
          rb.SelectRange(rb.TotalMinimum, rb.TotalMaximum);          
        }
        else if (x is TextBox)
        {
          (x as TextBox).Text = String.Empty;
        }
      }
      //
      foreach (var x in this.gbx1.Controls)
      {
        if (x is SkillComboBox)
        {
          (x as SkillComboBox).SelectedItem = TransferListSkill.noSkill;
        }
        else if (x is RangeBar)
        {
          RangeBar rb = (x as RangeBar);
          rb.SelectRange(rb.TotalMinimum, rb.TotalMaximum);
        }
      }
      foreach (var x in this.gbx2.Controls)
      {
        if (x is SkillComboBox)
        {
          (x as SkillComboBox).SelectedItem = TransferListSkill.noSkill;
        }
        else if (x is RangeBar)
        {
          RangeBar rb = (x as RangeBar);
          rb.SelectRange(rb.TotalMinimum, rb.TotalMaximum);
        }
      }
      //
      this.ResumeLayout(false);

    }
    #endregion    

    /// <summary>
    /// Player facets By Score
    /// </summary>
    Player[] _playerFacets = null;
  }


}


 
