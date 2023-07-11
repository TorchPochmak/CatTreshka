using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatTreshka
{
    public class CatController : MonoBehaviour, IPointerClickHandler
    {
        public GameObject obj;
        public bool isPlaced = false;

        private CatManager catManager;

        private void Awake()
        {
            catManager = GameObject.Find("CatManager").GetComponent<CatManager>();
        }
        public void OnEnable()
        {

        }
        public Vector3 SetZ(Vector3 vector, float z)
        {
            vector.z = z;
            return vector;
        }
        public void OnDisable()
        {
            isPlaced = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isPlaced)
            {
                isPlaced = true;
                this.GetComponent<Animator>().Play("Fade");
                catManager.CheckCats();
            }
        }
    }
}