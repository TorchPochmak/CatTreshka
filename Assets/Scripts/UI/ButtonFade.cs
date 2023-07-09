using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatTreshka
{
    public class ButtonFade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image thisButton;
        [SerializeField] private Color Entercolor;
        [SerializeField] private Color Disablecolor;


        private void Start()
        {
            thisButton = this.GetComponent<Image>();
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
        public void Click()
        {
            Debug.LogError("Clicked");
        }
    }
}
