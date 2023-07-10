using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatTreshka
{
    public class ButtonFade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image thisButton;
        [SerializeField] private Color Entercolor;
        [SerializeField] private Color Disablecolor;


        private void Start()
        {
            thisButton.color = Disablecolor;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            thisButton.color = Entercolor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            thisButton.color = Disablecolor;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            thisButton.color = Entercolor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            thisButton.color = Disablecolor;
        }
    }
}
