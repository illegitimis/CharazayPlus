
namespace CharazayPlus.WebApi.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Net.Http;
  using System.Web.Http;
  using Newtonsoft.Json;

    public class BaseController : ApiController
    {
      protected readonly JsonSerializerSettings _jss = 
        new JsonSerializerSettings() { Formatting = Formatting.Indented };
    }
}
