using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class SpawnPoint : MonoBehaviour
    {
        public void Awake()
        {
            Singletons.CurrentRespawnPoint = this.transform;
        }
    }
}
