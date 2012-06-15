﻿using System.Configuration;
using System.Drawing;
using System.Collections;

namespace MarketScanner.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }


        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SettingsSerializeAs( global::System.Configuration.SettingsSerializeAs.Binary )]
        public global::MarketScanner.EveApi.EveAccount SavedAccount
        {       
            get
            {
                return ((MarketScanner.EveApi.EveAccount)(this["SavedEveAccount"]));
            }
            set
            {
                this["SavedEveAccount"] = value;
            }
        }

        //[global::System.Configuration.UserScopedSettingAttribute()]
        //[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //[global::System.Configuration.SettingsSerializeAs( global::System.Configuration.SettingsSerializeAs.Binary )]
        //public ArrayList ExeptedSystems
        //{
        //    get
        //    {
        //        return ((ArrayList)this["ExeptedSystems"]);
        //    }
        //    set
        //    {
        //        this["ExeptedSystems"] = value;
        //    }
        //}

    }
}
