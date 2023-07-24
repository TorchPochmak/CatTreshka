using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatTreshka
{
    public class FadeAndBackScreen : MonoBehaviour
    {
        public bool ShowOnStart;
        public bool PlayOnAwake;

        [SerializeField] private Image img;

        [SerializeField] private float fadeTime;
        [SerializeField] private float ticksToFade;

        private void Awake()
        {
            //Можно и убрать getcomponent...
            img = this.GetComponent<Image>();

            Singletons.BlackScreen = this;
        }
        private void Start()
        {
            if (ShowOnStart)
            {
                img.gameObject.SetActive(true);
                img.color = new Color(img.color.r, img.color.g, img.color.b, 255);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                img.gameObject.SetActive(false);
            }
            if(ShowOnStart && PlayOnAwake)
            {
                StartCoroutine(Black_Off());
            }
        }
        public IEnumerator Black_Off()
        {
            Debug.Log('d');
            Time.timeScale = 1;
            img.gameObject.SetActive(true);
            float tick = fadeTime / ticksToFade;
            int Atick = 255 / (int)ticksToFade;
            for (int i = 255; i >= 0; i -= Atick)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, (float)i / 255);
                yield return new WaitForSecondsRealtime(tick);
            }
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            img.gameObject.SetActive(false);
        }
        public IEnumerator Black_On()
        {
            Debug.Log("hm?");
            Time.timeScale = 0;
            float tick = fadeTime / ticksToFade;
            int Atick = 255 / (int)ticksToFade;
            for (int i = 0; i <= 255; i += Atick)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, (float)i / 255);
                yield return new WaitForSecondsRealtime(tick);
            }
            img.color = new Color(img.color.r, img.color.g, img.color.b, 255);
        }
    }
}