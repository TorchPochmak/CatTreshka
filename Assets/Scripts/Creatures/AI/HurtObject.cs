using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour
{
    [SerializeField] private float hurtCooldown = 1f;
    private HPController playerHP;
    private bool isTrigger = false;

    private Collider2D _collision;
    private void Start()
    {
        playerHP = Singletons.CatPlayer.GetComponent<HPController>();
    }
    private void Update()
    {
        if (isTrigger)
        {
            if (_collision != null)
            {
                if (_collision.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("oof");
                    playerHP.SetHP(playerHP.GetHp() - 1);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collision = collision;
        isTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _collision = null;
        isTrigger = false;
    }
}
