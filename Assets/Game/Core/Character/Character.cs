using Prefs;
using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour {

    Rigidbody2D rigitbody; 
    Vector3 lastPosition = Vector3.zero;
    Animator animator;
    bool _phisics = false;
    bool _jump = false;
    bool jump {
        get { return _jump; }
        set { if (_jump == value) return;
            _jump = value;
            if (_jump && _phisics) {
                Broadcaster.SendEvent("PlayOneShot", "jump");
            }
            animator.SetBool("jump", value);
        }
    }
    bool walk {
        get { return animator.GetBool("walk"); }
        set { animator.SetBool("walk", value); }
    }

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
        animator = GetComponent<Animator>();
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
        if (phisics) {
            phisics = false;
            Broadcaster.SendEvent("PlayOneShot", "death");
            Broadcaster.SendEvent("OpenContinue");
        }                                                 
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

    internal void OnChangeBottomCollider(bool r) {
        jump = r;
    }

    void StopPhysics() {
        rigitbody.velocity = Vector2.zero;
        rigitbody.isKinematic = true;
    }

    void StartPhysics() {
        rigitbody.velocity = Vector2.zero;
        rigitbody.isKinematic = false;
    }


    float lastX = 0;

    void Update () {
        if (MicInput.MicLoudness > 0.2f) {               
            rigitbody.AddForce(new Vector2(Mathf.Min(MicInput.MicLoudness * 3.0f + 3.0f, 12.0f), 0.1f), ForceMode2D.Force);
        }
        if (MicInput.MicLoudness >= 4.5f && !jump) {
            rigitbody.AddForce(new Vector2(0, Mathf.Min(MicInput.MicLoudness * 0.02f +2.5f, 4.0f)), ForceMode2D.Impulse);
        }

        walk = lastX < transform.position.x;
        lastX = transform.position.x;

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
