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
        // ��� ������ ���� ���������� - ��������
        SceneManager.LoadScene(GameMenu);
    }

    public void OnGameExit()
    {
        // ����� ������� ���� ������ ����� ..
        Application.Quit();
    }
    public void ToMenu()
    {
        // ��� ������ ���� ���������� - ��������
        //TODO ����������???
        SceneManager.LoadScene(Menu);
    }
    public void LoadLevelByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
