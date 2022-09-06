using TMPro;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public TMP_Text levelDisplay;
    public TMP_Text xpDisplay;
    public TMP_Text goldDisplay;

    public Stats heroStats;

    private void Start()
    {
        UpdatePanelCharacter(); 
    }

    public void GetXp(int xpReceived)
    {
        heroStats.playerXp += xpReceived;
        LevelUp();
        UpdatePanelCharacter();
    }

    public void GetGold(int goldReceived)
    {
        heroStats.playerGold += goldReceived;
        UpdatePanelCharacter();
    }

    private void LevelUp()
    {
        while (heroStats.playerXp >= heroStats.playerXpToNextLevel)
        {
            heroStats.playerLevel++;
            heroStats.playerXp -= heroStats.playerXpToNextLevel;
            heroStats.playerXpToNextLevel *= 2;
        }
    }

    public void UpdatePanelCharacter()
    {
        levelDisplay.SetText($"Level: {heroStats.playerLevel}");
        xpDisplay.SetText($"{heroStats.playerXp}/{heroStats.playerXpToNextLevel}");
        goldDisplay.SetText($"Gold: {heroStats.playerGold}");
    }
}