using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetter : MonoBehaviour
{
    [SerializeField] GameObject ScissorsButton;
    [SerializeField] GameObject TapeButton;

    private GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (GM.currLevels == 0)
        {
            ScissorsButton.SetActive(false);
            TapeButton.SetActive(false);
        }

        if (GM.currLevels == 1)
        {
            ScissorsButton.SetActive(false);
            TapeButton.SetActive(false);
        }

        if (GM.currLevels == 2)
        {
            ScissorsButton.SetActive(false);
            TapeButton.SetActive(true);
        }

        if (GM.currLevels == 3)
        {
            ScissorsButton.SetActive(true);
            TapeButton.SetActive(true);
        }

        if (GM.currLevels == 4)
        {
            ScissorsButton.SetActive(true);
            TapeButton.SetActive(true);
        }

        if (GM.currLevels == 5)
        {
            ScissorsButton.SetActive(true);
            TapeButton.SetActive(true);
        }
    }
}
