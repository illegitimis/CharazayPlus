namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;
  using BrightIdeasSoftware;
  using AndreiPopescu.CharazayPlus.Objects;
 using AndreiPopescu.CharazayPlus.Data;

#if DOTNET30
  using System.Linq; 
#endif

  public partial class TrainingTabUserControl : UserControl
  {
    public TrainingTabUserControl ( )
    {
      InitializeComponent();
    }

    #region local data holders for efficiency/training combination    
    
    IDictionary<TrainingCombination,List<TrainingCombinationItem>> TrainingCombinationValues = new Dictionary<TrainingCombination,List<TrainingCombinationItem>>();
    IList<TrainingEfficiencyScoreItem> TrainingEfficiencyScores = new List<TrainingEfficiencyScoreItem>();

    #endregion

   
    public void initCoachesList ( )
    {
      this.olvCoaches.HeaderUsesThemes = false;
      this.olvCoaches.HeaderWordWrap = false;
      //coaches list
      Generator.GenerateColumns(olvCoaches, PlayersEnvironment.Coaches);
      foreach (OLVColumn col in olvCoaches.Columns)
      {
        if (col.Index != 0)
          col.IsHeaderVertical = true;
      }
      olvCoaches.SetObjects(PlayersEnvironment.Coaches);
    }

    // training skill increase
    public void initTrainingSkillIncrease ( )
    {
      Generator.GenerateColumns(this.olvSkillIncrease, TrainingEnvironment.SkillIncreaseItems);
      this.olvSkillIncrease.SetObjects(TrainingEnvironment.SkillIncreaseItems);
    }

    /// <summary>
    /// 
    /// </summary>
    public void initTrainingScoreIncrease ( )
    {
      Generator.GenerateColumns(this.olvTraining, TrainingEnvironment.ScoreIncreaseItems);
      this.olvTraining.SetObjects(TrainingEnvironment.ScoreIncreaseItems);
    }

     

    public void initTrainingEfficiency ()
    {
      Generator.GenerateColumns(olvTrainingEfficiency, typeof(TrainingEfficiencyScoreItem));
      //
      Generator.GenerateColumns(this.folvTrainComb, typeof(TrainingCombinationItem));
      foreach (OLVColumn col in this.folvTrainComb.Columns)
      {
        if (col.Index != 0)
          //col.IsHeaderVertical = true;
          col.WordWrap = true;
      }
      //
      TrainingEfficiencyCalculator.Go (PlayersEnvironment.OptimumPlayers
        , PlayersEnvironment.MaxCoach
        , ref TrainingCombinationValues
        , ref TrainingEfficiencyScores);
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyScores);
     }

    private void chkTEu18_CheckedChanged (object sender, EventArgs e)
    {
      var players = this.chkTEu18.Checked 
        ? TrainingEfficiencyCalculator.TopN(PlayersEnvironment.OptimumPlayers, 8)
        : PlayersEnvironment.OptimumPlayers;
      TrainingEfficiencyCalculator.Go(players
        , PlayersEnvironment.MaxCoach
        , ref this.TrainingCombinationValues
        , ref this.TrainingEfficiencyScores);
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyScores);
    }

    private void chkRemove32_CheckedChanged (object sender, EventArgs e)
    {
      var players = this.chkRemove32.Checked
        ? TrainingEfficiencyCalculator.Under32(PlayersEnvironment.OptimumPlayers)
        : PlayersEnvironment.OptimumPlayers;
      TrainingEfficiencyCalculator.Go(players
        , PlayersEnvironment.MaxCoach
        , ref this.TrainingCombinationValues
        , ref this.TrainingEfficiencyScores);
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyScores);
    }

    #region OLV event handlers
    private void olvCoaches_FormatCell (object sender, FormatCellEventArgs e)
    {
      //e.RowIndex == _coaches.Count - 1 &&
      if (e.Item.Text == "Active Coach")
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
    }
          
    private void olvSkillIncrease_FormatCell (object sender, FormatCellEventArgs e)
    {
      if (e.Item.Text.StartsWith("TOTAL"))
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
      else
      {
        if (e.ColumnIndex > 0)
        {
          if ((double)e.CellValue > 0.25d)
            e.SubItem.ForeColor = System.Drawing.Color.Red;
          else if ((double)e.CellValue > 0.1d)
            e.SubItem.ForeColor = System.Drawing.Color.DarkGreen;
        }
        
      }

    }

    private void olvTraining_FormatCell (object sender, FormatCellEventArgs e)
    {
      if (e.Item.Text.StartsWith("TOTAL"))
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
      else
      {
        if (e.ColumnIndex > 0)
        {
          if ((double)e.CellValue > 0.04d)
            e.SubItem.ForeColor = System.Drawing.Color.Red;
          else if ((double)e.CellValue > 0.01d)
            e.SubItem.ForeColor = System.Drawing.Color.DarkGreen;
        }

      }
    }

    private void olvTrainingEfficiency_SelectedIndexChanged (object sender, EventArgs e)
    {
      TrainingEfficiencyScoreItem tefsi = (TrainingEfficiencyScoreItem)this.olvTrainingEfficiency.SelectedObject;
      if (tefsi == null)
        return;
      TrainingCombination tc = new TrainingCombination(tefsi.TC1, tefsi.TC2);
      var tcis = TrainingCombinationValues[tc];
      this.folvTrainComb.SetObjects(tcis);      
    }

    private void folvTrainComb_FormatRow (object sender, FormatRowEventArgs e)
    {
      var tci = (TrainingCombinationItem)e.Model;
      if (tci.Category1Increase > tci.Category2Increase)
        e.Item.SubItems[1].Font = new System.Drawing.Font(e.Item.SubItems[1].Font, System.Drawing.FontStyle.Bold);
      else
        e.Item.SubItems[2].Font = new System.Drawing.Font(e.Item.SubItems[2].Font, System.Drawing.FontStyle.Bold);
    }
    #endregion

    

   
    
  }
}
