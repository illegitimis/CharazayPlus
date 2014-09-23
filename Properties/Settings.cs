namespace AndreiPopescu.CharazayPlus.Properties 
{
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before m setting'tlPlayer value is changed.
    //  The PropertyChanged event is raised after m setting'tlPlayer value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]  
  internal sealed partial class Settings 
      : global::System.Configuration.ApplicationSettingsBase
    {

      private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

      public static Settings Default
      {
        get
        {
          return defaultInstance;
        }
      }
          
      public Settings() 
        {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) 
        {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserName
        {
          get
          {
            return ((string)(this["UserName"]));
          }
          set { this["UserName"] = value; } 
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SecurityCode
        {
          get
          {
            return ((string)(this["SecurityCode"]));
          }
          set { this["SecurityCode"] = value; } 
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;Initial Catalog=CharazayTM;Integrated Security=True")]
        public string CharazayTM_TDS_ConnectionString
        {
          get
          {
            return ((string)(this["CharazayTM_TDS_ConnectionString"]));
          }
        }

    }
}
