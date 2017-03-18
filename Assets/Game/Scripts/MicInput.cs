using Prefs;
using UnityEngine;

public class MicInput : MonoBehaviour {

    public static float MicLoudness;
    public float m;
    private string _device;

    void InitMic() {
        if (_device == null) _device = Microphone.devices[0];
        _clipRecord = Microphone.Start(_device, true, 999, 44100);
    }

    void StopMicrophone() {
        Microphone.End(_device);
    }


    AudioClip _clipRecord = new AudioClip();
    int _sampleWindow = 128;

    float LevelMax() {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);  

        for (int i = 0; i < _sampleWindow; i++) {
            float wavePeak = waveData[i] * waveData[i] * (UserPrefs.sensitivity * 10);
            levelMax = Mathf.Max(levelMax, wavePeak);
        }
        return levelMax;
    }



    void Update() {
        MicLoudness = LevelMax();
        m = MicLoudness;
    }

    bool _isInitialized;

    void OnEnable() {
        InitMic();
        _isInitialized = true;
    }

    void OnDisable() {
        StopMicrophone();
    }

    void OnDestroy() {
        StopMicrophone();
    }      

    void OnApplicationFocus(bool focus) {
        if (focus) {
            if (!_isInitialized) {
                InitMic();
                _isInitialized = true;
            }
        } else {
            StopMicrophone();         
            _isInitialized = false;
        }                             
    }
}
