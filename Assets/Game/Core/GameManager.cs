using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class GameManager : MonoBehaviour {
         
        GeneratorWorld world;
        [SerializeField]
        Character character;

        void Awake() {
            world = GetComponent<GeneratorWorld>();
        }

        IEnumerator Start() {
            while (true) {
                world.Init();
                character.Init();
                yield return new WaitUntil(() => GameState.state == GAME_STATE.PLAY);
                character.Play();
                world.Play();
                yield return new WaitUntil(() => GameState.state == GAME_STATE.FINISH);
                //Проиграли игру
            }
        }
        

    }
}


