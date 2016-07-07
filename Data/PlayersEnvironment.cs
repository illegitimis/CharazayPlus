namespace AndreiPopescu.CharazayPlus.Data
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using AndreiPopescu.CharazayPlus.Web;
  using AndreiPopescu.CharazayPlus.Utils;

  /// <summary>
  /// static own team player related data
  /// </summary>
  class PlayersEnvironment
  {
    public static IList<PG2014> PointGuards { get { return Nested.PGs; } }
    public static IList<SG2014> ShootingGuards { get { return Nested.SGs; } }
    public static IList<SF2014> SmallForwards { get { return Nested.SFs; } }
    public static IList<PF2014> PowerForwards { get { return Nested.PFs; } }
    public static IList<C2014> Centers { get { return Nested.Cs; } }

    public static IList<Player> OptimumPlayers { get { return Nested.OptimumPlayers; } }
    
    public static IList<Coach> Coaches { get { return Nested.Coaches; } }
    public static Coach MaxCoach { get { return Coaches[Coaches.Count - 1]; } }
    

    private class Nested
    {
      internal static readonly IList<PG2014> PGs;
      internal static readonly IList<SG2014> SGs;
      internal static readonly IList<SF2014> SFs;
      internal static readonly IList<PF2014> PFs;
      internal static readonly IList<C2014> Cs;
      internal static readonly IList<Player> OptimumPlayers;
      internal static readonly  IList<Coach> Coaches;
      
      static Nested ()
      {
        PGs = new List<PG2014>();
        SGs = new List<SG2014>();
        PFs = new List<PF2014>();
        SFs = new List<SF2014>();
        Cs = new List<C2014>();
        OptimumPlayers = new List<Player>();
        Coaches = new List<Coach>();

        //
        //init from charazay xml
        //
        var objects = Utils.SerializeHelper.GoGetXml(new Web.XmlDownloadItem[] {
          new Web.MyPlayersXml(WebServiceUsers.Instance.MainUser)
        , new Web.CoachesXml(WebServiceUsers.Instance.MainUser)
        }).ToArray();
        //
        var players = (Xsd2.charazayPlayer[])objects[0];
        // update development data
        DevelopmentHistory.Instance.Players = players;
        //
        var coaches = (Xsd2.charazayCoach[])objects[1];
        //
        var facetsAlgorithm = new FacetsAlgorithm();
        foreach (var p in players)
        {
            PlayerEvaluator evaluator = new PlayerEvaluator(p);
            Player opt = evaluator.Best(facetsAlgorithm);
            OptimumPlayers.Add(opt);
        }
        // 
        InitCoachesData(coaches);        
      }

      // coaches file
      private static void InitCoachesData (Xsd2.charazayCoach[] xsdCoaches)
      { //
        // alloc max coach (inner struct)
        //      
        var maxCoach = new Xsd2.charazayCoach() { skills = new Xsd2.charazayCoachSkills(), basic = new Xsd2.charazayCoachBasic() };
        foreach (Xsd2.charazayCoach xsdCoach in xsdCoaches)
        { //
          // get maximum skills from al coaches
          //
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
          // add maximum skills/active coach to coaches pool
          //
          Coaches.Add(new Coach(xsdCoach));
        }
        //
        // common props for active coach
        //
        maxCoach.basic.name = "Active";
        maxCoach.basic.surname = "Coach";
        maxCoach.id = 0;
        Coaches.Add(new Coach(maxCoach));
      }
    }
  }
}
