using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameUI {
    public class Continue : Window {

        protected override void Awake() {
            base.Awake();
            Broadcaster.Subscribe(this, "OpenContinue");
        }

        void OpenContinue() {
            Show();
        }
    }
}
