//ве щрн гдеяэ гюашкн юкн
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class SaveSystem : MonoBehaviour
    {
        private void Awake()
        {
            LoadData();
        }
        public void LoadData()
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
                GameData.CurrentLevel = 0;
        }
        public void SaveCoins(int coins)
        {
            PlayerPrefs.SetInt("Coins", coins);
            GameData.CoinsCount = coins;
            PlayerPrefs.Save();
        }
        public void SaveLevel(int level)
        {
            PlayerPrefs.SetInt("Level", level);
            GameData.CurrentLevel = level;
            PlayerPrefs.Save();
        }
    }
}