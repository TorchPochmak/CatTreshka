using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string Menu = "MainMenu";
    [SerializeField] string GameMenu = "GameScene";
    public void OnGameStart()
    {
        // тут должна быть сохрянение - загрузка
        SceneManager.LoadScene(GameMenu);
    }

    public void OnGameExit()
    {
        // можно сделать типо хотите выйти ..
        Application.Quit();
    }
    public void ToMenu()
    {
        // тут должна быть сохрянение - загрузка
        //TODO сохранение???
        SceneManager.LoadScene(Menu);
    }
    public void LoadLevelByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
