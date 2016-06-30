namespace AndreiPopescu.CharazayPlus.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AndreiPopescu.CharazayPlus.Model;
    using AndreiPopescu.CharazayPlus.Extensions;

    public interface IDecidePlayerPositionAlgorithm
    {
        /*ST_PlayerPositionEnum*/
        Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true);
        IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true);
    }
    /// <summary>
    /// Best position for a player based on total score
    /// </summary>  
    class DecidePlayerPositionByTotalScoreAlgorithm : IDecidePlayerPositionAlgorithm
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

    class DecideMostAdequatePlayerPositionByHeightAlgorithm : IDecidePlayerPositionAlgorithm
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
    /// 
    /// </summary>
    class DecidePotentialPlayerPositionAlgorithm : IDecidePlayerPositionAlgorithm
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

    class Smart : IDecidePlayerPositionAlgorithm
    {
        static readonly IDecidePlayerPositionAlgorithm a1 = new DecidePlayerPositionByTotalScoreAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a2 = new DecideMostAdequatePlayerPositionByHeightAlgorithm();
        static readonly IDecidePlayerPositionAlgorithm a3 = new DecidePotentialPlayerPositionAlgorithm();

        public Player Decide(PlayerEvaluator eval, bool mostProbableOnly = true)
        {
            var p1 = a1.Decide(eval, mostProbableOnly);
            var p2 = a2.Decide(eval, mostProbableOnly);
            var p3 = a3.Decide(eval, mostProbableOnly);
            
            //http://stackoverflow.com/a/15184669/2239678
            var grouped = new[] { p1, p2, p3 }.ToLookup(x => x);
            var maxRepetitions = grouped.Max(x => x.Count());
            var maxRepeatedItems = grouped
                .Where(x => x.Count() == maxRepetitions)
                .Select(x => x.Key);
            var maxScore = maxRepeatedItems.Max(x => x.TotalScore);
            return maxRepeatedItems
                .Where(x => x.TotalScore == maxScore)
                .First();
        }

        //http://stackoverflow.com/questions/11401622/sort-by-count-occurrences-of-a-word-in-list-rows-linq?rq=1
        //http://stackoverflow.com/a/13018477
        public IEnumerable<Player> Decide(PlayerEvaluator eval, int top, bool mostProbableOnly = true)
        {
            var e1 = a1.Decide(eval, 2, mostProbableOnly);
            var e2 = a2.Decide(eval, 2, mostProbableOnly);
            var e3 = a3.Decide(eval, 2, mostProbableOnly);

            var q = from p in e1.Concat(e2).Concat(e3)
                    group p by p.PositionEnum into g
                    orderby g.Count() descending
                    select new { Count = g.Count(), Item = g };

            return q
                .Take(top)
                .Select (anonymous => anonymous.Item.ElementAt(0))
                .OrderByDescending(x=>x.TotalScore);
        }
    }
}
