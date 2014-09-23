using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndreiPopescu.CharazayPlus.Data
{
  /// <summary>
  /// singleton wrapper for the transfer history data context
  /// </summary>
  class DbEnvironment
  {
    Objects.TransferHistoryDataContext _dc = null;

    public Objects.TransferHistoryDataContext TransferHistoryDC { get { lock (sync) { return this._dc; } } }

    #region singleton
    private static object sync = new object();

    public static DbEnvironment Instance
    {
      get { lock (sync) { return SingletonCreator.dbenv; } }
    }

    private static class SingletonCreator
    {
      static SingletonCreator ( )
      {
        dbenv = new DbEnvironment();
      }

      internal static readonly DbEnvironment dbenv = null;
    }

    DbEnvironment ( )
    {
      if (this._dc == null) this._dc = new Objects.TransferHistoryDataContext();
    }
    #endregion

  }
}
