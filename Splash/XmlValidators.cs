
namespace AndreiPopescu.CharazayPlus.Splash
{
  using System;
  using AndreiPopescu.CharazayPlus.Data;
  using AndreiPopescu.CharazayPlus.Utils;

  public class CountryInfoXmlValidator : BaseValidator
  {

    public CountryInfoXmlValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting country information ...";
      this.ErrorString = "Ccountry information failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.CountryInfo == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.TeamInfo != null; } }
  }

  public class ArenaInfoXmlValidator : BaseValidator
  {
    public ArenaInfoXmlValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting arena information ...";
      this.ErrorString = "Arena information failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.Arena == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.CountryInfo != null; } }
  }

  public class ScheduleXmlValidator : BaseValidator
  {
    public ScheduleXmlValidator ( ) : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting team schedule ...";
      this.ErrorString = "Team schedule failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.Schedule == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.Arena != null; } }
  }

  public class DivisionScheduleXmlValidator : BaseValidator
  {

    public DivisionScheduleXmlValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting division schedule ...";
      this.ErrorString = "Division schedule failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.DivisionSchedule == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.Schedule != null; } }
  }

  public class StandingsXmlValidator : BaseValidator
  {

    public StandingsXmlValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting standings ...";
      this.ErrorString = "Standings failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.Standings == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.DivisionSchedule != null; } }
  }

  public class EconomyXmlValidator : BaseValidator
  {

    public EconomyXmlValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting economy info";
      this.ErrorString = "Economy info failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.Economy == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.Standings != null; } }
  }

  public class TransfersXmlValidator : BaseValidator
  {

    public TransfersXmlValidator ( )
      : base()
    {
      this.QuestionString = Defines.InternetConnection;
      this.SuccessString = "Getting team transfers ...";
      this.ErrorString = "Team transfers failure";
    }

    protected override ValidationResult Validate ( )
    {
      try
      {
        return (MyXmlTeam.Transfers == null) ? ValidationResult.Error : ValidationResult.Success;
      }
      catch (Exception ex)
      {
        throw new ValidatorExcpetion(ex.Message, ex);
      }
    }

    protected override bool CanRun { get { return MyXmlTeam.Economy != null; } }
  }
}
