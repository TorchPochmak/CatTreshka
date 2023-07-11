using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = {-1, -2};

    void Start()
    {
        int originalLength = faceIndexes.Count;
        float yPosition = 2.3f;
        float xPosition = -2.2f;
        for (int i = 0; i < 7; i++)
        {
            shuffleNum = rnd.Next(0, (faceIndexes.Count));
            var temp = Instantiate(token, new Vector3(
                xPosition, yPosition, 0),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition + 4;
            if (i == (originalLength / 2 - 2))
            {
                yPosition = -2.3f;
                xPosition = -6.2f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
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
        SpriteRenderer spriteRenderer = token.GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        float fadeDuration = 1.0f; // Adjust this value to control the fade duration

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(token);
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

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

}
