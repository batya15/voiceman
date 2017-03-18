using System;
using UnityEngine;


namespace Prefs {
    public static class UserPrefs {

        const string BEST = "user.best";
        const string COUNS = "user.coins";
        const string SENSITIVITY = "user.sensitivity";

        public static int best {
            get { return PlayerPrefs.GetInt(BEST, 0); }
            set {
                if (value != best) {
                    PlayerPrefs.SetInt(BEST, value);
                    Broadcaster.SendEvent("ChangedBestScore");
                }
            }
        }

        public static int coins {
            get { return PlayerPrefs.GetInt(COUNS, 0); }
            set {
                if (value != coins) {
                    PlayerPrefs.SetInt(COUNS, value);
                    Broadcaster.SendEvent("ChangedCoins");
                }
            }
        }

        public static float sensitivity {
            get { return (float)PlayerPrefs.GetInt(SENSITIVITY, 40) / 100; }
            set {
                if (value != sensitivity) {
                    Debug.Log(value);
                    PlayerPrefs.SetInt(SENSITIVITY, Mathf.FloorToInt(value * 100));
                }
            }
        }

    }
}
