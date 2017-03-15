using UnityEngine;
using UnityEngine.UI;


namespace DevTools {
    public class LevelVoiceSlider : MonoBehaviour {

        Slider slider;
        float max = 1f;

        void Awake() {
            slider = GetComponent<Slider>();
        }

        void Update() {
            max = Mathf.Max(max, MicInput.MicLoudness);       
            slider.value = Mathf.Max(MicInput.MicLoudness / max, slider.value - 0.01f);   
        }

    }
}
