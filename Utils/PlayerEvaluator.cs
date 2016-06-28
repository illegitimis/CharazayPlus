﻿

namespace AndreiPopescu.CharazayPlus.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AndreiPopescu.CharazayPlus.Model;
    using AndreiPopescu.CharazayPlus.Extensions;

    public class PlayerEvaluator
    {
        readonly Xsd2.charazayPlayer _p;
        readonly bool _isHw;
        readonly bool _isFatigue;
        readonly bool _isForm;
        readonly Evaluation _evaluationType;

        public PlayerEvaluator(Xsd2.charazayPlayer p, bool isHw = false, bool isFatigue = false, bool isForm = false, Evaluation evaluationType = Evaluation.season30)
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

        #region position aspects

        /// <param name="pg">PG aspect</param>
        public Player PG { get { return _pg; } }
        /// <param name="sg">SG Aspect</param>
        public Player SG { get { return _sg; } }
        /// <param name="sf">SF aspect</param>
        public Player SF { get { return _sf; } }
        /// <param name="pf">PF aspect</param>
        public Player PF { get { return _pf; } }
        /// <param name="M">C aspect</param>
        public Player C { get { return _c; } }


        Player _pg = null;
        Player _sg = null;
        Player _sf = null;
        Player _pf = null;
        Player _c = null;

        internal Player GetPlayer(ST_PlayerPositionEnum pos)
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

        internal IEnumerable<Player> GetPlayers()
        {
            yield return _c;
            yield return _pf;
            yield return _sf;
            yield return _sg;
            yield return _pg;

        }

        #endregion


        internal Player Best(IDecidePlayerPositionAlgorithm x)
        {
            return x.Decide(this);
        }

        public byte Age { get { return _sg.Age; } }

        public byte Height { get { return _pg.Height; } }
    }

    public interface IDecidePlayerPositionAlgorithm
    {
        /*ST_PlayerPositionEnum*/
        Player Decide(PlayerEvaluator eval);
        IEnumerable<Player> Decide(PlayerEvaluator eval, int top);
    }
    /// <summary>
    /// Best position for a player based on total score
    /// </summary>  
    class DecidePlayerPositionByTotalScoreAlgorithm : IDecidePlayerPositionAlgorithm
    {

        public /*ST_PlayerPositionEnum*/Player Decide(PlayerEvaluator eval)
        {
            //double maxTotalScore = _pg.TotalScore;
            //Player p = _pg;

            //if (_sg.TotalScore > maxTotalScore)
            //{
            //    p = _sg;
            //    maxTotalScore = _sg.TotalScore;
            //}

            //if (_sf.TotalScore > maxTotalScore)
            //{
            //    p = _sf;
            //    maxTotalScore = _sf.TotalScore;
            //}

            //if (_pf.TotalScore > maxTotalScore)
            //{
            //    p = _pf;
            //    maxTotalScore = _pf.TotalScore;
            //}

            //if (_c.TotalScore > maxTotalScore)
            //{
            //    p = _c;
            //    maxTotalScore = _c.TotalScore;
            //}

            //return p;

            return eval.GetPlayers().OrderByDescending(x => x.TotalScore).First();

        }

        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top)
        {
            return eval.GetPlayers().OrderByDescending(x => x.TotalScore).Take(top);
        }
    }

    class DecideMostAdequatePlayerPositionByHeightAlgorithm : IDecidePlayerPositionAlgorithm
    {
        public Player Decide(PlayerEvaluator eval)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.MostAdequatePositionsForAgeAndHeight(eval.Age, eval.Height, true);
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).First();
        }
        
        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.MostAdequatePositionsForAgeAndHeight(eval.Age, eval.Height, true);
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).Take(top);
        }
    }

    class DecidePotentialPlayerPositionAlgorithm : IDecidePlayerPositionAlgorithm
    {
        public Player Decide(PlayerEvaluator eval)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.PotentialPositionsForAgeAndHeight(eval.Age, eval.Height, true).ToList();
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).First();
        }

        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.PotentialPositionsForAgeAndHeight(eval.Age, eval.Height, true).ToList();
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).Take(top);
        }
    }

}