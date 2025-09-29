using UnityEngine;
using System;

[Serializable]
public class Answer
{
    [SerializeField] private string answerText;
    [SerializeField] private bool isCorrect;

    public string GetAnswerText()
    {
        return answerText;
    }

    public bool GetIsCorrect()
    {
        return isCorrect;
    }
}

[CreateAssetMenu(fileName = "QuestionSO", menuName = "Scriptable Objects/QuestionSO")]
public class QuestionSO : ScriptableObject
{
    [SerializeField] private string question = "Question HERE!";
    [SerializeField] private Answer[] answers = new Answer[4];
    [SerializeField] private string feedback;

    public string GetQuestion()
    {
        return question;
    }

    public Answer[] GetAnswers()
    {
        return answers;
    }

    public string GetFeedback()
    {
        return feedback;
    }
}

