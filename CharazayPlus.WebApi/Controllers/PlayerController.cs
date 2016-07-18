namespace CharazayPlus.WebApi.Controllers
{
  using System;
  using System.Linq;
  using System.Web.Http;
  using AndreiPopescu.CharazayPlus;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.Xsd2;
  using CharazayPlus.WebApi.Models;
  using Newtonsoft.Json;

  /// <summary>
  /// 
  /// </summary>
  /// <remarks>
  /// <para>
  /// /// http://enable-cors.org/server_aspnet.html
  /// Get-Project CharazayPlus.WebApi | Install-Package Microsoft.AspNet.WebApi.Cors -Verbose
  /// </para>  
  /// </remarks>
  public class PlayerController : ApiController
  {
    static readonly IDecidePlayerPositionAlgorithm smart = new DecidePlayerPositionAggregatorAlgorithm();
    static readonly IDecidePlayerPositionAlgorithm facets = new FacetsAlgorithm();

    [HttpGet]
    [Route("player/test1")]
    public IHttpActionResult Test1()
    {
      // return a Json Object, you could define a new class
      //return Json(new { Success = true, Message = "Success" });
      return Ok(new { Success = true, Message = "test 1" });
    }

    [HttpGet]
    [Route("player/test2")]
    public IHttpActionResult Test2()
    {
      // return a Json Object, you could define a new class
      return Json(new { Success = true, Message = "test 2" });
    }

    //GET /player/aggregate?base64StringState=D890BCUFBAUHAgQFCQcB
    [Route("player/aggregate/{base64StringState}")]
    public IHttpActionResult GetAggregatedBestPlayers(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => eval.Best2(smart).Select(PlayerDTOCreator));
    }


    //GET /player/aggregate/top?base64StringState=G75RAAsRCQYHEAYYBQQT
    [Route("player/aggregate/top/{base64StringState}")]
    public IHttpActionResult GetAggregatedBestPlayer(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.Best(smart)));
    }

    [Route("player/facets/{base64StringState}")]
    public IHttpActionResult GetFacetsBestPlayers(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => eval.Best2(facets).Select(PlayerDTOCreator));
    }

    [Route("player/facets/top/{base64StringState}")]
    public IHttpActionResult GetFacetsBestPlayer(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.Best(facets)));
    }

    [Route("player/C/{base64StringState}")]
    public IHttpActionResult GetCenter(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.C));
    }

    [Route("player/PF/{base64StringState}")]
    public IHttpActionResult GetPowerForward(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.PF));
    }

    [Route("player/SF/{base64StringState}")]
    public IHttpActionResult GetSmallForward(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.SF));
    }

    [Route("player/SG/{base64StringState}")]
    public IHttpActionResult GetShootingGuard(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.SG));
    }

    [Route("player/PG/{base64StringState}")]
    public IHttpActionResult GetPointGuard(string base64StringState)
    {
      return JsonCreator(base64StringState, eval => PlayerDTOCreator(eval.PG));
    }

    charazayPlayer CreateXsdPlayerFromByteArray(byte[] byteArray)
    {
      var basic = new charazayPlayerBasic()
      {
        age = byteArray[0],
        height = byteArray[1],
        weight = byteArray[2]
      };

      var status = new charazayPlayerStatus()
      {
        form = byteArray[3],
        fatigue = byteArray[4]
      };

      var skills = new charazayPlayerSkills()
      {
        defence = byteArray[5],
        freethrow = byteArray[6],
        twopoint = byteArray[7],
        threepoint = byteArray[8],
        dribling = byteArray[9],
        passing = byteArray[10],
        speed = byteArray[11],
        footwork = byteArray[12],
        rebounds = byteArray[13],
        experience = byteArray[14]
      };

      return new charazayPlayer() { skills = skills, basic = basic, status = status };
    }

    static Func<Player, PlayerDTO> PlayerDTOCreator = best => new PlayerDTO
    {
      Position = best.PositionEnum
        ,
      ValueIndex = best.ValueIndex
        ,
      TotalScore = best.TotalScore
        ,
      DefensiveScore = best.DefensiveScore
        ,
      OffensiveScore = best.OffensiveScore
        ,
      OffensiveAbility = best.OffensiveAbilityScore
        ,
      ShootingScore = best.ShootingScore
        ,
      TransferMarketValue = best.TransferMarketValue
    };

    static readonly JsonSerializerSettings _jss = new JsonSerializerSettings() { Formatting = Formatting.Indented };

    [NonAction]
    public IHttpActionResult JsonCreator(string base64StringState, Func<PlayerEvaluator, object> objectSelector)
    {
      // http://stackoverflow.com/questions/16527742/web-api-get-route-values
      //var rd = System.Web.HttpContext.Current.Request.RequestContext.RouteData;
      //System.Web.Http.Routing.IHttpRouteData routeData = Request.GetRouteData();

      //byteArray = new byte[] { 15, 207, 116, 4, 37, 5, 4, 5, 7, 2, 4, 5, 9, 7, 1 };
      //D890BCUFBAUHAgQFCQcB

      byte[] result = Convert.FromBase64String(base64StringState);

      if (result == null || result.Length != 15)
        return BadRequest(string.Join("; ", result));

      charazayPlayer p = CreateXsdPlayerFromByteArray(result);

      PlayerEvaluator eval = new PlayerEvaluator(p);

      var @object = objectSelector(eval);

      //return Ok(@object);

      return Json(@object, _jss);

    }
  }

}
