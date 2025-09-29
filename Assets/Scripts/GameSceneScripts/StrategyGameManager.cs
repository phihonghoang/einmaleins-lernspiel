using UnityEngine;
using System;

public class StrategyGameManager : MonoBehaviour
{
    public event Action QuestionSelectedEvent;

    public void OnClickQuestionSelected()
    {
        QuestionSelectedEvent?.Invoke();
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
