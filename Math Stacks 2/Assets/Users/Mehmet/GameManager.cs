// Author: Mehmet Holbert
// Description: Manages General Game Loop.
// Date: 1/21/2019
// Last Edited By: 
// Last Edited Date: 1/21/2019

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Creating a Singleton
    private AnswerChecker AC;
    public int currLevels;
    private Scene curScene;
    public EquationGen EG;
    private string sceneName;
    public GameObject LabelButton;
    public GameObject Plus;
    public GameObject Minus;
    public GameObject Multiply;
    public GameObject Divide;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
       
        curScene = SceneManager.GetActiveScene();
        sceneName = curScene.name;
        if (sceneName != "Main Menu")
        {
            if (EG == null)
            {
                EG = FindObjectOfType<EquationGen>().GetComponent<EquationGen>(); //Finding the Equation Gen
                EG.enabled = true;
            }

            if (AC == null) AC = FindObjectOfType<AnswerChecker>().GetComponent<AnswerChecker>();
        }

        switch (currLevels)
        {
            case 0:
                LabelButton.SetActive(false);
                break;
            case 1:
                LabelButton.SetActive(false);
                break;
            case 2:
                LabelButton.SetActive(true);
                Minus.SetActive(false);
                Multiply.SetActive(false);
                Divide.SetActive(false);
                break;
            case 3:
                LabelButton.SetActive(true);
                Minus.SetActive(true);
                Multiply.SetActive(false);
                Divide.SetActive(false);
                break;
            case 4:
                LabelButton.SetActive(true);
                Minus.SetActive(true);
                Multiply.SetActive(true);
                Divide.SetActive(false);
                break;
            case 5:
                LabelButton.SetActive(true);
                Minus.SetActive(true);
                Multiply.SetActive(true);
                Divide.SetActive(true);
                
                break;
           default:
               LabelButton.SetActive(true);
               break;

        }
    }

    public void Check()
    {
        AC.Check = true;
    }

    public void LevelSelect(int level) //Sets current level selected 
    {
        currLevels = level;
        
        SceneManager.LoadScene("Test_Scene");
    
    }

    public void CorrectAnswer() //Regenerates an equation 
    {
        EG.CallGrade();
    }
}