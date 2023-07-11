using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatTreshka
{
    public class MainToken : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameControl gameControl;
        Image img;
        public Sprite[] faces;
        public Sprite back;
        public int faceIndex;

        public bool matched = false;

        private void Awake()
        {
            gameControl = GameObject.Find("MINIGAME_3").GetComponent<GameControl>();
            img = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (matched == false)
            {
                if (img.sprite == back)
                {
                    if (gameControl.TwoCardsUp() == false)
                    {
                        img.sprite = faces[faceIndex];
                        gameControl.AddVisibleFace(faceIndex);
                        gameControl.CheckMatch();
                    }
                }
                else
                {
                    img.sprite = back;
                    gameControl.RemoveVisibleFace(faceIndex);
                }
            }
        }
    }
}