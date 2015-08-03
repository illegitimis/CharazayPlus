
namespace AndreiPopescu.CharazayPlus.Splash
{
  using System;
  using System.Diagnostics;
  using System.ComponentModel;
  using AndreiPopescu.CharazayPlus.Extensions;
  using AndreiPopescu.CharazayPlus.Data;
  
  public class UserInfoXmlValidator : BaseValidator
  {
    public UserInfoXmlValidator ( )
      : base()
    {
      this.QuestionString = "Please ensure internet connection is up and running";
      this.SuccessString = "User information xml was downloaded";
      this.ErrorString = "The current user is not administrator";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.UserInfo == null) ? ValidationResult.Error : ValidationResult.Success;        
      }
      catch (UnauthorizedAccessException ex)
      {
        Trace.Fail(ex.Message, ex.StackTrace);        
      }
      catch (Win32Exception ex)
      {
        Trace.TraceError(ex.GetMessages());
      }
      catch (InvalidOperationException ex)
      {
        Trace.TraceError(ex.GetMessages());
      }

      return ValidationResult.Inconclusive;
    }

    protected override bool CanRun { get { return true; } }
  }

  public class TeamInfoXmlValidator : BaseValidator
  {
    public TeamInfoXmlValidator ( )
      : base()
    {
      this.QuestionString = "Please ensure internet connection is up and running";
      this.SuccessString = "Team information xml was downloaded";
      this.ErrorString = "The current team info is missing!";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        if (MyXmlTeam.TeamInfo == null)
          return ValidationResult.Error;
        return ValidationResult.Success;
      }
      catch (UnauthorizedAccessException ex)
      {
        Trace.Fail(ex.Message, ex.StackTrace);
      }
      catch (Win32Exception ex)
      {
        Trace.TraceError(ex.GetMessages());
      }
      catch (InvalidOperationException ex)
      {
        Trace.TraceError(ex.GetMessages());
      }

      return ValidationResult.Inconclusive;
    }

    protected override bool CanRun { get { return MyXmlTeam.UserInfo != null; } }
  }
}
