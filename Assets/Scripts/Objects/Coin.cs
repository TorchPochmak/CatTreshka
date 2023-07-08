using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class Coin : MonoBehaviour
    {
        public int Weight = 1;
        private CoinCollector PlayerCollector;
        // Start is called before the first frame update
        void Start()
        {
            PlayerCollector = Singletons.CatPlayer.GetComponent<CoinCollector>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerCollector.Coins += Weight;
            if (collision.gameObject == CatTreshka.Singletons.CatPlayer.gameObject)
            {
                Destroy(this.gameObject);
            }
        }
    }
}