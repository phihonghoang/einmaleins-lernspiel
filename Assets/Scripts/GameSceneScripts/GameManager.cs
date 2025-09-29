using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CategorySelectionManager categorySelectionManager;
    [SerializeField] private QuestionManager questionManager;
    [SerializeField] private StrategyGameManager strategyGameManager;
    [SerializeField] private EndScreenManager endScreenManager;

    void Start()
    {
        categorySelectionManager.Show();
        questionManager.Hide();
        endScreenManager.Hide();
        strategyGameManager.Hide();

        categorySelectionManager.CategorySelectedEvent += HandleCategorySelectedEvent;
        questionManager.AllQuestionsCompletedEvent += HandleAllQuestionsCompletedEvent;
        questionManager.StrategySelectedEvent += HandleStrategySelectedEvent;
        strategyGameManager.QuestionSelectedEvent += HandleQuestionSelectedEvent;
        endScreenManager.ReplayEvent += HandleReplayEvent;
        endScreenManager.MainMenuEvent += HandleMainMenuEvent;
    }

    private void HandleCategorySelectedEvent(QuestionCategorySO questions)
    {
        categorySelectionManager.Hide();
        questionManager.SetQuestions(questions);
        questionManager.Show();
    }

    private void HandleAllQuestionsCompletedEvent()
    {
        questionManager.Hide();
        endScreenManager.SetResults(
            questionManager.GetCorrectAnswerCount(),
            questionManager.GetTotalQuestions()
        );
        endScreenManager.Show();
    }

    private void HandleStrategySelectedEvent()
    {
        questionManager.Hide();
        strategyGameManager.Show();
    }

    private void HandleQuestionSelectedEvent()
    {
        strategyGameManager.Hide();
        questionManager.Show();
    }

    public void HandleReplayEvent()
    {
        endScreenManager.Hide();
        categorySelectionManager.Show();
    }

    public void HandleMainMenuEvent()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
