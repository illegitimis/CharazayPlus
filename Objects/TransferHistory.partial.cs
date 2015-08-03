using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndreiPopescu.CharazayPlus.Objects
{
  
  public partial class History
  {
    public override string ToString ( )
    {
      return String.Format("{0,-4}{2,-4}{1,-10:F02}{3,-13:F02}{4,-10:yyMMdd}", 
        this.Age, this.AgeValueIndex, this.PosId, this.Price, this.Day);
    }

    public static explicit operator Outliers (History h)
    {
      return new Outliers()
      {
        Age = h.Age,
        AgeValueIndex = h.AgeValueIndex,
        Day = h.Day,
        PosId = h.PosId,
        Price = h.Price
      };
    }
  }

  public partial class Outliers
  {
    public static explicit operator History (Outliers o)
    {
      return new History()
      {
        Age = o.Age,
        AgeValueIndex = o.AgeValueIndex,
        Day = o.Day,
        PosId = o.PosId,
        Price = o.Price
      };
    }
  }
}
