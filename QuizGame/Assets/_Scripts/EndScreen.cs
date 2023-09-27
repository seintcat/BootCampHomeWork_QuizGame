using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalScoreText;
    [SerializeField]
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = $"�����մϴ�!\n{scoreManager.CalculateScore()}���� ȹ���ϼ̽��ϴ�!";
    }
}
