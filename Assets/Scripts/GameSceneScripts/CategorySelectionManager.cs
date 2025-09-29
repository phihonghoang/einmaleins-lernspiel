using UnityEngine;
using System;

public class CategorySelectionManager : MonoBehaviour
{
    public event Action<QuestionCategorySO> CategorySelectedEvent;

    public void OnClickChooseCategory(QuestionCategorySO category)
    {
        CategorySelectedEvent?.Invoke(category);
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
