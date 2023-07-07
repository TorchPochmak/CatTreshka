using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    private int hp = 3;

    [SerializeField] private Texture yesHP;
    [SerializeField] private Texture noHP;

    [SerializeField] private List<RawImage> interafaceLinks;
    public int HP { 
        get 
        {
            return hp;
        }
        set
        {
            if (value < 0) hp = 0;
            else if (value > 3) hp = 3;
            else hp = value;

            ChangeHP(hp);
        }
    }
    private void ChangeHP(int hp)
    {
        for(int i = 0; i < hp; i++)
        {
            interafaceLinks[i].texture = yesHP;
        }
        for(int i = hp; i < 3; i++)
        {
            interafaceLinks[i].texture = noHP;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
