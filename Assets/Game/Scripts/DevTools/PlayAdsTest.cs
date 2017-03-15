using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using UnityEngine.UI;
using AppodealAds.Unity.Common;

public class PlayAdsTest : MonoBehaviour, ISkippableVideoAdListener {
                                                                        
    void Start() {
        string appKey = "a01b9829151af0b897fb60f24183f870b4e5f5abc36e53f9";

       // Appodeal.setTesting(true);
        Appodeal.setLogging(true);
        Appodeal.initialize(appKey, Appodeal.SKIPPABLE_VIDEO);
        Appodeal.setSkippableVideoCallbacks(this);
        GetComponent<Image>().color = Color.cyan;

    }

    public void onSkippableVideoLoaded() { Debug.Log("Interstitial loaded"); GetComponent<Image>().color = Color.red; }
    public void onSkippableVideoFailedToLoad() { Debug.Log("Interstitial failed"); GetComponent<Image>().color = Color.blue; }
    public void onSkippableVideoShown() { Debug.Log("Interstitial opened"); GetComponent<Image>().color = Color.green; }
    public void onSkippableVideoFinished() { Debug.Log("Interstitial closed"); GetComponent<Image>().color = Color.black; }
    public void onSkippableVideoClosed() { Debug.Log("Interstitial clicked"); GetComponent<Image>().color = Color.yellow; }

    public void Click() {
        Appodeal.show(Appodeal.SKIPPABLE_VIDEO);
    }
}

