
namespace CharazayPlus.WebApi.Infrastructure
{
  using System;
  using System.Collections.Concurrent;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using System.Web;
  using CharazayPlus.WebApi.Models;

  public class ProtoBookmarksContext
  {
    

    readonly static Lazy<ProtoBookmarksContext> instance =
            new Lazy<ProtoBookmarksContext>(() => new ProtoBookmarksContext());

    readonly string CacheFile =
      System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Bookmarks.protobuf");

    readonly string CacheBackup =
      System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Bookmarks.protobuf.bak");

    /// <summary>
    /// data holder
    /// </summary>
    readonly ConcurrentDictionary<int, ProtoBookmark> Bookmarks = null;

    private ProtoBookmarksContext()
    {
      Bookmarks = new ConcurrentDictionary<int, ProtoBookmark>();

      try
      {
        DeserializeProtobuf(CacheFile);
      }
      catch 
      {
        DeserializeProtobuf(CacheBackup);
      }

      //Action WaitToPersist =() => {
      //  Thread.Sleep(TimeSpan.FromMinutes(MINUTES_BETWEEN_SERIALIZATION));
      //  Persist();
      //}; 

#pragma warning disable
      // fire and forget
      TaskExtensions.RepeatDelayAsync(
        TimeSpan.FromMinutes(MINUTES_SERIALIZATION_DELAY),
        TimeSpan.FromMinutes(MINUTES_BETWEEN_SERIALIZATION),
        CancellationToken.None,
        () => Persist()
      );
#pragma warning enable


    }

    private void DeserializeProtobuf(string fileName)
    {
      if (File.Exists(fileName))
      {
        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
          try
          {
            ProtoBookmark[] bookmarks = ProtoBuf.Serializer.Deserialize<ProtoBookmark[]>(fs);
            foreach (var b in bookmarks)
              Bookmarks.TryAdd(b.CharazayId, b);
          }
          catch
          {
            // delete badly formatted file on deserialize error
            File.Delete(CacheFile);
          }
        }
      }
    }

    ~ProtoBookmarksContext()
    {
      Persist();
    }

    const int MINUTES_BETWEEN_SERIALIZATION = 15;
    const int MINUTES_SERIALIZATION_DELAY = 5;
    readonly static object _persistLock = new object();

    private void Persist()
    {
      lock (_persistLock)
      {
        try
        {
          if (File.Exists(CacheFile))
          {
            File.Copy(CacheFile, CacheBackup, true);
            File.Delete(CacheFile);
          }
          using (var fs = new FileStream(CacheFile, FileMode.CreateNew, FileAccess.Write))
          {
            var x = Bookmarks.Select(kvp => kvp.Value).ToArray();

            ProtoBuf.Serializer.Serialize<ProtoBookmark[]>(fs, x);
            fs.Flush(true);
          }
        }
        catch
        {

        } 
      }
    }

    public static ProtoBookmarksContext Instance
    {
      get { return instance.Value; }
    }


    internal void Upsert(ProtoBookmark pb)
    {
      ProtoBookmark value;
      Bookmarks.TryRemove(pb.CharazayId, out value);
      Bookmarks.TryAdd(pb.CharazayId, pb);
    }

    internal IEnumerable<ProtoBookmark> GetBookmarks()
    {
      return Bookmarks.Values.OrderByDescending(pb => pb.Deadline);
    }

    internal IEnumerable<ProtoBookmark> GetBookmarks(int pageIndex, int pageSize)
    {
      return GetBookmarks().Skip(pageIndex * pageSize).Take(pageSize);
    }

    internal bool Delete(int playerId)
    {
      if (Bookmarks.ContainsKey(playerId))
      {
        ProtoBookmark pb;
        return Bookmarks.TryRemove(playerId, out pb);
      }
      else
      {
        return false;
      }
    }
  }
}