using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        
public class CameraBehaviour : MonoBehaviour {

    [SerializeField]
    Transform character;
    [SerializeField]
    BoxCollider2D coll;

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

    private void Start() {
        coll.size = new Vector2(sizeW + 10, coll.size.y);
    }

    void Update () {
        transform.position = new Vector3(character.position.x + delta, 0,-10);
        Voiceman.GameState.distance = Mathf.FloorToInt(character.position.x);	
	}
}
