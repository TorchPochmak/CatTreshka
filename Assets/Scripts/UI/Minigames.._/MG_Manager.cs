using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CatTreshka
{
    public class MG_Manager : MonoBehaviour
    {
        private void Awake()
        {
            Singletons.mg_manager = this;
        }
        public GameObject Minigame1;
        public GameObject Minigame2;
        public GameObject Minigame3;
    }
}
