using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public static class GameState {
        public static GAME_STATE state = GAME_STATE.WAIT;

        static int _distance = 0;
        public static int distance {
            get { return _distance; }
            set {
                if (value != _distance) {
                    _distance = value;
                    Broadcaster.SendEvent("ChangedScore");
                    if (_distance > Prefs.UserPrefs.best) {
                        Prefs.UserPrefs.best = _distance;
                    }
                }       
            }
        }
    }



    public enum GAME_STATE {
        WAIT,
        PLAY,   
        FINISH
    }

}
