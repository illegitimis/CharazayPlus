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

  public partial class MainForm : System.Windows.Forms.Form
  {
    private void initTrainingPropertyGrid ( )
    {
      Coach maxCoach = _coaches[_coaches.Count - 1];
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
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sDEFENSE, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sDRIBLING, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sFOOTWORK, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sFREETHROWS, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sPASSING, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sREBOUNDS, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sSPEED, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sTHREEPOINT, maxCoach));
     _optimumPlayers.Sum(P => P.GetSkillTrainingDelta(Skills.sTWOPOINT, maxCoach));

      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.defense, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.dribling, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.footwork, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.inside_sh, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.outside_sh, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.passing, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.rebounds, maxCoach));
      _optimumPlayers.Sum(P => P.GetScoreTrainingDelta(TrainingCategories.speed, maxCoach));
#endif
      foreach (Player P in _optimumPlayers)
      {
        skIncDef += P.SkillTrainingDelta(Skills.sDEFENSE, maxCoach);
        skIncDri += P.SkillTrainingDelta(Skills.sDRIBLING, maxCoach);
        skIncFtw += P.SkillTrainingDelta(Skills.sFOOTWORK, maxCoach);
        skIncFt += P.SkillTrainingDelta(Skills.sFREETHROWS, maxCoach);
        skIncPas += P.SkillTrainingDelta(Skills.sPASSING, maxCoach);
        skIncReb += P.SkillTrainingDelta(Skills.sREBOUNDS, maxCoach);
        skIncSpe += P.SkillTrainingDelta(Skills.sSPEED, maxCoach);
        skInc3p += P.SkillTrainingDelta(Skills.sTHREEPOINT, maxCoach);
        skInc2p += P.SkillTrainingDelta(Skills.sTWOPOINT, maxCoach);
        trnIncDef += P.GetScoreTrainingDelta(TrainingCategories.defense, maxCoach);
        trnIncDri += P.GetScoreTrainingDelta(TrainingCategories.dribling, maxCoach);
        trnIncFtw += P.GetScoreTrainingDelta(TrainingCategories.footwork, maxCoach);
        trnIncIn += P.GetScoreTrainingDelta(TrainingCategories.inside_sh, maxCoach);
        trnIncOut += P.GetScoreTrainingDelta(TrainingCategories.outside_sh, maxCoach);
        trnIncPas += P.GetScoreTrainingDelta(TrainingCategories.passing, maxCoach);
        trnIncReb += P.GetScoreTrainingDelta(TrainingCategories.rebounds, maxCoach);
        trnIncSpe += P.GetScoreTrainingDelta(TrainingCategories.speed, maxCoach);
      }

      TrainingAdvicePropertyGridObject tpg = new TrainingAdvicePropertyGridObject(
      skIncDef, skIncDri, skIncFtw, skIncFt, skIncPas, skIncReb, skIncSpe, skInc3p, skInc2p,
      trnIncDef, trnIncDri, trnIncFtw, trnIncIn, trnIncOut, trnIncPas, trnIncReb, trnIncSpe);

      propGrid.SelectedObject = tpg;
    }

    private void initCoachesList ( )
    {
      //coaches list
      Generator.GenerateColumns(olvCoaches, _coaches);
      foreach (OLVColumn col in olvCoaches.Columns)
      {
        if (col.Index != 0)
          col.IsHeaderVertical = true;
      }
      //olvCoaches.RebuildColumns();

      olvCoaches.SetObjects(_coaches);
    }

    // training skill increase
    private void initTrainingSkillIncrease ( )
    {
      TypedObjectListView<Player> typedOlv = new TypedObjectListView<Player>(olvSkillIncrease);
      Coach maxCoach = _coaches[_coaches.Count - 1];
      for (int index = 1; index < 10; index++)
      {
        Skills trainingSkill = (Skills)index;
        typedOlv.GetColumn(index).AspectGetter =
          delegate(Player p) { return p.SkillTrainingDelta(trainingSkill, maxCoach); };
      }

      //olvSkillIncrease.SetObjects(pgs);      
      olvSkillIncrease.SetObjects(_optimumPlayers);
    }

    /// <summary>
    /// 
    /// </summary>
    private void initTrainingScoreIncrease ( )
    {
      // training score increase
      TypedObjectListView<Player> typedOlv = new TypedObjectListView<Player>(olvTraining);
      Coach maxCoach = _coaches[_coaches.Count - 1];
      for (int index = 1; index < 9; index++)
      {
        TrainingCategories tc = (TrainingCategories)(index - 1);
        typedOlv.GetColumn(index).AspectGetter =
          delegate(Player p) { return p.GetScoreTrainingDelta(tc, maxCoach); };
      }

      //olvTraining.SetObjects(pgs);
      olvTraining.SetObjects(_optimumPlayers);
    }

    private void initTrainingEfficiency (bool top8=false)
    {
      Generator.GenerateColumns(olvTrainingEfficiency, typeof(TrainingEfficiencyScoreItem));
      olvTrainingEfficiency.RebuildColumns();
      Coach maxCoach = _coaches[_coaches.Count - 1];
      var plyrs = top8 ? TrainingEfficiencyCalculator.TopN(_optimumPlayers, 8) : _optimumPlayers;
      olvTrainingEfficiency.SetObjects(TrainingEfficiencyCalculator.Go(plyrs, maxCoach));      
    }

    private void chkTEu18_CheckedChanged (object sender, EventArgs e)
    {
      initTrainingEfficiency(chkTEu18.Checked);      
    }
  }
}