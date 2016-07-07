namespace AndreiPopescu.CharazayPlus.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AndreiPopescu.CharazayPlus.Model;
    using AndreiPopescu.CharazayPlus.Extensions;

    /// <summary>
    /// strategy pattern for <see cref="PlayerEvaluator"/>
    /// </summary>
    public interface IDecidePlayerPositionAlgorithm
    {
        /*ST_PlayerPositionEnum*/
        Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true);
        IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true);
    }
    
    /// <summary>
    /// Best position for a player based on total score
    /// </summary>  
    class TotalScoreAlgorithm : IDecidePlayerPositionAlgorithm
    {

        public /*ST_PlayerPositionEnum*/Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true)
        {
#if DOTNET30
            return eval.GetPlayers().OrderByDescending(x => x.TotalScore).First();
#else

            double maxTotalScore = eval.PG.TotalScore;
            Player p = eval.PG;

            if (eval.SG.TotalScore > maxTotalScore)
            {
                p = eval.SG;
                maxTotalScore = eval.SG.TotalScore;
            }

            if (eval.SF.TotalScore > maxTotalScore)
            {
                p = eval.SF;
                maxTotalScore = eval.SF.TotalScore;
            }

            if (eval.PF.TotalScore > maxTotalScore)
            {
                p = eval.PF;
                maxTotalScore = eval.PF.TotalScore;
            }

            if (eval.C.TotalScore > maxTotalScore)
            {
                p = eval.C;
                maxTotalScore = eval.C.TotalScore;
            }

            return p;
#endif
        }

        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true)
        {
            return eval.GetPlayers().OrderByDescending(x => x.TotalScore).Take(top);
        }
    }

    /// <summary>
    /// decide based on most adequate position for his height or possible future height if below 18
    /// </summary>
    class MostAdequatePositionByHeightAlgorithm : IDecidePlayerPositionAlgorithm
    {
        public Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.MostAdequatePositionsForAgeAndHeight(eval.Age, eval.Height, mostProbableOnly);
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).First();
        }

        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.MostAdequatePositionsForAgeAndHeight(eval.Age, eval.Height, mostProbableOnly);
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).Take(top);
        }
    }

    /// <summary>
    /// decide based on positions/score for his height or possible future positions & score if below 18
    /// </summary>
    class PotentialPlayerPositionAlgorithm : IDecidePlayerPositionAlgorithm
    {
        public Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.PotentialPositionsForAgeAndHeight(eval.Age, eval.Height, mostProbableOnly).ToList();
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).First();
        }

        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true)
        {
            List<ST_PlayerPositionEnum> positions = PlayerExtensions.PotentialPositionsForAgeAndHeight(eval.Age, eval.Height, mostProbableOnly).ToList();
            return positions.Select(pos => eval.GetPlayer(pos)).OrderByDescending(x => x.TotalScore).Take(top);
        }
    }

    /// <summary>
    /// aggregate total score/potential position/most adequate
    /// judge on position frequency, then score
    /// </summary>
    public class DecidePlayerPositionAggregatorAlgorithm : IDecidePlayerPositionAlgorithm
    {
        static readonly IDecidePlayerPositionAlgorithm a1 = new TotalScoreAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a2 = new MostAdequatePositionByHeightAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a3 = new PotentialPlayerPositionAlgorithm();

        public Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true)
        {
            //var p1 = a1.Decide(eval, mostProbableOnly);
            //var p2 = a2.Decide(eval, mostProbableOnly);
            //var p3 = a3.Decide(eval, mostProbableOnly);
            
            ////http://stackoverflow.com/a/15184669/2239678
            //var grouped = new[] { p1, p2, p3 }.ToLookup(x => x);
            //var maxRepetitions = grouped.Max(x => x.Count());
            //var maxRepeatedItems = grouped
            //    .Where(x => x.Count() == maxRepetitions)
            //    .Select(x => x.Key);
            //var maxScore = maxRepeatedItems.Max(x => x.TotalScore);
            //return maxRepeatedItems
            //    .Where(x => x.TotalScore == maxScore)
            //    .First();

            return Decide(eval, 1, mostProbableOnly).First();
        }

        //http://stackoverflow.com/questions/11401622/sort-by-count-occurrences-of-a-word-in-list-rows-linq?rq=1
        //http://stackoverflow.com/a/13018477
        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true)
        {
            // get everything, select top results at the end
            var e1 = a1.Decide(eval, top, mostProbableOnly);
            var e2 = a2.Decide(eval, 5, mostProbableOnly);
            var e3 = a3.Decide(eval, 5, mostProbableOnly);

            var q = from p in e1.Concat(e2).Concat(e3)
                    group p by p.PositionEnum into g
                    orderby g.Count() descending,
                     g.ElementAtOrDefault(0).TotalScore descending
                    select new { Count = g.Count(), Item = g.ElementAtOrDefault(0) };

            return q
                .Take(top)
                .Select(anonymous => anonymous.Item);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FacetsAlgorithm : IDecidePlayerPositionAlgorithm
    {
        const double INCREASE = 0.7d;

        static readonly IDecidePlayerPositionAlgorithm totalScoreAlgo = new TotalScoreAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm potentialPositionsAlgo = new PotentialPlayerPositionAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm adequatePositionsAlgo = new MostAdequatePositionByHeightAlgorithm();

        public Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true)
        {
            return DecideCourtPosition(eval).FirstOrDefault();
        }

        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true)
        {
            return DecideCourtPosition(eval).Take(top);
        }

        /// <summary>
        /// Best position for a player, called on shortlist
        /// taller player may qualify for smaller position
        // no facets inside the contiguous future positions zone, e.g.
        // future position PG, facets SF, PF
        // future positions PF, C facet PG, SF
        // future positions SG,SF,PF facets PG, C
        // strong indicator for that pos, as skillset is concerned
        // a single court position for the current player
        // current player facet is not a future viable position
        // for instance facet is C and future positions are PG, SG, SF
        // or facet is PF and future positions are PG, SG
        // or facet is PG and future position is SF
        // multiple positions returned
        // pinpoint positions from score & value index as most relevant
        /// </summary>
        private IEnumerable<Player> DecideCourtPosition(PlayerEvaluator eval)
        { 
            var _scoreFacets = totalScoreAlgo.Decide(eval, 5, false).ToArray();
            var _potentialFacets = potentialPositionsAlgo.Decide(eval, 5, false).ToArray();
            var _possibleFacets = potentialPositionsAlgo.Decide(eval, 5, true).ToArray();
            var _adequateFacets = adequatePositionsAlgo.Decide(eval, 5, false).ToArray();
            var _probableFacets = adequatePositionsAlgo.Decide(eval, 5, true).ToArray();

            var positionScores = new Dictionary<ST_PlayerPositionEnum, double>();
            foreach (var pos in new[]{ST_PlayerPositionEnum.PG, ST_PlayerPositionEnum.SG, ST_PlayerPositionEnum.SF, ST_PlayerPositionEnum.PF, ST_PlayerPositionEnum.C })
            {
                Func<Player, bool> GetPlayerByPosition = x => x.PositionEnum == pos;
                positionScores[pos] = _scoreFacets.Single(GetPlayerByPosition).TotalScore;
                if (_potentialFacets.Any(GetPlayerByPosition)) positionScores[pos] += INCREASE;
                if (_possibleFacets.Any(GetPlayerByPosition))  positionScores[pos] += INCREASE;
                if (_adequateFacets.Any(GetPlayerByPosition))  positionScores[pos] += INCREASE;
                if (_probableFacets.Any(GetPlayerByPosition))  positionScores[pos] += INCREASE;
            }
            
            // get back player list sorted by score
            return positionScores
                .OrderByDescending(kvp => kvp.Value)
                .Select(x => eval.GetPlayer(x.Key));            
        }

        /*
        private IEnumerable<Player> DecideFrontBackCourt(PlayerEvaluator eval, Player[] _scoreFacets, Player[] _potentialFacets)
        {
            //var _scoreFacets = totalScoreAlgo.Decide (eval, 2, false);
            //var _potentialFacets = potentialPositionsAlgo.Decide(eval, 3, false);

            var _playerFacets = _scoreFacets.Union(_potentialFacets);
            var backCourtPosition = _playerFacets.Select(x=>x.PositionEnum).Min();
            var frontCourtPosition = _playerFacets.Select(x => x.PositionEnum).Max();
            
            foreach (var pos in (ST_PlayerPositionEnum[])Enum.GetValues(typeof(ST_PlayerPositionEnum)))
            {
                if (pos >= backCourtPosition && pos <= frontCourtPosition)
                {
                    //yield return SerializeHelper.GetPlayerFromIdAndPosition(_playerFacets[0].Id, pos, Evaluation.season30);
                    yield return eval.GetPlayer(pos);
                }
            }

            //if (_playerFacets[idx].PositionEnum < ppmin)
            //  //score for backcourt, height for frontcourt
            //  return _playerFacets[0];                      
            //else if (_playerFacets[0].PositionEnum > ppmax)
            //  // score for frontcourt, height for backcourt
            //  return SerializeHelper.GetPlayerFromIdAndPosition(_playerFacets[0].Id, ppmax, Evaluation.season30);
            //else
            //  throw new Exception("DecideFrontBackCourt");
        }
        */
    }
}
