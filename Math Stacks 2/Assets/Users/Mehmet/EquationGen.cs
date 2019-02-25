// Author: Mehmet Holbert
// Description: Generates Equations based on Current selected Grade Level and well Evaluates them for Answer Checker Script.
// Date: 1/15/2019
// Last Edited By: 
// Last Edited Date: 1/21/2019

using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquationGen : MonoBehaviour
{
    private readonly string[] opperand = {"+", "-", "x", "/"}; //List of Operators
    public float answer;

    public Text EquationText;
    private int currLevel;
    private int index;
    private int index2;
    public bool isK, IsFirst, isSecond, isThird, isFourth, isFifth; //Boolians for each Grade type
    private float firstNum;
    private float SecondNum;
    private float ThirdNum;
    private float tmpHolder;
    public GameObject[] Boxes;
    private Scene curScene;
    private string SceneName;
    private bool startGame;
    public void Awake ()

    {
        startGame = true;
        EquationText = EquationText.GetComponent<Text>();
    
        CallGrade();

        currLevel = GameManager.Instance.currLevels;
    }

    public void Update()
    {
       
        Boxes = GameObject.FindGameObjectsWithTag("Draggable");

        Evaluate();
      
        if (GameManager.Instance.currLevels != currLevel)
        {
            answer = 0;
            CallGrade();
            currLevel = GameManager.Instance.currLevels;
        }

   


    }

    public void StartShow()
    {
        EquationText.text = "    ";
        if (GameManager.Instance.currLevels == 0)
        {
            
            CallGrade();
           
        }
    }
    public void CallGrade()
    {
        if (startGame)
        {
            isK = true;
            IsFirst = false;
            isSecond = false;
            isThird = false;
            isFourth = false;
            isFifth = false;
            startGame = false;
        }
        else
        {
            
            switch (GameManager.Instance.currLevels) //Switch Statement for when a Grade was Selected.
            {
                case 0:
                    isK = true;
                    IsFirst = false;
                    isSecond = false;
                    isThird = false;
                    isFourth = false;
                    isFifth = false;
                    break;
                case 1:
                    isK = false;
                    IsFirst = true;
                    isSecond = false;
                    isThird = false;
                    isFourth = false;
                    isFifth = false;
                    break;
                case 2:
                    isK = false;
                    IsFirst = false;
                    isSecond = true;
                    isThird = false;
                    isFourth = false;
                    isFifth = false;
                    break;
                case 3:
                    isK = false;
                    IsFirst = false;
                    isSecond = false;
                    isThird = true;
                    isFourth = false;
                    isFifth = false;
                    break;
                case 4:
                    isK = false;
                    IsFirst = false;
                    isSecond = false;
                    isThird = false;
                    isFourth = true;
                    isFifth = false;
                    break;
                case 5:
                    isK = false;
                    IsFirst = false;
                    isSecond = false;
                    isThird = false;
                    isFourth = false;
                    isFifth = true;
                    break;
                default:
                    isK = true;
                    IsFirst = false;
                    isSecond = false;
                    isThird = false;
                    isFourth = false;
                    isFifth = false;
                    Debug.Log("Exceeded Range Potential Setting to Kindergarten as Safe Protocol ");
                    break;
            }
        }
        //Calls appropriate method for each grade level.
        if (isK)
            Kindergarden();
        else if (IsFirst || isSecond)
            FirstandSecond();
        else if (isThird)
            Third();
        else if (isFourth || isFifth)
            FourthandFifth();
    }

    private void Kindergarden()
    {
        firstNum = Random.Range(1, 10);
        WriteEquation();
    }

    private void FirstandSecond()
    {
        firstNum = Random.Range(1, 11);
        SecondNum = Random.Range(1, 11);
        index = Random.Range(0, 2);
    }

    private void Third()
    {
        firstNum = Random.Range(1, 11);
        SecondNum = Random.Range(1, 11);
        index = Random.Range(0, opperand.Length);
    }

    private void FourthandFifth()
    {
        firstNum = Random.Range(1, 11);
        SecondNum = Random.Range(1, 11);
        ThirdNum = Random.Range(1, 11);
        index = Random.Range(0, opperand.Length);
        index2 = Random.Range(0, opperand.Length);
    }

    public void Evaluate()
    {
        if (!isK)
        {
            if (index == 0) //Addition
            {
                tmpHolder = firstNum + SecondNum;
                if (!isFifth || !isFourth)
                {
                    answer = tmpHolder;

                    if (answer <= ((Boxes[0].GetComponent<NumberGen>().number) +
                                   (Boxes[1].GetComponent<NumberGen>().number) +
                                   (Boxes[2].GetComponent<NumberGen>().number) +
                                   (Boxes[3].GetComponent<NumberGen>().number) +
                                   (Boxes[4].GetComponent<NumberGen>().number) + 
                                   (Boxes[5].GetComponent<NumberGen>().number) +
                                   (Boxes[6].GetComponent<NumberGen>().number) +
                                   (Boxes[7].GetComponent<NumberGen>().number) +
                                   (Boxes[8].GetComponent<NumberGen>().number)))
                        WriteEquation();
                    else
                    {
                        firstNum = Random.Range(1, 11);
                        SecondNum = Random.Range(1, 11);
                    }
                }
            }
            else if (index == 1) //Subtraction
            {
                if (firstNum > SecondNum) //preventing negative numbers
                {
                    tmpHolder = firstNum - SecondNum;
                }
                else if (SecondNum > firstNum)
                {
                    tmpHolder = SecondNum - firstNum;
                }
                else //preventing an answer of 0
                {
                    firstNum = Random.Range(1, 11);
                    SecondNum = Random.Range(1, 11);
                }

                if (!isFifth || !isFourth) //Because of order of operation 
                {
                    answer = tmpHolder;
                    WriteEquation();
                }
            }
            else if (index == 2) //Multiplication
            {
                tmpHolder = firstNum * SecondNum;
                if (!isFifth || !isFourth) //Because of order of operation 
                {
                    answer = tmpHolder;
                    if (answer <= ((Boxes[0].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[1].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[2].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[3].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[4].GetComponent<NumberGen>().number + 5)
                                   + (Boxes[5].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[6].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[7].GetComponent<NumberGen>().number + 5) +
                                   (Boxes[8].GetComponent<NumberGen>().number + 5)))
                        WriteEquation();
                    else
                    {
                        Debug.Log("Exceeded Maximum possibility");
                        firstNum = Random.Range(1, 11);
                        SecondNum = Random.Range(1, 11);
                    }
                }
            }
            else if (index == 3) //Division 
            {
                if (firstNum % SecondNum == 0
                ) //Using Modulus to find if the remainder is equal to 0, thus concluding that the two numbers are divisible 
                {
                    tmpHolder = firstNum / SecondNum;
                    if (!isFifth || !isFourth) //Because of order of operation 
                    {
                        answer = tmpHolder;
                        if (answer <= ((Boxes[0].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[1].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[2].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[3].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[4].GetComponent<NumberGen>().number + 5)
                                       + (Boxes[5].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[6].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[7].GetComponent<NumberGen>().number + 5) +
                                       (Boxes[8].GetComponent<NumberGen>().number + 5)))
                            WriteEquation();
                        else
                        {
                            firstNum = Random.Range(1, 11);
                            SecondNum = Random.Range(1, 11);
                        }
                    }
                }
                else //Keep changing until a divisible equation comes.
                {
                    firstNum = Random.Range(1, 11);
                    SecondNum = Random.Range(1, 11);
                }
            }

            if (isFourth || isFifth)
            {
                if (index2 == 0) //Second Addition
                {
                    answer = tmpHolder + ThirdNum;
                    if (answer <= ((Boxes[0].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[1].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[2].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[3].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[4].GetComponent<NumberGen>().number * 5)
                                   + (Boxes[5].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[6].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[7].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[8].GetComponent<NumberGen>().number * 5)))
                        WriteEquation();
                    else
                    {
                        ThirdNum = Random.Range(1, 11);
                    }
                }
                else if (index2 == 1) //Second Subtraction
                {
                    if (tmpHolder > ThirdNum) // Preventing Negative Solution 
                    {
                        answer = tmpHolder - ThirdNum;
                        if (answer <= ((Boxes[0].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[1].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[2].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[3].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[4].GetComponent<NumberGen>().number * 5)
                                       + (Boxes[5].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[6].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[7].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[8].GetComponent<NumberGen>().number * 5)))
                            WriteEquation();
                        else
                        {
                            ThirdNum = Random.Range(1, 11);
                        }
                    }
                    else if (tmpHolder < ThirdNum)
                    {
                        answer = ThirdNum - tmpHolder;
                        if (answer <= ((Boxes[0].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[1].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[2].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[3].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[4].GetComponent<NumberGen>().number * 5)
                                       + (Boxes[5].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[6].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[7].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[8].GetComponent<NumberGen>().number * 5)))
                            WriteEquation();
                        else
                        {
                            ThirdNum = Random.Range(1, 11);
                        }
                    }
                    else //Preventing answer of 0
                    {
                        ThirdNum = Random.Range(1, 11);
                    }
                }
                else if (index2 == 2) //Second multiplication
                {
                    answer = tmpHolder * ThirdNum;
                    if (answer <= ((Boxes[0].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[1].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[2].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[3].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[4].GetComponent<NumberGen>().number * 5)
                                   + (Boxes[5].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[6].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[7].GetComponent<NumberGen>().number * 5) +
                                   (Boxes[8].GetComponent<NumberGen>().number * 5)))
                        WriteEquation();
                    else
                    {
                        ThirdNum = Random.Range(1, 11);
                    }
                }
                else if (index2 == 3) //Second Division
                {
                    if (tmpHolder % ThirdNum == 0) //Using Modulus to find if the two are divisible 
                    {
                        answer = tmpHolder / ThirdNum;
                        if (answer <= ((Boxes[0].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[1].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[2].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[3].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[4].GetComponent<NumberGen>().number * 5)
                                       + (Boxes[5].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[6].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[7].GetComponent<NumberGen>().number * 5) +
                                       (Boxes[8].GetComponent<NumberGen>().number * 5)))
                            WriteEquation();
                        else
                        {
                            ThirdNum = Random.Range(1, 11);
                        }
                    }
                    else //Keep changing until a divisible number shows up
                    {
                        ThirdNum = Random.Range(1, 11);
                    }
                }
            }
        }
        else
        {
            answer = firstNum;
        }
    }

    public void WriteEquation() //Changes text to represent the generated equation.
    {
        if (isK)
        {
            EquationText.text = firstNum.ToString();
        }
        else if (IsFirst || isSecond || isThird)
        {
            if (index == 1)
            {
                if (firstNum > SecondNum)
                    EquationText.text = firstNum + opperand[index] + SecondNum;
                else
                    EquationText.text = SecondNum + opperand[index] + firstNum;
            }
            else
            {
                EquationText.text = firstNum + opperand[index] + SecondNum;
            }
        }
        else
        {
            if (index == 1 && index2 != 1)
            {
                if (firstNum > SecondNum)
                    EquationText.text =
                        "(" + firstNum + opperand[index] + SecondNum + ")" + opperand[index2] + ThirdNum;
                else
                    EquationText.text =
                        "(" + SecondNum + opperand[index] + firstNum + ")" + opperand[index2] + ThirdNum;
            }
            else if (index == 1 && index2 == 1)
            {
                if (firstNum > SecondNum && tmpHolder > ThirdNum)
                    EquationText.text =
                        "(" + firstNum + opperand[index] + SecondNum + ")" + opperand[index2] + ThirdNum;
                else if (firstNum < SecondNum && tmpHolder > ThirdNum)
                    EquationText.text =
                        "(" + SecondNum + opperand[index] + firstNum + ")" + opperand[index2] + ThirdNum;
                else if (firstNum > SecondNum && tmpHolder < ThirdNum)
                    EquationText.text =
                        ThirdNum + opperand[index2] + "(" + firstNum + opperand[index] + SecondNum + ")";
                else if (firstNum < SecondNum && tmpHolder < ThirdNum)
                    EquationText.text =
                        ThirdNum + opperand[index2] + "(" + SecondNum + opperand[index] + firstNum + ")";
            }
            else if (index != 1 && index2 == 1)
            {
                if (tmpHolder > ThirdNum)
                    EquationText.text =
                        "(" + firstNum + opperand[index] + SecondNum + ")" + opperand[index2] + ThirdNum;
                else
                    EquationText.text =
                        ThirdNum + opperand[index2] + "(" + firstNum + opperand[index] + SecondNum + ")";
            }
            else
            {
                EquationText.text = "(" + firstNum + opperand[index] + SecondNum + ")" + opperand[index2] + ThirdNum;
            }
        }
    }
}