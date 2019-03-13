// Shijun: Add the HighScore System

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText;
    private bool scoreTrigger = true;
    //public GameObject popUP;
    public int level;
    private GameManager GM;

    // Set the values for high scores
    public bool printHighScore;
    private int currentHighScore;
    IList<string> levelList = new List<string>()
    {
        "highScore_level0",
        "highScore_level1",
        "highScore_level2",
        "highScore_level3",
        "highScore_level4",
        "highScore_level5",
    };

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        // Initailize all the keys for the high scores.
        foreach (var level in levelList)
            if (!PlayerPrefs.HasKey(level))
            {
                PlayerPrefs.SetInt(level, 0);
                Debug.Log("Initailize the high score in level" + level);
            }
            else
            {
                Debug.Log("The current high score in " + level + " is " + PlayerPrefs.GetInt(level));
            };
    }

    private void Update()
    {
        level = GM.currLevels;
        scoreText.text = "" + score;
        if (scoreTrigger)
        {
            if (level == 5)
            {
                if (score > 20)
                {
                    Debug.Log("Great Job!!!!");
                    scoreTrigger = false;
                }
            }
            else
            {
                if (score > 20)
                {

                    Debug.Log("Great Job!!!!UP Grade!!!");
                    //popUP.SetActive(true);
                    scoreTrigger = false;
                    //Invoke("StopShow", 5f);
                }
            }
        }

        // Update the score to the PlayerPrefs > AnswerChecker
        //CheckHighScore();
        // Print high scores
        if (Input.GetKeyDown("space") && printHighScore)
        {
            foreach (var level in levelList)
                if (!PlayerPrefs.HasKey(level))
                {
                    Debug.Log("The high score does not exist");
                }
                else
                {
                    Debug.Log("The current high score in " + level + " is " + PlayerPrefs.GetInt(level));
                };
        }
    }

    public void StopShow()
    {
        //popUP.SetActive(false);
    }
    public void ScoreZero()
    {
        score = 0;
    }

    // Check the highest score and save it.
    public void CheckHighScore()
    {
        currentHighScore = PlayerPrefs.GetInt("highScore_level0");

        if (score > currentHighScore)
        {
            switch (level)
            {
                case 0:
                    PlayerPrefs.SetInt("highScore_level0", score);
                    PlayerPrefs.Save();
                    break;
                case 1:
                    PlayerPrefs.SetInt("highScore_level1", score);
                    PlayerPrefs.Save();
                    break;
                case 2:
                    PlayerPrefs.SetInt("highScore_level2", score);
                    PlayerPrefs.Save();
                    break;
                case 3:
                    PlayerPrefs.SetInt("highScore_level3", score);
                    PlayerPrefs.Save();
                    break;
                case 4:
                    PlayerPrefs.SetInt("highScore_level4", score);
                    PlayerPrefs.Save();
                    break;
                case 5:
                    PlayerPrefs.SetInt("highScore_level5", score);
                    PlayerPrefs.Save();
                    break;
            }

            
        }
        
    }
}

