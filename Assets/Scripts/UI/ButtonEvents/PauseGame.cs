using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class PauseGame : MonoBehaviour
    {
        public void FreezeTime()
        {
            Time.timeScale = 0;
        }
    }
}