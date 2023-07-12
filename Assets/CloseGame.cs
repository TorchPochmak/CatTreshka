using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTreshka
{
    public class CloseGame : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioSource source;

        [SerializeField] private PuzzleManager manager;
        [SerializeField] private GameObject thisMinigame;
        [SerializeField] private ArtekHolder artekholder;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (manager.YOUWIN)
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
