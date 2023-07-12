using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNext : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gogo());
    }
    private IEnumerator gogo()
    {
        Debug.Log("WTF");
        yield return new WaitForSeconds(14f);
        Debug.Log("WTF");
        manager.LoadLevelByName("LevelLearn");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
