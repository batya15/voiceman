using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsCoin : MonoBehaviour {

    int i = 22;

    [SerializeField]
    Text coins;

    Text t;
    CanvasGroup canvas;

    private void Awake() {
        t = GetComponentInChildren<Text>();
        canvas = GetComponent<CanvasGroup>();
        t.text = "Free " + i + " COINS";
        Broadcaster.Subscribe(this, "ChangedScore");
    }

    bool block = false;

    IEnumerator Click() {
        yield return Ads.Manager.Play(Ads.PLACEMENT.SETTING_COIN);
        Prefs.UserPrefs.coins += i;
        i -= 2;
        t.text = "Free " + i + " COINS";
        if (i <= 0) {
            block = true;
            yield return new WaitForSeconds(120);
            i = 12;
            block = false;
        }
    }


    void ChangedCoins() {
        coins.text = "Coins: " + Prefs.UserPrefs.coins;
    }

    void Update () {
        if (block || !Ads.Manager.Ready(Ads.PLACEMENT.SETTING_COIN)) {
            canvas.interactable = false;
            canvas.alpha = 0;
        } else {
            canvas.interactable = true;
            canvas.alpha = 1;
        }        		
	}
}
