using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetter : MonoBehaviour
{
    [SerializeField] GameObject ScissorsButton;
    [SerializeField] GameObject TapeButton;

    private GameManager GM;

    private void Update()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (GM.currLevels == 0 || GM.currLevels == 1 || GM.currLevels == 2)
        {
            ScissorsButton.SetActive(false);
        }

        if (GM.currLevels == 3 || GM.currLevels == 4 || GM.currLevels == 5)
        {
            ScissorsButton.SetActive(true);
        }

        if (GM.currLevels == 0 || GM.currLevels == 1)
        {
            TapeButton.SetActive(false);
        }

        if (GM.currLevels == 2 || GM.currLevels == 3 || GM.currLevels == 4 || GM.currLevels == 5)
        {
            ScissorsButton.SetActive(true);
        }
    }
}
