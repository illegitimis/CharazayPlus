
namespace AndreiPopescu.CharazayPlus
{
  internal static class Extensions
  {
#if DOTNET30
    public static bool IsNullOrEmpty<T> (this T[] ar)
#else
    public static bool IsNullOrEmpty<T> (T[] ar)
#endif
    
    {    
      return ar == null || ar.Length == 0;
    }

#if DOTNET30
        public static bool IsNullOrEmpty<T> (this IEnumerable<T> ar)
#else
    public static bool IsNullOrEmpty<T> (System.Collections.Generic.IEnumerable<T> ar)
#endif
    {
      if (ar == null)
      {
        return true;
      }
      else
      {
        try
        {
          var enumerator = ar.GetEnumerator();
          if (!enumerator.MoveNext())
            return true;
          else
            return enumerator.Current != null;
        }
        catch { return true; }
      }
    }

    public static bool IsNullOrEmpty<K,V> (System.Collections.Generic.IDictionary<K,V> ar)

    {
      return (ar == null) || ar.Count == 0;      
      
    }


  
  
  }


}
