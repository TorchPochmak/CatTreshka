using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour 
{
    public Item slotItem;
    public GameObject itemObject;
    public Text countText;
    public SimpleSlot simpleSlot;


    private Image icon;
    private Button button;
    private ItemInfo inf;
    

    private void Awake()
    {
        
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        countText = icon.transform.GetChild(0).GetComponent<Text>();
        countText.text = "";

        icon.enabled = false;
        button = GetComponent<Button>();
        inf = GameObject.Find("Info").GetComponent<ItemInfo>();
    }

    private void Start()
    {
        button.onClick.AddListener(ShowInfo);
    }

    public void PutItem(Item item_, GameObject obj)
    {
        if (item_.isStackable && item_.currCount > 0)
        {
            item_.countIncrease();
            countText.fontSize = 24;
            countText.color = Color.white;
            countText.text = slotItem.currCount.ToString();
        } 
        else if (item_.isStackable && item_.currCount == 0)
        {
            icon.sprite = item_.icon;
            slotItem = item_;
            icon.enabled = true;
            itemObject = obj;

            slotItem.countIncrease();
            countText.fontSize = 24;
            countText.color = Color.white;
            countText.text = slotItem.currCount.ToString();
        } 
        else if (!item_.isStackable)
        {
            icon.sprite = item_.icon;
            slotItem = item_;
            icon.enabled = true;
            itemObject = obj;
        }

        Debug.Log("Item was putten");
    }

    private void ShowInfo()
    {
        if (slotItem != null && simpleSlot != null)
        {
            inf.OpenInfo(slotItem, itemObject, this, simpleSlot);
        } else
        {
            inf.OpenInfo(slotItem, itemObject, this);
        }
    }

    public void ClearSlot()
    {
        if (slotItem.isStackable && slotItem.currCount == 1)
        {
            countText.text = "" + slotItem.currCount;
            slotItem.countDecrease();
            countText.text = "";

            slotItem = null;
            itemObject = null;
            icon.enabled = false;
        } 
        else if (slotItem.isStackable && slotItem.currCount > 1)
        {
            slotItem.countDecrease();
            countText.text = slotItem.currCount.ToString();
        } 
        else if (!slotItem.isStackable)
        {
            slotItem = null;
            itemObject = null;
            icon.enabled = false;
        }
        
    }
}
