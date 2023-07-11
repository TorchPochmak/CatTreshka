using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    [SerializeField] private SaveSystem savesystem;
    // Start is called before the first frame update
    public void Click()
    {
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.Save();
        savesystem.LoadData();
    }
}
