
namespace CharazayPlus.WebApi.Controllers
{
  using System.Collections.Generic;
  using System.IO;
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
  public class BookmarksController : ApiController
  {
    private static readonly object _lock = new object();

    // GET: api/Bookmarks
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Bookmarks/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Bookmarks
    [NonAction]
    public void Post([FromBody]string value)
    {
      ProtoBookmark pb = ProtoBookmark.CreateProto(value);
      PostData(pb);
    }

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

    //[Route("bookmark")]
    //[HttpPost]
    [NonAction]
    public void PostData([FromBody]ProtoBookmark pb)
    {
      ProtoBookmarksContext.Instance.Upsert(pb);      
    }

    // PUT: api/Bookmarks/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Bookmarks/5
    public void Delete(int id)
    {
    }
  }
}
