namespace AndreiPopescu.CharazayPlus.UI
{
  using System;
  using System.Collections.Generic;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.Utils;
  using BrightIdeasSoftware;

  public partial class TrainingTabUserControl : UserControl
  {
    public TrainingTabUserControl ( )
    {
      InitializeComponent();
    }

    Coach MaxCoach { get { return Coaches[Coaches.Count - 1];} }
    public List<Coach> Coaches { get; set; }
    public List<Player> OptimumPlayers { get; set; }

    public void initTrainingPropertyGrid ( )
    {
      double skIncDef = 0
      , skIncDri = 0f
      , skIncFtw = 0f
      , skIncFt = 0f
      , skIncPas = 0f
      , skIncReb = 0f
      , skIncSpe = 0f
      , skInc3p = 0f
      , skInc2p = 0f
      , trnIncDef = 0f
      , trnIncDri = 0f
      , trnIncFtw = 0f
      , trnIncIn = 0f
      , trnIncOut = 0f
      , trnIncPas = 0f
      , trnIncReb = 0f
      , trnIncSpe = 0f;
#if DOTNET30
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sDEFENSE, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sDRIBLING, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sFOOTWORK, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sFREETHROWS, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sPASSING, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sREBOUNDS, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sSPEED, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sTHREEPOINT, maxCoach));
     OptimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sTWOPOINT, maxCoach));

      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.defense, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.dribling, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.footwork, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.inside_sh, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.outside_sh, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.passing, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.rebounds, maxCoach));
      OptimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.speed, maxCoach));
#endif
      foreach (Player P in OptimumPlayers)
      {
        skIncDef += P.SkillTrainingDelta(Skills.sDEFENSE, MaxCoach);
        skIncDri += P.SkillTrainingDelta(Skills.sDRIBLING, MaxCoach);
        skIncFtw += P.SkillTrainingDelta(Skills.sFOOTWORK, MaxCoach);
        skIncFt += P.SkillTrainingDelta(Skills.sFREETHROWS, MaxCoach);
        skIncPas += P.SkillTrainingDelta(Skills.sPASSING, MaxCoach);
        skIncReb += P.SkillTrainingDelta(Skills.sREBOUNDS, MaxCoach);
        skIncSpe += P.SkillTrainingDelta(Skills.sSPEED, MaxCoach);
        skInc3p += P.SkillTrainingDelta(Skills.sTHREEPOINT, MaxCoach);
        skInc2p += P.SkillTrainingDelta(Skills.sTWOPOINT, MaxCoach);
        trnIncDef += P.GetScoreTrainingDelta(TrainingCategories.defense, MaxCoach);
        trnIncDri += P.GetScoreTrainingDelta(TrainingCategories.dribling, MaxCoach);
        trnIncFtw += P.GetScoreTrainingDelta(TrainingCategories.footwork, MaxCoach);
        trnIncIn += P.GetScoreTrainingDelta(TrainingCategories.inside_sh, MaxCoach);
        trnIncOut += P.GetScoreTrainingDelta(TrainingCategories.outside_sh, MaxCoach);
        trnIncPas += P.GetScoreTrainingDelta(TrainingCategories.passing, MaxCoach);
        trnIncReb += P.GetScoreTrainingDelta(TrainingCategories.rebounds, MaxCoach);
        trnIncSpe += P.GetScoreTrainingDelta(TrainingCategories.speed, MaxCoach);
      }

      TrainingAdvicePropertyGridObject tpg = new TrainingAdvicePropertyGridObject(
      skIncDef, skIncDri, skIncFtw, skIncFt, skIncPas, skIncReb, skIncSpe, skInc3p, skInc2p,
      trnIncDef, trnIncDri, trnIncFtw, trnIncIn, trnIncOut, trnIncPas, trnIncReb, trnIncSpe);

      propGrid.SelectedObject = tpg;
    }

    public void initCoachesList ( )
    {
      //coaches list
      Generator.GenerateColumns(olvCoaches, Coaches);
      foreach (OLVColumn col in olvCoaches.Columns)
      {
        if (col.Index != 0)
          col.IsHeaderVertical = true;
      }
      //olvCoaches.RebuildColumns();

      olvCoaches.SetObjects(Coaches);
    }

    // training skill increase
    public void initTrainingSkillIncrease ( )
    {
      TypedObjectListView<Player> typedOlv = new TypedObjectListView<Player>(olvSkillIncrease);
      Coach maxCoach = Coaches[Coaches.Count - 1];
      for (int index = 1; index < 10; index++)
      {
        Skills trainingSkill = (Skills)index;
        typedOlv.GetColumn(index).AspectGetter =
          delegate(Player p) { return p.SkillTrainingDelta(trainingSkill, maxCoach); };
      }

      //olvSkillIncrease.SetObjects(_pgs);      
      olvSkillIncrease.SetObjects(OptimumPlayers);
    }

    /// <summary>
    /// 
    /// </summary>
    public void initTrainingScoreIncrease ( )
    {
      // training score increase
      TypedObjectListView<Player> typedOlv = new TypedObjectListView<Player>(olvTraining);
      Coach maxCoach = Coaches[Coaches.Count - 1];
      for (int index = 1; index < 9; index++)
      {
        TrainingCategories tc = (TrainingCategories)(index - 1);
        typedOlv.GetColumn(index).AspectGetter =
          delegate(Player p) { return p.GetScoreTrainingDelta(tc, maxCoach); };
      }

      //olvTraining.SetObjects(_pgs);
      olvTraining.SetObjects(OptimumPlayers);
    }

    public void initTrainingEfficiency (bool top8 = false)
    {
      Generator.GenerateColumns(olvTrainingEfficiency, typeof(TrainingEfficiencyScoreItem));
      olvTrainingEfficiency.RebuildColumns();
      Coach maxCoach = Coaches[Coaches.Count - 1];
      var plyrs = top8 ? TrainingEfficiencyCalculator.TopN(OptimumPlayers, 8) : OptimumPlayers;
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyCalculator.Go(plyrs, maxCoach));
    }

    private void chkTEu18_CheckedChanged (object sender, EventArgs e)
    {
      initTrainingEfficiency(chkTEu18.Checked);
    }

    private void olvCoaches_FormatCell (object sender, FormatCellEventArgs e)
    {
      //e.RowIndex == _coaches.Count - 1 &&
      if (e.Item.Text == "Active Coach")
        e.SubItem.Font = new System.Drawing.Font(e.SubItem.Font, System.Drawing.FontStyle.Bold);
    }

    private void olvCoaches_FormatRow (object sender, FormatRowEventArgs e)
    {

    }
  }
}
