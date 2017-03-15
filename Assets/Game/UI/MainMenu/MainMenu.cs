using Voiceman;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI {
    public class MainMenu : MonoBehaviour {

        CanvasGroup canvasGroup;

        void Awake() {
            canvasGroup = GetComponent<CanvasGroup>(); 
        } 

        IEnumerator Start() {
            while (true) {    
            }
        }


        public void Play() {
            GameState.state = GAME_STATE.PLAY;
        }

    }
}

