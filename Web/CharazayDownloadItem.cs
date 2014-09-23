using System;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;
using System.IO;

namespace AndreiPopescu.CharazayPlus.Web
{
  //http://www.charazay.com/index.php?act=player&code=1&id=25829364
  internal class CharazayDownloadItem : DownloadItem
  {
    
    private static Uri ConstructUri (string act, byte code, ulong id)
    {
      return new Uri(string.Format("http://www.charazay.com/index.php?act={0}&code={1}&id={2}", act, code, id));
    }

    private static Uri ConstructUri (string act, ulong id)
    {
      return new Uri(string.Format("http://www.charazay.com/index.php?act={0}&id={1}", act, id));
    }

    //"http://www.charazay.com/?act=transfer&id2=0&userid=0&code=1&country=&profile=&name=&price_l=&price_h=&value_l=440000&value_h=450000&age_l=&age_h=&height_l=&height_h=&defence_l=&defence_h=&ft_l=&ft_h=&tpt_l=&tpt_h=&thpt_l=&thpt_h=&dribbling_l=&dribbling_h=&passing_l=&passing_h=&speed_l=&speed_h=&footwork_l=&footwork_h=&rebound_l=&rebound_h=&experience_l=&experience_h=&skill1a=0&skill1b=0&skill1c=0&skill1d=0&skill1_l=&skill1_h=&skill2a=0&skill2b=0&skill2c=0&skill2d=0&skill2_l=&skill2_h=&view=1";
    //"http://www.charazay.com/?act=transfer&id2=0&userid=0&code=1&country=&profile=&name=&price_l=&price_h=&value_l=&value_h=&age_l=15&age_h=35&height_l=160&height_h=230&defence_l=1&defence_h=2&ft_l=3&ft_h=4&tpt_l=&tpt_h=&thpt_l=&thpt_h=&dribbling_l=&dribbling_h=&passing_l=&passing_h=&speed_l=&speed_h=&footwork_l=&footwork_h=&rebound_l=&rebound_h=&experience_l=&experience_h=&skill1a=0&skill1b=0&skill1c=0&skill1d=0&skill1_l=&skill1_h=&skill2a=0&skill2b=0&skill2c=0&skill2d=0&skill2_l=&skill2_h=&view=0"
    //"http://www.charazay.com/?act=transfer&id2=0&userid=0&code=6&country=31&profile=&name=&price_l=&price_h=&value_l=&value_h=&age_l=15&age_h=35&height_l=160&height_h=230&defence_l=1&defence_h=2&ft_l=3&ft_h=4&tpt_l=&tpt_h=&thpt_l=&thpt_h=&dribbling_l=&dribbling_h=&passing_l=&passing_h=&speed_l=&speed_h=&footwork_l=&footwork_h=&rebound_l=&rebound_h=&experience_l=&experience_h=&skill1a=0&skill1b=0&skill1c=0&skill1d=0&skill1_l=&skill1_h=&skill2a=0&skill2b=0&skill2c=0&skill2d=0&skill2_l=&skill2_h=&view=0"
    //"http://www.charazay.com/?act=transfer&id2=0&userid=0&code=6&country=5&profile=&name=&price_l=1&price_h=100000000&value_l=1&value_h=1000000&age_l=&age_h=&height_l=&height_h=&defence_l=&defence_h=&ft_l=&ft_h=&tpt_l=&tpt_h=&thpt_l=&thpt_h=&dribbling_l=&dribbling_h=&passing_l=&passing_h=&speed_l=&speed_h=&footwork_l=&footwork_h=&rebound_l=&rebound_h=&experience_l=&experience_h=&skill1a=1&skill1b=2&skill1c=3&skill1d=4&skill1_l=1&skill1_h=75&skill2a=5&skill2b=6&skill2c=7&skill2d=8&skill2_l=4&skill2_h=90&view=0"
    internal static Uri ConstructUri (bool isTransferMarket, byte? countryId
      , uint? price_l, uint? price_h
      , uint? value_l, uint? value_h
      , byte? age_l, byte? age_h
      , byte? height_l, byte? height_h
      , byte? defence_l, byte? defence_h
      , byte? ft_l, byte? ft_h
      , byte? tpt_l, byte? tpt_h
      , byte? thpt_l, byte? thpt_h
      , byte? dribbling_l, byte? dribbling_h
      , byte? passing_l, byte? passing_h
      , byte? speed_l, byte? speed_h
      , byte? footwork_l, byte? footwork_h
      , byte? rebound_l, byte? rebound_h
      , byte? experience_l, byte? experience_h
      , byte skill1a, byte skill1b, byte skill1c, byte skill1d, byte? skill1_l, byte? skill1_h
      , byte skill2a, byte skill2b, byte skill2c, byte skill2d, byte? skill2_l, byte? skill2_h
      , bool isClassicView
      )
    {
      StringBuilder sb = new StringBuilder("http://www.charazay.com/?act=transfer&id2=0&userid=0");
      sb.AppendFormat("&code={0}", isTransferMarket ? 1 : 6);
      sb.AppendFormat("&country={0}", countryId.HasValue ? countryId.Value.ToString() : string.Empty);
      sb.Append("&profile=&name=");

      sb.AppendFormat("&price_l={0}", price_l.HasValue ? price_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&price_h={0}", price_h.HasValue ? price_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&value_l={0}", value_l.HasValue ? value_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&value_h={0}", value_h.HasValue ? value_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&age_l={0}", age_l.HasValue ? age_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&age_h={0}", age_h.HasValue ? age_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&height_l={0}", height_l.HasValue ? height_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&height_h={0}", height_h.HasValue ? height_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&defence_l={0}", defence_l.HasValue ? defence_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&defence_h={0}", defence_h.HasValue ? defence_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&ft_l={0}", ft_l.HasValue ? ft_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&ft_h={0}", ft_h.HasValue ? ft_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&tpt_l={0}", tpt_l.HasValue ? tpt_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&tpt_h={0}", tpt_h.HasValue ? tpt_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&thpt_l={0}", thpt_l.HasValue ? thpt_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&thpt_h={0}", thpt_h.HasValue ? thpt_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&dribbling_l={0}", dribbling_l.HasValue ? dribbling_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&dribbling_h={0}", dribbling_h.HasValue ? dribbling_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&passing_l={0}", passing_l.HasValue ? passing_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&passing_h={0}", passing_h.HasValue ? passing_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&speed_l={0}", speed_l.HasValue ? speed_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&speed_h={0}", speed_h.HasValue ? speed_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&footwork_l={0}", footwork_l.HasValue ? footwork_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&footwork_h={0}", footwork_h.HasValue ? footwork_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&rebound_l={0}", rebound_l.HasValue ? rebound_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&rebound_h={0}", rebound_h.HasValue ? rebound_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&experience_l={0}", experience_l.HasValue ? experience_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&experience_h={0}", experience_h.HasValue ? experience_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&skill1a={0}&skill1b={1}&skill1c={2}&skill1d={3}", skill1a, skill1b, skill1c, skill1d);
      sb.AppendFormat("&skill1_l={0}", skill1_l.HasValue ? skill1_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&skill1_h={0}", skill1_h.HasValue ? skill1_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&skill2a={0}&skill2b={1}&skill2c={2}&skill2d={3}", skill2a, skill2b, skill2c, skill2d);
      sb.AppendFormat("&skill2_l={0}", skill2_l.HasValue ? skill2_l.Value.ToString() : string.Empty);
      sb.AppendFormat("&skill2_h={0}", skill2_h.HasValue ? skill2_h.Value.ToString() : string.Empty);

      sb.AppendFormat("&view={0}", isClassicView ? 1 : 0);
      return new Uri(sb.ToString());
    }

