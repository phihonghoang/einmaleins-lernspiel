using UnityEngine;

[CreateAssetMenu(fileName = "QuestionCategorySO", menuName = "Scriptable Objects/QuestionCategorySO")]
public class QuestionCategorySO : ScriptableObject
{
    [SerializeField] private string categoryName;
    [SerializeField] private QuestionSO[] questions;

    public string GetCategoryName()
    {
        return categoryName;
    }

    public QuestionSO[] GetQuestions()
    {
        return questions;
    }
}
