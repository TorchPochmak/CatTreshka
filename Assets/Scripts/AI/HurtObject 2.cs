using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
    [SerializeField] private float hurtCooldown = 1f;
    private HPController playerHP;
    private IEnumerator HurtCoroutine;
    private void Start()
    {
        playerHP = Singletons.CatPlayer.GetComponent<HPController>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == CatTreshka.Singletons.CatPlayer.gameObject)
        {
            HurtCoroutine = HurtPlayer();
            StartCoroutine(HurtCoroutine);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == CatTreshka.Singletons.CatPlayer.gameObject)
        {
            StopCoroutine(HurtCoroutine);
        }
    }
    private IEnumerator HurtPlayer()
    {
        while (true)
        {
            playerHP.SetHP(playerHP.GetHp() - 1);
            yield return new WaitForSeconds(hurtCooldown);
        }
    }
}
