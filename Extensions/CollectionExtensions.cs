
namespace AndreiPopescu.CharazayPlus.Extensions
{
#if DOTNET30
    using System;
    using System.Linq;
    using System.Collections.Generic;
#endif
 
   public static class CollectionExtensions
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
    public static bool IsNullOrEmpty (this Array ar)
#else
    public static bool IsNullOrEmpty (System.Array ar)
#endif
    {
      return ar == null || ar.Length == 0;
    }

    
#if DOTNET30
    public static bool IsNullOrEmpty<T> (this IEnumerable<T> enumerable)
    {
        return enumerable == null || enumerable.Count() == 0;
    }
#else
    public static bool IsNullOrEmpty<T> (System.Collections.Generic.IEnumerable<T> ar)
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
            return enumerator.Current == null;
        }
        catch { return true; }
      }
    }
#endif
    

#if DOTNET30
    public static bool IsNullOrEmpty<K,V> (this System.Collections.Generic.IDictionary<K,V> ar)
#else
      public static bool IsNullOrEmpty<K,V> (System.Collections.Generic.IDictionary<K,V> ar)
#endif
    {
      return (ar == null) || ar.Count == 0;            
    }

       


  }


  


}
