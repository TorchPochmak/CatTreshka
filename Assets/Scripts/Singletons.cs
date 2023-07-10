using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public static class Singletons
    {
        public static GameObject CatPlayer;
        public static FadeAndBackScreen BlackScreen;
        public static Transform CurrentRespawnPoint;
    }
    public static class GameData
    {
        // PlayerPrefs - "Coins" int
        public static int CoinsCount; // [0;100]

        // PlayerPrefs - "Level" int
        public static int CurrentLevel; // 1-индексация [1;3] 
    }
}
