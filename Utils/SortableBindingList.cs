/*
 * Copied from http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=65826&SiteID=1
 * Posted by Joe Stegman
 * http://blogs.msdn.com/b/winformsue/archive/2008/05/19/implementing-filtering-on-the-ibindinglistview.aspx
 * http://www.microsoft.com/en-us/download/details.aspx?id=17914
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AndreiPopescu.CharazayPlus.Utils
{
  [Serializable()]
  public class SortableBindingList<T> : BindingList<T>, IBindingListView
  {
    private bool _isSorted;
    private ListSortDirection _dir = ListSortDirection.Ascending;

    [NonSerialized()]
    private PropertyDescriptor _sort = null;

    public SortableBindingList(IList<T> list)
      : base (list)
    { 
    }

    #region BindingList<T> Public Sorting API
    public void Sort()
    {
      ApplySortCore(_sort, _dir);
    }

    public void Sort(string property)
    {
      /* Get the PD */
      _sort = FindPropertyDescriptor(property);

      /* Sort */
      ApplySortCore(_sort, _dir);
    }

    public void Sort(string property, ListSortDirection direction)
    {
      /* Get the sort property */
      _sort = FindPropertyDescriptor(property);
      _dir = direction;

      /* Sort */
      ApplySortCore(_sort, _dir);
    }
    #endregion

    #region BindingList<T> Sorting Overrides
    protected override bool SupportsSortingCore
    {
      get { return true; }
    }

    protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
    {
      List<T> items = this.Items as List<T>;
      T[] items2 = this.Items as T[];
      
      if ((null != items) && (null != property))
      {
        PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
        items.Sort(pc);

        /* Set sorted */
        _isSorted = true;
      }
      else if ((null != items2) && (null != property))
      {
        PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
        Array.Sort<T>(items2, pc);

        /* Set sorted */
        _isSorted = true;
      }
      else
      {
        /* Set sorted */
        _isSorted = false;
      }
    }

    protected override bool IsSortedCore
    {
      get { return _isSorted; }
    }

    protected override void RemoveSortCore()
    {
      _isSorted = false;
    }
    #endregion

    #region BindingList<T> Private Sorting API
    private PropertyDescriptor FindPropertyDescriptor(string property)
    {
      PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(typeof(T));
      PropertyDescriptor prop = null;

      if (null != pdc)
      {
        prop = pdc.Find(property, true);
      }

      return prop;
    }
    #endregion

    #region PropertyComparer<TKey>
    internal class PropertyComparer<TKey> : System.Collections.Generic.IComparer<TKey>
    {
      /*
      * The following code contains code implemented by Rockford Lhotka:
      * //msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadvnet/html/vbnet01272004.asp" 
       * href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadvnet/html/vbnet01272004.asp">
       * http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadvnet/html/vbnet01272004.asp
      */

      private PropertyDescriptor _property;
      private ListSortDirection _direction;

      public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
      {
        _property = property;
        _direction = direction;
      }

      public int Compare(TKey xVal, TKey yVal)
      {
        /* Get property values */
        object xValue = GetPropertyValue(xVal, _property.Name);
        object yValue = GetPropertyValue(yVal, _property.Name);

        /* Determine sort order */
        if (_direction == ListSortDirection.Ascending)
        {
          return CompareAscending(xValue, yValue);
        }
        else
        {
          return CompareDescending(xValue, yValue);
        }
      }

      public bool Equals(TKey xVal, TKey yVal)
      {
        return xVal.Equals(yVal);
      }

      public int GetHashCode(TKey obj)
      {
        return obj.GetHashCode();
      }

      /* Compare two property values of any type */
      private int CompareAscending(object xValue, object yValue)
      {
        int result;

        /* If values implement IComparer */
        if (xValue is IComparable)
        {
          result = ((IComparable)xValue).CompareTo(yValue);
        }
        /* If values don'm implement IComparer but are equivalent */
        else if (xValue.Equals(yValue))
        {
          result = 0;
        }
        /* Values don'm implement IComparer and are not equivalent, so compare as string values */
        else result = xValue.ToString().CompareTo(yValue.ToString());

        /* Return result */
        return result;
      }

      private int CompareDescending(object xValue, object yValue)
      {
        /* Return result adjusted for ascending or descending sort order ie
           multiplied by 1 for ascending or -1 for descending */
        return CompareAscending(xValue, yValue) * -1;
      }

      private object GetPropertyValue(TKey value, string property)
      {
        /* Get property */
        PropertyInfo propertyInfo = value.GetType().GetProperty(property);

        /* Return value */
        return propertyInfo.GetValue(value, null);
      }
    }
    #endregion

    #region Find
    protected override bool SupportsSearchingCore
    {
      get
      {
        return true;
      }
    }

    protected override int FindCore(PropertyDescriptor prop, object key)
    {
      return FindCore(prop, key, 0, Count);
    }

    private int FindCore(PropertyDescriptor prop, object key, int start, int end)
    {
      if (start < 0 || start > Count - 1 || end < 1 || end > Count)
        throw new ArgumentException("FindCore");
      
      // Get the property info for the specified property.
      PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
      T item;

      if (key != null)
      {
        // Loop through the the items to see if the key
        // value matches the property value.
        for (int i = start; i < end; ++i)
        {
          item = (T)Items[i];
          if (propInfo.GetValue(item, null).Equals(key))
            return i;
        }
      }
      return -1;
    }

    public int Find(string property, object key)
    {
      // Check the properties for a property with the specified name.
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
      PropertyDescriptor prop = properties.Find(property, true);
      //
      // If there is not a match, return -1 otherwise pass search to FindCore method.
      //
      return (prop == null) ? -1 : FindCore(prop, key);
    }
    #endregion

    #region Filtering

    public bool SupportsFiltering
    {
      get { return true; }
    }

    public void RemoveFilter()
    {
      if (Filter != null) Filter = null;
    }

    private string filterValue = null;

    public string Filter
    {
      get
      {
        return filterValue;
      }
      set
      {
        if (filterValue == value) return;

        // If the value is not null or empty, but doesn'm
        // match expected format, throw an exception.
        if (!string.IsNullOrEmpty(value) &&
            !Regex.IsMatch(value,
            BuildRegExForFilterFormat(), RegexOptions.Singleline))
          throw new ArgumentException("Filter is not in " +
                "the format: propName[<>=]'value'.");

        //Turn off list-changed events.
        RaiseListChangedEvents = false;

        // If the value is null or empty, reset list.
        if (string.IsNullOrEmpty(value))
          ResetList();
        else
        {
          int count = 0;
          string[] matches = value.Split(new string[] { " AND " },
              StringSplitOptions.RemoveEmptyEntries);

          while (count < matches.Length)
          {
            string filterPart = matches[count].ToString();

            // Check to see if the filter was set previously.
            // Also, check if current filter is a subset of 
            // the previous filter.
            if (!String.IsNullOrEmpty(filterValue)
                    && !value.Contains(filterValue))
              ResetList();

            // Parse and apply the filter.
            SingleFilterInfo filterInfo = ParseFilter(filterPart);
            ApplyFilter(filterInfo);
            count++;
          }
        }
        // Set the filter value and turn on list changed events.
        filterValue = value;
        RaiseListChangedEvents = true;
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
      }
    }


    // Build a regular expression to determine if 
    // filter is in correct format.
    public static string BuildRegExForFilterFormat()
    {
      StringBuilder regex = new StringBuilder();

      // Look for optional literal brackets, 
      // followed by word characters or space.
      regex.Append(@"\[?[\w\s]+\]?\s?");

      // Add the operators: > < or =.
      regex.Append(@"[><=]");

      //Add optional space followed by optional quote and
      // any character followed by the optional quote.
      regex.Append(@"\s?'?.+'?");

      return regex.ToString();
    }

    private void ResetList()
    {
      IList<T> items_ = this.Items;
      this.ClearItems();
      
      //foreach (T m in originalListValue)
        //this.Items.Add(m);
      foreach (T t in items_)
        this.Items.Add(t);
      if (IsSortedCore)
        ApplySortCore(SortPropertyCore, SortDirectionCore);
    }


    protected override void OnListChanged(ListChangedEventArgs e)
    {
      // If the list is reset, check for a filter. If a filter 
      // is applied don'm allow items to be added to the list.
      if (e.ListChangedType == ListChangedType.Reset)
      {
        AllowNew = (Filter == null || Filter == "");        
      }
      // Add the new item to the original list.
      if (e.ListChangedType == ListChangedType.ItemAdded)
      {
        Items.Add(this[e.NewIndex]);
        if (!String.IsNullOrEmpty(Filter))
        //if (Filter == null || Filter == "")
        {
          string cachedFilter = this.Filter;
          this.Filter = "";
          this.Filter = cachedFilter;
        }
      }
      // Remove the new item from the original list.
      if (e.ListChangedType == ListChangedType.ItemDeleted)
        Items.RemoveAt(e.NewIndex);

      base.OnListChanged(e);
    }


    internal void ApplyFilter(SingleFilterInfo filterParts)
    {
      List<T> results;

      // Check to see if the property type we are filtering by implements
      // the IComparable interface.
      Type interfaceType =
          TypeDescriptor.GetProperties(typeof(T))[filterParts.PropName]
          .PropertyType.GetInterface("IComparable");

      if (interfaceType == null)
        throw new InvalidOperationException("Filtered property" +
        " must implement IComparable.");

      results = new List<T>();

      // Check each value and add to the results list.
      foreach (T item in this)
      {
        if (filterParts.PropDesc.GetValue(item) != null)
        {
          IComparable compareValue =
              filterParts.PropDesc.GetValue(item) as IComparable;
          int result =
              compareValue.CompareTo(filterParts.CompareValue);
          if (filterParts.OperatorValue ==
              FilterOperator.EqualTo && result == 0)
            results.Add(item);
          if (filterParts.OperatorValue ==
              FilterOperator.GreaterThan && result > 0)
            results.Add(item);
          if (filterParts.OperatorValue ==
              FilterOperator.LessThan && result < 0)
            results.Add(item);
        }
      }
      this.ClearItems();
      foreach (T itemFound in results)
        this.Add(itemFound);
    }

    internal SingleFilterInfo ParseFilter(string filterPart)
    {
      SingleFilterInfo filterInfo = new SingleFilterInfo();
      filterInfo.OperatorValue = DetermineFilterOperator(filterPart);

      string[] filterStringParts =
          filterPart.Split(new char[] { (char)filterInfo.OperatorValue });

      filterInfo.PropName =
          filterStringParts[0].Replace("[", "").
          Replace("]", "").Replace(" AND ", "").Trim();

      // Get the property descriptor for the filter property name.
      PropertyDescriptor filterPropDesc =
          TypeDescriptor.GetProperties(typeof(T))[filterInfo.PropName];

      // Convert the filter compare value to the property type.
      if (filterPropDesc == null)
        throw new InvalidOperationException("Specified property to " +
            "filter " + filterInfo.PropName +
            " on does not exist on type: " + typeof(T).Name);

      filterInfo.PropDesc = filterPropDesc;

      string comparePartNoQuotes = StripOffQuotes(filterStringParts[1]);
      try
      {
        TypeConverter converter =
            TypeDescriptor.GetConverter(filterPropDesc.PropertyType);
        filterInfo.CompareValue =
            converter.ConvertFromString(comparePartNoQuotes);
      }
      catch (NotSupportedException)
      {
        throw new InvalidOperationException("Specified filter" +
            "value " + comparePartNoQuotes + " can not be converted" +
            "from string. Implement a type converter for " +
            filterPropDesc.PropertyType.ToString());
      }
      return filterInfo;
    }

    internal FilterOperator DetermineFilterOperator(string filterPart)
    {
      // Determine the filter's operator.
      if (Regex.IsMatch(filterPart, "[^>^<]="))
        return FilterOperator.EqualTo;
      else if (Regex.IsMatch(filterPart, "<[^>^=]"))
        return FilterOperator.LessThan;
      else if (Regex.IsMatch(filterPart, "[^<]>[^=]"))
        return FilterOperator.GreaterThan;
      else
        return FilterOperator.None;
    }

    internal static string StripOffQuotes(string filterPart)
    {
      // Strip off quotes in compare value if they are present.
      if (Regex.IsMatch(filterPart, "'.+'"))
      {
        int quote = filterPart.IndexOf('\'');
        filterPart = filterPart.Remove(quote, 1);
        quote = filterPart.LastIndexOf('\'');
        filterPart = filterPart.Remove(quote, 1);
        filterPart = filterPart.Trim();
      }
      return filterPart;
    }

    public struct SingleFilterInfo
    {
      internal string PropName;
      internal PropertyDescriptor PropDesc;
      internal Object CompareValue;
      internal FilterOperator OperatorValue;
    }

    // Enum to hold filter operators. The chars 
    // are converted to their integer values.
    public enum FilterOperator
    {
      EqualTo = '=',
      LessThan = '<',
      GreaterThan = '>',
      None = ' '
    }


    #endregion Filtering

    #region AdvancedSorting
    public bool SupportsAdvancedSorting
    {
      get { return false; }
    }
    public ListSortDescriptionCollection SortDescriptions
    {
      get { return null; }
    }

    public void ApplySort(ListSortDescriptionCollection sorts)
    {
      throw new NotSupportedException();
    }

    #endregion AdvancedSorting
  }
}
