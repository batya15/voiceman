using System.Collections.Generic;
using UnityEngine;
using System.Linq;

static class GlobalCacheFinder {

    static Dictionary<System.Type, Object> cache = new Dictionary<System.Type, Object>();

    static public T FindObjectOfType<T>() where T : Object {
        return (T)FindObjectOfType(typeof(T));
    }

    static public Object FindObjectOfType(System.Type t) {
        if (!cache.ContainsKey(t) || cache[t] == null || IsDestroyed(cache[t])) {
            cache[t] = Object.FindObjectOfType(t);
            if (cache[t] == null) {
                try {
                    cache[t] = Resources.FindObjectsOfTypeAll(t)[0];
                } catch {
                }
            }
        }
        return cache[t];
    }

    static public bool IsDestroyed(Object obj) {
        if (obj == null) {
            return true;
        }
        try {
            if (obj is MonoBehaviour) {
                return (obj as MonoBehaviour).gameObject == null;
            }
        } catch (MissingReferenceException) {
            return true;
        }
        return false;
    }

    static public void CleanDestroyed() {
        System.Type[] destroyed = cache.Keys.Where(k => IsDestroyed(cache[k])).ToArray();
        foreach (System.Type k in destroyed) {
            cache.Remove(k);
        }
    }
}
