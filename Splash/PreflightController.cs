
namespace AndreiPopescu.CharazayPlus.Splash
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Windows.Forms;
  using AndreiPopescu.CharazayPlus.UI;

  public class PreflightController
  {
    ValidationService service = new ValidationService();

    /// <summary>
    /// SplashScreen or LoginForm
    /// </summary>
    public Form SplashForm { get; private set; }
    void UpdateProgress(string s) 
    {
      if (SplashForm is SplashScreen)
        (SplashForm as SplashScreen).UpdateProgress(s);
      if (SplashForm is LoginForm)
        (SplashForm as LoginForm).Info(s);
      }

    public PreflightController (SplashScreen splashScreen) { SplashForm = splashScreen; }
    public PreflightController (LoginForm splashScreen) { SplashForm = splashScreen; }

    public bool Validate ( )
    {
      UpdateProgress("Preflight check...");

      //var validators = IoCContainer.Resolve<IEnumerable<IValidator>>();
      //var validators = CompositionProvider.Current.GetExportedValues<BaseValidator>();
      //service.AddRange(validators);
      service.AddRange(new BaseValidator[]
      {
        new WebServiceUserValidator(),
        
        new WebScraperValidator(),

        new UserInfoXmlValidator(),
        new TeamInfoXmlValidator(),

        new CountryInfoXmlValidator(), 
        new ArenaInfoXmlValidator(),
        new ScheduleXmlValidator(),
        new DivisionScheduleXmlValidator(),
        new StandingsXmlValidator(),
         new EconomyXmlValidator(),
         new TransfersXmlValidator(),

         new CoachesEnironmentValidator(),
         new PlayersEnironmentValidator(),
         new TransferBookmarksValidator(),
         
      }
        );

      service.ValidatorSucceed += delegate(IValidator validator) { UpdateProgress(validator.SuccessString); };
      service.ValidatorFailed += delegate(IValidator validator) { UpdateProgress(validator.ErrorString); };
      service.ValidatorSkipped += delegate(IValidator validator) { UpdateProgress(validator.QuestionString); };

      service.Run();

      if (service.Errors > 0)
      {
        HandleErrors();
        return false;
      }

      return true;
    }

    private void HandleErrors ( )
    {

      var messages = (from p in service.Validators.validators
                      where p.Result == ValidationResult.Error
                      select p.ErrorString + ".\r\n" + p.QuestionString + ".").ToList();



      messages.Add("The application is unable to continue and will now terminated.");
      var message = String.Join("\r\n\r\n", messages.ToArray());
      MessageBox.Show(message, "SharePoint Manager Preflight check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }


  }
}
