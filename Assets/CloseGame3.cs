
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTreshka
{
    public class CloseGame3 : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioSource source;

        [SerializeField] private GameControl manager;
        [SerializeField] private GameObject thisMinigame;
        [SerializeField] private ArtekHolder artekholder;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (manager.CheckEndOfGame())
            {
                artekholder.CollectArtek();
            }
            artekholder.ReturnMG();
            source.Play();
            thisMinigame.SetActive(false);
            Time.timeScale = 1;
        }
    }
}