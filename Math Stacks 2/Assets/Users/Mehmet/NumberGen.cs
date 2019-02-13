// Author: Mehmet Holbert
// Description: Generates Equations based on Current selected Grade Level and well Evaluates them for Answer Checker Script.
// Date: 1/16/2019
// Last Edited By: 
// Last Edited Date: 1/21/2019
using TMPro;
using UnityEditor;
using UnityEngine;

public class NumberGen : MonoBehaviour
{
    public int number;
    private TextMeshProUGUI numText;

    private GameManager GM;
    int newValue;
    int result;
    string operant;
    int temp;
    public bool canEvaluate;
    public bool hasStamp;
    public int oldValue;

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (GM.currLevels == 0 || GM.currLevels == 1 || GM.currLevels == 2 || GM.currLevels == 3)
        {
            number = 1;
        }

        else if (GM.currLevels == 4 || GM.currLevels == 5)
        {
            number = Random.Range(1, 12);
        }

        if (this.gameObject.GetComponent<BlankID>() != null)
        {
            number = 0;
        }

        canEvaluate = false;
        hasStamp = false;

        oldValue = number;
        numText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (number < 0)
        {
            number = 0;
        }

        numText.text = number.ToString();

        Reevaluate();
    }

    private void Reevaluate()
    {
        if (canEvaluate)
        {
            Invoke("InvokeEvaluation", 0.1f);
            canEvaluate = false;
        }
    }

    public void InvokeEvaluation()
    {
        newValue = GetComponentInChildren<Stamp>().stampNumber;
        operant = GetComponentInChildren<Stamp>().stampOpperator;

        switch (operant)
        {
            case "+":
                result = oldValue + newValue;
                break;
            case "-":
                result = oldValue - newValue;
                break;
            case "*":
                result = oldValue * newValue;
                break;
            case "/":
                result = oldValue / newValue;
                break;
        }

        number = result;
    }
}