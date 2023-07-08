using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public int Coins;

    private void Update()
    {
        text.text = Coins.ToString();
    }
}
