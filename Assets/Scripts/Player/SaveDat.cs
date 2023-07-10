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
                int pog = other.gameObject.GetComponent<Pogosan>().numberOfLeveltoSave;// 2,3,100
                int coins = collector.GetCoins();
                saveSystem.SaveLevel(pog);
                saveSystem.SaveCoins(coins);
                manager.OnGameStart();
            }
        }
    }
}
