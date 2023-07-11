
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTreshka
{
    public class CloseGame3 : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameControl manager;
        [SerializeField] private GameObject thisMinigame;
        [SerializeField] private ArtekHolder artekholder;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (manager.CheckEndOfGame())
            {
                artekholder.CollectArtek();
            }
            Debug.Log("fff");
            artekholder.ReturnMG();
            thisMinigame.SetActive(false);
            Time.timeScale = 1;
        }
    }
}