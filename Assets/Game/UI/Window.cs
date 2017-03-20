using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI {
    public class Window : MonoBehaviour {

        Animator anim;
                                   
        protected virtual void Awake() {
            anim = GetComponent<Animator>();
        }

        protected void Show() {
            Broadcaster.SendEvent("PlayOneShot", "window");
            anim.SetBool("show", true);
            OnShow();
        }

        protected virtual void OnShow() { }

        protected void Close() {
            anim.SetBool("show", false);
            OnClose();
        }

        protected virtual void OnClose() { }
    }
}
