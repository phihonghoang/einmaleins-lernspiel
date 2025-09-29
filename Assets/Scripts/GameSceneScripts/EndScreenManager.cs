using UnityEngine;
using TMPro;
using System;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI percentageText;
    private int rightAnswerCount;
    private int totalQuestions;
    public event Action ReplayEvent;
    public event Action MainMenuEvent;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        scoreText.text = "Punkte: " + rightAnswerCount + "/" + totalQuestions;
        float percentage = (float)Math.Round((float)rightAnswerCount / totalQuestions * 100, 2);
        percentageText.text = "Prozent: " + percentage + "%";
        gameObject.SetActive(true);
    }

    public void SetResults(int rightAnswerCount, int totalQuestions)
    {
        this.rightAnswerCount = rightAnswerCount;
        this.totalQuestions = totalQuestions;
    }

    public void OnClickReplay()
    {
        ReplayEvent?.Invoke();
    }

    public void OnClickMainMenu()
    {
        MainMenuEvent?.Invoke();
    }
}
