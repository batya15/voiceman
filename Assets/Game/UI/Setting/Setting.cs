using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI {
    public class Setting : Window {

        protected override void Awake() {
            base.Awake();
            Broadcaster.Subscribe(this, "OpenSetting");
        }


        string initiator = "";
        void OpenSetting(string i) {
            initiator = i;
            Show();
        }

        protected override void OnClose() {
            base.OnClose();
            Broadcaster.SendEvent(initiator);
        }


    }
}
