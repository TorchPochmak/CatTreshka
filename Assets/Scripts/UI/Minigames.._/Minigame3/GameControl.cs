using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatTreshka
{
    public class GameControl : MonoBehaviour
    {
        bool donedone = false;


        [SerializeField] private AudioSource done;

        [SerializeField] private GameObject TokenParent;
        [SerializeField] private GameObject token;
        List<int> faceIndexes;
        public static System.Random rnd = new System.Random();
        public int shuffleNum;
        List<int> visibleFaces;


        void OnEnable()
        {
            shuffleNum = 0;
            visibleFaces = new List<int>{ -1, -2 };
            faceIndexes = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 };

            int originalLength = faceIndexes.Count;



            for (int i = 0; i < 7; i++)
            {
                shuffleNum = rnd.Next(0, (faceIndexes.Count));
                var temp = Instantiate(token, TokenParent.transform);
                temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
                faceIndexes.Remove(faceIndexes[shuffleNum]);
            }
            var gm = Instantiate(token, TokenParent.transform);
            gm.GetComponent<MainToken>().faceIndex = faceIndexes[0];
        }

        private void OnDisable()
        {
            Debug.Log(TokenParent.transform.childCount);
            for(int i = 0; i < TokenParent.transform.childCount; i++)
            {
                Destroy(TokenParent.transform.GetChild(i).gameObject);
            }
        }
        public bool TwoCardsUp()
        {
            bool cardsUp = false;
            if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
            {
                cardsUp = true;
            }
            return cardsUp;
        }

        public void AddVisibleFace(int index)
        {
            if (visibleFaces[0] == -1)
            {
                visibleFaces[0] = index;
            }
            else if (visibleFaces[1] == -2)
            {
                visibleFaces[1] = index;
            }
        }

        public void RemoveVisibleFace(int index)
        {
            if (visibleFaces[0] == index)
            {
                visibleFaces[0] = -1;
            }
            else if (visibleFaces[1] == index)
            {
                visibleFaces[1] = -2;
            }
        }

        public IEnumerator FadeOutToken(GameObject token)
        {
            token.GetComponent<MainToken>().matched = true;
            Image img = token.GetComponent<Image>();
            Color originalColor = img.color;
            float fadeDuration = 1.0f; // Adjust this value to control the fade duration

            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                img.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }
            img.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
            bool OK = true;
            for (int i = 0; i < TokenParent.transform.childCount; i++)
            {
                if (TokenParent.transform.GetChild(i).gameObject.GetComponent<MainToken>().matched == false) OK = false;
            }
            if (OK  && !donedone)
            {
                donedone = true;
                done.Play();
            }
            }
            public bool CheckEndOfGame()
        {
            for (int i = 0; i < TokenParent.transform.childCount; i++)
            {
                if (TokenParent.transform.GetChild(i).gameObject.GetComponent<MainToken>().matched == false) return false;
            }
            return true;
        }
        public bool CheckMatch()
        {
            bool success = false;
            if (visibleFaces[0] == visibleFaces[1])
            {
                GameObject[] tokens = GameObject.FindGameObjectsWithTag("Token(Clone)");

                // Loop through the clones to find the matched pairs
                foreach (GameObject token in tokens)
                {
                    // If the token's face index matches the visible face index, move it out of the frame
                    if (token.GetComponent<MainToken>().faceIndex == visibleFaces[0])
                    {
                        //token.transform.position = new Vector3(1000f, 1000f, 0f); // move the token out of the frame
                        StartCoroutine(FadeOutToken(token));

                    }
                }

                visibleFaces[0] = -1;
                visibleFaces[1] = -2;

                success = true;
            }
            return success;
        }
    }
}