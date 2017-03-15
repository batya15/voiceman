using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class Ground : MonoBehaviour {

        public const int STANDART_HEIGHT = -3;
        [SerializeField]
        Material material;
        SpriteRenderer sr;

        static Dictionary<int, Material> materials = new Dictionary<int, Material>();

        void Awake() {
            sr = GetComponent<SpriteRenderer>();
        }

        public void Init(int start = 0, int size = 1) {
            transform.localScale = new Vector3(size, 1);
            transform.position = new Vector2(start, STANDART_HEIGHT);
            if (!materials.ContainsKey(size)) {
                materials.Add(size, Instantiate(material));
                materials[size].mainTextureScale = new Vector3(size, 1);
            }
            sr.material = materials[size];

        }
    }
}

