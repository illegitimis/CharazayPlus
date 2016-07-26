
namespace CharazayPlus.WebApi.Infrastructure
{
  using System;
  using System.Collections.Concurrent;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Web;
  using CharazayPlus.WebApi.Models;

  public class ProtoBookmarksContext
  {
    readonly static Lazy<ProtoBookmarksContext> instance =
            new Lazy<ProtoBookmarksContext>(() => new ProtoBookmarksContext());

    readonly string PhysicalCacheFile =
      System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Bookmarks.protobuf");

    readonly ConcurrentDictionary<int, ProtoBookmark> Bookmarks = null;

    private ProtoBookmarksContext()
    {
      Bookmarks = new ConcurrentDictionary<int, ProtoBookmark>();
      if (File.Exists(PhysicalCacheFile))
      {
        using (var fs = new FileStream(PhysicalCacheFile, FileMode.Open, FileAccess.Read))
        {
          ProtoBookmark[] bookmarks = ProtoBuf.Serializer.Deserialize<ProtoBookmark[]>(fs);
          foreach (var b in bookmarks)
            Bookmarks.TryAdd(b.CharazayId, b);
        }
      }
    }

    ~ProtoBookmarksContext()
    {
      //Bookmarks.CompleteAdding();

      using (var fs = new FileStream(PhysicalCacheFile, FileMode.OpenOrCreate, FileAccess.Write))
      {
        //var x = Bookmarks.GetConsumingEnumerable().ToArray();
        var x = Bookmarks.Select(kvp => kvp.Value).ToArray();

        ProtoBuf.Serializer.Serialize<ProtoBookmark[]>(fs, x);
        fs.Flush(true);
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
      return Bookmarks.Values.OrderByDescending (pb => pb.Deadline);
    }

    internal IEnumerable<ProtoBookmark> GetBookmarks(int pageIndex, int pageSize)
    {
      return GetBookmarks ().Skip (pageIndex * pageSize).Take(pageSize);
    }
  }
}