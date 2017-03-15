using UnityEngine;

namespace Voiceman {
    public class GeneratorWorld : MonoBehaviour {

        [SerializeField]
        GameObject platform;

        int maxDistance = 0;

        public void Init() {
            run = false;
            maxDistance = (int)-CameraBehaviour.delta;
            foreach (Transform t in transform) {
                Destroy(t.gameObject);
            }

            BuildPlatform(Mathf.FloorToInt(CameraBehaviour.sizeW));
        }

        void BuildPlatform(int count) {
            GameObject pl = Instantiate(platform);
            pl.transform.SetParent(transform);
            pl.GetComponent<Ground>().Init(maxDistance, count);
            maxDistance += count;
        }


        bool run = false;
        public void Play() {
            run = true;
        }

        void Update() {
            if (run && Camera.main.transform.position.x + Camera.main.orthographicSize * 2 * Screen.width / Screen.height / 2 + 1 >= maxDistance) {
                maxDistance += Random.Range(1, 5);
                BuildPlatform(Random.Range(1, 5));
            }
        }

        /*void Build(GameObject prefab) {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(transform, false);
            maxDistance = go.GetComponent<IRegion>().Init(maxDistance);
        } */

    }   
}
