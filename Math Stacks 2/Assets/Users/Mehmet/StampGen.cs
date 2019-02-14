// Author: Mehmet Holbert
// Description: Generates stamps
// Date: 2/1/2019
// Last Edited By: 
// Last Edited Date: 2/7/2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StampGen : MonoBehaviour
{
    private int Number;
    private string Operator;
    public Text StampTag;
    public GameObject Stamp;
    public Transform StampSpwn;
    private Stamp stmp;
    private MenuManager mng;
    private bool canNum;
    private bool canOpp;
    public bool canMake;
    public bool gameobjectHere;
    private TutorialK TK;
    void Awake()
    {
        StampTag = StampTag.GetComponent<Text>();
        mng = FindObjectOfType<MenuManager>();

        canNum = false;
        canOpp = false;
        canMake = true;
        gameobjectHere = false;
}

    public void ChangeNumber(int _num)
    {
        Number = _num;
        canNum = true;
        GameObject[] temp = SceneManager.GetSceneByName("Test_Scene").GetRootGameObjects();
        for (int i = 0; i < temp.Length; i++)
        {

            if (temp[i].name == "TutorialTwo")
            {
                TK = temp[i].GetComponent<TutorialK>();
                TK.ClickNumber();
            }
        }
    }

    public void ChangeOperator(string _Op)
    {
        Operator = _Op;
        canOpp = true;
        TK.ClickOperator();
    }

    void FixedUpdate()
    {
        StampTag.text = Operator + Number.ToString();
    }

    public void CreateStamp()
    {
        StampSpwn = GameObject.Find("StampSpwn").transform;

        if (canMake)
        {
            if (canNum && canOpp)
            {
                Instantiate(Stamp, StampSpwn.transform.position, Quaternion.Euler(0, 180, 0));
                stmp = FindObjectOfType<Stamp>().GetComponent<Stamp>();
                stmp.StampValue(Operator, Number);
                mng.Cancel();
                Operator = "";
                Number = 0;
                //StampTag.text = "0";
                canNum = false;
                canOpp = false;
                canMake = false;
                TK.ClickCrate();
            }
        }
    }


}
