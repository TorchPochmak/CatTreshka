using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Item item;
    private GameObject itemObj;

    private InventoryManager inventoryManager;
    private InventorySlot[] slots;

    private void Awake()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        itemObj = gameObject;
      //  item.countReset(); - appear bugs
    }

    private void Start()
    {
        slots = inventoryManager.inventorySlots;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CAT")
        {
            gameObject.SetActive(false);

            if (!item.isStackable || (item.isStackable && item.currCount == 0))
            {
                inventoryManager.PutIntoEmpty(item, itemObj);
            }
            else
            {
                for (int i = 0; i < slots.Length; ++i)
                {
                    if (slots[i].slotItem == item)
                    {
                        inventoryManager.PutIntoExist(item, itemObj);
                    }
                }
            }
            
            
            
            Debug.Log("Put Item");
        }
    }
}
