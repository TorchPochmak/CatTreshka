using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogs : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    [SerializeField] private GameObject HowToPlay;
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

    public void Start() // фиксить
        //мда
    {
        StartCoroutine(startALL());
    }
    public IEnumerator startALL()
    {
        Time.timeScale = 0;
        text.text = "";

        for (int i = 0; i < replicList.Length; i++)
        {
            source.Play();
            string curName = replicList[i].name, curSent = replicList[i].sentense, write = "";
            Sprite curImage = null;
            // хотя бы потом на мапу заменить а то не кошерно
            // сука это пиздец, как вы вообще такой код могли высрать я в ахуе
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
                yield return new WaitForSecondsRealtime(0.08f);
            }
            source.Stop();
            yield return new WaitForSecondsRealtime(2f);
        }
        yield return new WaitForSecondsRealtime(.1f);

        Time.timeScale = 1;
        HowToPlay.SetActive(true);
        Destroy(thisDialog);
    }

}