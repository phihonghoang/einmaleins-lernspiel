using UnityEngine;
using UnityEngine.UI;

public class BadgeManager : MonoBehaviour
{
    [SerializeField] private Image[] badgeImages;
    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private Sprite unlockedSprite;

    private string[] badgeIDs = { "Kernaufgaben", "Quadratzahlaufgaben", "Ableitungsaufgaben" };

    public void UpdateBadges()
    {
        for (int i = 0; i < badgeImages.Length; i++)
        {
            if (PlayerPrefs.GetInt(badgeIDs[i], 0) == 1)
            {
                badgeImages[i].sprite = unlockedSprite;
            }
            else
            {
                badgeImages[i].sprite = lockedSprite;
            }
        }
    }

    public void ResetBadges()
    {
        for (int i = 0; i < badgeIDs.Length; i++)
        {
            PlayerPrefs.SetInt(badgeIDs[i], 0);
        }
        PlayerPrefs.Save();
        UpdateBadges();
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


