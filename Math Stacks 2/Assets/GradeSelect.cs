using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeSelect : MonoBehaviour
{
    private MenuManager mM;

    private GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        mM = FindObjectOfType<MenuManager>().GetComponent<MenuManager>();
        gM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallLvK()
    {
        gM.LevelSelect(0);
        mM.InGameOverlayActive();
    }
    public void CallLv1()
    {
        gM.LevelSelect(1);
        mM.InGameOverlayActive();
    }
    public void CallLv2()
    {
        gM.LevelSelect(2);
        mM.InGameOverlayActive();
    }
    public void CallLv3()
    {
        gM.LevelSelect(3);
        mM.InGameOverlayActive();
    }
    public void CallLv4()
    {
        gM.LevelSelect(4);
        mM.InGameOverlayActive();
    }
    public void CallLv5()
    {
        gM.LevelSelect(5);
        mM.InGameOverlayActive();
    }

    public void Back()
    {
        gM.BackToMain();
        mM.Back();
    }
}
