using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour {

    Text t; 
    void Awake() {
        t = GetComponentInChildren<Text>();
        t.text = Prefs.UserPrefs.activeSound ? "On" : "Off";
    }

    void Click() {
        Prefs.UserPrefs.activeSound = !Prefs.UserPrefs.activeSound;
        t.text = Prefs.UserPrefs.activeSound ? "On" : "Off";
    }   
	   
}
