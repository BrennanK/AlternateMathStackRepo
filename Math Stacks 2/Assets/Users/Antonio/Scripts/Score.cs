using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText;

    private void Update()
    {
        scoreText.text = "" + score;
    }

    public void ScoreZero()
    {
        score = 0;
    }
}

