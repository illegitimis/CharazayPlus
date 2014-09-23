using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndreiPopescu.CharazayPlus.Web;

namespace AndreiPopescu.CharazayPlus.Data
{
  /// <summary>
  /// static own team player related data
  /// </summary>
  class PlayersEnvironment
  {
    public static IList<PG> PointGuards { get { return Nested.PGs; } }
    public static IList<SG> ShootingGuards { get { return Nested.SGs; } }
    public static IList<SF> SmallForwards { get { return Nested.SFs; } }
    public static IList<PF> PowerForwards { get { return Nested.PFs; } }
    public static IList<C> Centers { get { return Nested.Cs; } }

    public static IList<Player> OptimumPlayers { get { return Nested.OptimumPlayers; } }
    
    public static IList<Coach> Coaches { get { return Nested.Coaches; } }
    public static Coach MaxCoach { get { return Coaches[Coaches.Count - 1]; } }
    

    private class Nested
    {
      internal static readonly IList<PG> PGs;
      internal static readonly IList<SG> SGs;
      internal static readonly IList<SF> SFs;
      internal static readonly IList<PF> PFs;
      internal static readonly IList<C> Cs;
      internal static readonly IList<Player> OptimumPlayers;
      internal static readonly  IList<Coach> Coaches;
      
      static Nested ()
      {
        PGs = new List<PG>();
        SGs = new List<SG>();
        PFs = new List<PF>();
        SFs = new List<SF>();
        Cs = new List<C>();
        OptimumPlayers = new List<Player>();
        Coaches = new List<Coach>();

        //
        //init from charazay xml
        //
         var objects = Utils.Deserializer.GoGetXml(new Web.XmlDownloadItem[] {
          new Web.MyPlayersXml(WebServiceUser.Instance)
        ,new Web.CoachesXml(WebServiceUser.Instance)
        }).ToArray();
        //
        var players = (Xsd2.charazayPlayer[])objects[0];
        var coaches = (Xsd2.charazayCoach[])objects[1];
        //
        foreach (var plyr in players)
        {
            PGs.Add(new PG(plyr));
            SGs.Add(new SG(plyr));
            PFs.Add(new PF(plyr));
            SFs.Add(new SF(plyr));
            Cs.Add(new C(plyr));
            Player p = Player.DecideOnValueIndex(PGs.Last(), SGs.Last(), SFs.Last(), PFs.Last(), Cs.Last());
            OptimumPlayers.Add(p);
        }
        // 
        initCoachesData(coaches);
        
      }

      // coaches file
      private static void initCoachesData (Xsd2.charazayCoach[] xsdCoaches)
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
          // add from coach to pool
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
