using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

public static class Broadcaster {

    public static void SendEvent(string fun, object msg = null, params GameObject[] parents) {
        if (parents.Length == 0) {
            if (subscribes.ContainsKey(fun)) {
                GameObject[] subscribesArr = subscribes[fun].ToArray();
                foreach (GameObject go in subscribesArr) {
                    go.SendMessage(fun, msg, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }     

    private static Dictionary<string, List<GameObject>> subscribes = new Dictionary<string, List<GameObject>>();

    public static void Subscribe(GameObject obj, params string[] names) {
        foreach (string name in names) {
            if (!subscribes.ContainsKey(name)) {
                subscribes[name] = new List<GameObject>();
            }
            List<GameObject> s = subscribes[name];
            if (!s.Contains(obj)) {
                s.Add(obj);
            }
        }
        if (obj.GetComponent<AutoUnsubscribeOnDestroy>() == null) {
            obj.AddComponent<AutoUnsubscribeOnDestroy>();
        }
    }

    public static void Unsubscribe(GameObject obj) {
        foreach (List<GameObject> s in subscribes.Values) {
            s.Remove(obj);
        }
    }

    public class AutoUnsubscribeOnDestroy : MonoBehaviour {
        void OnDestroy() {
            Unsubscribe(gameObject);
        }
    }

}

