using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private ModeManager modeManager;
    [SerializeField] private BadgeManager badgeManager;
    [SerializeField] private StrategyManager strategyManager; 

    void Start()
    {
        modeManager.Show();
        badgeManager.Hide();
        strategyManager.Hide();

        modeManager.PlaySelectedEvent += HandlePlaySelected;
        modeManager.StrategySelectedEvent += HandleStrategySelected;
        modeManager.BadgeSelectedEvent += HandleBadgeSelected;
        modeManager.ExitSelectedEvent += HandleExitSelected;
    }

    public void HandlePlaySelected()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HandleStrategySelected()
    {
        modeManager.Hide();
        strategyManager.Show();
    }

    public void HandleBadgeSelected()
    {
        modeManager.Hide();
        badgeManager.Show();
        badgeManager.UpdateBadges();
    }

    public void OnClickModeManager()
    {
        badgeManager.Hide();
        strategyManager.Hide();
        modeManager.Show();   
    }

    public void HandleExitSelected()
    {
        Application.Quit();
    }
}
