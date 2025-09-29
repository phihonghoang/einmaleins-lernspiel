using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class QuestionManager : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button nextQuestionButton;
    private string questionCategoryName;
    private List<QuestionSO> questionList;
    private QuestionSO currentQuestion;
    private int currentQuestionIndex;
    public event Action AllQuestionsCompletedEvent;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButtons;
    private List<Answer> currentShuffledAnswers;

    [Header("Answer Sprites")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite rightAnswerSprite;
    [SerializeField] private Sprite wrongAnswerSprite;

    [Header("ProgressBar")]
    [SerializeField] private Slider progressBar;

    private int correctAnswerCount;
    private int totalQuestions;
    public event Action StrategySelectedEvent;

    public void SetQuestions(QuestionCategorySO questions)
    {
        questionList = new List<QuestionSO>(questions.GetQuestions());
        questionCategoryName = questions.GetCategoryName();
        currentQuestionIndex = 0;
        ShuffleList(questionList);

        totalQuestions = questionList.Count;
        correctAnswerCount = 0;

        progressBar.maxValue = questionList.Count;
        progressBar.value = 0;

        NextQuestion();
    }

    public void NextQuestion()
    {
        if (currentQuestionIndex >= questionList.Count)
        {
            if (correctAnswerCount == totalQuestions && "Kernaufgaben" == questionCategoryName)
            {
                PlayerPrefs.SetInt("Kernaufgaben", 1);
                PlayerPrefs.Save();
            }
            else if (correctAnswerCount == totalQuestions && "Quadratzahlaufgaben" == questionCategoryName)
            {
                PlayerPrefs.SetInt("Quadratzahlaufgaben", 1);
                PlayerPrefs.Save();
            }
            else if (correctAnswerCount == totalQuestions && "Ableitungsaufgaben" == questionCategoryName)
            {
                PlayerPrefs.SetInt("Ableitungsaufgaben", 1);
                PlayerPrefs.Save();
            }

            AllQuestionsCompletedEvent?.Invoke();
            return;
        }

        currentQuestion = questionList[currentQuestionIndex];
        currentQuestionIndex++;
        progressBar.value = currentQuestionIndex;

        currentShuffledAnswers = new List<Answer>(currentQuestion.GetAnswers());
        ShuffleList(currentShuffledAnswers);

        DisplayQuestion();
        nextQuestionButton.gameObject.SetActive(false);
    }

    // Fisher-Yates Shuffle
    private void ShuffleList<T>(List<T> list)
    {
        for (int index = 0; index < list.Count; index++)
        {
            int randomIndex = Random.Range(index, list.Count);
            T temp = list[index];
            list[index] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI answerButtonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            answerButtonText.text = currentShuffledAnswers[i].GetAnswerText();

            Button answerButton = answerButtons[i].GetComponent<Button>();
            answerButton.interactable = true;

            Image answerButtonImage = answerButtons[i].GetComponent<Image>();
            answerButtonImage.sprite = defaultAnswerSprite;
        }
    }

    public void OnClickAnswerSelected(int index)
    {
        Image answerImage = answerButtons[index].GetComponent<Image>();

        if (currentShuffledAnswers[index].GetIsCorrect())
        {
            questionText.text = "Super!";
            answerImage.sprite = rightAnswerSprite;
            correctAnswerCount++;
        }
        else
        {
            for (int i = 0; i < currentShuffledAnswers.Count; i++)
            {
                if (currentShuffledAnswers[i].GetIsCorrect())
                {
                    questionText.text += " = " + currentShuffledAnswers[i].GetAnswerText();

                    Image correctImage = answerButtons[i].GetComponent<Image>();
                    correctImage.sprite = rightAnswerSprite;
                    break;
                }
            }

            answerImage.sprite = wrongAnswerSprite;
        }

        SetAnswerButtonsState(false);
        nextQuestionButton.gameObject.SetActive(true);
    }

    public void OnClickNextQuestion()
    {
        NextQuestion();
    }

    public void OnClickStrategy()
    {
        StrategySelectedEvent?.Invoke();
    }

    public void SetAnswerButtonsState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    public int GetCorrectAnswerCount()
    {
        return correctAnswerCount;
    }

    public int GetTotalQuestions()
    {
        return totalQuestions;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}

