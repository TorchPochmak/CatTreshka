using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

namespace CatTreshka
{
    public class SaveDat : MonoBehaviour
    {
        [SerializeField] private CoinCollector collector;
        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private GameManager manager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Pogosan")
            {
                var pog = other.gameObject.GetComponent<Pogosan>();
                if ((pog.needsArtek && this.gameObject.GetComponent<ArtekHolder>().hasArtek) || (!pog.needsArtek)) {
                    int pogg = pog.numberOfLeveltoSave;// 1,2,3,100
                    int coins = collector.GetCoins();
                    saveSystem.SaveLevel(pogg);
                    saveSystem.SaveCoins(coins);
                    manager.OnGameStart();
                }
            }
        }
    }
}
