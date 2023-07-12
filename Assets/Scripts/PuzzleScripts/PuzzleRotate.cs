using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTreshka
{

    public class PuzzleRotate : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioSource audio;

        [SerializeField] private RectTransform pieceToRotate;

        public float currentDegrees = 0f;
        public bool isPlaced;
        public float speed = 1f;

        public float[] correctRotation;
        private float[] rotate = { 0, 90, 180, 270 };
        private PuzzleManager puzzleManager;
        

        bool IsRotating = false;

        private void Awake()
        {
            puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
        }

        private void OnEnable()
        {
            A:
            int Rand = Random.Range(0, rotate.Length); // Puzzle mustn't be solved after Start

            pieceToRotate.eulerAngles = new Vector3(0, 0, rotate[Rand]);
            currentDegrees = rotate[Rand];
            isPlaced = CheckTile();
            if (isPlaced) goto A;
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

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(IsRotating);
            if (!IsRotating)
            {
                StartCoroutine(Rotate());
            }
        }
        public IEnumerator Rotate()
        {
            audio.Play();
            float weight = 0;
            IsRotating = true;
            float lastz = pieceToRotate.eulerAngles.z;
            while (weight <= 1f) 
            {
                float time = Time.fixedDeltaTime / speed;
                weight += time;
                pieceToRotate.Rotate(0, 0, time * 90f);
                if (pieceToRotate.eulerAngles.z >= lastz + 90f) break;
                Debug.Log(pieceToRotate.eulerAngles.z);
                yield return null;
            }
            currentDegrees = ((lastz + 90f) + 360) % 360;
            pieceToRotate.eulerAngles = new Vector3(0, 0, ((lastz + 90f) + 360) % 360);
            isPlaced = CheckTile();
            puzzleManager.CheckPuzzle();
            IsRotating = false;
        }
    }
}