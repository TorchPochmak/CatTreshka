using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioSource CoinCollected;
    [SerializeField] private TextMeshProUGUI text;
    private int Coins;
    private void Start()
    {
        Coins = GameData.CoinsCount;
    }

    private void Update()
    {
        text.text = Coins.ToString();
    }
    public void AddCoins(int coins)
    {
        if (CoinCollected.isPlaying) CoinCollected.Stop();
        CoinCollected.Play();
        Coins += coins;
    }
    public int GetCoins()
    {
        return Coins;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("d");
        if (collision.gameObject.tag == "Coin")
        {
            AddCoins(1);
            collision.gameObject.SetActive(false);
        }
    }

}
