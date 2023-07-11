using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTreshka
{


    public class CloseGame2 : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CatManager manager;
        [SerializeField] private GameObject thisMinigame;
        [SerializeField] private ArtekHolder artekholder;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (manager.YOUWIN)
            {
                artekholder.CollectArtek();
            }
            artekholder.ReturnMG();
            thisMinigame.SetActive(false);
            Time.timeScale = 1;
        }
    }
}