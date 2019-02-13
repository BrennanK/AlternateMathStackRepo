
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 180f;
    public float time;

    [SerializeField] private Text timerText;
    [SerializeField] private Slider slider;

    private MenuManager mng;

    private void Start()
    {
        mng = GameObject.Find("UI Screens").GetComponent<MenuManager>();

        time = maxTime;
        slider.maxValue = 180f;
        slider.minValue = 0f;
    }

    private void Update()
    {
        timerText.text = "Time Left: " + Mathf.Round(time);
        time -= Time.deltaTime;
        slider.value = time;

        if (time <= 0)
        {
            time = 180f;
            mng.GameOverActive();
        }

        if (time >= 180f)
        {
            time = maxTime;
        }
    }
}
