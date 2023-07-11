using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class ArtekHolder : MonoBehaviour
    {
        public int numberOfMinigame = 0;//1,2,3
        public bool canTake = true;
        public bool hasArtek;
        [SerializeField] private GameObject ArtekBody;

        private void Awake()
        {
            hasArtek = false;
        }
        public void CollectArtek()
        {
            hasArtek = true;
            ArtekBody.GetComponentInParent<Animator>().SetBool("Collected", true);
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (canTake)
            {
                if (collision.gameObject.tag == "Artek")
                {
                    Time.timeScale = 0;
                    switch (numberOfMinigame) {
                        case 1:
                            {
                                Singletons.mg_manager.Minigame1.SetActive(true);
                                break;
                            }
                        case 2:
                            {
                                Singletons.mg_manager.Minigame2.SetActive(true);
                                break;
                            }
                        case 3:
                            {
                                Singletons.mg_manager.Minigame3.SetActive(true);
                                break;
                            }
                        default:
                            {
                                Debug.LogError("Не привязана Мини-игра");
                                break;
                            }

                    }

                    
                }
            }
        }
        public void ReturnMG()
        {
            StartCoroutine(ReturnFromMinigame());
        }
        public IEnumerator ReturnFromMinigame()
        {
            canTake = false;
            yield return new WaitForSeconds(2);
            canTake = true;
        }

    }
}
