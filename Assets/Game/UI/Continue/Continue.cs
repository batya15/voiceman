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

        void No() {
            Voiceman.GameState.state = Voiceman.GAME_STATE.FINISH;
            Close();
        }

        void ForCoins() {
            Broadcaster.SendEvent("RegenerateCharacter");
            Close();
        }
    }
}
