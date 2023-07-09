using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzleRotate[] puzzles;

    public int allTiles = 6;
    public int solvedTiles = 6;
    public GameObject lamp;

    private void Start()
    {
        puzzles = FindObjectsOfType<PuzzleRotate>();
    }
    public void GenerateField()
    {
        // paste your code here
    }

    public Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
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
            lamp.transform.position = SetZ(lamp.transform.position, -2);
            Debug.Log("solved");
        }

    }
}