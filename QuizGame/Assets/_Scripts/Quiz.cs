using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private List<QuestionSO> questions;
    private int currentQuestion = -1;

    [Header("Answers")]
    [SerializeField]
    private Image[] answerButtons;

    [Header("Button Colors")]
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private Sprite answerSprite;

    [Header("Timer")]
    [SerializeField]
    private QuizTimer timer;

    [Header("Score")]
    [SerializeField]
    private ScoreManager scoreManager;

    [Header("Score")]
    [SerializeField]
    private Slider progressBar;

    [Header("Audio")]
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> clipList;

    public bool isComplete;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        progressBar.maxValue = questions.Count;
        GetNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isNextQuestion)
        {
            timer.isNextQuestion = false;
            GetNextQuestion();
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = questions[currentQuestion].GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestion].GetAnswer(i);
        }
    }

    public void OnAnswerClickedEvent(int index)
    {
        if (!timer.IsAnswering())
        {
            questionText.text = "Time Over!";
            audioSource.PlayOneShot(clipList[1]);
            return;
        }

        int correctAnswerIndex = questions[currentQuestion].GetCorrectAnswerIndex();
        if (index == correctAnswerIndex)
        {
            questionText.text = "정답입니다!";
            answerButtons[index].sprite = answerSprite;
            scoreManager.IncrementCorrectAnswer();
            audioSource.PlayOneShot(clipList[0]);
        }
        else
        {
            questionText.text = "땡! 틀렸습니다.";
            answerButtons[correctAnswerIndex].sprite = answerSprite;
            audioSource.PlayOneShot(clipList[1]);
        }

        SetButtonState(false);
        timer.ResetTimer();
        scoreManager.CalculateScore();
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.GetComponent<Button>().interactable = state;
        }
    }

    private void GetNextQuestion()
    {
        scoreManager.CalculateScore();
        if (currentQuestion > -1)
        {
            questions.RemoveAt(currentQuestion);
        }
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            currentQuestion = Random.Range(0, questions.Count);
            DisplayQuestion();
            scoreManager.IncrementQuestionCount();
            progressBar.value++;
        }
        else
        {
            isComplete = true;
        }
    }

    //private void GetRandomQuestion()
    //{
    //    currentQuestion = Random.Range(0, questions.Count);
    //}

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].sprite = defaultSprite;
        }
    }
}
