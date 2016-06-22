using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace AndreiPopescu.CharazayPlus.Extensions
{
  class ParsingExtensions
  {
    static readonly CultureInfo enCI;
    static readonly CultureInfo roCI;

    static readonly CultureInfo[] cultures = new CultureInfo[] { enCI, roCI, CultureInfo.InvariantCulture };
    static readonly NumberStyles[] numberStyles = new NumberStyles[] { NumberStyles.AllowThousands|NumberStyles.Integer, NumberStyles.AllowThousands};


    static ParsingExtensions()
    {
      enCI = new CultureInfo("en-US", true);
      enCI.NumberFormat.NumberGroupSeparator = ".";
      enCI.NumberFormat.NumberDecimalSeparator = ",";

      roCI = new CultureInfo("ro-RO", true);
      roCI.NumberFormat.NumberGroupSeparator = ",";
      roCI.NumberFormat.NumberDecimalSeparator = ".";
    }

    /// <summary>
    /// parse prices and skill index, unsigned integers 
    /// with a dot as group separator and a comma as decimal separator
    /// </summary>
    /// <param name="input">string to parse</param>
    /// <returns>parsed uint32</returns>
    internal static uint GetUInt (string input)
    {
      if (String.IsNullOrWhiteSpace(input))
        return 0;
      else
      {
        uint result = 0;
        bool parsed = false;

        input = input.Replace("&euro;", string.Empty).Trim();

        foreach (var ci in cultures)
        {
          if (parsed)
            break;

          foreach (var ns in numberStyles)
          {
            if (parsed)
              break;

            if (uint.TryParse(input, ns, ci, out result))
              parsed = true;
            else
              continue;
          }
        }
          
 return result;
      }

     
        
    }

    internal static DateTime GetDate (string input)
    {
      return DateTime.ParseExact(input, "yyyy-MM-dd HH:mm", enCI);
    }
  }
}
