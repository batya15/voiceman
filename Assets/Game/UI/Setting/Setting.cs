using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI {
    public class Setting : Window {

        [SerializeField]
        Slider slider;

        protected override void Awake() {
            base.Awake();
            Broadcaster.Subscribe(this, "OpenSetting");
        }


        string initiator = "";
        void OpenSetting(string i) {
            initiator = i;                           
            slider.value = Prefs.UserPrefs.sensitivity;
            Show();
        }

        void ChangedSensitivity() {
            Prefs.UserPrefs.sensitivity = slider.value;
        }

        protected override void OnClose() {
            base.OnClose();
            Broadcaster.SendEvent(initiator);
        }


    }
}
