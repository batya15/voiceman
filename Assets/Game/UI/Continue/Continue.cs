using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI {
    public class Continue : Window {

        [SerializeField]
        Button coinBtn;
        [SerializeField]
        CanvasGroup adsBtn;

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

        IEnumerator No() {
            if (countDeath == 1) {
                yield return Ads.Manager.Play(Ads.PLACEMENT.FAILED_GAME);
            }
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

        IEnumerator forAds() {
            countDeath++;
            yield return Ads.Manager.Play(Ads.PLACEMENT.DEATH_VIDEO);
            Broadcaster.SendEvent("RegenerateCharacter");
            Close();

        }    

        void Update() {
            if (countDeath > 2 || !Ads.Manager.Ready(Ads.PLACEMENT.DEATH_VIDEO)) {
                adsBtn.interactable = false;
                adsBtn.alpha = 0;
            } else {
                adsBtn.interactable = true;
                adsBtn.alpha = 1;
            }
        }
    }
}
