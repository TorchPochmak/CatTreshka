using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSlot : MonoBehaviour // same with InventorySlot but for SimpleSlot
{
    public Item simpleItem;
    //public Item slotItem;
    public GameObject itemObject;

    private Image icon;
    private Button button;
    private Text countText;


    private void Awake()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        countText = icon.transform.GetChild(0).GetComponent<Text>();
        icon.enabled = false;
        button = GetComponent<Button>();
        
    }

    public void PutSimpleItem(Item item_, GameObject obj)
    {
        if (item_.isStackable && item_.currCount > 1)
        {
            //item_.countIncrease();
            countText.fontSize = 24;
            countText.color = Color.white;
            countText.text = simpleItem.currCount.ToString();
        }
        else if (item_.isStackable && item_.currCount == 1)
        {
            icon.sprite = item_.icon;
            simpleItem = item_;
            icon.enabled = true;
            itemObject = obj;

            //simpleItem.currCount++;
            countText.fontSize = 24;
            countText.color = Color.white;
            countText.text = simpleItem.currCount.ToString();
        }
        else if (!item_.isStackable)
        {
            icon.sprite = item_.icon;
            simpleItem = item_;
            icon.enabled = true;
            itemObject = obj;

            Debug.Log("Simple item was putten");
        }
    }

    public void ClearSimpleSlot()
    {

        if (simpleItem.isStackable && simpleItem.currCount == 0)
        {
            simpleItem = null;
            itemObject = null;
            icon.enabled = false;
            //simpleItem.countDecrease();
            countText.text = "";
        }
        else if (simpleItem.isStackable && simpleItem.currCount > 0)
        {
            //simpleItem.countDecrease();
            if (simpleItem.currCount > 1)
            {
                countText.text = simpleItem.currCount.ToString();
            } 
            else
            {
                countText.text = "" + 1;
            }
            
        }
        else if (!simpleItem.isStackable)
        {
            simpleItem = null;
            itemObject = null;
            icon.enabled = false;
        }
    }
        
}
