using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatTreshka
{
    public class CatManager : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        public bool YOUWIN = false;
        public Animator circle;
        public Color color;

        [SerializeField] private CatController[] cats;
        private int allCats;
        public int solved;

        private void Start()
        {
            cats = FindObjectsOfType<CatController>();
        }
        public void OnEnable()
        {
            CheckCats();
        }
        public void CheckCats()
        {
            solved = 0;
            allCats = cats.Length;
            for (int i = 0; i < cats.Length; ++i)
            {
                if (cats[i].isPlaced)
                {
                    solved++;
                }
            }
            if (solved == allCats)
            {
                circle.Play("CircleWin");
                source.Play();
                YOUWIN = true;
            }
        }
    }
}