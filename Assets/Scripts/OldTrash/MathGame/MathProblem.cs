using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathProblem : MonoBehaviour
{
    public TMP_Text firstNum;
    public TMP_Text secondNum;

    public TMP_Text[] answers;
    
    public TMP_Text operatorProbl;
    public TMP_Text xAnsw;
    public TMP_Text winMessage;
    public TMP_Text solved;

    public Button[] buttons = new Button[3];
    public Color colorWin;
    public Color colorLose;
    public Image image;

    private int firstNumProbl;
    private int secondNumProbl;

    private int answCorrect;
    private int answTwo;
    private int answThree;

    private int displayRandAnsw;
    private int randPlacement;

    private int countRightAnsw = 0;
    public int currentAnsw;
    public int maxWins;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        DisplayMathProblem();
    }

    private int GenerateUniq(int currNum, int prevNum, int oneMoreNum = 0)
    {
        //Generate uniq number
        if (oneMoreNum != 0)
        {
            do
            {
                currNum = Random.Range(prevNum - 50, prevNum + 50);
            } while (currNum == prevNum);
        } else
        {
            do
            {
                currNum = Random.Range(prevNum - 50, prevNum + 50);
            } while (currNum == prevNum || currNum == oneMoreNum);
        }
        
        
        return currNum;
    }

    private void SetProblemNums(int firstNum, int secondNum, int oper)
    {
        if (oper == 0) // equal +
        {
            int randFirst = Random.Range(-100, 100);
            int randSecond = Random.Range(0, 150);

            firstNumProbl = randFirst;
            secondNumProbl = randSecond;
            return;
        } 
        else if (oper == 1) // equal -
        {
            int randFirst = Random.Range(50, 200);
            int randSecond = Random.Range(0, 150);

            firstNumProbl = randFirst;
            secondNumProbl = randSecond;
            return;
        } 
        else if (oper == 2) // equal *
        {
            int randFirst = Random.Range(3, 10);
            int randSecond = Random.Range(4, 15);

            firstNumProbl = randFirst;
            secondNumProbl = randSecond;
            return;
        }
        //Generate first and second number for our prolem
    }

    public void DisplayMathProblem()
    {

        int rnd = Random.Range(0, 3);
        if (rnd == 0) // eq +
        {
            SetProblemNums(firstNumProbl, secondNumProbl, 0);
            answCorrect = firstNumProbl + secondNumProbl;
            operatorProbl.text = "+";
        } 
        else if (rnd == 1) // eq -
        {
            SetProblemNums(firstNumProbl, secondNumProbl, 1);
            answCorrect = firstNumProbl - secondNumProbl;
            operatorProbl.text = "-";
        } 
        else if (rnd == 2) //eq *
        {
            SetProblemNums(firstNumProbl, secondNumProbl, 2);
            answCorrect = firstNumProbl * secondNumProbl;
            operatorProbl.text = "*";
        }

        
        answTwo = GenerateUniq(answTwo, answCorrect); // Genreate uniq wrong answers
        answThree = GenerateUniq(answThree, answTwo, answCorrect);

        firstNum.text = "" + firstNumProbl;
        secondNum.text = "" + secondNumProbl;

        randPlacement = Random.Range(0, 3);
        if (randPlacement == 0)
        {
            answers[0].text = "" + answCorrect;
            answers[1].text = "" + answTwo;
            answers[2].text = "" + answThree;
            currentAnsw = 0;
        } else if (randPlacement == 1) 
        {
            answers[1].text = "" + answCorrect;
            answers[0].text = "" + answTwo;
            answers[2].text = "" + answThree;
            currentAnsw = 1;
        } else if (randPlacement == 2)
        {
            answers[0].text = "" + answTwo;
            answers[1].text = "" + answThree;
            answers[2].text = "" + answCorrect;
            currentAnsw = 2;
        }
    }

    private void SetColor(Button button, int status)
    {
        if (status == 1) // 1 equal win
        {
            ColorBlock cb = button.colors;
            cb.pressedColor = colorWin;
            cb.highlightedColor = colorWin;
            //cb.normalColor = colorWin;  //   - create some bugs
            button.colors = cb;
        } 
        else if (status == 0) // 0 equal lose
        {
            ColorBlock cb = button.colors;
            cb.pressedColor = colorLose;
            cb.highlightedColor = colorLose;
            button.colors = cb;
        }
    }

    public void ButtonAnswer1()
    {
        if (currentAnsw == 0)
        {
            //SetColor(buttons[0], 1); //may be some bugs
            countRightAnsw++;
            solved.text = "Solved: " + countRightAnsw.ToString() + "/" + maxWins;
            if (countRightAnsw == maxWins)
            {
                Debug.Log("You win");
                xAnsw.text = "" + answCorrect;
                winMessage.color = Color.green;
                winMessage.text = "You win!";
                image.transform.localScale = Vector3.zero;
                //gameManager.toMenu(); // load menu scene
            }
            DisplayMathProblem();

        } else
        {
            xAnsw.text = "x";
            DisplayMathProblem();
        }
    }

    public void ButtonAnswer2()
    {
        if (currentAnsw == 1)
        {
            countRightAnsw++;
            solved.text = "Solved: " + countRightAnsw.ToString() + "/" + maxWins;
            if (countRightAnsw == maxWins)
            {
                Debug.Log("You win");
                xAnsw.text = "" + answCorrect;
                winMessage.color = Color.green;
                winMessage.text = "You win!";
                image.transform.localScale = Vector3.zero;
                //gameManager.toMenu(); // load menu scene
            }
            DisplayMathProblem();
        }
        else
        {
            xAnsw.text = "x";
            DisplayMathProblem();
        }
    }


    public void ButtonAnswer3()
    {
        if (currentAnsw == 2)
        {
            countRightAnsw++;
            solved.text = "Solved: " + countRightAnsw.ToString() + "/" + maxWins;
            if (countRightAnsw == maxWins)
            {
                Debug.Log("You win");
                xAnsw.text = "" + answCorrect;
                winMessage.color = Color.green;
                winMessage.text = "You win!";
                image.transform.localScale = Vector3.zero;
                //gameManager.toMenu(); // load menu scene
            }
            DisplayMathProblem();
        }
        else
        {
            xAnsw.text = "x";
            DisplayMathProblem();
        }
    }
}
