using UnityEngine;

namespace Voiceman {
    public class GeneratorWorld : MonoBehaviour {

        [SerializeField]
        GameObject ground;
        [SerializeField]
        GameObject coin;

        int maxDistance = 0;

        float camDistance = 0;
        Trash trash;

        void Awake() {
            trash = GlobalCacheFinder.FindObjectOfType<Trash>();
        }

        public void Init() {
            run = false;
            maxDistance = (int)-CameraBehaviour.delta;
            foreach (Transform t in transform) {
                Destroy(t.gameObject);
            }
            camDistance = Camera.main.orthographicSize * 2 * Screen.width / Screen.height / 2 + 1;
            BuildPlatform(true);

        }


        int countGenCoin = 0;

        void BuildPlatform(bool first = false) {
            maxDistance += first ? 0 : Random.Range(2, 4);

            int count = first ? Mathf.FloorToInt(CameraBehaviour.sizeW) : Random.Range(3, 8);
            int height = first ? 0 : Random.Range(0, 3);

            GameObject pl = trash.GetGround();
            if (pl == null) {
                pl = Instantiate(ground);
            }                       

            pl.transform.SetParent(transform);
            pl.GetComponent<Ground>().Init(maxDistance, count, height);
            maxDistance += count;

            if (first) {
                for (int i = 0; i < 3; i++) {
                    InstanseCoin(new Vector3(maxDistance - 2 - i, Ground.STANDART_HEIGHT + .5f));
                }
                countGenCoin = Random.Range(2, 4);
            }

            if (countGenCoin == 0) {
                InstanseCoin(new Vector3(maxDistance - Random.Range(1, count), Ground.STANDART_HEIGHT + .5f + height));
                countGenCoin = Random.Range(2, 4);
            }

            countGenCoin--;
        }

        void InstanseCoin(Vector3 pos) {
            GameObject c = trash.GetCoins(); 
            if (c == null) {
                c = Instantiate(coin);
            }
            c.transform.SetParent(transform, false);
            c.transform.position = pos;     
        }


        bool run = false;
        public void Play() {
            run = true;
        }

        void Update() {
            if (run && Camera.main.transform.position.x + camDistance >= maxDistance) {
                BuildPlatform();
            }
        }
    
    }   
}
