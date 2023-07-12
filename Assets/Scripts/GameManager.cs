using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatTreshka
{
    //Все упоминания названия сцен с комменатрием SCENE_NAME
    public class GameManager : MonoBehaviour
    {
        [SerializeField] string Menu = "MainMenu";
        [SerializeField] string LevelLearn = "LevelLearn";
        [SerializeField] string Level1 = "Level1";
        [SerializeField] string Level2 = "Level2";
        [SerializeField] string Level3 = "Level3";
        [SerializeField] string gameEnded = "GameEnd";
        [SerializeField] string DemoKat = "DemoMenu";

        //MainMenu_Play
        public void OnGameStart()
        {
            switch (GameData.CurrentLevel)
            {
                
                case 0:
                    {
                        // SCENE_NAME
                        LoadLevelByName(DemoKat);
                        break;
                    }
                case 1:
                    {
                        LoadLevelByName(Level1);
                        break;
                    }
                case 2:
                    {
                        // SCENE_NAME
                        LoadLevelByName(Level2);
                        break;
                    }
                case 3:
                    {
                        // SCENE_NAME
                        LoadLevelByName(Level3);
                        break;
                    }
                default:
                case 100:
                    {
                        LoadLevelByName(gameEnded);
                        break;
                    }
            }
        }

        //MainMenu_Exit
        public void OnGameExit()
        {
            // можно сделать типо хотите выйти ..
            Application.Quit();
        }

        //Game_ToMainMenu
        public void ToMenu()
        {
            SceneManager.LoadScene(Menu);
        }
        public void LoadLevelByName(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}