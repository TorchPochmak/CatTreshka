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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("d");
        if (collision.gameObject.tag == "Coin")
        {
            AddCoins(1);
            Destroy(collision.gameObject);
        }
    }

}
