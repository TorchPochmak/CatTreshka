using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}