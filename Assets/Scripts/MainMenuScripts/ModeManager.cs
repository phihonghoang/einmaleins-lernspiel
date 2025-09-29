using UnityEngine;
using System;

public class ModeManager : MonoBehaviour
{
    public event Action PlaySelectedEvent;
    public event Action StrategySelectedEvent;
    public event Action BadgeSelectedEvent;
    public event Action ExitSelectedEvent;

    public void OnClickPlaySelected()
    {
        PlaySelectedEvent?.Invoke();
    }

    public void OnClickStrategySelected()
    {
        StrategySelectedEvent?.Invoke();
    }

    public void OnClickBadgeSelected()
    {
        BadgeSelectedEvent?.Invoke();
    }

    public void OnClickExitSelected()
    {
        ExitSelectedEvent?.Invoke();
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
