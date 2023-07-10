using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class GameSaver : MonoBehaviour
    {
        private void Awake()
        {
            if (PlayerPrefs.HasKey("Coins"))
                GameData.CoinsCount = PlayerPrefs.GetInt("Coins");
            else
                GameData.CoinsCount = 0;

            if (PlayerPrefs.HasKey("Level"))
            {
                GameData.CurrentLevel = PlayerPrefs.GetInt("Level");
            }
            else
                GameData.CurrentLevel = 1;
        }

        public void SaveCoins(int coins)
        {
            PlayerPrefs.SetInt("Coins", coins);
        }
        public void SaveLevel(int level)
        {
            PlayerPrefs.SetInt("Level", level);
        }
    }
}