using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace CatTreshka
{
    public class CounterMG2_Script : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmp;
        [SerializeField] private CatManager manager;

        private void Update()
        {
            tmp.text = Convert.ToString(manager.solved);
        }

    }

}