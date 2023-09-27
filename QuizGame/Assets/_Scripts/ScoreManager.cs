using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int correctAnswer = 0;
    private int questionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }

    public void IncrementCorrectAnswer()
    {
        correctAnswer++;
    }

    //public int GetQuestionCount()
    //{
    //    return questionCount;
    //}

    public void IncrementQuestionCount()
    {
        questionCount++;
    }

    public int CalculateScore()
    {
        if(questionCount > 0)
        {
            int score = Mathf.RoundToInt(((float)correctAnswer / questionCount) * 100);
            scoreText.text = $"Score: {score}%";
            return score;
        }
        else
        {
            scoreText.text = "Score: -%";
            return -1;
        }
    }
}
