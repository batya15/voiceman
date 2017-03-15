using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        
public class CameraBehaviour : MonoBehaviour {

    [SerializeField]
    Transform character;

    public static float delta {
        get;
        private set;
    }

    public static float sizeW {
        get;
        private set;
    }

    void Awake() {
        sizeW = Camera.main.orthographicSize * 2 * Screen.width / Screen.height;
        delta = sizeW / 4;
    }

    void Update () {
        transform.position = new Vector3(character.position.x + delta, 0,-10);
        Voiceman.GameState.distance = Mathf.FloorToInt(character.position.x);	
	}
}
