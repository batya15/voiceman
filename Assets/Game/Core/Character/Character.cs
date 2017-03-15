using UnityEngine;

public class Character : MonoBehaviour {

    Rigidbody2D rigitbody;

    void Awake() {
        rigitbody = GetComponent<Rigidbody2D>();
    }

    public void Init() {
        transform.position = Vector3.zero;
        StopPhysics();
    }       

    public void Play() {
        StartPhysics();
    }

    public void Death() {
        StopPhysics();
        Voiceman.GameState.state = Voiceman.GAME_STATE.FINISH;
    }

    void StopPhysics() {
        rigitbody.velocity = Vector2.zero;
        rigitbody.isKinematic = true;
    }

    void StartPhysics() {
        rigitbody.velocity = Vector2.zero;
        rigitbody.isKinematic = false;
    }

    void Update () {
        if (MicInput.MicLoudness > 0.1f) {  
            rigitbody.AddForce(new Vector2(MicInput.MicLoudness * 2, MicInput.MicLoudness * 2), ForceMode2D.Impulse);
        }

#if TEST_BUILD
        if (Input.GetButton("Horizontal")) {
            rigitbody.AddForce(transform.right * 15, ForceMode2D.Force);
          
        }

        if (Input.GetButton("Vertical")) {
            rigitbody.AddForce(transform.up * 15, ForceMode2D.Force);

        }      
#endif  
    }
}
