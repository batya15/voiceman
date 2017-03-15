using Voiceman;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI {
    public class FirstMenu : Window {

        protected override void Awake() {
            base.Awake();
            Broadcaster.Subscribe(this, "OpenFirstMenu");
        }

        void Start() {
            Show();
        }

        void Play() {
            Close();
            Voiceman.GameState.state = Voiceman.GAME_STATE.PLAY;
        }

        void OpenFirstMenu() {
            Show();
        }

        void OpenSetting() {
            Broadcaster.SendEvent("OpenSetting", "OpenFirstMenu");
            Close();
        }
                   
    }
}

