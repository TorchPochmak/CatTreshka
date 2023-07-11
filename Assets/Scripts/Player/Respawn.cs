using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka {
    public class Respawn : MonoBehaviour
    {
        public Transform FirstSpawner;

        private void Start()
        {
            SpawnDefault();
        }
        public void SpawnDefault()
        {
            Singletons.CatPlayer.transform.position = Singletons.CurrentRespawnPoint.position;
        }
        public IEnumerator RespawnFirst()
        {
            Debug.Log("OK");
            Singletons.BlackScreen.gameObject.SetActive(true);
            yield return StartCoroutine(Singletons.BlackScreen.Black_On());
            Debug.Log("Better");
            Singletons.CatPlayer.transform.position = FirstSpawner.position;
            yield return StartCoroutine(Singletons.BlackScreen.Black_Off());
        }
    }
}