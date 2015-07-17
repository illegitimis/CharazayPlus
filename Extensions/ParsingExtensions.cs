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

    static ParsingExtensions()
    {
      enCI = new CultureInfo("en-US", true);
      enCI.NumberFormat.NumberGroupSeparator = ".";
      enCI.NumberFormat.NumberDecimalSeparator = ",";
    }

    /// <summary>
    /// parse prices and skill index, unsigned integers 
    /// with a dot as group separator and a comma as decimal separator
    /// </summary>
    /// <param name="input">string to parse</param>
    /// <returns>parsed uint32</returns>
    internal static uint GetUInt (string input)
    {
      return String.IsNullOrWhiteSpace(input)
          ? 0
          : uint.Parse(input.Replace("&euro;", string.Empty).Trim(), NumberStyles.AllowThousands | NumberStyles.Integer, enCI);
    }

    internal static DateTime GetDate (string input)
    {
      return DateTime.ParseExact(input, "yyyy-MM-dd HH:mm", enCI);
    }
  }
}
