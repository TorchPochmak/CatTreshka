using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    public SpriteRenderer circle;
    public Color color;

    [SerializeField] private CatController[] cats;
    private int allCats ;
    private int solved;
    
    private void Start()
    {
        cats = FindObjectsOfType<CatController>();
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
                //Debug.Log("Another one");
            }
        }
        Debug.Log(solved);
        if (solved == allCats)
        {
            Debug.Log("You win");
            circle.color = color;
        }
    }
}
