using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndreiPopescu.CharazayPlus.Utils;

namespace AndreiPopescu.CharazayPlus.Extensions
{
  internal static class PlayerExtensions
  {
    public static PlayerPosition PlayerPositionFromHeight (byte Height)
    {
      if (Height < Defines.AverageHeightPg)
        return PlayerPosition.PG;
      else
      {
        if (Height < Defines.AverageHeightSg)
        {
          return Math.Abs(Height - Defines.AverageHeightPg) < Math.Abs(Height - Defines.AverageHeightSg) ? PlayerPosition.PG : PlayerPosition.SG;
        }
        else
        {
          if (Height < Defines.AverageHeightSf)
          {
            return Math.Abs(Height - Defines.AverageHeightSg) < Math.Abs(Height - Defines.AverageHeightSf) ? PlayerPosition.SG : PlayerPosition.SF;
          }
          else
          {
            if (Height < Defines.AverageHeightPf)
            {
              return Math.Abs(Height - Defines.AverageHeightSf) < Math.Abs(Height - Defines.AverageHeightPf) ? PlayerPosition.SF : PlayerPosition.PF;
            }
            else
            {
              if (Height < Defines.AverageHeightC)
              {
                return Math.Abs(Height - Defines.AverageHeightPf) < Math.Abs(Height - Defines.AverageHeightC) ? PlayerPosition.PF : PlayerPosition.C;
              }
              else return PlayerPosition.C;
            }
          }
        }
      }
    }

    //PlayerPosition
  }
}
