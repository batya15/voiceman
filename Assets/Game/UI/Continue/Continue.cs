using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI {
    public class Continue : Window {

        [SerializeField]
        Button coinBtn;

        int countDeath = 1;

        protected override void Awake() {
            base.Awake();
            Broadcaster.Subscribe(this, "OpenContinue");
        }


        int price;
        void OpenContinue() {
            price = countDeath * 10;
            coinBtn.interactable = (Prefs.UserPrefs.coins >= price);
            coinBtn.GetComponentInChildren<Text>().text = price + " coins";
            Show();
        }

        void No() {
            countDeath = 1;
            Voiceman.GameState.state = Voiceman.GAME_STATE.FINISH;
            Close();
        }

        void ForCoins() {
            countDeath ++;
            Prefs.UserPrefs.coins -= price;
            Broadcaster.SendEvent("RegenerateCharacter");
            Close();
        }
    }
}
