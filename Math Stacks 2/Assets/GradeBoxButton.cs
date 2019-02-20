using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeBoxButton : MonoBehaviour
{
    public int GradeLevel = 0;
    public MenuManager MM;
   public void PushGradeValue()
    {
        GameManager.Instance.LevelSelect(GradeLevel);
        MM = GameManager.Instance.GetComponentInChildren<MenuManager>();
        MM.SendMessage("InGameOverlayActive");
    }
}
