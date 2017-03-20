using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioCore {          
    [RequireComponent(typeof(AudioSource))]
    public class AudioFX : MonoBehaviour {
          
        [System.Serializable]
        public struct NamedAudioList {
            public string name;
            public AudioClip source;
            public float volume;
        }

        public NamedAudioList[] audiolist;

        private Dictionary<string, NamedAudioList> DictionaryAudio = new Dictionary<string, NamedAudioList>();

        AudioSource audioSrc;

        void Awake() {
            foreach(NamedAudioList sound in audiolist) {
                DictionaryAudio.Add(sound.name, sound);
            }

            audioSrc = GetComponent<AudioSource>();
            Broadcaster.Subscribe(this, "PlayOneShot");
        }

        void Start() {
            PlayOneShot("startGame");
        }

        void PlayOneShot(string nameSound) {
            float v = DictionaryAudio[nameSound].volume;
            if (v <= 0) {
                v = 1;
            }
            if (DictionaryAudio.ContainsKey(nameSound) && Prefs.UserPrefs.activeSound) {
                audioSrc.PlayOneShot(DictionaryAudio[nameSound].source, v);
            }
        }
    }

}
