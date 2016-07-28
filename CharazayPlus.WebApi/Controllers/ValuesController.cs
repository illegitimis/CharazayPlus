using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CharazayPlus.WebApi.Controllers
{
  public class ValuesController : ApiController
  {
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    public string Get(int id)
    {
      return "value";
    }


    // POST api/values
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }

    [HttpGet]
    [Route("css/bookmark")]
    public IHttpActionResult BookmarkTableCss()
    {
      string bookmarkTableCssFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/tblbkmrk.css");
      string cssContent = "";
      using (var fs = File.OpenRead(bookmarkTableCssFilePath))
      using (var sr = new StreamReader(fs))
      {
        cssContent = sr.ReadToEnd();
      }
      return Ok(new { Css = cssContent });
    }
  }
}
