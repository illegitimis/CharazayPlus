

namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using AndreiPopescu.CharazayPlus.Model;

  public class PlayerEvaluator
  {
    readonly Xsd2.charazayPlayer _p;
    readonly bool _isHw;
    readonly bool _isFatigue;
    readonly bool _isForm;
    readonly Evaluation _evaluationType;

    public PlayerEvaluator (Xsd2.charazayPlayer p, bool isHw = false, bool isFatigue = false, bool isForm = false, Evaluation evaluationType=Evaluation.season30)
    {
      _p = p;
      _isHw = isHw;
      _isFatigue = isFatigue;
      _isForm = isForm;
      _evaluationType = evaluationType;

      _pg = _evaluationType == Evaluation.season30 ? new PG2014(_p, _isHw, _isFatigue, _isForm) : new PG(_p, _isHw, _isFatigue, _isForm);
      _sg = _evaluationType == Evaluation.season30 ? new SG2014(_p, _isHw, _isFatigue, _isForm) : new SG(_p, _isHw, _isFatigue, _isForm);
      _sf = _evaluationType == Evaluation.season30 ? new SF2014(_p, _isHw, _isFatigue, _isForm) : new SF(_p, _isHw, _isFatigue, _isForm);
      _pf = _evaluationType == Evaluation.season30 ? new PF2014(_p, _isHw, _isFatigue, _isForm) : new PF(_p, _isHw, _isFatigue, _isForm);
      _c = _evaluationType == Evaluation.season30 ? new C2014(_p, _isHw, _isFatigue, _isForm) : new C(_p, _isHw, _isFatigue, _isForm);
    }

    public Player PG { get { return _pg; } }
    public Player SG { get { return _sg; } }
    public Player SF { get { return _sf; } }
    public Player PF { get { return _pf; } }
    public Player C { get { return _c; } }


    Player _pg = null;
    Player _sg = null;
    Player _sf = null;
    Player _pf = null;
    Player _c = null;

    internal Player GetPlayer (ST_PlayerPositionEnum pos)
    {
      switch (pos)
      {
        case ST_PlayerPositionEnum.C: return _c;
        case ST_PlayerPositionEnum.PF: return _pf;
        case ST_PlayerPositionEnum.SF: return _sf;
        case ST_PlayerPositionEnum.SG: return _sg;
        case ST_PlayerPositionEnum.PG: return _pg;
        default: return null;
      }
    }

    internal IEnumerable<Player> GetPlayers ( )
    {
      yield return _c;
      yield return _pf;
      yield return _sf;
      yield return _sg;
      yield return _pg;

    }
  }
}
