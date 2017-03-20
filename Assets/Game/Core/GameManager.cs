using AppodealAds.Unity.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class GameManager : MonoBehaviour {
         
        GeneratorWorld world;
        [SerializeField]
        Character character;
        bool noAdsVideo = true;

        void Awake() {
            world = GetComponent<GeneratorWorld>();
            Ads.Manager.Init();
            Broadcaster.Subscribe(this, "PlayAds");
        }

        void PlayAds() {
            noAdsVideo = false;
        }

        IEnumerator Baner() {
            yield return new WaitWhile(() => !Ads.Manager.Ready(Ads.PLACEMENT.BANER));
            Ads.Manager.Play(Ads.PLACEMENT.BANER);
            yield return new WaitWhile(() => noAdsVideo); 
            Appodeal.hide(Appodeal.BANNER);
        }

        IEnumerator Start() {
            while (true) {
                world.Init();
                character.Init();
                yield return new WaitUntil(() => GameState.state == GAME_STATE.PLAY);
                character.Play();
                world.Play();
                yield return new WaitUntil(() => GameState.state == GAME_STATE.FINISH);
                GameState.state = GAME_STATE.PLAY;
            }
        }
        

    }
}


