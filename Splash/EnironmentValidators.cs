
namespace AndreiPopescu.CharazayPlus.Splash
{
  using System;
  using AndreiPopescu.CharazayPlus.Data;
  using AndreiPopescu.CharazayPlus.Utils;
  using AndreiPopescu.CharazayPlus.Extensions;
  using AndreiPopescu.CharazayPlus.Web;


  public class CoachesEnironmentValidator : BaseValidator
  {
    public CoachesEnironmentValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Coaches data ...";
      this.ErrorString = "Coaches data failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (PlayersEnvironment.Coaches == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.Transfers != null; } }
  }

  public class PlayersEnironmentValidator : BaseValidator
  {
    public PlayersEnironmentValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Computing player positions ...";
      this.ErrorString = "Computing player positions failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (PlayersEnvironment.OptimumPlayers == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return ! PlayersEnvironment.Coaches.IsNullOrEmpty(); } }
  }

  public class TransferBookmarksValidator : BaseValidator
  {
    public TransferBookmarksValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Deserializing transfer bookmarks ...";
      this.ErrorString = "Deserializing transfer bookmarks failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (TransferList.Bookmarks == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return !PlayersEnvironment.OptimumPlayers.IsNullOrEmpty(); } }
  }

  /// <summary>
  /// 
  /// </summary>
  public class WebScraperValidator : BaseValidator
  {
    public WebScraperValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Logging in to Charazay ...";
      this.ErrorString = "Logging in to Charazay failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      { // fire and forget
        new System.Threading.Thread(( ) => Web.Scraper.Instance.Login()).Start();
        return  ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return ! TransferList.Bookmarks.IsNullOrEmpty(); } }
  }

  public class WebServiceUserValidator : BaseValidator
  {
    public WebServiceUserValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Checking Charazay web services user data ...";
      this.ErrorString = "Charazay web services user data failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        AssignWebServiceManager();
        return (WebServiceUsers.Instance.MainUser == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return true; } }

    /// <summary>
    /// Method assigns Charazay xml web service  user information from serialized 
    /// application data to the internal <see cref="WebServiceUsers"/> singleton manager
    /// </summary>
    void AssignWebServiceManager ( )
    {
      if (WebServiceUsers.Instance.MainUser == null && !String.IsNullOrEmpty(Properties.Settings.Default.UserName))
      {
        WebServiceUsers.Instance.MainUser = new CharazayUserData();
      }
      WebServiceUsers.Instance.MainUser.User = Properties.Settings.Default.UserName;
      WebServiceUsers.Instance.MainUser.SecurityCode = Properties.Settings.Default.SecurityCode;
      /*
      if (WebServiceUsers.Instance.AlternateUser == null && !String.IsNullOrEmpty(Properties.Settings.Default.UserName2))
      {
        WebServiceUsers.Instance.AlternateUser = new CharazayUserData();
      }
      WebServiceUsers.Instance.AlternateUser.User = Properties.Settings.Default.UserName2;     
      WebServiceUsers.Instance.AlternateUser.SecurityCode = Properties.Settings.Default.SecurityCode2;
      */
    }
  }
}
