using System.Collections;
using UnityEngine;

public class WinConditions : MonoBehaviour {
    public static WinConditions Instance;
    public GameObject winBoard, levelWinBoard;

    private void Awake() {
        Instance = this;
    }

    void Update() {
        GameObject[] woodObjects = GameObject.FindGameObjectsWithTag("Wood");
        if (woodObjects.Length == 0) {
            if (winBoard != null) {
                if (PlayerPrefs.GetInt(StringsManager.PlayBtnLoadScene) == 1) {
                    TimeManager.instance.StopTimer();
                    StartCoroutine(ShowWinBoard());
                }
                else if(PlayerPrefs.GetInt(StringsManager.LevelBtnLoadScene) == 1) {
                    TimeManager.instance.StopTimer();
                    StartCoroutine(ShowLevelWinBoard());
                }
            }
        }
    }

    IEnumerator ShowWinBoard() {
        LevelDisplay.Instance.UpdateLevel();
        yield return new WaitForSeconds(1f);
        winBoard.SetActive(true);
    }
    
    IEnumerator ShowLevelWinBoard() {
        yield return new WaitForSeconds(1f);
        levelWinBoard.SetActive(true);
    }
}
