using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour {
    public static LevelDisplay Instance;
    public TextMeshProUGUI levelText;
    public GameObject[] levels;
    int levelToDisplay ;

    private void Awake() {
        Instance = this;
    }

    void Start() {
        //levelToDisplay = 1;
        levelToDisplay = PlayerPrefs.GetInt(AnimationStrings.LevelToDisplay,1);
        if (levelText == null) {
            levelText = GetComponent<TextMeshProUGUI>();
        }
        //if (levelToDisplay != 1) {
            UpdateLevelDisplay();
        //}
    }

    void Update() { 
        //UpdateLevelDisplay();
    }
            
    void UpdateLevelDisplay() {
        //PlayerPrefs.SetInt(AnimationStrings.LevelToDisplay, levelToDisplay);
        levelToDisplay = PlayerPrefs.GetInt(AnimationStrings.LevelToDisplay,1);
        for (int i = 0; i < levels.Length; i++) {
            if (i == levelToDisplay - 1) {
                levels[i].SetActive(true);
                levelText.text = "Level " + (i + 1);
            } else {
                levels[i].SetActive(false);
            }
        }
    }

    public void UpdateLevel() {
        PlayerPrefs.SetInt(AnimationStrings.LevelToDisplay, levelToDisplay + 1);
    }
}
