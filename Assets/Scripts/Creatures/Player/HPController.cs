using CatTreshka;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] private AudioSource source;

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


    float r, g, b,tick,time;
    Color c;
    private IEnumerator changeColor(Color targetColor)
    {
        r = Mathf.Abs(targetColor.r - sprite.color.r) / ticksToChangeColor * 2;
        g = Mathf.Abs(targetColor.g - sprite.color.g) / ticksToChangeColor * 2;
        b = Mathf.Abs(targetColor.b - sprite.color.b) / ticksToChangeColor * 2;
        tick = timeToChangeColor / ticksToChangeColor;
        time = 0f;
        c = sprite.color;
        yield return new WaitForEndOfFrame();
        WaitForSeconds tck = new WaitForSeconds(tick);
        while (time < timeToChangeColor / 2)
        {
            time += tick;
            c.r = sprite.color.r - r;
            c.g = sprite.color.g - g;
            c.b = sprite.color.b - b;
            sprite.color = c;
            yield return tck;
        }
        time = timeToChangeColor / 2;
        c = sprite.color;
        while (time > 0f)
        {
            time -= tick;
            c.r = sprite.color.r + r;
            c.g = sprite.color.g + g;
            c.b = sprite.color.b + b;
            sprite.color = c;
            yield return tck;
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
            source.Play();
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
        StartCoroutine(ChangeInterface());
        if(hp == 0) StartCoroutine(Die());
    }
    private IEnumerator ChangeInterface()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < hp; i++)
        {
            interafaceLinks[i].texture = yesHP;
            interafaceLinks[i].color = yesColor;
        }
        yield return new WaitForEndOfFrame();
        for (int i = hp; i < 3; i++)
        {
            interafaceLinks[i].color = noColor;
            interafaceLinks[i].texture = noHP;
        }
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
        Color c = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        WaitForSecondsRealtime tck = new WaitForSecondsRealtime(tick);
        for (int i = 255; i >= 0; i -= Atick)
        {
            c.a = (float)i / 255;
            sprite.color = c;
            yield return tck;
        }
        c.a = 0;
        sprite.color = c;
        yield return StartCoroutine(RespawnGo());
    }
    public IEnumerator RespawnGo()
    {
        yield return StartCoroutine(respawn.RespawnFirst());
        Debug.Log("ppppppppopopoppepepeop");
        
        
    }
}
