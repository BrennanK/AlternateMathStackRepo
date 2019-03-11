// Author: Mehmet Holbert
// Description: Generates Equations based on Current selected Grade Level and well Evaluates them for Answer Checker Script.
// Date: 1/16/2019
// Last Edited By: Shijn Guo
// Last Edited Date: 03/08/2019 add animator;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour
{
    private BoxSpawner spwn;
    private StampGen stmp;
    private Score scre;
    private int answer;
    public List<GameObject> boxes = new List<GameObject>();
    public bool Check;
    public EquationGen EG;
    private Timer timer;
    public List<int> numbers = new List<int>();
    private int correctAnswers = 0;
    bool changeColor;
    private TutorialK TK;
    private Tape tape;

    // reference for animation in background
    public GameObject movingWalker;
    private WorkAnimation workAnimation;
   
    private void Awake()
    {
        TK = FindObjectOfType<TutorialK>().GetComponent<TutorialK>();
    }
    private void Start()
    {
        EG = FindObjectOfType<EquationGen>().GetComponent<EquationGen>();
        timer = FindObjectOfType<Timer>();
        spwn = GameObject.Find("SpawnEngine").GetComponent<BoxSpawner>();
        stmp = GameObject.Find("UI Screens").GetComponent<StampGen>();
        scre = GameObject.Find("Score Bar").GetComponent<Score>();
        tape = GetComponent<Tape>();
        changeColor = false;
    }

    private void FixedUpdate()
    {
        if (Check && boxes.Any())//Are we checking and are there any boxes in the trigger?
        {
            int i;
            for (i = 0; i < boxes.Count; i++) numbers.Add(boxes[i].GetComponent<NumberGen>().number);//For loop for pulling the number values out of the boxes.

            if (i == boxes.Count)//stop at the list length
            {
                
                answer = numbers.Sum();
                CheckAnswer();
                Check = false;
            }
        }
    }

    private void Update()
    {
        if (changeColor)
        {
            ColorSwapper();
        }
        
    }

    private void CheckAnswer()//Checks the answer with what is being placed on the pallet
    {
        Check = true;
        if (Check && answer != null)// are we checking and has the answer been predefined
        {
            if (answer == EG.answer)
            {
                EG.EquationText.color = Color.green;
                GameManager.Instance.CorrectAnswer();
                changeColor = true;
                numbers.Clear();
                boxes.Clear();
                Check = false;
                spwn.DestroyBoxes();
                stmp.gameobjectHere = false;
                correctAnswers++;
                scre.score += 10;
                timer.time += 10f;
                //tape.startfunciton = true;
                if (correctAnswers >= 10)
                {
                    scre.score += 100;
                    correctAnswers = 0;
                }

                // Trigger of Animator in Test_Scene
                GameObject[] temp = SceneManager.GetSceneByName("Test_Scene").GetRootGameObjects();
                for (int i = 0; i < temp.Length; i++)
                {
                    // Debug.Log(temp[i]);
                    if (temp[i].name == "Animator")
                    {
                        // Debug.Log(temp[i]);
                        workAnimation = temp[i].GetComponent<WorkAnimation>();
                        workAnimation.isAnimating = true;
                        //temp[i].GetComponent<WorkAnimation>().isAnimating = true;
                        //FindObjectOfType<WorkAnimation>().GetComponent<WorkAnimation>().isAnimating = true;
                    }
                }

            }

            else
            {
                EG.EquationText.color = Color.red;
                Debug.Log("Wrong");
                changeColor = true;
                numbers.Clear();
                answer = 0;
                timer.time -= 5f;
                //boxes.Clear();
                Check = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)//Adds boxes into a list when they enter the pallets trigger
    {
        if (col.GetComponent<NumberGen>())
        {
            if (!boxes.Contains(col.gameObject))
            {
                boxes.Add(col.gameObject);
            }
        }
        TK.BoxEnter();
    }

    
    private void OnTriggerExit(Collider col)//Removes boxes from the list when they leave the pallet trigger
    {
        Debug.Log("something has been staying in this trigger");
        if (col.GetComponent<NumberGen>())
        {
            Debug.Log("box entered trigger");
            if (boxes.Contains(col.gameObject))
            {
                boxes.Remove(col.gameObject);
                Debug.Log("added box into list");
            }
        }
    }

    public void ColorSwapper()
    {
        EG.EquationText.color = Color.Lerp(EG.EquationText.color, Color.white, 0.01f);
    }
}