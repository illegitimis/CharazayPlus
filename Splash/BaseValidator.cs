
namespace AndreiPopescu.CharazayPlus.Splash
{
  using System;

  public abstract class BaseValidator : IValidator
  {
    //private InstallConfiguration configuration;

    const int InBetweenValidatorsSleepTimeMilliseconds = 10;

    protected BaseValidator ( ) { Id = this.GetType().Name; }

    public ValidationResult RunValidator ( )
    {
      Result = ValidationResult.Inconclusive;
      if (CanRun)
      {
        System.Threading.Thread.Sleep(InBetweenValidatorsSleepTimeMilliseconds);
        Result = Validate();
      }
      return Result;
    }

    protected abstract ValidationResult Validate ( );

    protected virtual bool CanRun { get { return true; } }

    public String QuestionString { get; set; }

    public String SuccessString { get; set; }

    public String ErrorString { get; set; }

    public String Id { get; private set; }

    public ValidationResult Result { get; set; }

    //public InstallConfiguration Configuration
    //{
    //    get
    //    {
    //        if (configuration == null)
    //            configuration = InstallConfiguration.GetConfiguration();
    //        return configuration;
    //    }
    //}
  }

  public interface IValidator
  {
    string ErrorString { get; set; }
    string Id { get; }
    string QuestionString { get; set; }
    ValidationResult Result { get; set; }
    ValidationResult RunValidator ( );
    string SuccessString { get; set; }
  }

  public enum ValidationResult { Inconclusive, Success, Error }
}
