using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CatTreshka
{
    public class PuzzleManager : MonoBehaviour
    {
        public bool YOUWIN = false;
        [SerializeField] private PuzzleRotate[] puzzles;
        [SerializeField] private Sprite lampOff;
        [SerializeField] private Sprite lampOn;
        [SerializeField] private GameObject Zaslon;

        public int allTiles = 6;
        public int solvedTiles = 6;
        public GameObject lamp;

        public void GenerateField()
        {
            // paste your code here
        }
        public void CheckPuzzle()
        {
            solvedTiles = 0;
            for (int i = 0; i < puzzles.Length; i++)
            {
                if (puzzles[i].isPlaced)
                {
                    solvedTiles++;
                }
            }

            if (solvedTiles == allTiles)
            {
                // send action to other scripts
                lamp.GetComponent<Image>().sprite = lampOn;
                Zaslon.SetActive(true);
                YOUWIN = true;
            }

        }
    }
}