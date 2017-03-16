using System;
using System.Collections;        
using UnityEngine;

public class Character : MonoBehaviour {

    Rigidbody2D rigitbody; 
    Vector3 lastPosition = Vector3.zero;
    bool _phisics = false;
    bool phisics {
        get { return _phisics; }
        set {
            _phisics = value;
            if (_phisics) {
                StartPhysics();
            } else {
                StopPhysics();
            }
        }
    }

    void Awake() {
        rigitbody = GetComponent<Rigidbody2D>();
        Broadcaster.Subscribe(this, "RegenerateCharacter");
    }

    public void Init() {
        transform.position = Vector3.zero;
        phisics = false;
    }       

    public void Play() {
        phisics = true;
    }

    public void Death() {
        phisics = false;
        Broadcaster.SendEvent("OpenContinue");
    }

    
    IEnumerator RegenerateCharacter() {
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(lastPosition.x, lastPosition.y + 2, lastPosition.z);
        for (float t = 0; t < 1; t += Time.deltaTime) {
            transform.position = Vector3.Lerp(startPos, targetPos, t * t);
            yield return null;
        }
        transform.position = targetPos;     
        phisics = true;
    }

    internal void saveLastPosition() {
        if (phisics) {
            lastPosition = transform.position;
        }                                             
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
