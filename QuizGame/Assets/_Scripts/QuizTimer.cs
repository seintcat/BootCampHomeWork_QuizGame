using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    [SerializeField]
    private float finishTime = 15;
    [SerializeField]
    private float checkingTime = 5;
    [SerializeField]
    private bool isAnswering;
    [SerializeField]
    private Image timer;

    private float timerValue;

    public bool isNextQuestion;

    // Start is called before the first frame update
    void Start()
    {
        timerValue = (isAnswering ? finishTime : checkingTime);
    }

    // Update is called once per frame
    void Update()
    {
        timerValue -= Time.deltaTime;
        timer.fillAmount = timerValue / (isAnswering ? finishTime : checkingTime);

        if (timerValue < 0)
        {
            if (!isAnswering)
            {
                isNextQuestion = true;
            }
            timerValue = (isAnswering ? checkingTime : finishTime );
            isAnswering = !isAnswering;
        }
    }

    public void ResetTimer()
    {
        timerValue = 0;
        timer.fillAmount = 0;
    }

    public bool IsAnswering()
    {
        return isAnswering;
    }
}
