using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

public static class Broadcaster {

    public static void SendEvent(string fun, object msg = null, params GameObject[] parents) {
        if (parents.Length == 0) {
            if (subscribes.ContainsKey(fun)) {
                Component[] subscribesArr = subscribes[fun].ToArray();
                foreach (Component go in subscribesArr) {
                    go.SendMessage(fun, msg, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }     

    private static Dictionary<string, List<Component>> subscribes = new Dictionary<string, List<Component>>();

    public static void Subscribe(Component obj, params string[] names) {
        foreach (string name in names) {
            if (!subscribes.ContainsKey(name)) {
                subscribes[name] = new List<Component>();
            }
            List<Component> s = subscribes[name];
            if (!s.Contains(obj)) {
                s.Add(obj);
            }
        }
        if (obj.gameObject.GetComponent<AutoUnsubscribeOnDestroy>() == null) {
            obj.gameObject.AddComponent<AutoUnsubscribeOnDestroy>();
        }
    }

    public static void Unsubscribe(Component obj) {
        foreach (List<Component> s in subscribes.Values) {
            s.Remove(obj);
        }
    }

    public class AutoUnsubscribeOnDestroy : MonoBehaviour {
        void OnDestroy() {
            MonoBehaviour[] m = GetComponents<MonoBehaviour>();
            foreach (var r in m) { 
                Unsubscribe(r);
            }
        }
    }

}

