using UnityEngine;

namespace Voiceman {
    public class GeneratorWorld : MonoBehaviour {

        [SerializeField]
        GameObject ground;
        [SerializeField]
        GameObject coin;
        [SerializeField]
        GameObject bee;
        [SerializeField]
        GameObject fish;

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
        int beesCount = 0;
        int fishCount = 0;

        void BuildPlatform(bool first = false) {
            int water = first ? 0 : Random.Range(2, 4);

            if (GameState.distance > 15 && fishCount <= 0) {
                InstanseFish(new Vector3(maxDistance + water / 2, Ground.STANDART_HEIGHT + .5f));
                fishCount = Random.Range(3, 6);
                countGenCoin = countGenCoin < 0? 1 : countGenCoin++;
            }

            maxDistance += water;

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
                beesCount = Random.Range(3, 6);
            }

            if (countGenCoin == 0) {
                InstanseCoin(new Vector3(maxDistance - Random.Range(1, count), Ground.STANDART_HEIGHT + .5f + height));
                countGenCoin = Random.Range(2, 4);
            } else if (beesCount <= 0 && count > 4) {
                InstanseBee(new Vector3(maxDistance - 1, Ground.STANDART_HEIGHT + height));
                beesCount = Random.Range(3, 6);
            }

            beesCount--;
            countGenCoin--;
            fishCount--;
        }

        void InstanseCoin(Vector3 pos) {
            GameObject c = trash.GetCoins(); 
            if (c == null) {
                c = Instantiate(coin);
            }
            c.transform.SetParent(transform, false);
            c.transform.position = pos;     
        }

        void InstanseBee(Vector3 pos) {
            GameObject c = trash.GetBee();
            if (c == null) {
                c = Instantiate(bee);
            }
            c.transform.SetParent(transform, false);
            c.transform.position = pos;
            c.GetComponent<BeeMob.Bee>().Init();
        }

        void InstanseFish(Vector3 pos) {
            GameObject c = trash.GetFish();
            if (c == null) {
                c = Instantiate(fish);
            }
            c.transform.SetParent(transform, false);
            c.transform.position = pos;
            c.GetComponent<Fish>().Init();
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
