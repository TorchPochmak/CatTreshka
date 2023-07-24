using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] // Создание менюшки в инспекторе

public class Item : ScriptableObject
{
    [SerializeField] private string title_ = "Name";
    [SerializeField] private string description_ = "Description";
    [SerializeField] private string properties_ = "Properties";
    [SerializeField] private bool isStackable_ = false;
    [SerializeField] private int currCount_ = 0;
    [SerializeField] private int maxCount_ = 100;
    [SerializeField] private Sprite icon_ = null;

    public string title
    {
        get
        {
            return title_;
        }
    }

    public string description
    {
        get
        {
            return description_;
        }
    }

    public string properties
    {
        get
        {
            return properties_;
        }
    }

    public bool isStackable
    {
        get
        {
            return isStackable_;
        }
    }

    public int currCount
    {
        get
        {
            return currCount_;
        }
    }

    public int maxCount
    {
        get
        {
            return maxCount_;
        }
    }

    public Sprite icon
    {
        get
        {
            return icon_;
        }
    }

    public void countIncrease()
    {
        if (isStackable && currCount + 1 <= maxCount)
        {
            currCount_++;
        }
    }
    
    public void countDecrease()
    {
        if (isStackable && currCount - 1 >= 0)
        {
            currCount_--;
        }
    }

    public void countReset()
    {
        currCount_ = 0;
    }

}