    internal static Uri ConstructUri (bool isTransferMarket, byte? countryId
      , uint? price_l, uint? price_h
      , uint? value_l, uint? value_h
      , byte? age_l, byte? age_h
      , byte? height_l, byte? height_h
      , byte? defence_l, byte? defence_h
      , byte? ft_l, byte? ft_h
      , byte? tpt_l, byte? tpt_h
      , byte? thpt_l, byte? thpt_h
      , byte? dribbling_l, byte? dribbling_h
      , byte? passing_l, byte? passing_h
      , byte? speed_l, byte? speed_h
      , byte? footwork_l, byte? footwork_h
      , byte? rebound_l, byte? rebound_h
      , byte? experience_l, byte? experience_h
      , TransferListSkill skill1a, TransferListSkill skill1b, TransferListSkill skill1c, TransferListSkill skill1d, byte? skill1_l, byte? skill1_h
      , TransferListSkill skill2a, TransferListSkill skill2b, TransferListSkill skill2c, TransferListSkill skill2d, byte? skill2_l, byte? skill2_h
      , bool isClassicView
      ) 
    {
      return CharazayDownloadItem.ConstructUri(isTransferMarket, countryId
      , price_l, price_h
      , value_l, value_h
      , age_l, age_h
      , height_l, height_h
      , defence_l, defence_h
      , ft_l, ft_h
      , tpt_l, tpt_h
      , thpt_l, thpt_h
      , dribbling_l, dribbling_h
      , passing_l, passing_h
      , speed_l, speed_h
      , footwork_l, footwork_h
      , rebound_l, rebound_h
      , experience_l, experience_h
      , (byte)skill1a, (byte)skill1b, (byte)skill1c, (byte)skill1d, skill1_l, skill1_h
      , (byte)skill2a, (byte)skill2b, (byte)skill2c, (byte)skill2d, skill2_l, skill2_h
      , isClassicView);
    }

    private static string ConstructFileName (string act, byte code, ulong id)
    {
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, act);
      if (!Directory.Exists(pathCategory))
        Directory.CreateDirectory(pathCategory);

      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("{0}_{1}.htm", id, code);

      string path = Path.Combine(pathCategory, sb.ToString());
      if (!File.Exists(path))
        File.CreateText(path).Close();

      return path;
    }

    private static string ConstructFileName (string act, ulong id)
    {
      AssemblyInfo asInfo = new AssemblyInfo();
      string pathCategory = Path.Combine(asInfo.ApplicationFolder, act);
      if (!Directory.Exists(pathCategory))
        Directory.CreateDirectory(pathCategory);

      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("{0}.htm", id);

      string path = Path.Combine(pathCategory, sb.ToString());
      if (!File.Exists(path))
        File.CreateText(path).Close();

      return path;
    }

    internal CharazayDownloadItem (string act, byte code, ulong id) :
      base(ConstructUri(act, code, id), ConstructFileName(act, code, id)) { }

    internal CharazayDownloadItem (string act, ulong id) :
      base(ConstructUri(act, id), ConstructFileName(act, id)) { }
  }

  //http://www.charazay.com/index.php?act=player&code=2&id=24868821
  internal class PlayerTransferHistoryDownloadItem : CharazayDownloadItem
  {
    internal PlayerTransferHistoryDownloadItem (ulong pid) : base("player", (byte)2, pid) { }
  }

  /// <summary>
  /// download details for a Charazay (site) player page
  /// </summary>
  internal class PlayerPageDownloadItem : CharazayDownloadItem
  {
    internal PlayerPageDownloadItem (ulong pid) : base("player", (byte)1, pid) { }
  }
}
