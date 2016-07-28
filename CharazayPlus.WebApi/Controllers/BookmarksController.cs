
namespace CharazayPlus.WebApi.Controllers
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Collections.Generic;
  using System.Web.Http;
  using CharazayPlus.WebApi.Infrastructure;
  using CharazayPlus.WebApi.Models;
  
  /// <summary>
  ///  In Web API, it's very simple to remember how parameter binding is happening.
  ///  if you POST simple types, Web API tries to bind it from the URL
  ///  if you POST complex type, Web API tries to bind it from the body of the request (this uses a media-type formatter).
  ///  If you want to bind a complex type from the URL, you'll use [FromUri] in your action parameter. 
  ///  The limitation of this is down to how long your data going to be and if it exceeds the url character limit.
  ///  public IHttpActionResult Put([FromUri] ViewModel data) { ... }
  ///  If you want to bind a simple type from the request body, you'll use [FromBody] in your action parameter.
  ///  public IHttpActionResult Put([FromBody] string name) { ... }
  /// </summary>
  public class BookmarksController : BaseController
  {
    private static readonly object _lock = new object();

    /// <summary>
    /// GET: /Bookmarks
    /// </summary>
    /// <returns>json array</returns>
    [HttpGet]
    [Route("bookmarks")]
    public IHttpActionResult Get()
    {
      var bookmarks = ProtoBookmarksContext.Instance.GetBookmarks();
      Func<ProtoBookmark, BookmarkDTO> bookmarkAdapter = x => x.Convert();
      
      return JsonCreator(bookmarks, bookmarkAdapter);
    }

    [HttpGet]
    [Route("bookmarks/{pageIndex}/{pageSize}")]
    public IHttpActionResult Get(int pageIndex, int pageSize)
    {
      var bookmarks = ProtoBookmarksContext.Instance.GetBookmarks(pageIndex, pageSize);
      Func<ProtoBookmark, BookmarkDTO> bookmarkAdapter = x => x.Convert();

      return JsonCreator(bookmarks, bookmarkAdapter);
    }

    //// GET: api/Bookmarks/5
    //public string Get(int id)
    //{
    //  return "value";
    //}

    [NonAction]
    public IHttpActionResult JsonCreator(
      IEnumerable<ProtoBookmark> bks, 
      Func<ProtoBookmark, BookmarkDTO> bookmarkAdapter
    )
    {
      try
      {
        var dtos = bks.Select(x => bookmarkAdapter(x));
        return Json(dtos, _jss);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [NonAction]
    public IHttpActionResult JsonCreator(ProtoBookmark pbk, Func<ProtoBookmark, BookmarkDTO> bookmarkAdapter)
    {
      try
      {
        BookmarkDTO dto = bookmarkAdapter(pbk);
        return Json(dto, _jss);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    #region POST

    /// <summary>
    /// POST: /bookmark
    /// <para>
    ///   $.ajax( { 
    ///   url: "http://localhost/CharazayPlus.WebApi/bookmark",
    ///   type: "POST",
    ///   data: bookmarkData 
    ///   });
    /// </para>
    /// </summary>
    /// <param name="bdto">dto built from JS e.g.</param>
    /// <returns></returns>
    [Route("bookmark")]
    [HttpPost]
    public IHttpActionResult PostJson([FromBody]BookmarkDTO bdto)
    {
      try
      {
        ProtoBookmark pb = bdto.CreateProto();
        PostData(pb);

        return Ok("PostJson BookmarkDTO");
      }
      catch
      {
        return StatusCode(System.Net.HttpStatusCode.Conflict);
      }
    }

    [NonAction]
    public void PostData([FromBody]ProtoBookmark pb)
    {
      ProtoBookmarksContext.Instance.Upsert(pb);
    }

    [NonAction]
    public void Post([FromBody]string value)
    {
      ProtoBookmark pb = ProtoBookmark.CreateProto(value);
      PostData(pb);
    }
    
    #endregion

    // PUT: api/Bookmarks/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Bookmarks/5
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    [Route("bookmark/{id}")]
    [HttpDelete]
    public IHttpActionResult /*void*/ Delete(int id)
    {
      if (ProtoBookmarksContext.Instance.Delete(id))
        return Ok("deleted");
      else
        return NotFound();
    }
  }
}
