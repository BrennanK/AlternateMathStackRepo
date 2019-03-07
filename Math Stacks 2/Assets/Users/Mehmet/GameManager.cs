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
    public GameObject tapeButton;
    public GameObject scissorButton;
    private Tape tape;
    private Boxcount BC;
    public float timer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        curScene = SceneManager.GetActiveScene();
        sceneName = curScene.name;
        if (sceneName == "Test_Scene")
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
                tapeButton.SetActive(false);
                scissorButton.SetActive(false);
                break;
            case 1:
                LabelButton.SetActive(false);
                tapeButton.SetActive(false);
                scissorButton.SetActive(false);
                break;
            case 2:
                LabelButton.SetActive(true);
                tapeButton.SetActive(true);
                scissorButton.SetActive(true);
                Minus.SetActive(false);
                Multiply.SetActive(false);
                Divide.SetActive(false);
                break;
            case 3:
                LabelButton.SetActive(true);
                tapeButton.SetActive(true);
                scissorButton.SetActive(true);
                Minus.SetActive(true);
                Multiply.SetActive(false);
                Divide.SetActive(false);
                break;
            case 4:
                LabelButton.SetActive(true);
                tapeButton.SetActive(true);
                scissorButton.SetActive(true);
                Minus.SetActive(true);
                Multiply.SetActive(true);
                Divide.SetActive(false);
                break;
            case 5:
                LabelButton.SetActive(true);
                tapeButton.SetActive(true);
                scissorButton.SetActive(true);
                Minus.SetActive(true);
                Multiply.SetActive(true);
                Divide.SetActive(true);
                
                break;
           default:
               LabelButton.SetActive(true);
               tapeButton.SetActive(true);
               scissorButton.SetActive(true);
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

    public void GradeSelect()
    {
        SceneManager.LoadScene("Grade Select");
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void CorrectAnswer() //Regenerates an equation 
    {
        EG.CallGrade();
        tape = FindObjectOfType<Tape>().GetComponent<Tape>();
        tape.startfunciton = true;
        BC = FindObjectOfType<Boxcount>().GetComponent<Boxcount>();
        BC.DeletAll();
    }
}