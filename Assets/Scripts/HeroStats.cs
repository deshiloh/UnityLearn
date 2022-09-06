using TMPro;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public TMP_Text levelDisplay;
    public TMP_Text xpDisplay;
    public TMP_Text goldDisplay;

    public int currentLevel;
    public int force;
    public int currentXp;
    public int gold;
    public int xpToNextLevel = 20;

    private void Awake()
    {
        currentLevel = 1;
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 1);
        currentXp = PlayerPrefs.GetInt("CurrentXP", 0);
        xpToNextLevel = PlayerPrefs.GetInt("XpToNextLevel", 20);
        gold = PlayerPrefs.GetInt("Gold", 0);
        
        UpdatePanelCharacter(); 
    }

    public void GetXp(int xpReceived)
    {
        currentXp += xpReceived;
        LevelUp();
        UpdatePanelCharacter();
    }

    public void GetGold(int goldReceived)
    {
        gold += goldReceived;
        PlayerPrefs.SetInt("Gold", gold);
        UpdatePanelCharacter();
    }

    private void LevelUp()
    {
        while (currentXp >= xpToNextLevel)
        {
            currentLevel++;
            currentXp -= xpToNextLevel;
            xpToNextLevel *= 2;
        }
        
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.SetInt("CurrentXP", currentXp);
        PlayerPrefs.SetInt("XpToNextLevel", xpToNextLevel);
    }

    private void UpdatePanelCharacter()
    {
        levelDisplay.SetText($"Level: {currentLevel}");
        xpDisplay.SetText($"{currentXp}/{xpToNextLevel}");
        goldDisplay.SetText($"Gold: {gold}");
    }
}