using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText;
    private bool scoreTrigger = true;
    //public GameObject popUP;
    public int level;
    private GameManager GM;

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    }

    public void StopShow()
    {
        //popUP.SetActive(false);
    }
    public void ScoreZero()
    {
        score = 0;
    }
}

