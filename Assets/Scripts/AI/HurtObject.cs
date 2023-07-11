using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
    [SerializeField] private float hurtCooldown = 1f;
    private HPController playerHP;
    private void Start()
    {
        playerHP = Singletons.CatPlayer.GetComponent<HPController>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHP.SetHP(playerHP.GetHp() - 1);
        }
    }
}
