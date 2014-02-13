namespace AndreiPopescu.CharazayPlus.Utils
{
  using System;
  using AssemblyCopyrightAttribute = System.Reflection.AssemblyCopyrightAttribute;
  using AssemblyCompanyAttribute = System.Reflection.AssemblyCompanyAttribute;
  using AssemblyDescriptionAttribute = System.Reflection.AssemblyDescriptionAttribute;
  using AssemblyTitleAttribute = System.Reflection.AssemblyTitleAttribute;
  using AssemblyProductAttribute = System.Reflection.AssemblyProductAttribute;
  using System.Configuration;

  #region " Helper class to get information for the About form. "
  // This class uses the System.Reflection.Assembly class to
  // access assembly meta-data
  // This class is not a normal feature of AssemblyInfo._cs
  //"This application uses information downloaded from Charazay.com"
  public class AssemblyInfo
  {
    // Used by Helper Functions to access information from Assembly Attributes

    private Type myType;

    public AssemblyInfo()
    {
      myType = typeof(AndreiPopescu.CharazayPlus.MainForm);
    }

    public string AsmName
    {

      get
      {

        return myType.Assembly.GetName().Name.ToString();

      }

    }

    public string AsmFQName
    {

      get
      {

        return myType.Assembly.GetName().FullName.ToString();

      }

    }

    /// <summary>
    /// 
    /// </summary>
    public string CodeBase { get { return myType.Assembly.CodeBase; } }

    /// <summary>
    /// 
    /// </summary>
    public string Copyright
    { 
      get
      {
        object[] r = myType.Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        AssemblyCopyrightAttribute ct = (AssemblyCopyrightAttribute)r[0];
        return ct.Copyright;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Company
    {
      get
      {
        object[] r = myType.Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        AssemblyCompanyAttribute ct = (AssemblyCompanyAttribute)r[0];
        return ct.Company;

      }

    }

    /// <summary>
    /// 
    /// </summary>
    public string Description
    {
      get
      {
        object[] r = myType.Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        AssemblyDescriptionAttribute da = (AssemblyDescriptionAttribute)r[0];
        return da.Description;
      }

    }

    public string Product
    {
      get
      {
        Type at = typeof(AssemblyProductAttribute);
        object[] r = myType.Assembly.GetCustomAttributes(at, false);
        AssemblyProductAttribute pt = (AssemblyProductAttribute)r[0];
        return pt.Product;
      }
    }

    public string Title
    {

      get
      {

        Type at = typeof(AssemblyTitleAttribute);

        object[] r = myType.Assembly.GetCustomAttributes(at, false);

        AssemblyTitleAttribute ta = (AssemblyTitleAttribute)r[0];

        return ta.Title;

      }

    }

    public string Version
    {

      get
      {

        return myType.Assembly.GetName().Version.ToString();

      }

    }

    public string ApplicationFolder
    {
      get
      {
        return System.IO.Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
          , Product);
      }
    }

  }

  #endregion
}