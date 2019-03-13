using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherGrade : MonoBehaviour
{
    public GameObject GradeUP;
    public GameObject InGame;
    private MenuManager MM;
    private int currentLevel;
    public GameObject levelk4;
    public GameObject level5;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnEnable()
    {
        InGame.SetActive(false);
        MM = FindObjectOfType<MenuManager>().GetComponent<MenuManager>();
        currentLevel = GameManager.Instance.currLevels;
        if (currentLevel < 5)
        {
            levelk4.SetActive(true);
            level5.SetActive(false);
        }
        else
        {
            levelk4.SetActive(false);
            level5.SetActive(true);
        }

    }

    public void ContinueGame()
    {

        InGame.SetActive(true);
        GradeUP.SetActive(false);
    }

    public void ExitScreen()
    {

        GradeUP.SetActive(false);
        MM.ReturnToMainMenu();
        MM.MainMenuActive();
    }
}
