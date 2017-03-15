using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevTools {
    public class Play : MonoBehaviour {

       
        public void Click() {
            Voiceman.GameState.state = Voiceman.GAME_STATE.PLAY;
        }
       
    }

}
