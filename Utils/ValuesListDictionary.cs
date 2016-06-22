

namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  public class ValuesListDictionary<K,V> : Dictionary<K,IList<V>>
  {
    public void Insert (K k, V v)
    {
      if (this.ContainsKey(k))
        this[k].Add(v);
      else
        this.Add(k, new List<V>(new V[] { v }));
    }
  }

  public class CompositeDictionary<T1,T2,T3,T4> 
    : Dictionary<Tuple<T1,T2>, List<Tuple<T3,T4>>>
  {
    public List<Tuple<T3, T4>> this[T1 t1, T2 t2] 
    { 
      get
      { 
        var key = Tuple.Create(t1,t2);
        if (this.ContainsKey(key))
          return this[key];
        else
          throw new KeyNotFoundException("composite index");
        }
      set
      {
        var key = Tuple.Create(t1, t2);
        if (this.ContainsKey(key))
          this[key] = value;
        else
          this.Add(key, value);
      }
    }

    public void Insert (T1 t1, T2 t2, T3 t3, T4 t4)
    {
      var key = Tuple.Create(t1, t2);
      if (this.ContainsKey(key))
        this[key].Add(Tuple.Create(t3, t4));
      else
      {
        var list = new List<Tuple<T3, T4>>();
        list.Add(Tuple.Create(t3, t4));
        this.Add(key, list);
      }
        
    }
  }
}
