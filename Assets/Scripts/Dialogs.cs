using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogs : MonoBehaviour
{
    [System.Serializable]
    public struct Replic
    {
        public string name;
        public string sentense;
    }
    public Replic[] replicList;

    [System.Serializable]
    public struct Sayer
    {
        public string name;
        public Sprite image;
    }

    public Sayer[] sayers;
    public Image image;

    public TextMeshProUGUI text;

    public GameObject thisDialog;
    public GameObject player;

    public void Start() // фиксить
    {
        StartCoroutine(startALL());
    }
    public IEnumerator startALL()
    {
        player.SetActive(false);
        text.text = "";

        for (int i = 0; i < replicList.Length; i++)
        {
            string curName = replicList[i].name, curSent = replicList[i].sentense, write = "";
            Sprite curImage = null;
            // хотя бы потом на мапу заменить а то не кошерно
            for (int j = 0; j < sayers.Length; j++)
            {
                if (sayers[j].name == curName)
                {
                    curImage = sayers[j].image;
                    break;
                }
            }

            image.sprite = curImage;

            for (int j = 0; j < curSent.Length; j++)
            {
                write += curSent[j];
                text.text = write;
                yield return new WaitForSeconds(0.08f);
            }
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(.1f);

        //UI.SetActive(true);
        player.SetActive(true);
        Destroy(thisDialog);

    }

}