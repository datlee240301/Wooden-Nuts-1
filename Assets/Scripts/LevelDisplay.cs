using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour {
    public TextMeshProUGUI levelText;
    public GameObject[] levels; 

    void Start() {
        if (levelText == null) {
            levelText = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update() {
        for (int i = 0; i < levels.Length; i++) {
            if (levels[i].activeSelf) {
                levelText.text = "Level " + (i + 1);
                break; 
            }
        }
    }
}
