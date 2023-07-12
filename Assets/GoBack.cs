using CatTreshka;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gogo());
    }
    private IEnumerator gogo()
    {
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(time);
        manager.LoadLevelByName("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
