using CatTreshka;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HPController : MonoBehaviour
{
    [SerializeField] private Respawn respawn;

    private bool CanBeHurt = true;




    public bool isDead = false;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Color yesColor;
    [SerializeField] private Color noColor;

    [SerializeField] private Color hurtColor;
    [SerializeField] private Color healColor;

    [SerializeField] private float ticksToChangeColor;
    [SerializeField] private float timeToChangeColor;

    [SerializeField] private float dieTime;
    [SerializeField] private float ticksToDie;

    [SerializeField] private int beginHP;
    private int hp;

    [SerializeField] private Texture yesHP;
    [SerializeField] private Texture noHP;

    [SerializeField] private List<RawImage> interafaceLinks;

    private IEnumerator changeColor(Color targetColor)
    {
            float r = Mathf.Abs(targetColor.r - sprite.color.r) / ticksToChangeColor * 2;
            float g = Mathf.Abs(targetColor.g - sprite.color.g) / ticksToChangeColor * 2;
            float b = Mathf.Abs(targetColor.b - sprite.color.b) / ticksToChangeColor * 2;
            float tick = timeToChangeColor / ticksToChangeColor;
            float time = 0f;
            while (time < timeToChangeColor / 2)
            {
                time += tick;
                sprite.color = new Color(sprite.color.r - r, sprite.color.g - g, sprite.color.b - b, sprite.color.a);
                yield return new WaitForSeconds(tick);
            }
            time = timeToChangeColor / 2;
            while (time > 0f)
            {
                time -= tick;
                sprite.color = new Color(sprite.color.r + r, sprite.color.g + g, sprite.color.b + b, sprite.color.a);
                yield return new WaitForSeconds(tick);
            }
    }
    private IEnumerator Hurting()
    {
        CanBeHurt = false;
        yield return new WaitForSeconds(2f);
        CanBeHurt = true;
    }
    public int GetHp()
    {
        return hp;
    }
    public void SetHP(int _hp)
    {
        if (isDead) return;
        if (_hp < hp)
        {
            //hurt
            if (!CanBeHurt) return;
            StartCoroutine(changeColor(hurtColor));
            StartCoroutine(Hurting());
        }
        else if (_hp > hp)
        {
            StartCoroutine(changeColor(healColor));
        }
        if (_hp < 0)
        {
            hp = 0;
        }
        else if (_hp > 3) hp = 3;
        else hp = _hp;

        for (int i = 0; i < hp; i++)
        {
            interafaceLinks[i].texture = yesHP;
            interafaceLinks[i].color = yesColor;
        }
        for(int i = hp; i < 3; i++)
        {
            interafaceLinks[i].color = noColor;
            interafaceLinks[i].texture = noHP;
        }
        if(hp == 0) StartCoroutine(Die());
    }
    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        isDead = false;
        SetHP(beginHP);

    }
    public IEnumerator Die()
    {
        isDead = true;
        float tick = dieTime / ticksToDie;
        int Atick = 255 / (int)ticksToDie;
        for (int i = 255; i >= 0; i -= Atick)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, (float)i / 255);
            yield return new WaitForSecondsRealtime(tick);
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        yield return StartCoroutine(RespawnGo());
    }
    public IEnumerator RespawnGo()
    {
        yield return StartCoroutine(respawn.RespawnFirst());
        Debug.Log("ppppppppopopoppepepeop");
        
        
    }
}
