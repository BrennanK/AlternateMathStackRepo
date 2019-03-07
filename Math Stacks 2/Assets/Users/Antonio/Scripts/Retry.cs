using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    public int retryLevel;
    [HideInInspector]public MenuManager MM;
    private Score scre;
    public Retry retry;
    private AnswerChecker check;
    private bool doIt;

    private void Start()
    {
        check = FindObjectOfType<AnswerChecker>();
        scre = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if (doIt)
        {
            check.ColorSwapper();
            CallBoolSetter();
        } 
    }

    private void CallBoolSetter()
    {
        StartCoroutine("SetBool");
    }

    private IEnumerator SetBool()
    {
        yield return new WaitForSeconds(5);
        doIt = false;
        StopAllCoroutines();
    }

    public void PushGradeValue()
    {
        retryLevel = GameManager.Instance.currLevels;
        GameManager.Instance.LevelSelect(retryLevel);
        GameManager.Instance.CorrectAnswer();
        doIt = true;
        MM = GameManager.Instance.GetComponentInChildren<MenuManager>();
        MM.SendMessage("InGameOverlayActive");
        scre.score = 0;
    }
}
