using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRotate : MonoBehaviour
{
    public float currentDegrees = 0f;
    public bool isPlaced;

    public float[] correctRotation;
    private float[] rotate = { 0, 90, 180, 270 };
    private PuzzleManager puzzleManager;

    private void Awake()
    {
        puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

    private void Start()
    {
        int Rand = Random.Range(0, rotate.Length); // Puzzle mustn't be solved after Start

        transform.eulerAngles = new Vector3(0, 0, rotate[Rand]);
        currentDegrees = rotate[Rand];
        isPlaced = CheckTile();

    }
    private void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);
        currentDegrees = ((currentDegrees + 90) % 360);
        isPlaced = CheckTile();
        puzzleManager.CheckPuzzle();
    }
    private bool CheckTile()
    {
        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (currentDegrees == correctRotation[i])
            {
                return true;
            }
        }
        return false;
    }
}