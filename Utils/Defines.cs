
namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using SB = System.Text.StringBuilder;

  internal static class Defines
  {
    public const string ImagesDirectory = "http://www.charazay.com/images/language/";
    public const string ImagesExtension = ".png";

    public const byte ActiveHeight = 190;
    public const byte ActiveWeight = 90;

    public const byte AverageHeightPg = 186;
    public const byte AverageHeightSg = 195;
    public const byte AverageHeightSf = 204;
    public const byte AverageHeightPf = 211;
    public const byte AverageHeightC  = 220;

    public const double HeightDribblingScaleFactor = 0.1;
    public const double HeightReboundsScaleFactor = 0.1;
    public const double HeightFootworkScaleFactor = 0.075;

    public const double WeightSpeedScaleFactor = 0.1;



    public const byte DefaultForm = 4;
    public const double FormScaleFactor = 10.0;

    public static readonly double[][] ShootingPositionPercentages = new double[][]
    { new double[] {0.3, 0.6, 0.1}
    , new double[] {0.3, 0.5, 0.2}
    , new double[] {0.3, 0.4, 0.3}
    , new double[] {0.3, 0.3, 0.4}
    , new double[] {0.3, 0.2, 0.5}
    };

    public const byte CountryIdStart = 1;
    public const byte CountryIdEnd = 74;

    public static readonly Country[] Countries = new Country[] {
      new Country {Name="Padding", ShortName="xx", Id=0}
      , new Country {Name="Norway", ShortName="no", Id=1}
      , new Country {Name="Denmark", ShortName="dk", Id=2}
      , new Country {Name="Sweden", ShortName="se", Id=3}
      , new Country {Name="United States", ShortName="us", Id=4}
      , new Country {Name="Romania", ShortName="ro", Id=5}
      , new Country {Name="Poland", ShortName="pl", Id=6}
      , new Country {Name="Netherlands", ShortName="nl", Id=7}
      , new Country {Name="Lithuania", ShortName="lt", Id=8}
      , new Country {Name="Italy", ShortName="it", Id=9}
      , new Country {Name="Israel", ShortName="il", Id=10}
      , new Country {Name="Greece", ShortName="gr", Id=11}
      , new Country {Name="Spain", ShortName="es", Id=12}
      , new Country {Name="United Kingdom", ShortName="en", Id=13}
      , new Country {Name="Estonia", ShortName="ee", Id=14}
      , new Country {Name="Canada", ShortName="ca", Id=15}
      , new Country {Name="Brazil", ShortName="br", Id=16}
      , new Country {Name="Belgium", ShortName="be", Id=17}
      , new Country {Name="France", ShortName="fr", Id=18}
      , new Country {Name="Germany", ShortName="de", Id=19}
      , new Country {Name="Slovenia", ShortName="si", Id=20}
      , new Country {Name="Uruguay", ShortName="uy", Id=21}
      , new Country {Name="Latvia", ShortName="lv", Id=22}
      , new Country {Name="Chile", ShortName="cl", Id=23}
      , new Country {Name="Portugal", ShortName="pt", Id=24}
      , new Country {Name="Finland", ShortName="fi", Id=25}
      , new Country {Name="Argentina", ShortName="ar", Id=26}
      , new Country {Name="Australia", ShortName="au", Id=27}
      , new Country {Name="Serbia", ShortName="rs", Id=28}
      , new Country {Name="Croatia", ShortName="hr", Id=29}
      , new Country {Name="Austria", ShortName="at", Id=30}
      , new Country {Name="Albania", ShortName="al", Id=31}
      , new Country {Name="Belarus", ShortName="by", Id=32}
      , new Country {Name="Bolivia", ShortName="bo", Id=33}
      , new Country {Name="Bosnia & Herzegovina", ShortName="ba", Id=34}
      , new Country {Name="Bulgaria", ShortName="bg", Id=35}
      , new Country {Name="Cameroon", ShortName="cm", Id=36}
      , new Country {Name="Czech,Republic", ShortName="cz", Id=37}
      , new Country {Name="Cyprus", ShortName="cy", Id=38}
      , new Country {Name="Colombia", ShortName="co", Id=39}
      , new Country {Name="Egypt", ShortName="eg", Id=40}
      , new Country {Name="Georgia", ShortName="gg", Id=41}
      , new Country {Name="Macedonia", ShortName="mk", Id=42}
      , new Country {Name="India", ShortName="id", Id=43}
      , new Country {Name="Jamaica", ShortName="jm", Id=44}
      , new Country {Name="Mexico", ShortName="mx", Id=45}
      , new Country {Name="Nigeria", ShortName="ng", Id=46}
      , new Country {Name="Saudi,Arabia", ShortName="sa", Id=47}
      , new Country {Name="Slovakia", ShortName="sk", Id=48}
      , new Country {Name="Korea", ShortName="kr", Id=49}
      , new Country {Name="Ukraine", ShortName="ua", Id=50}
      , new Country {Name="Hungary", ShortName="hu", Id=51}
      , new Country {Name="China", ShortName="cn", Id=52}
      , new Country {Name="Russia", ShortName="ru", Id=53}
      , new Country {Name="Turkey", ShortName="tr", Id=54}
      , new Country {Name="Philippines", ShortName="pi", Id=55}
      , new Country {Name="Japan", ShortName="jp", Id=56}
      , new Country {Name="Thailand", ShortName="th", Id=57}
      , new Country {Name="Singapore", ShortName="sg", Id=58}
      , new Country {Name="New,Zealand", ShortName="nz", Id=59}
      , new Country {Name="Armenia", ShortName="am", Id=60}
      , new Country {Name="Azerbaijan", ShortName="az", Id=61}
      , new Country {Name="Ghana", ShortName="gh", Id=62}
      , new Country {Name="Iceland", ShortName="is", Id=63}
      , new Country {Name="Iran", ShortName="ir", Id=64}
      , new Country {Name="Ivory Coast", ShortName="ci", Id=65}
      , new Country {Name="Paraguay", ShortName="py", Id=66}
      , new Country {Name="Peru", ShortName="pe", Id=67}
      , new Country {Name="Senegal", ShortName="sn", Id=68}
      , new Country {Name="South,Africa", ShortName="za", Id=69}
      , new Country {Name="Switzerland", ShortName="ch", Id=70}
      , new Country {Name="Tunisia", ShortName="tn", Id=71}
      , new Country {Name="Venezuela", ShortName="ve", Id=72}
      , new Country {Name="Taiwan", ShortName="tw", Id=73}
      , new Country {Name="Puerto Rico", ShortName="pr", Id=74}
    };
  }

  internal struct Country
  {
    /// <summary>
    /// represents Charazay db country id
    /// </summary>
    public UInt16 Id;
    /// <summary>
    /// Charazay abbreviated country name
    /// </summary>
    public string ShortName;
    /// <summary>
    /// English country name 
    /// </summary>
    public string Name;
  }



  internal static class Custom
  {
    internal static TabType tabTypeAll = TabType.status | TabType.skills | TabType.position;
    internal static string TagName = ToString(tabTypeAll);
    internal static string TagStatus = ToString(TabType.status);
    internal static string TagSkills = ToString(TabType.skills);
    internal static string TagPosition = ToString(TabType.position);

    internal static string ToString (TabType tt)
    {
      SB sb = new SB();
      if ((tt & TabType.skills) != 0)
        sb.Append(TabType.skills);
      if ((tt & TabType.position) != 0)
        sb.Append(TabType.position);
      if ((tt & TabType.status) != 0)
        sb.Append(TabType.status);
      return sb.ToString();
    }
  }

  //public static class CustomSequenceOperators
  //{
  //  public static System.Collections.Generic.IEnumerable<T> Combine(
  //    this System.Collections.Generic.IEnumerable<T> first
  //    , System.Collections.Generic.IEnumerable<T> second, Func<T> func)
  //  {
  //    using (System.Collections.Generic.IEnumerator<T> e1 = first.GetEnumerator()
  //      , e2 = second.GetEnumerator())
  //    {
  //      while (e1.MoveNext() && e2.MoveNext())
  //      {
  //        yield return func(e1.Current, e2.Current);
  //      }
  //    }
  //  }
  //}
}
